using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spp.API.Data;
using Spp.Data.Entities;

namespace Spp.API.Controllers
{
    public class FondosController : Controller
    {
        private readonly DataContext _context;

        public FondosController(DataContext context)
        {
            _context = context;
        }

        // GET: Fondos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fondos.ToListAsync());
        }

        // GET: Fondos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fondo = await _context.Fondos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fondo == null)
            {
                return NotFound();
            }

            return View(fondo);
        }

        // GET: Fondos/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fondo fondo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fondo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fondo);
        }

        // GET: Fondos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fondo = await _context.Fondos.FindAsync(id);
            if (fondo == null)
            {
                return NotFound();
            }
            return View(fondo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Fondo fondo)
        {
            if (id != fondo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fondo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FondoExists(fondo.Id))
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
            return View(fondo);
        }

        // GET: Fondos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fondo = await _context.Fondos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fondo == null)
            {
                return NotFound();
            }

            return View(fondo);
        }

        // POST: Fondos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fondo = await _context.Fondos.FindAsync(id);
            _context.Fondos.Remove(fondo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FondoExists(int id)
        {
            return _context.Fondos.Any(e => e.Id == id);
        }
    }
}
