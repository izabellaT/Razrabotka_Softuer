using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkateApp.Data;
using SkateApp.Domain;
using SkateApp.Models;
using SkateApp.Models.Skateboard;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SkateApp.Controllers
{
    [Authorize]
    public class SkateboardsController : Controller
    {
        private readonly ApplicationDbContext context;
        public SkateboardsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult All()
        {
            List<SkateboardAllViewModel> skateboards = context.Skateboards.Select(skateboardsFromDb => new SkateboardAllViewModel
            {
                Id = skateboardsFromDb.Id,
                Name = skateboardsFromDb.Name,
                Colour = skateboardsFromDb.Colour,
                Picture = skateboardsFromDb.Picture,
                Price = skateboardsFromDb.Price
            }
            ).ToList();
            return this.View(skateboards);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SkateboardCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Skateboard skateboardsFromDb = new Skateboard
                {
                    Id = bindingModel.Id,
                    Name = bindingModel.Name,
                    Colour = bindingModel.Colour,
                    Size = bindingModel.Size,
                    Description = bindingModel.Description,
                    Picture = bindingModel.Picture,
                    Quantity = bindingModel.Quantity,
                    Price = bindingModel.Price
                };

                context.Skateboards.Add(skateboardsFromDb);
                context.SaveChanges();

                return this.RedirectToAction("All");
            }
            return this.View();
        }

        [Authorize]
        public IActionResult My(string searchString)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.context.Users.SingleOrDefault(u => u.Id == currentUserId);
            if (user == null)
            {
                return null;
            }
            List<OrderListingViewModel> orders = this.context.Orders.Where(o => o.CustomerId == user.Id).Select(o => new OrderListingViewModel
            {
                Id = o.Id,
                SkateboardId = o.SkateboardId,
                SkateboardName = o.Skateboard.Name,
                SkateboardsCount = o.SkateboardsCount,
                OrderedOn = o.OrderedOn.ToString("dd mm yyyy hh:mm", CultureInfo.InvariantCulture),
                CustomerId = o.CustomerId,
                CustomerUsername = o.Customer.UserName
            }).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o => o.SkateboardName.Contains(searchString)).ToList();
            }
            return this.View(orders);
        }

        [Authorize]
        public IActionResult Favorite(string searchString)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.context.Users.SingleOrDefault(u => u.Id == currentUserId);
            if (user == null)
            {
                return null;
            }
            List<FavoriteListingViewModel> favorites = this.context.Favorites.Where(o => o.CustomerId == user.Id).Select(o => new FavoriteListingViewModel
            {
                Id = o.Id,
                SkateboardId = o.SkateboardId,
                SkateboardName = o.Skateboard.Name,
                SkateboardPicture = o.Skateboard.Picture,
                SkateboardsCount = o.SkateboardCount,
                SkateboardColour = o.Skateboard.Colour,
                SkateboardSize = o.Skateboard.Size,
                SkateboardPrice = o.Skateboard.Price,
                CustomerId = o.CustomerId,
                CustomerUsername = o.Customer.UserName

            }).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                favorites = favorites.Where(o => o.SkateboardName.Contains(searchString)).ToList();
            }
            return this.View(favorites);
        }
        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Skateboard item = context.Skateboards.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            SkateboardCreateViewModel skateboards = new SkateboardCreateViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Colour = item.Colour,
                Size = item.Size,
                Description = item.Description,
                Picture = item.Picture,
                Quantity = item.Quantity,
                Price = item.Price
            };
            return View(skateboards);
        }

        [HttpPost]
        public IActionResult Edit(SkateboardCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Skateboard skateboard = new Skateboard
                {
                    Id = bindingModel.Id,
                    Name = bindingModel.Name,
                    Colour = bindingModel.Colour,
                    Size = bindingModel.Size,
                    Description = bindingModel.Description,
                    Picture = bindingModel.Picture,
                    Quantity = bindingModel.Quantity,
                    Price = bindingModel.Price
                };

                context.Skateboards.Update(skateboard);
                context.SaveChanges();

                return this.RedirectToAction("All");
            }
            return this.View();
        }

        public IActionResult Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Skateboard item = context.Skateboards.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            SkateboardCreateViewModel skateboard = new SkateboardCreateViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Colour = item.Colour,
                Size = item.Size,
                Description = item.Description,
                Picture = item.Picture,
                Quantity = item.Quantity,
                Price = item.Price
            };
            return View(skateboard);
        }

        [HttpPost]
        public IActionResult Delete1(string id)
        {
            Skateboard item = context.Skateboards.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            context.Skateboards.Remove(item);
            context.SaveChanges();
            return this.RedirectToAction("All", "Skateboards");
        }
        public IActionResult Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Skateboard item = context.Skateboards.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            SkateboardDetailsViewModel skateboard = new SkateboardDetailsViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Colour = item.Colour,
                Size = item.Size,
                Description = item.Description,
                Picture = item.Picture,
                Quantity = item.Quantity,
                Price = item.Price
            };
            return this.View(skateboard);
        }
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
