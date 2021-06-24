using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab02.Models;
using System.ComponentModel.DataAnnotations;
namespace Lab02.Controllers
{
    public class BookController : Controller
    { 
        public String HelloTeacher(String university)
        {
            return "Hello Nguyen Thanh Tung - University: " + university;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML & CSS3 The complete Manual -Author NameBook 1");
            books.Add("HTML & CSS3 Responsive web Design cookbook- Author Name Book 2");
            books.Add("Profession ASP.NET MVC5 - Author Name Book2");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual"," Author Name Book 1 ", "/Content/images/book1.jpg"));
            books.Add(new Book(2,"HTML5 & Responsive web Design cookcook "," Author Name Book 2","/Content/images/book2.jpg"));
            books.Add(new Book(3,"Professional ASP.NET MVC5 - Author Name Book 2","Author Name Book 3","/Content/images/book3.jpg"));
            
            ViewBag.Books = books;
            return View(books);
        }

        
        [HttpPost,ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id,string Title,string Author,string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", " Author Name Book 1 ", "/Content/images/book1.jpg"));
            books.Add(new Book(2, "HTML5 & Responsive web Design cookcook ", " Author Name Book 2", "/Content/images/book2.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5 - Author Name Book 2", "Author Name Book 3", "/Content/images/book3.jpg"));
            
            if( id==null)
            {
                return HttpNotFound();
            }

            foreach(Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.ImageCover = ImageCover;
                    break;
                }
            }
            return View("ListBookModel",books);

        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost,ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include="Id,Title,Author,ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", " Author Name Book 1 ", "/Content/images/book1.jpg"));
            books.Add(new Book(2, "HTML5 & Responsive web Design cookcook ", " Author Name Book 2", "/Content/images/book2.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5 - Author Name Book 2", "Author Name Book 3", "/Content/images/book3.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch(Exception Ex)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel",books);
        }



    }
}
