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
    public class DedicadoTelefonicasController : Controller
    {
        private readonly ApoioDbContext _context;

        public DedicadoTelefonicasController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.DedicadoTelefonica.OrderBy(a => a.Opcoes).ToListAsync());

        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dedicadoTelefonica = await _context.DedicadoTelefonica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dedicadoTelefonica == null)
            {
                return NotFound();
            }

            return View(dedicadoTelefonica);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] DedicadoTelefonica dedicadoTelefonica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dedicadoTelefonica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dedicadoTelefonica);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dedicadoTelefonica = await _context.DedicadoTelefonica.FindAsync(id);
            if (dedicadoTelefonica == null)
            {
                return NotFound();
            }
            return View(dedicadoTelefonica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] DedicadoTelefonica dedicadoTelefonica)
        {
            if (id != dedicadoTelefonica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dedicadoTelefonica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DedicadoTelefonicaExists(dedicadoTelefonica.Id))
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
            return View(dedicadoTelefonica);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dedicadoTelefonica = await _context.DedicadoTelefonica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dedicadoTelefonica == null)
            {
                return NotFound();
            }

            return View(dedicadoTelefonica);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var dedicadoTelefonica = await _context.DedicadoTelefonica.FindAsync(id);
            _context.DedicadoTelefonica.Remove(dedicadoTelefonica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DedicadoTelefonicaExists(Guid id)
        {
            return _context.DedicadoTelefonica.Any(e => e.Id == id);
        }
    }
}
