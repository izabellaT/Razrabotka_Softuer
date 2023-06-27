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
                    Count = bindingModel.Count,
                    Price = bindingModel.Price
                };

                context.Accessories.Add(accessoriesFromDb);
                context.SaveChanges();

                return this.RedirectToAction("All");
            }
            return this.View();
        }
    }
}
