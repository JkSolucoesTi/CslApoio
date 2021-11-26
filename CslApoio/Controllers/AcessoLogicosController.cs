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
    public class AcessoLogicosController : Controller
    {
        private readonly ApoioDbContext _context;

        public AcessoLogicosController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.AcessoLogico.OrderBy(ac => ac.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessoLogico = await _context.AcessoLogico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acessoLogico == null)
            {
                return NotFound();
            }

            return View(acessoLogico);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] AcessoLogico acessoLogico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acessoLogico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acessoLogico);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessoLogico = await _context.AcessoLogico.FindAsync(id);
            if (acessoLogico == null)
            {
                return NotFound();
            }
            return View(acessoLogico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] AcessoLogico acessoLogico)
        {
            if (id != acessoLogico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acessoLogico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcessoLogicoExists(acessoLogico.Id))
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
            return View(acessoLogico);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessoLogico = await _context.AcessoLogico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acessoLogico == null)
            {
                return NotFound();
            }

            return View(acessoLogico);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var acessoLogico = await _context.AcessoLogico.FindAsync(id);
            _context.AcessoLogico.Remove(acessoLogico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcessoLogicoExists(Guid id)
        {
            return _context.AcessoLogico.Any(e => e.Id == id);
        }
    }
}
