﻿using BookMgr.Data;
using BookMgr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookMgr.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AuthorController(ApplicationDbContext context)
        {
            _context = context;            
        }
        public async Task<IActionResult> Index()
        {
            var authors = await _context.Authors.ToListAsync();
            return View(authors);
        }
        //View details of a specific author
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var author = await _context.Authors
                                .Include(a => a.BookAuthors)
                                .ThenInclude(ba => ba.Book)
                                .FirstOrDefaultAsync(m => m.Id == id);
            if(author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        //show the form to create a new author
        public IActionResult Create()
        {
            return View();
        }
        //Save the author to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(author);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
    }
}
