using EventuresApp.Data;
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
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext context;
        public EventsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult All()
        {
            List<EventAllViewModel> events = context.Events.Select(eventFromDb => new EventAllViewModel
            {
<<<<<<< HEAD
                Id = eventFromDb.Id,
=======
>>>>>>> c8cd4aa8cf956f70ec44df258c3daeb04f16c10b
                Name = eventFromDb.Name,
                Place = eventFromDb.Place,
                Start = eventFromDb.Start.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                End = eventFromDb.End.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                Owner = eventFromDb.Owner.UserName
            }
            ).ToList();
            return this.View(events);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EventCreateBindingModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Event eventFromDb = new Event
                {
                    Name = bindingModel.Name,
                    Place = bindingModel.Place,
                    Start = bindingModel.Start,
                    End = bindingModel.End,
                    TotalTickets = bindingModel.TotalTickets,
                    PricePerTicket = bindingModel.PricePerTicket,
                    OwnerId= currentUserId
                };

                context.Events.Add(eventFromDb);
                context.SaveChanges();

                return this.RedirectToAction("All");
            }
            return this.View();
        }
<<<<<<< HEAD

        [Authorize]
        public IActionResult My(string searchString)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.context.Users.SingleOrDefault(u => u.Id == currentUserId);
            if (user==null)
            {
                return null;
            }
            List<OrderListingViewModel> orders = this.context.Orders.Where(o => o.CustomerId == user.Id).Select(o => new OrderListingViewModel
            {
                Id = o.Id,
                EventId = o.EventId,
                EventName = o.Event.Name,
                EventStart = o.Event.Start.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                EventEnd = o.Event.End.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                EventPlace = o.Event.Place,
                OrderedOn = o.OrderedOn.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                CustomerId = o.CustomerId,
                CustomerUsername = o.Customer.UserName,
                TicketsCount = o.TicketsCount
            })
             .ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o => o.EventPlace.Contains(searchString)).ToList();
            }
            return this.View(orders);
        }
=======
>>>>>>> c8cd4aa8cf956f70ec44df258c3daeb04f16c10b
    }
}
