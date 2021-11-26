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
    public class StatusTerceirosController : Controller
    {
        private readonly ApoioDbContext _context;

        public StatusTerceirosController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusTerceiro.OrderBy(a => a.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusTerceiro = await _context.StatusTerceiro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusTerceiro == null)
            {
                return NotFound();
            }

            return View(statusTerceiro);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] StatusTerceiro statusTerceiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusTerceiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusTerceiro);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusTerceiro = await _context.StatusTerceiro.FindAsync(id);
            if (statusTerceiro == null)
            {
                return NotFound();
            }
            return View(statusTerceiro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] StatusTerceiro statusTerceiro)
        {
            if (id != statusTerceiro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusTerceiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusTerceiroExists(statusTerceiro.Id))
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
            return View(statusTerceiro);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusTerceiro = await _context.StatusTerceiro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusTerceiro == null)
            {
                return NotFound();
            }

            return View(statusTerceiro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var statusTerceiro = await _context.StatusTerceiro.FindAsync(id);
            _context.StatusTerceiro.Remove(statusTerceiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusTerceiroExists(Guid id)
        {
            return _context.StatusTerceiro.Any(e => e.Id == id);
        }
    }
}
