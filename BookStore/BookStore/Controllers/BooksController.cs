
using BookStore.Data;
using BookStore.Domain;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogsAppWeb.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext context;

        public BooksController(ApplicationDbContext context)
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
        public IActionResult Create(BookDetailsViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Book bookFromDb = new Book
                {
                    BookName = bindingModel.BookName,
                    Author = bindingModel.Author,
                    Genre = bindingModel.Genre,
                    Picture = bindingModel.Picture,
                    YearOfPublication = bindingModel.YearOfPublication,
                    Price = bindingModel.Price
                };

                context.Books.Add(bookFromDb);
                context.SaveChanges();

                return this.RedirectToAction("Success");
            }
            return this.View();
        }

        public IActionResult Success()
        {
            return this.View();
        }
        public IActionResult All(string searchStringGenre, string searchStringPrice)
        {
            List<BookAllViewModel> books = context.Books.Select(bookFromDb => new BookAllViewModel
            {
                Id = bookFromDb.Id,
                BookName = bookFromDb.BookName,
                Author = bookFromDb.Author,
                Genre = bookFromDb.Genre,
                Picture = bookFromDb.Picture,
                YearOfPublication = bookFromDb.YearOfPublication,
                Price = bookFromDb.Price
            }
            ).ToList();
            if (!String.IsNullOrEmpty(searchStringGenre) && !String.IsNullOrEmpty(searchStringPrice))
            {
                books = books.Where(x => x.Genre.Contains(searchStringGenre) && x.Price.ToString().Contains(searchStringPrice)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringGenre))
            {
                books = books.Where(x => x.Genre.Contains(searchStringGenre)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringPrice))
            {
                books = books.Where(x => x.Price.ToString().Contains(searchStringPrice)).ToList();
            }
            return View(books);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book item = context.Books.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            BookDetailsViewModel book = new BookDetailsViewModel()
            {
                Id = item.Id,
                BookName = item.BookName,
                Author = item.Author,
                Genre = item.Genre,
                Picture = item.Picture,
                YearOfPublication = item.YearOfPublication,
                Price = item.Price
            };
            return this.View(book);
        }

        [HttpPost]
        public IActionResult Edit(BookDetailsViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Book book = new Book
                {
                    BookName = bindingModel.BookName,
                    Author = bindingModel.Author,
                    Genre = bindingModel.Genre,
                    Picture = bindingModel.Picture,
                    YearOfPublication = bindingModel.YearOfPublication,
                    Price = bindingModel.Price
                };

                context.Books.Add(book);
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

            Book item = context.Books.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            BookDetailsViewModel book = new BookDetailsViewModel()
            {
                Id = item.Id,
                BookName = item.BookName,
                Author = item.Author,
                Genre = item.Genre,
                Picture = item.Picture,
                YearOfPublication = item.YearOfPublication,
                Price = item.Price
            };
            return this.View(book);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Book item = context.Books.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            context.Books.Remove(item);
            context.SaveChanges();
            return this.RedirectToAction("All", "Books");
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book item = context.Books.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            BookDetailsViewModel book = new BookDetailsViewModel()
            {
                Id = item.Id,
                BookName = item.BookName,
                Author = item.Author,
                Genre = item.Genre,
                Picture = item.Picture,
                YearOfPublication = item.YearOfPublication,
                Price = item.Price
            };
            return this.View(book);
        }
    }
}
