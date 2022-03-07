#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using The_Archivist.Models;

namespace The_Archivist.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ArchiveTypesController : Controller
    {
        private readonly ArchivistDBContext _context;

        public ArchiveTypesController(ArchivistDBContext context)
        {
            _context = context;
        }

        // GET: ArchiveTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.archiveTypes.ToListAsync());
        }

        // GET: ArchiveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archiveType = await _context.archiveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (archiveType == null)
            {
                return NotFound();
            }

            return View(archiveType);
        }

        // GET: ArchiveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArchiveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,typeName")] ArchiveType archiveType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(archiveType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(archiveType);
        }

        // GET: ArchiveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archiveType = await _context.archiveTypes.FindAsync(id);
            if (archiveType == null)
            {
                return NotFound();
            }
            return View(archiveType);
        }

        // POST: ArchiveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,typeName")] ArchiveType archiveType)
        {
            if (id != archiveType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(archiveType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArchiveTypeExists(archiveType.Id))
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
            return View(archiveType);
        }

        // GET: ArchiveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archiveType = await _context.archiveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (archiveType == null)
            {
                return NotFound();
            }

            return View(archiveType);
        }

        // POST: ArchiveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var archiveType = await _context.archiveTypes.FindAsync(id);
            _context.archiveTypes.Remove(archiveType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArchiveTypeExists(int id)
        {
            return _context.archiveTypes.Any(e => e.Id == id);
        }
    }
}
