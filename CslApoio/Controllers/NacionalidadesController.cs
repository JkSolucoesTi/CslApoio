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
    public class NacionalidadesController : Controller
    {
        private readonly ApoioDbContext _context;

        public NacionalidadesController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoNacionalidade.OrderBy(a => a.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionalidade = await _context.TipoNacionalidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nacionalidade == null)
            {
                return NotFound();
            }

            return View(nacionalidade);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Nacionalidade nacionalidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nacionalidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nacionalidade);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionalidade = await _context.TipoNacionalidade.FindAsync(id);
            if (nacionalidade == null)
            {
                return NotFound();
            }
            return View(nacionalidade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] Nacionalidade nacionalidade)
        {
            if (id != nacionalidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nacionalidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NacionalidadeExists(nacionalidade.Id))
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
            return View(nacionalidade);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionalidade = await _context.TipoNacionalidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nacionalidade == null)
            {
                return NotFound();
            }

            return View(nacionalidade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var nacionalidade = await _context.TipoNacionalidade.FindAsync(id);
            _context.TipoNacionalidade.Remove(nacionalidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NacionalidadeExists(Guid id)
        {
            return _context.TipoNacionalidade.Any(e => e.Id == id);
        }
    }
}
