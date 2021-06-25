using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookManager.Models;
using System.Data.Entity.Migrations;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listBook = context.Book.ToList();
            return View(listBook);
        }


        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Book.SingleOrDefault(p => p.ID == id);
           if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Book book)
        {
            BookManagerContext context = new BookManagerContext();
            context.Book.AddOrUpdate(book);
            context.SaveChanges();
            return RedirectToAction("ListBook");
        }
        public ActionResult Edit(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Book.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            BookManagerContext context = new BookManagerContext();
            Book bookUpdate = context.Book.SingleOrDefault(p => p.ID == book.ID);
            if (bookUpdate != null)
            {
                context.Book.AddOrUpdate(book);
                context.SaveChanges();
            }

            return RedirectToAction("ListBook");
        }
        public ActionResult Delete(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Book.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteBook(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Book.SingleOrDefault(p => p.ID == id);
            if (book != null)
            {
                context.Book.Remove(book);
                context.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }
    }
}