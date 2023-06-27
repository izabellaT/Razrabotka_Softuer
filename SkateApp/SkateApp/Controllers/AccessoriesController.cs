using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkateApp.Data;
using SkateApp.Domain;
using SkateApp.Models.Accessorie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SkateApp.Controllers
{
    [Authorize]
    public class AccessoriesController : Controller
    {
        private readonly ApplicationDbContext context;
        public AccessoriesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult All()
        {
            List<AccessoriesAllViewModel> accessories = context.Accessories.Select(accessoriesFromDb => new AccessoriesAllViewModel
            {
                Id = accessoriesFromDb.Id,
                Name = accessoriesFromDb.Name,
                Colour = accessoriesFromDb.Colour,
                Picture = accessoriesFromDb.Picture,
                Price = accessoriesFromDb.Price
            }
            ).ToList();
            return this.View(accessories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AccessoriesCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Accessorie accessoriesFromDb = new Accessorie
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

                context.Accessories.Add(accessoriesFromDb);
                context.SaveChanges();

                return this.RedirectToAction("All");
            }
            return this.View();
        }
        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Accessorie item = context.Accessories.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            AccessoriesCreateViewModel accessories = new AccessoriesCreateViewModel()
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
            return this.View(accessories);
        }

        [HttpPost]
        public IActionResult Edit(AccessoriesCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Accessorie accessorie = new Accessorie
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

                context.Accessories.Update(accessorie);
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

            Accessorie item = context.Accessories.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            AccessoriesCreateViewModel accessorie = new AccessoriesCreateViewModel()
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
            return this.View(accessorie);
        }

        [HttpPost]
        public IActionResult Delete1(string id)
        {
            Accessorie item = context.Accessories.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            context.Accessories.Remove(item);
            context.SaveChanges();
            return this.RedirectToAction("All", "Accessories");
        }
        public IActionResult Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Accessorie item = context.Accessories.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            AccessoriesDetailsViewModel accessorie = new AccessoriesDetailsViewModel()
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
            return this.View(accessorie);
        }
    }
}
