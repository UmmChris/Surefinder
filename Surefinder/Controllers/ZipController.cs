using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Surefinder.Data;
using Surefinder.Models;

namespace Surefinder.Controllers
{
    public class ZipController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZipController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Zip
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zip.ToListAsync());
        }

        // GET: Zip/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zip = await _context.Zip
                .SingleOrDefaultAsync(m => m.ZipID == id);
            if (zip == null)
            {
                return NotFound();
            }

            return View(zip);
        }

        // GET: Zip/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZipID,State,Status")] Zip zip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zip);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(zip);
        }

        // GET: Zip/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zip = await _context.Zip.SingleOrDefaultAsync(m => m.ZipID == id);
            if (zip == null)
            {
                return NotFound();
            }
            return View(zip);
        }

        // POST: Zip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZipID,State,Status")] Zip zip)
        {
            if (id != zip.ZipID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZipExists(zip.ZipID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(zip);
        }

        // GET: Zip/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zip = await _context.Zip
                .SingleOrDefaultAsync(m => m.ZipID == id);
            if (zip == null)
            {
                return NotFound();
            }

            return View(zip);
        }

        // POST: Zip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zip = await _context.Zip.SingleOrDefaultAsync(m => m.ZipID == id);
            _context.Zip.Remove(zip);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ZipExists(int id)
        {
            return _context.Zip.Any(e => e.ZipID == id);
        }
    }
}
