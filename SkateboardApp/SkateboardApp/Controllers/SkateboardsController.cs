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
            List<SkateboardAllViewModel> skateboards = context.Skateboards.Select(skateboardFromDb => new SkateboardAllViewModel
            {
                Id = skateboardFromDb.Id,
                Name = skateboardFromDb.Name,
                Colour = skateboardFromDb.Colour,
                Picture = skateboardFromDb.Picture,
                Price = skateboardFromDb.Price
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
                Skateboard skateboardFromDb = new Skateboard
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

                context.Skateboards.Add(skateboardFromDb);
                context.SaveChanges();

                return this.RedirectToAction("All");
            }
            return this.View();
        }
    }
}
