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
    public class CertificadoesController : Controller
    {
        private readonly ApoioDbContext _context;

        public CertificadoesController(ApoioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Certificados.OrderBy(c => c.Opcoes).ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificado = await _context.Certificados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificado == null)
            {
                return NotFound();
            }

            return View(certificado);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opcoes,Id")] Certificado certificado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certificado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(certificado);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificado = await _context.Certificados.FindAsync(id);
            if (certificado == null)
            {
                return NotFound();
            }
            return View(certificado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Opcoes,Id")] Certificado certificado)
        {
            if (id != certificado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificadoExists(certificado.Id))
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
            return View(certificado);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificado = await _context.Certificados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificado == null)
            {
                return NotFound();
            }

            return View(certificado);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var certificado = await _context.Certificados.FindAsync(id);
            _context.Certificados.Remove(certificado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificadoExists(Guid id)
        {
            return _context.Certificados.Any(e => e.Id == id);
        }
    }
}
