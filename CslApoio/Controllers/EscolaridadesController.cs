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
    public class EscolaridadesController : Controller
    {
        private readonly ApoioDbContext _context;

        public EscolaridadesController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoEscolaridade.OrderBy(e => e.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolaridade = await _context.TipoEscolaridade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escolaridade == null)
            {
                return NotFound();
            }

            return View(escolaridade);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] Escolaridade escolaridade)
        {
            if (ModelState.IsValid)
            {
                escolaridade.Id = Guid.NewGuid();
                _context.Add(escolaridade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escolaridade);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolaridade = await _context.TipoEscolaridade.FindAsync(id);
            if (escolaridade == null)
            {
                return NotFound();
            }
            return View(escolaridade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] Escolaridade escolaridade)
        {
            if (id != escolaridade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escolaridade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscolaridadeExists(escolaridade.Id))
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
            return View(escolaridade);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolaridade = await _context.TipoEscolaridade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escolaridade == null)
            {
                return NotFound();
            }

            return View(escolaridade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var escolaridade = await _context.TipoEscolaridade.FindAsync(id);
            _context.TipoEscolaridade.Remove(escolaridade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscolaridadeExists(Guid id)
        {
            return _context.TipoEscolaridade.Any(e => e.Id == id);
        }
    }
}
