using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkateApp.Data;
using SkateApp.Domain;
using SkateApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SkateApp.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext context;
        public OrdersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult Create(OrderCreateBindingModel bindingModel)
        {
            if (this.ModelState.IsValid)
            {
                string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var user = this.context.Users.SingleOrDefault(u => u.Id == currentUserId);
                var ev = this.context.Skateboards.SingleOrDefault(e => e.Id == bindingModel.SkateboardId);
                if (user == null || ev == null || ev.Quantity < bindingModel.SkateboardsCount)
                {
                    return this.RedirectToAction("All", "Skateboards");
                }

                Order orderFromDb = new Order
                {
                    OrderedOn = DateTime.UtcNow,
                    SkateboardId = bindingModel.SkateboardId,
                    SkateboardsCount = bindingModel.SkateboardsCount,
                    CustomerId = currentUserId
                };

                ev.Quantity -= bindingModel.SkateboardsCount;

                this.context.Skateboards.Update(ev);
                this.context.Orders.Add(orderFromDb);
                this.context.SaveChanges();
            }
            return this.RedirectToAction("Success");
        }
        public IActionResult Success()
        {
            return this.View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            List<OrderListingViewModel> orders = this.context.Orders.Select(o => new OrderListingViewModel
            {
                SkateboardName = o.Skateboard.Name,
                SkateboardsCount = o.SkateboardsCount,
                CustomerUsername = o.Customer.UserName,
                OrderedOn = o.OrderedOn.ToString("dd-mm-yyy hh:mm", CultureInfo.InvariantCulture),
            }).ToList();

            return this.View(orders);
        }
    }
}
