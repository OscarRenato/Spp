using Spp.API.Models;
using Spp.Data.Entities;
using System.Threading.Tasks;

namespace Spp.API.Helpers
{
    public interface IConverterHelper
    {
        Task<Proyecto> ToProyectoAsync(ProyectoViewModel model, bool isNew);
        ProyectoViewModel ToProyectoViewModel(Proyecto proyecto);

    }
}
