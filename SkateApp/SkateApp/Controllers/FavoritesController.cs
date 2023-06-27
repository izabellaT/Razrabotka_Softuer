using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkateApp.Data;
using SkateApp.Domain;
using SkateApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SkateApp.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly ApplicationDbContext context;
        public FavoritesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult Create(FavoriteCreateBindingModel bindingModel)
        {
            if (this.ModelState.IsValid)
            {
                string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var user = this.context.Users.SingleOrDefault(u => u.Id == currentUserId);
                var ev = this.context.Skateboards.SingleOrDefault(e => e.Id == bindingModel.SkateboardId);

                Favorite favoriteFromDb = new Favorite
                {
                    SkateboardId = bindingModel.SkateboardId,
                    SkateboardCount = bindingModel.SkateboardCount,
                    CustomerId = currentUserId
                };

                this.context.Skateboards.Update(ev);
                this.context.Favorites.Add(favoriteFromDb);
                this.context.SaveChanges();
            }
            return this.RedirectToAction("All", "Skateboards");
        }
    }
}
