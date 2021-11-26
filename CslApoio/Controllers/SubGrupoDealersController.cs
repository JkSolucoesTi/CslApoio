using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CslApoio.Context;
using CslApoio.Models;

namespace CslApoio.Migrations
{
    public class SubGrupoDealersController : Controller
    {
        private readonly ApoioDbContext _context;

        public SubGrupoDealersController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.SubGrupoDealers.OrderBy(a => a.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGrupoDealers = await _context.SubGrupoDealers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subGrupoDealers == null)
            {
                return NotFound();
            }

            return View(subGrupoDealers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] SubGrupoDealers subGrupoDealers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subGrupoDealers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subGrupoDealers);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGrupoDealers = await _context.SubGrupoDealers.FindAsync(id);
            if (subGrupoDealers == null)
            {
                return NotFound();
            }
            return View(subGrupoDealers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] SubGrupoDealers subGrupoDealers)
        {
            if (id != subGrupoDealers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subGrupoDealers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubGrupoDealersExists(subGrupoDealers.Id))
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
            return View(subGrupoDealers);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGrupoDealers = await _context.SubGrupoDealers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subGrupoDealers == null)
            {
                return NotFound();
            }

            return View(subGrupoDealers);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var subGrupoDealers = await _context.SubGrupoDealers.FindAsync(id);
            _context.SubGrupoDealers.Remove(subGrupoDealers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubGrupoDealersExists(Guid id)
        {
            return _context.SubGrupoDealers.Any(e => e.Id == id);
        }
    }
}
