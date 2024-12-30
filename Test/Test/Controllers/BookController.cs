using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    public class BookController : Controller
    {
      
        
            private readonly ApplicationDbContext _context;
            Authentication objAuth;

        public BookController(ApplicationDbContext context, Authentication _objAuth)
            {
                _context = context;
            objAuth = _objAuth;
            }



        public IActionResult Index1(int? PublisherId)
        {
            // Get all books with related data
            var booksQuery = _context.Books
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .AsQueryable();

            // Apply filter if PublisherId is provided
            if (PublisherId.HasValue && PublisherId.Value > 0)
            {
                booksQuery = booksQuery.Where(b => b.BookPublishedId == PublisherId);
            }

            var books = booksQuery.ToList();

            // Pass the list of publishers to the ViewBag for the dropdown
            ViewBag.Publishers = _context.Publishers.ToList();

            return View(books);
        }


        // Index Action - Display all books
        public IActionResult Index()
            {
            // Include Category and Publisher navigation properties
            ViewBag.msg = TempData["name"].ToString();
            TempData.Keep("name");
            var books = _context.Books
                    .Include(b => b.Category)
                    .Include(b => b.Publisher)
                    .ToList();

                return View(books);
            }

            // New Action - Display form to add a new book
            public IActionResult New()
            {
            ViewBag.msg = TempData["name"].ToString();
            TempData.Keep("name");
            ViewBag.Categories = _context.Categories.ToList();
                ViewBag.Publishers = _context.Publishers.ToList();

                return View("Register", new Book());
            }

            // Save Action - Save or Update Book
        
      
        [HttpPost]
        public IActionResult Save1(Book book, string ActionType)
        {
            if (!string.IsNullOrEmpty(ActionType) && ActionType.Equals("edit", StringComparison.OrdinalIgnoreCase))
            {
                // Update existing book
                var existingBook = _context.Books.SingleOrDefault(b => b.BookId == book.BookId);
                ViewBag.msg = TempData["name"].ToString();
                TempData.Keep("name");
                if (existingBook != null)
                {
                    existingBook.BookName = book.BookName;
                    existingBook.BookAuthor = book.BookAuthor;
                    existingBook.BookCategoryId = book.BookCategoryId;
                    existingBook.BookPublishedId = book.BookPublishedId;
                    existingBook.BookPublishedYear = book.BookPublishedYear;
                    existingBook.BookPrice = book.BookPrice;

                    _context.SaveChanges();
                }
            }
            else
            {
                // Add a new book
                book.Category = null;
                book.Publisher = null;
                _context.Books.Add(book);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Save(Book book, string ActionType)
        {
            if (!string.IsNullOrEmpty(ActionType) && ActionType.Equals("edit", StringComparison.OrdinalIgnoreCase))
            {
                // Update existing book
                var existingBook = _context.Books.SingleOrDefault(b => b.BookId == book.BookId);

                if (existingBook != null)
                {
                    existingBook.BookName = book.BookName;
                    existingBook.BookAuthor = book.BookAuthor;
                    existingBook.BookCategoryId = book.BookCategoryId;
                    existingBook.BookPublishedId = book.BookPublishedId;
                    existingBook.BookPublishedYear = book.BookPublishedYear;
                    existingBook.BookPrice = book.BookPrice;

                    _context.SaveChanges();
                }
            }
            else if (ActionType.Equals("add", StringComparison.OrdinalIgnoreCase))
            {
                // Add a new book
                _context.Books.Add(book);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }




        // Edit Action - Display form to edit a book
        public IActionResult Edit(int id)
        {
            ViewBag.msg = TempData["name"].ToString();
            TempData.Keep("name");
            var book = _context.Books.SingleOrDefault(b => b.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            // Set TempData["action"] to "edit" when editing a book
            TempData["action"] = "edit";

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Publishers = _context.Publishers.ToList();

            return View("Register", book);  // Pass book data to populate the form
        }



        // Delete Action - Remove a book
        public IActionResult Delete(int id)
            {
                var book = _context.Books.SingleOrDefault(b => b.BookId == id);

                if (book == null)
                {
                    return NotFound();
                }

                _context.Books.Remove(book);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User emp)
        {
            if (objAuth.IsUserValid(emp.Email, emp.PWD))
            {
                TempData["name"] = objAuth.UserName;
                TempData.Keep("name");
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Login failed";
            return View();
            
        }
        public IActionResult Home()
        {
            return View();
        }
    }
    }


