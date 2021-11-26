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
    public class RecursosHumanosController : Controller
    {
        private readonly ApoioDbContext _context;

        public RecursosHumanosController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.RecursosHumanos.OrderBy(a => a.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recursosHumanos = await _context.RecursosHumanos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recursosHumanos == null)
            {
                return NotFound();
            }

            return View(recursosHumanos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] RecursosHumanos recursosHumanos)
        {
            if (ModelState.IsValid)
            {
                recursosHumanos.Id = Guid.NewGuid();
                _context.Add(recursosHumanos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recursosHumanos);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recursosHumanos = await _context.RecursosHumanos.FindAsync(id);
            if (recursosHumanos == null)
            {
                return NotFound();
            }
            return View(recursosHumanos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] RecursosHumanos recursosHumanos)
        {
            if (id != recursosHumanos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recursosHumanos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecursosHumanosExists(recursosHumanos.Id))
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
            return View(recursosHumanos);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recursosHumanos = await _context.RecursosHumanos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recursosHumanos == null)
            {
                return NotFound();
            }

            return View(recursosHumanos);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var recursosHumanos = await _context.RecursosHumanos.FindAsync(id);
            _context.RecursosHumanos.Remove(recursosHumanos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecursosHumanosExists(Guid id)
        {
            return _context.RecursosHumanos.Any(e => e.Id == id);
        }
    }
}
