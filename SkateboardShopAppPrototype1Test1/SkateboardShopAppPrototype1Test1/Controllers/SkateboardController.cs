using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkateboardShopAppPrototype1Test1.Data;
using SkateboardShopAppPrototype1Test1.Domain;
using SkateboardShopAppPrototype1Test1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SkateboardShopAppPrototype1Test1.Controllers
{
    [Authorize]
    public class SkateboardController : Controller
    {
            private readonly ApplicationDbContext context;
            public SkateboardController(ApplicationDbContext context)
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
                    Name = skateboardFromDb.Name,
                    Image = skateboardFromDb.Image,
                    Image1 = skateboardFromDb.Image1,
                    Image2 = skateboardFromDb.Image2,
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
            public IActionResult Create(SkateboardCreateBindingModel bindingModel)
            {
                if (ModelState.IsValid)
                {
                    string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Skateboard skateboardFromDb = new Skateboard
                    {
                        Name = bindingModel.Name,
                        Colour = bindingModel.Colour,
                        Size = bindingModel.Size,
                        Description = bindingModel.Description,
                        Features = bindingModel.Features,
                        Image = bindingModel.Image,
                        Image1 = bindingModel.Image1,
                        Image2 = bindingModel.Image2,
                        DeliveryAndReturns = bindingModel.DeliveryAndReturns,
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
