using CatAppWeb.Data;
using CatAppWeb.Domain;
using CatAppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatAppWeb.Controllers
{
    public class CatsController : Controller
    {
        private readonly ApplicationDbContext context;

        public CatsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CatDetailsViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Cat catFromDb = new Cat
                {
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    Image = bindingModel.Image
                };

                context.Cats.Add(catFromDb);
                context.SaveChanges();

                return this.RedirectToAction("Success");
            }
            return this.View();
        }

        public IActionResult Success()
        {
            return this.View();
        }
        public IActionResult All(string searchStringBuilder, string searchStringName)
        {
            List<CatAllViewModel> dogs = context.Cats.Select(catFromDb => new CatAllViewModel
            {
                Id = catFromDb.Id,
                Name = catFromDb.Name,
                Age = catFromDb.Age,
                Breed = catFromDb.Breed,
                Image = catFromDb.Image
            }
            ).ToList();
            if (!String.IsNullOrEmpty(searchStringBuilder) && !String.IsNullOrEmpty(searchStringName))
            {
                dogs = dogs.Where(x => x.Breed.Contains(searchStringBuilder) && x.Name.Contains(searchStringName)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringBuilder))
            {
                dogs = dogs.Where(x => x.Breed.Contains(searchStringBuilder)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringName))
            {
                dogs = dogs.Where(x => x.Name.Contains(searchStringName)).ToList();
            }
            return View(dogs);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cat item = context.Cats.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            CatDetailsViewModel cat = new CatDetailsViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Image = item.Image
            };
            return this.View(cat);
        }

        [HttpPost]
        public IActionResult Edit(CatDetailsViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Cat cat = new Cat
                {
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    Image = bindingModel.Image
                };

                context.Cats.Add(cat);
                context.SaveChanges();

                return this.RedirectToAction("All");
            }
            return this.View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cat item = context.Cats.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            CatDetailsViewModel cat = new CatDetailsViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Image = item.Image
            };
            return this.View(cat);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Cat item = context.Cats.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            context.Cats.Remove(item);
            context.SaveChanges();
            return this.RedirectToAction("All", "Cats");
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cat item = context.Cats.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            CatDetailsViewModel cat = new CatDetailsViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Image = item.Image
            };
            return this.View(cat);
        }
    }
}
