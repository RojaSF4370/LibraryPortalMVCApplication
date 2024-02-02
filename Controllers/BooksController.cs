using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryApplication.Models;
using System.Net;

namespace LibraryApplication.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.Books
                .Where(b => b.IsDeleted == false) 
                .Include(b => b.BookCategory); 

            return View(await libraryContext.ToListAsync());
        }


        // GET: Books/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return View("BookNotFound");
            }

            var book = await _context.Books
                .Where(b => b.IsDeleted == false)
                .Include(b => b.BookCategory)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return View("BookNotFound");
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {

            ViewData["BookCategory"] = new SelectList(_context.BookCategories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
          
     
            if (ModelState.IsValid)
            {
                
                book.IsDeleted = false;
                book.UpdatedOn = DateTime.Now;

                // Add the book to the database
                _context.Add(book);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["BookCategory"] = new SelectList(_context.BookCategories, "CategoryId", "CategoryName", book.BookCategoryId);
            return View(book);
        }

       
       
        // GET: Books/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return View("BookNotFound");
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return View("BookNotFound");
            }
            ViewData["BookCategory"] = new SelectList(_context.BookCategories, "CategoryId", "CategoryName", book.BookCategoryId);
            return View(book);
        }

        // POST: Books/Edit/id
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.BookId)
            {
                return View("BookNotFound");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    book.IsDeleted = false;
                    book.UpdatedOn = DateTime.Now;
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
                    {
                        return View("BookNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookCategoryId"] = new SelectList(_context.BookCategories, "CategoryId", "CategoryId", book.BookCategoryId);
            return View(book);
        }

        // GET: Books/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return View("BookNotFound");
            }

            var book = await _context.Books
                .Include(b => b.BookCategory)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return View("BookNotFound");
            }

            return View(book);
        }

        // POST: Books/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'LibraryContext.Books'  is null.");
            }
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                //_context.Books.Remove(book);
                book.IsDeleted = true;
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return (_context.Books?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
