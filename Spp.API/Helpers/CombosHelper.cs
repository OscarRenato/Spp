using Microsoft.AspNetCore.Mvc.Rendering;
using Spp.API.Data;
using System.Collections.Generic;
using System.Linq;

namespace Spp.API.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboFondos()
        {
            List<SelectListItem> list = _context.Fondos.Select(t => new SelectListItem
            {
                Text = t.Empresa,
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Selecciona un Fondo...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboGestors()
        {
            List<SelectListItem> list = _context.Proyectos.Select(t => new SelectListItem
            {
                Text = t.Empresa,
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Selecciona un Gestor...]",
                Value = "0"
            });

            return list;
        }
    }
}
