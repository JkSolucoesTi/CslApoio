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
    public class AcessoFisicosController : Controller
    {
        private readonly ApoioDbContext _context;

        public AcessoFisicosController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.AcessoFisico.OrderBy(a => a.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessoFisico = await _context.AcessoFisico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acessoFisico == null)
            {
                return NotFound();
            }

            return View(acessoFisico);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] AcessoFisico acessoFisico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acessoFisico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acessoFisico);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessoFisico = await _context.AcessoFisico.FindAsync(id);
            if (acessoFisico == null)
            {
                return NotFound();
            }
            return View(acessoFisico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] AcessoFisico acessoFisico)
        {
            if (id != acessoFisico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acessoFisico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcessoFisicoExists(acessoFisico.Id))
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
            return View(acessoFisico);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessoFisico = await _context.AcessoFisico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acessoFisico == null)
            {
                return NotFound();
            }

            return View(acessoFisico);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var acessoFisico = await _context.AcessoFisico.FindAsync(id);
            _context.AcessoFisico.Remove(acessoFisico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcessoFisicoExists(Guid id)
        {
            return _context.AcessoFisico.Any(e => e.Id == id);
        }
    }
}
