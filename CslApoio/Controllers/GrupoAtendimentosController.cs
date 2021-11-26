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
    public class GrupoAtendimentosController : Controller
    {
        private readonly ApoioDbContext _context;

        public GrupoAtendimentosController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.GrupoAtendimento.OrderBy(a => a.Opcoes).ToListAsync());

        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoAtendimento = await _context.GrupoAtendimento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupoAtendimento == null)
            {
                return NotFound();
            }

            return View(grupoAtendimento);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] GrupoAtendimento grupoAtendimento)
        {
            if (ModelState.IsValid)
            {
                grupoAtendimento.Id = Guid.NewGuid();
                _context.Add(grupoAtendimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupoAtendimento);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoAtendimento = await _context.GrupoAtendimento.FindAsync(id);
            if (grupoAtendimento == null)
            {
                return NotFound();
            }
            return View(grupoAtendimento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] GrupoAtendimento grupoAtendimento)
        {
            if (id != grupoAtendimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupoAtendimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoAtendimentoExists(grupoAtendimento.Id))
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
            return View(grupoAtendimento);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoAtendimento = await _context.GrupoAtendimento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupoAtendimento == null)
            {
                return NotFound();
            }

            return View(grupoAtendimento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var grupoAtendimento = await _context.GrupoAtendimento.FindAsync(id);
            _context.GrupoAtendimento.Remove(grupoAtendimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoAtendimentoExists(Guid id)
        {
            return _context.GrupoAtendimento.Any(e => e.Id == id);
        }
    }
}
