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
    //[Authorize(Roles = "Admin")]

    public class OrgnizationsController : Controller //CQRS
    {
        private readonly ArchivistDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public OrgnizationsController(ArchivistDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Orgnizations
        public async Task<IActionResult> Index()
        {
            var archivistDBContext = _context.orgnizations.Include(o => o.orgTypes).Include(o => o.departments).Include(o => o.employees);
            return View(await archivistDBContext.ToListAsync());
        }

        // GET: Orgnizations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgnization = await _context.orgnizations
                .Include(o => o.orgTypes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orgnization == null)
            {
                return NotFound();
            }

            return View(orgnization);
        }

        // GET: Orgnizations/Create
        public IActionResult Create()
        {
            ViewData["orgTypesId"] = new SelectList(_context.orgTypes, "Id", "typeName");
            return View();
        }

        // POST: Orgnizations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,orgName,imageFile,orgTypesId")] Orgnization orgnization)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;

                    //Add Image

                    // string imageFileName = Path.GetFileNameWithoutExtension(orgnization.imageFile.FileName);
                    string imageExtension = Path.GetExtension(orgnization.imageFile.FileName);
                    orgnization.imageSrc = "OrgAvatar-" + orgnization.orgName + DateTime.Now.ToString("yymmssffff") + imageExtension;
                    string imgPath = Path.Combine(wwwRootPath + "/images/OrgsAvatars", orgnization.imageSrc);

                    using (var FileStream = new FileStream(imgPath, FileMode.Create))
                    {
                        await orgnization.imageFile.CopyToAsync(FileStream);
                    }
                }
                catch
                {
                    throw new Exception();
                }

                _context.Add(orgnization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["orgTypesId"] = new SelectList(_context.orgTypes, "Id", "typeName", orgnization.orgTypesId);
            return View(orgnization);
        }

        // GET: Orgnizations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgnization = await _context.orgnizations.FindAsync(id);
            if (orgnization == null)
            {
                return NotFound();
            }
            ViewData["orgTypesId"] = new SelectList(_context.orgTypes, "Id", "typeName", orgnization.orgTypesId);
            return View(orgnization);
        }

        // POST: Orgnizations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,orgName,imageFile,orgTypesId")] Orgnization orgnization)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;

            //Add Image

            string imageExtension = Path.GetExtension(orgnization.imageFile.FileName);
            orgnization.imageSrc = "OrgAvatar-" + orgnization.orgName + DateTime.Now.ToString("yymmssffff") + imageExtension;
            string imgPath = Path.Combine(wwwRootPath + "/images/OrgsAvatars", orgnization.imageSrc);

            using (var FileStream = new FileStream(imgPath, FileMode.Create))
            {
                await orgnization.imageFile.CopyToAsync(FileStream);
            }

            if (id != orgnization.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orgnization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrgnizationExists(orgnization.Id))
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
            ViewData["orgTypesId"] = new SelectList(_context.orgTypes, "Id", "typeName", orgnization.orgTypesId);
            return View(orgnization);
        }

        // GET: Orgnizations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgnization = await _context.orgnizations
                .Include(o => o.orgTypes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orgnization == null)
            {
                return NotFound();
            }

            return View(orgnization);
        }

        // POST: Orgnizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orgnization = await _context.orgnizations.FindAsync(id);
            _context.orgnizations.Remove(orgnization);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrgnizationExists(int id)
        {
            return _context.orgnizations.Any(e => e.Id == id);
        }
    }
}
