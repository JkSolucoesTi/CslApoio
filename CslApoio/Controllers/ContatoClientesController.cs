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
    public class ContatoClientesController : Controller
    {
        private readonly ApoioDbContext _context;

        public ContatoClientesController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ContatoCliente.OrderBy(cc => cc.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatoCliente = await _context.ContatoCliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contatoCliente == null)
            {
                return NotFound();
            }

            return View(contatoCliente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] ContatoCliente contatoCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contatoCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contatoCliente);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatoCliente = await _context.ContatoCliente.FindAsync(id);
            if (contatoCliente == null)
            {
                return NotFound();
            }
            return View(contatoCliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] ContatoCliente contatoCliente)
        {
            if (id != contatoCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contatoCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoClienteExists(contatoCliente.Id))
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
            return View(contatoCliente);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatoCliente = await _context.ContatoCliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contatoCliente == null)
            {
                return NotFound();
            }

            return View(contatoCliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var contatoCliente = await _context.ContatoCliente.FindAsync(id);
            _context.ContatoCliente.Remove(contatoCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoClienteExists(Guid id)
        {
            return _context.ContatoCliente.Any(e => e.Id == id);
        }
    }
}
