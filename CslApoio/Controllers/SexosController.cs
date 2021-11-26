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
    public class SexosController : Controller
    {
        private readonly ApoioDbContext _context;

        public SexosController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoSexo.OrderBy(a => a.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sexo = await _context.TipoSexo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sexo == null)
            {
                return NotFound();
            }

            return View(sexo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] Sexo sexo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sexo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sexo);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sexo = await _context.TipoSexo.FindAsync(id);
            if (sexo == null)
            {
                return NotFound();
            }
            return View(sexo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] Sexo sexo)
        {
            if (id != sexo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sexo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SexoExists(sexo.Id))
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
            return View(sexo);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sexo = await _context.TipoSexo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sexo == null)
            {
                return NotFound();
            }

            return View(sexo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var sexo = await _context.TipoSexo.FindAsync(id);
            _context.TipoSexo.Remove(sexo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SexoExists(Guid id)
        {
            return _context.TipoSexo.Any(e => e.Id == id);
        }
    }
}
