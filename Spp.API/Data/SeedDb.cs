using Spp.API.Data.Entities;
using Spp.API.Helpers;
using Spp.API.Models;
using Spp.Common.Enums;
using Spp.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Spp.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly ICombosHelper _combosHelper;

        public SeedDb(DataContext context, IUserHelper userHelper, IConverterHelper converterHelper, ICombosHelper combosHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _converterHelper = converterHelper;
            _combosHelper = combosHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await CheckFondosAsync();
            await CheckTipoDocumentosAsync();
            await CheckProyectosAsync();
            await CheckRolesAsycn();
            await CheckUserAsync("Oscar", "Gomez", "oscarrenato@yahoo.com", "311 322 4620", "Jr. Palma 999", TipoUserEnum.Admin);
            await CheckUserAsync("Juan", "Zuluaga", "zulu@yopmail.com", "311 322 4620", "Calle Luna Calle Sol", TipoUserEnum.Admin);
            await CheckUserAsync("Ledys", "Bedoya", "ledys@yopmail.com", "311 322 4620", "Calle Luna Calle Sol", TipoUserEnum.User);
            await CheckUserAsync("Sandra", "Lopera", "sandra@yopmail.com", "311 322 4620", "Calle Luna Calle Sol", TipoUserEnum.User);

        }

        private async Task CheckUserAsync(string firstName, string lastName, string email, string phoneNumber, string address, TipoUserEnum tipoUserEnum)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Address = address,
                    TipoDocumento = _context.TipoDocumentos.FirstOrDefault(x => x.Description == "DNI"),
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    TipoUserEnum = tipoUserEnum
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, tipoUserEnum.ToString());
            }
        }

        private async Task CheckRolesAsycn()
        {
            await _userHelper.CheckRoleAsync(TipoUserEnum.Admin.ToString());
            await _userHelper.CheckRoleAsync(TipoUserEnum.User.ToString());
        }

        private async Task CheckTipoDocumentosAsync()
        {
            if (!_context.TipoDocumentos.Any())
            {
                _context.TipoDocumentos.Add(new TipoDocumento { Description = "DNI" });
                _context.TipoDocumentos.Add(new TipoDocumento { Description = "Carnet de Extranjeria" });
                _context.TipoDocumentos.Add(new TipoDocumento { Description = "RUC" });
                _context.TipoDocumentos.Add(new TipoDocumento { Description = "Pasaporte" });
                _context.TipoDocumentos.Add(new TipoDocumento { Description = "Cedula Diplomatica" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckFondosAsync()
        {
            if (!_context.Fondos.Any())
            {
                _context.Fondos.Add(new Fondo { Empresa = "ALFA", Web = "www.alfa.com", Telefonos = "675 98764", Email = "alfa@gmail.com", Direccion = "Av. Tacna 8374" });
                _context.Fondos.Add(new Fondo { Empresa = "BETA", Web = "www.beta.com", Telefonos = "445 98722", Email = "beta@gmail.com", Direccion = "Av. Alfonso Ugarte 8374" });
                _context.Fondos.Add(new Fondo { Empresa = "CHARLY", Web = "www.charly.com", Telefonos = "587 32764", Email = "charly@gmail.com", Direccion = "Av. Proceres 6463" });
                _context.Fondos.Add(new Fondo { Empresa = "DELTA", Web = "www.delta.com", Telefonos = "321 35464", Email = "delta@gmail.com", Direccion = "Jr. Poma 234" });
                _context.Fondos.Add(new Fondo { Empresa = "GAMMA", Web = "www.gamma.com", Telefonos = "321 34464", Email = "gamma@gmail.com", Direccion = "Av. Alcazar 3323" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckProyectosAsync()
        {
            if (!_context.Proyectos.Any())
            {
                ProyectoViewModel model = new ProyectoViewModel();
                
                // 1er registro
                model.ProyectoNro = "CSN-001";
                model.Empresa = "DYCSA";
                model.EmpresaRuc = "1008575690";
                model.EmpresaRepresentante = "Mario Moreno";
                model.Monto = 100000;
                model.TipoMoneda = 11;
                model.TipoPago = 12;
                model.Comision = "3%";
                model.FContrato = Convert.ToDateTime("2020/08/10");
                model.DireccionFinanc = "Av. Alfonso Ugarte 2932, Lima";
                model.MontoFinal = 100000;
                model.FondoId = 2;
                model.FIngreso = Convert.ToDateTime("2018/04/09");
                model.Observacion = "Construccion de un parque de diversiones";
                model.Fondos = _combosHelper.GetComboFondos();

                Proyecto proyecto = await _converterHelper.ToProyectoAsync(model, true);
                _context.Proyectos.Add(proyecto);
                await _context.SaveChangesAsync();

                // 2do registro
                model.ProyectoNro = "TRP-002";
                model.Empresa = "CRUZ DEL SUR";
                model.EmpresaRuc = "10084587690";
                model.EmpresaRepresentante = "Julio Martinez";
                model.Monto = 1900000;
                model.TipoMoneda = 10;
                model.TipoPago = 11;
                model.Comision = "5%";
                model.FContrato = Convert.ToDateTime("2021/02/10");
                model.DireccionFinanc = "Av. Izaguirre 3239, Los Oivos";
                model.MontoFinal = 1500000;
                model.FondoId = 3;
                model.FIngreso = Convert.ToDateTime("2021/06/09");
                model.Observacion = "Ampliacion de buses para nuevas rutas nacionales";

                Proyecto proyecto1 = await _converterHelper.ToProyectoAsync(model, true);
                _context.Proyectos.Add(proyecto1);
                await _context.SaveChangesAsync();

                // 3er registro
                model.ProyectoNro = "CSN-002";
                model.Empresa = "SOTO construccion";
                model.EmpresaRuc = "30066575690";
                model.EmpresaRepresentante = "Ernesto Soto";
                model.Monto = 3100000;
                model.TipoMoneda = 10;
                model.TipoPago = 12;
                model.Comision = "5%";
                model.FContrato = Convert.ToDateTime("2019/03/23");
                model.DireccionFinanc = "Av. Palmeras 8483, Chorrillos";
                model.MontoFinal = 3100000;
                model.FondoId = 1;
                model.FIngreso = Convert.ToDateTime("2018/05/19");
                model.Observacion = "Construccion de edificio para viviendas economicas";

                Proyecto proyecto2 = await _converterHelper.ToProyectoAsync(model, true);
                _context.Proyectos.Add(proyecto2);
                await _context.SaveChangesAsync();
            }
        }
    }
}
