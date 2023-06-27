using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkateboardApp.Data;
using SkateboardApp.Domain;
using SkateboardApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SkateboardApp.Controllers
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
                var ev = this.context.Products.SingleOrDefault(e => e.Id == bindingModel.ProductId);
                if (user == null || ev == null)
                {
                    return this.RedirectToAction("All", "Skateboards");
                }
                Order orderFromDb = new Order
                {
                    OrderedOn = DateTime.UtcNow,
                    Id = bindingModel.ProductId,
                    CustomerId = currentUserId
                };

              

                this.context.Products.Update(ev);
                this.context.Orders.Add(orderFromDb);
                this.context.SaveChanges();
            }
            return this.RedirectToAction("All", "Skateboards");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            List<OrderListingViewModel> orders = this.context.Orders.Select(o => new OrderListingViewModel
            {
                OrderedOn = o.OrderedOn.ToString("dd-mm-yyy hh:mm", CultureInfo.InvariantCulture),
            }).ToList();
            return this.View(orders);
        }
    }
}
