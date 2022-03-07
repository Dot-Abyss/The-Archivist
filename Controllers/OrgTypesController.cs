#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using The_Archivist.Models;

namespace The_Archivist.Controllers
{
    public class OrgTypesController : Controller
    {
        private readonly ArchivistDBContext _context;

        public OrgTypesController(ArchivistDBContext context)
        {
            _context = context;
        }

        // GET: OrgTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.orgTypes.ToListAsync());
        }

        // GET: OrgTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgType = await _context.orgTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orgType == null)
            {
                return NotFound();
            }

            return View(orgType);
        }

        // GET: OrgTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrgTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,typeName")] OrgType orgType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orgType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orgType);
        }

        // GET: OrgTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgType = await _context.orgTypes.FindAsync(id);
            if (orgType == null)
            {
                return NotFound();
            }
            return View(orgType);
        }

        // POST: OrgTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,typeName")] OrgType orgType)
        {
            if (id != orgType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orgType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrgTypeExists(orgType.Id))
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
            return View(orgType);
        }

        // GET: OrgTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgType = await _context.orgTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orgType == null)
            {
                return NotFound();
            }

            return View(orgType);
        }

        // POST: OrgTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orgType = await _context.orgTypes.FindAsync(id);
            _context.orgTypes.Remove(orgType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrgTypeExists(int id)
        {
            return _context.orgTypes.Any(e => e.Id == id);
        }
    }
}
