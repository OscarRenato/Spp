using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spp.API.Data;
using Spp.API.Helpers;
using Spp.API.Models;
using Spp.Data.Entities;

namespace Spp.API.Controllers
{
    public class ProyectosController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;

        public ProyectosController(DataContext context, ICombosHelper combosHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
        }

        // GET: Proyectos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proyectos.ToListAsync());
        }

        // GET: Proyectos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // GET: Proyectos/Create
        public IActionResult Create()
        {
            ProyectoViewModel model = new()
            {
                Fondos = _combosHelper.GetComboFondos()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProyectoViewModel model)
        {
            if (ModelState.IsValid)
            {
                Proyecto proyecto = await _converterHelper.ToProyectoAsync(model, true);
                _context.Proyectos.Add(proyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = model.Id });
            }

            model.Fondos = _combosHelper.GetComboFondos();
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Proyecto proyecto = await _context.Proyectos
                .Include(x => x.Fondo)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (proyecto == null)
            {
                return NotFound();
            }

            ProyectoViewModel model = _converterHelper.ToProyectoViewModel(proyecto);
            model.Fondos = _combosHelper.GetComboFondos();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProyectoViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Proyecto proyecto = await _converterHelper.ToProyectoAsync(model, false);
                    _context.Proyectos.Update(proyecto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new { id = model.Id });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un Proyecto con este nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            model.Fondos = _combosHelper.GetComboFondos();
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // POST: Proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            _context.Proyectos.Remove(proyecto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProyectoExists(int id)
        {
            return _context.Proyectos.Any(e => e.Id == id);
        }
    }
}
