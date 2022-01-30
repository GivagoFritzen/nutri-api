using Domain.Entity;
using Domain.Event;

namespace Core.Interfaces.Services
{
    public interface INutricionistaService : IServiceBase<NutricionistaEntity, NutricionistaEvent>
    {
    }
}