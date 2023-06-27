﻿using EventuresApp.Data;
using EventuresApp.Domain;
using EventuresApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventuresApp.Controllers
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
                var ev = this.context.Events.SingleOrDefault(e => e.Id == bindingModel.EventId);
                if (user == null || ev == null || ev.TotalTickets < bindingModel.TicketsCount)
                {
                    return this.RedirectToAction("All", "Events");
                }
                Order orderFromDb = new Order
                {
                    OrderedOn = DateTime.UtcNow,
                    EventId = bindingModel.EventId,
                    TicketsCount = bindingModel.TicketsCount,
                    CustomerId = currentUserId
                };

                ev.TotalTickets -= bindingModel.TicketsCount;

                this.context.Events.Update(ev);
                this.context.Orders.Add(orderFromDb);
                this.context.SaveChanges();
            }
            return this.RedirectToAction("All", "Events");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            List<OrderListingViewModel> orders = this.context.Orders.Select(o => new OrderListingViewModel
            {
               // Id=o.Id,
               // EventId=o.EventId,
                EventName = o.Event.Name,
                //EventStart=o.EventStart.ToString("dd-mm-yyy hh:mm", CultureInfo.InvariantCulture)
                // EventEnd =o.EventEnd.ToString("dd-mm-yyy hh:mm", CultureInfo.InvariantCulture),
                // EventPlace=o.EventPlace,
                // CustomerId=o.Customer.UserName,
                TicketsCount = o.TicketsCount,
                OrderedOn = o.OrderedOn.ToString("dd-mm-yyy hh:mm", CultureInfo.InvariantCulture),
            }).ToList();
            return this.View(orders);
        }

    }
}
