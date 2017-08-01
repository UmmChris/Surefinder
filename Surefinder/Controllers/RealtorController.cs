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
    public class RealtorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RealtorController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Realtor
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Realtor.Include(r => r.Company);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Realtor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realtor = await _context.Realtor
                .Include(r => r.Company)
                .SingleOrDefaultAsync(m => m.RealtorID == id);
            if (realtor == null)
            {
                return NotFound();
            }

            return View(realtor);
        }

        // GET: Realtor/Create
        public IActionResult Create()
        {
            ViewData["CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyID");
            return View();
        }

        // POST: Realtor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RealtorID,UserID,CompanyID,Name,Title,Description,Phone,Email,Website,City,State,Zip,Address,Status")] Realtor realtor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(realtor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyID", realtor.CompanyID);
            return View(realtor);
        }

        // GET: Realtor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realtor = await _context.Realtor.SingleOrDefaultAsync(m => m.RealtorID == id);
            if (realtor == null)
            {
                return NotFound();
            }
            ViewData["CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyID", realtor.CompanyID);
            return View(realtor);
        }

        // POST: Realtor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RealtorID,UserID,CompanyID,Name,Title,Description,Phone,Email,Website,City,State,Zip,Address,Status")] Realtor realtor)
        {
            if (id != realtor.RealtorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(realtor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RealtorExists(realtor.RealtorID))
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
            ViewData["CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyID", realtor.CompanyID);
            return View(realtor);
        }

        // GET: Realtor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realtor = await _context.Realtor
                .Include(r => r.Company)
                .SingleOrDefaultAsync(m => m.RealtorID == id);
            if (realtor == null)
            {
                return NotFound();
            }

            return View(realtor);
        }

        // POST: Realtor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var realtor = await _context.Realtor.SingleOrDefaultAsync(m => m.RealtorID == id);
            _context.Realtor.Remove(realtor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RealtorExists(int id)
        {
            return _context.Realtor.Any(e => e.RealtorID == id);
        }
    }
}
