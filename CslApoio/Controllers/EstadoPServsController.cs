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
    public class EstadoPServsController : Controller
    {
        private readonly ApoioDbContext _context;

        public EstadoPServsController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoPServ.OrderBy(a => a.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPServ = await _context.EstadoPServ
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoPServ == null)
            {
                return NotFound();
            }

            return View(estadoPServ);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] EstadoPServ estadoPServ)
        {
            if (ModelState.IsValid)
            {
                estadoPServ.Id = Guid.NewGuid();
                _context.Add(estadoPServ);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoPServ);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPServ = await _context.EstadoPServ.FindAsync(id);
            if (estadoPServ == null)
            {
                return NotFound();
            }
            return View(estadoPServ);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] EstadoPServ estadoPServ)
        {
            if (id != estadoPServ.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoPServ);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoPServExists(estadoPServ.Id))
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
            return View(estadoPServ);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPServ = await _context.EstadoPServ
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoPServ == null)
            {
                return NotFound();
            }

            return View(estadoPServ);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var estadoPServ = await _context.EstadoPServ.FindAsync(id);
            _context.EstadoPServ.Remove(estadoPServ);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoPServExists(Guid id)
        {
            return _context.EstadoPServ.Any(e => e.Id == id);
        }
    }
}
