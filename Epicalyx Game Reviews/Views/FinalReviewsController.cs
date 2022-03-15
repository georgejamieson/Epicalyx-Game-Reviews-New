#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Epicalyx_Game_Reviews.Data;
using Epicalyx_Game_Reviews.Models;

namespace Epicalyx_Game_Reviews.Views
{
    public class FinalReviewsController : Controller
    {
        private readonly Epicalyx_Game_ReviewsContext _context;

        public FinalReviewsController(Epicalyx_Game_ReviewsContext context)
        {
            _context = context;
        }

        // GET: FinalReviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.FinalReview.ToListAsync());
        }

        // GET: FinalReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalReview = await _context.FinalReview
                .FirstOrDefaultAsync(m => m.FinalReviewID == id);
            if (finalReview == null)
            {
                return NotFound();
            }

            return View(finalReview);
        }

        // GET: FinalReviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FinalReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FinalReviewID,Review,FinalRating,Genre,Publisher")] FinalReview finalReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(finalReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(finalReview);
        }

        // GET: FinalReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalReview = await _context.FinalReview.FindAsync(id);
            if (finalReview == null)
            {
                return NotFound();
            }
            return View(finalReview);
        }

        // POST: FinalReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FinalReviewID,Review,FinalRating,Genre,Publisher")] FinalReview finalReview)
        {
            if (id != finalReview.FinalReviewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finalReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinalReviewExists(finalReview.FinalReviewID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(finalReview);
        }

        // GET: FinalReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalReview = await _context.FinalReview
                .FirstOrDefaultAsync(m => m.FinalReviewID == id);
            if (finalReview == null)
            {
                return NotFound();
            }

            return View(finalReview);
        }

        // POST: FinalReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var finalReview = await _context.FinalReview.FindAsync(id);
            _context.FinalReview.Remove(finalReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinalReviewExists(int id)
        {
            return _context.FinalReview.Any(e => e.FinalReviewID == id);
        }
    }
}
