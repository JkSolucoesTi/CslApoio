using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CslApoio.Context;
using CslApoio.Models;

namespace CslApoio.Controllers
{
    public class SitesCallCentersController : Controller
    {
        private readonly ApoioDbContext _context;

        public SitesCallCentersController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.SitesCallCenter.OrderBy(a => a.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitesCallCenter = await _context.SitesCallCenter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sitesCallCenter == null)
            {
                return NotFound();
            }

            return View(sitesCallCenter);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] SitesCallCenter sitesCallCenter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sitesCallCenter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sitesCallCenter);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitesCallCenter = await _context.SitesCallCenter.FindAsync(id);
            if (sitesCallCenter == null)
            {
                return NotFound();
            }
            return View(sitesCallCenter);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] SitesCallCenter sitesCallCenter)
        {
            if (id != sitesCallCenter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sitesCallCenter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SitesCallCenterExists(sitesCallCenter.Id))
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
            return View(sitesCallCenter);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitesCallCenter = await _context.SitesCallCenter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sitesCallCenter == null)
            {
                return NotFound();
            }

            return View(sitesCallCenter);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var sitesCallCenter = await _context.SitesCallCenter.FindAsync(id);
            _context.SitesCallCenter.Remove(sitesCallCenter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SitesCallCenterExists(Guid id)
        {
            return _context.SitesCallCenter.Any(e => e.Id == id);
        }
    }
}
