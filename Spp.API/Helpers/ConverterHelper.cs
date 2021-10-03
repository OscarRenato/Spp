using Spp.API.Data;
using Spp.API.Models;
using Spp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spp.API.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public async Task<Proyecto> ToProyectoAsync(ProyectoViewModel model, bool isNew)
        {
            return new Proyecto
            {
                Fondo = await _context.Fondos.FindAsync(model.FondoId),
                //FondoId = model.FondoId,

                Id = isNew ? 0 : model.Id,
                ProyectoNro= model.ProyectoNro,
                Empresa = model.Empresa,
                EmpresaRuc = model.EmpresaRuc,
                EmpresaRepresentante = model.EmpresaRepresentante,
                Monto = model.Monto,
                TipoMoneda = model.TipoMoneda,
                TipoPago = model.TipoPago,
                Comision = model.Comision,
                FContrato = model.FContrato,
                DireccionFinanc = model.DireccionFinanc,
                MontoFinal = model.MontoFinal,
                FIngreso = model.FIngreso,
                Observacion = model.Observacion
            };
        }

        public ProyectoViewModel ToProyectoViewModel(Proyecto proyecto)
        {
            return new ProyectoViewModel
            {
                FondoId = proyecto.Fondo.Id,
                Fondos = _combosHelper.GetComboFondos(),
                //Fondo = proyecto.Fondo,

                Id = proyecto.Id,
                ProyectoNro = proyecto.ProyectoNro,
                Empresa = proyecto.Empresa,
                EmpresaRuc = proyecto.EmpresaRuc,
                EmpresaRepresentante = proyecto.EmpresaRepresentante,
                Monto = proyecto.Monto,
                TipoMoneda = proyecto.TipoMoneda,
                TipoPago = proyecto.TipoPago,
                Comision = proyecto.Comision,
                FContrato = proyecto.FContrato,
                DireccionFinanc = proyecto.DireccionFinanc,
                MontoFinal = proyecto.MontoFinal,
                FIngreso = proyecto.FIngreso,
                Observacion = proyecto.Observacion
            };
        }
    }
}
