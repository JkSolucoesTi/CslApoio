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
    public class AndarPredioTelsController : Controller
    {
        private readonly ApoioDbContext _context;

        public AndarPredioTelsController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.AndarPredioTel.OrderBy(a => a.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var andarPredioTel = await _context.AndarPredioTel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (andarPredioTel == null)
            {
                return NotFound();
            }

            return View(andarPredioTel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] AndarPredioTel andarPredioTel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(andarPredioTel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(andarPredioTel);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var andarPredioTel = await _context.AndarPredioTel.FindAsync(id);
            if (andarPredioTel == null)
            {
                return NotFound();
            }
            return View(andarPredioTel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] AndarPredioTel andarPredioTel)
        {
            if (id != andarPredioTel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(andarPredioTel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AndarPredioTelExists(andarPredioTel.Id))
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
            return View(andarPredioTel);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var andarPredioTel = await _context.AndarPredioTel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (andarPredioTel == null)
            {
                return NotFound();
            }

            return View(andarPredioTel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var andarPredioTel = await _context.AndarPredioTel.FindAsync(id);
            _context.AndarPredioTel.Remove(andarPredioTel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AndarPredioTelExists(Guid id)
        {
            return _context.AndarPredioTel.Any(e => e.Id == id);
        }
    }
}
