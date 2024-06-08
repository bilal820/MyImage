using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyImage.Models;

namespace MyImage.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Admin/OrderList
        public async Task<IActionResult> OrderList()
        {
            return _context.Orders != null ?
                        View(await _context.Orders.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
        }
        // GET: Admin
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Admin/SizeDetailList
        public async Task<IActionResult> SizeDetailList()
        {
            return _context.SizeDetails != null ?
                        View(await _context.SizeDetails.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.SizeDetails'  is null.");
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> SizeDetaiDetails(int? id)
        {
            if (id == null || _context.SizeDetails == null)
            {
                return NotFound();
            }

            var sizeDetail = await _context.SizeDetails
                .FirstOrDefaultAsync(m => m.Size_id == id);
            if (sizeDetail == null)
            {
                return NotFound();
            }

            return View(sizeDetail);
        }

        // GET: Admin/Create
        public IActionResult SizeDetaiCreate()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SizeDetaiCreate([Bind("Size_id,Size_Name,Size_Discription,Size_inches,Size_Price")] SizeDetail sizeDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sizeDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sizeDetail);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> SizeDetaiEdit(int? id)
        {
            if (id == null || _context.SizeDetails == null)
            {
                return NotFound();
            }

            var sizeDetail = await _context.SizeDetails.FindAsync(id);
            if (sizeDetail == null)
            {
                return NotFound();
            }
            return View(sizeDetail);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SizeDetaiEdit(int id, [Bind("Size_id,Size_Name,Size_Discription,Size_inches,Size_Price")] SizeDetail sizeDetail)
        {
            if (id != sizeDetail.Size_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sizeDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SizeDetailExists(sizeDetail.Size_id))
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
            return View(sizeDetail);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> SizeDetaiDelete(int? id)
        {
            if (id == null || _context.SizeDetails == null)
            {
                return NotFound();
            }

            var sizeDetail = await _context.SizeDetails
                .FirstOrDefaultAsync(m => m.Size_id == id);
            if (sizeDetail == null)
            {
                return NotFound();
            }

            return View(sizeDetail);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SizeDetaiDeleteConfirmed(int id)
        {
            if (_context.SizeDetails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SizeDetails'  is null.");
            }
            var sizeDetail = await _context.SizeDetails.FindAsync(id);
            if (sizeDetail != null)
            {
                _context.SizeDetails.Remove(sizeDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SizeDetailExists(int id)
        {
          return (_context.SizeDetails?.Any(e => e.Size_id == id)).GetValueOrDefault();
        }
    }
}
