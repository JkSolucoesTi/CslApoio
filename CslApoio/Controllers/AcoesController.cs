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
    public class AcoesController : Controller
    {
        private readonly ApoioDbContext _context;

        public AcoesController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Acao.OrderBy(a => a.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acao = await _context.Acao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acao == null)
            {
                return NotFound();
            }

            return View(acao);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] Acao acao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acao);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acao = await _context.Acao.FindAsync(id);
            if (acao == null)
            {
                return NotFound();
            }
            return View(acao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] Acao acao)
        {
            if (id != acao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcaoExists(acao.Id))
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
            return View(acao);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acao = await _context.Acao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acao == null)
            {
                return NotFound();
            }

            return View(acao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var acao = await _context.Acao.FindAsync(id);
            _context.Acao.Remove(acao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcaoExists(Guid id)
        {
            return _context.Acao.Any(e => e.Id == id);
        }
    }
}
