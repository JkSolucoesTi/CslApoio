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
    public class DependenciasController : Controller
    {
        private readonly ApoioDbContext _context;

        public DependenciasController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Dependencia.OrderBy(a => a.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependencia = await _context.Dependencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dependencia == null)
            {
                return NotFound();
            }

            return View(dependencia);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] Dependencia dependencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dependencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dependencia);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependencia = await _context.Dependencia.FindAsync(id);
            if (dependencia == null)
            {
                return NotFound();
            }
            return View(dependencia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] Dependencia dependencia)
        {
            if (id != dependencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dependencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DependenciaExists(dependencia.Id))
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
            return View(dependencia);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependencia = await _context.Dependencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dependencia == null)
            {
                return NotFound();
            }

            return View(dependencia);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var dependencia = await _context.Dependencia.FindAsync(id);
            _context.Dependencia.Remove(dependencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DependenciaExists(Guid id)
        {
            return _context.Dependencia.Any(e => e.Id == id);
        }
    }
}
