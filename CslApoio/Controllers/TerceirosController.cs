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
    public class TerceirosController : Controller
    {
        private readonly ApoioDbContext _context;

        public TerceirosController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoTerceiro.OrderBy(a => a.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terceiro = await _context.TipoTerceiro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (terceiro == null)
            {
                return NotFound();
            }

            return View(terceiro);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] Terceiro terceiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(terceiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(terceiro);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terceiro = await _context.TipoTerceiro.FindAsync(id);
            if (terceiro == null)
            {
                return NotFound();
            }
            return View(terceiro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] Terceiro terceiro)
        {
            if (id != terceiro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terceiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerceiroExists(terceiro.Id))
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
            return View(terceiro);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terceiro = await _context.TipoTerceiro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (terceiro == null)
            {
                return NotFound();
            }

            return View(terceiro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var terceiro = await _context.TipoTerceiro.FindAsync(id);
            _context.TipoTerceiro.Remove(terceiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerceiroExists(Guid id)
        {
            return _context.TipoTerceiro.Any(e => e.Id == id);
        }
    }
}
