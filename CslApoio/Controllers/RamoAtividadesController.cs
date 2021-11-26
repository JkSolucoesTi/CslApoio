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
    public class RamoAtividadesController : Controller
    {
        private readonly ApoioDbContext _context;

        public RamoAtividadesController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.RamoAtividade.OrderBy(a => a.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramoAtividade = await _context.RamoAtividade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ramoAtividade == null)
            {
                return NotFound();
            }

            return View(ramoAtividade);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] RamoAtividade ramoAtividade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ramoAtividade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ramoAtividade);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramoAtividade = await _context.RamoAtividade.FindAsync(id);
            if (ramoAtividade == null)
            {
                return NotFound();
            }
            return View(ramoAtividade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] RamoAtividade ramoAtividade)
        {
            if (id != ramoAtividade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ramoAtividade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RamoAtividadeExists(ramoAtividade.Id))
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
            return View(ramoAtividade);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramoAtividade = await _context.RamoAtividade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ramoAtividade == null)
            {
                return NotFound();
            }

            return View(ramoAtividade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ramoAtividade = await _context.RamoAtividade.FindAsync(id);
            _context.RamoAtividade.Remove(ramoAtividade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RamoAtividadeExists(Guid id)
        {
            return _context.RamoAtividade.Any(e => e.Id == id);
        }
    }
}
