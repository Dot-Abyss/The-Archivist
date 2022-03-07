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
    public class ArchivesController : Controller
    {
        private readonly ArchivistDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ArchivesController(ArchivistDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Archives
        public async Task<IActionResult> Index()
        {
            var archivistDBContext = _context.archives.Include(a => a.archiveType).Include(a => a.client).Include(a => a.department).Include(a => a.department.orgnization);
            return View(await archivistDBContext.ToListAsync());
        }

        // GET: Archives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archive = await _context.archives
                .Include(a => a.archiveType)
                .Include(a => a.client)
                .Include(a => a.department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (archive == null)
            {
                return NotFound();
            }

            return View(archive);
        }

        // GET: Archives/Create
        public IActionResult Create()
        {
            ViewData["archiveTypeId"] = new SelectList(_context.archiveTypes, "Id", "typeName");
            ViewData["clientId"] = new SelectList(_context.clients, "Id", "clientName");
            ViewData["departmentId"] = new SelectList(_context.departments, "Id", "depName");
            return View();
        }

        // POST: Archives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,title,content,archiveTypeId,departmentId,imageFile,archFile,addDateTime,publishDateTime,clientId")] Archive archive)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;

                    //Add File
                    string archFileName = Path.GetFileNameWithoutExtension(archive.archFile.FileName);
                    string archExtension = Path.GetExtension(archive.archFile.FileName);
                    archive.fileSrc = archFileName = archFileName + DateTime.Now.ToString("yymmssffff") + archExtension;
                    string archPath = Path.Combine(wwwRootPath + "/files/ArchivesFiles", archFileName);

                    using (var FileStream = new FileStream(archPath, FileMode.Create))
                    {
                        await archive.archFile.CopyToAsync(FileStream);
                    }

                    //Add Image

                    string imageFileName = Path.GetFileNameWithoutExtension(archive.imageFile.FileName);
                    string imageExtension = Path.GetExtension(archive.imageFile.FileName);
                    archive.imageSrc = imageFileName = imageFileName + DateTime.Now.ToString("yymmssffff") + imageExtension;
                    string imgPath = Path.Combine(wwwRootPath + "/images/ArchivesImages", imageFileName);

                    using (var FileStream = new FileStream(imgPath, FileMode.Create))
                    {
                        await archive.imageFile.CopyToAsync(FileStream);
                    }


                }
                catch
                {
                    throw new Exception();
                }

                _context.Add(archive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["archiveTypeId"] = new SelectList(_context.archiveTypes, "Id", "typeName", archive.archiveTypeId);
            ViewData["clientId"] = new SelectList(_context.clients, "Id", "clientName", archive.clientId);
            ViewData["departmentId"] = new SelectList(_context.departments, "Id", "depName", archive.departmentId);
            return View(archive);
        }

        // GET: Archives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archive = await _context.archives.FindAsync(id);
            if (archive == null)
            {
                return NotFound();
            }
            ViewData["archiveTypeId"] = new SelectList(_context.archiveTypes, "Id", "typeName", archive.archiveTypeId);
            ViewData["clientId"] = new SelectList(_context.clients, "Id", "clientName", archive.clientId);
            ViewData["departmentId"] = new SelectList(_context.departments, "Id", "depName", archive.departmentId);
            return View(archive);
        }

        // POST: Archives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,title,content,archiveTypeId,departmentId,imageSrc,fileSrc,addDateTime,publishDateTime,clientId")] Archive archive)
        {
            if (id != archive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(archive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArchiveExists(archive.Id))
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
            ViewData["archiveTypeId"] = new SelectList(_context.archiveTypes, "Id", "typeName", archive.archiveTypeId);
            ViewData["clientId"] = new SelectList(_context.clients, "Id", "clientName", archive.clientId);
            ViewData["departmentId"] = new SelectList(_context.departments, "Id", "depName", archive.departmentId);
            return View(archive);
        }

        // GET: Archives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archive = await _context.archives
                .Include(a => a.archiveType)
                .Include(a => a.client)
                .Include(a => a.department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (archive == null)
            {
                return NotFound();
            }

            return View(archive);
        }

        // POST: Archives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var archive = await _context.archives.FindAsync(id);
            _context.archives.Remove(archive);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArchiveExists(int id)
        {
            return _context.archives.Any(e => e.Id == id);
        }
    }
}
