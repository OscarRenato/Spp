using Spp.API.Data.Entities;
using Spp.API.Helpers;
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

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
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
                _context.Proyectos.Add(new Proyecto
                {
                    ProyectoNro = "CSN-001",
                    Empresa = "DYCSA",
                    EmpresaRuc = "10084575690",
                    EmpresaRepresentante = "Mario Salvatierra",
                    Monto = 100000,
                    TipoMoneda = 11,
                    TipoPago = 12,
                    Comision = "3%",
                    FContrato = Convert.ToDateTime("2020/08/10"),
                    DireccionFinanc = "Av. Alfonso Ugarte 2932, Lima",
                    MontoFinal = 100000,
                    FondoId = 2,
                    FIngreso = Convert.ToDateTime("2018/04/09"),
                    Observacion = "Construccion de un parque de diversiones"
                });
                _context.Proyectos.Add(new Proyecto
                {
                    ProyectoNro = "TRP-002",
                    Empresa = "CRUZ DEL SUR",
                    EmpresaRuc = "10084587690",
                    EmpresaRepresentante = "Julio Martinez",
                    Monto = 1900000,
                    TipoMoneda = 10,
                    TipoPago = 11,
                    Comision = "5%",
                    FContrato = Convert.ToDateTime("2021/02/10"),
                    DireccionFinanc = "Av. Izaguirre 3239, Los Oivos",
                    MontoFinal = 1500000,
                    FondoId = 3,
                    FIngreso = Convert.ToDateTime("2021/06/09"),
                    Observacion = "Ampliacion de buses para nuevas rutas nacionales"
                });
                _context.Proyectos.Add(new Proyecto
                {
                    ProyectoNro = "CSN-002",
                    Empresa = "SOTO construccion",
                    EmpresaRuc = "30066575690",
                    EmpresaRepresentante = "Ernesto Soto",
                    Monto = 3100000,
                    TipoMoneda = 10,
                    TipoPago = 12,
                    Comision = "5%",
                    FContrato = Convert.ToDateTime("2019/03/23"),
                    DireccionFinanc = "Av. Palmeras 8483, Chorrillos",
                    MontoFinal = 3100000,
                    FondoId = 1,
                    FIngreso = Convert.ToDateTime("2018/05/19"),
                    Observacion = "Construccion de edificio para viviendas economicas"
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
