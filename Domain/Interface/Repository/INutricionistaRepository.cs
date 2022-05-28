using Domain.Entity;
using Domain.Event;
using Domain.Interface.Repository.Base;

namespace Domain.Interface.Repository
{
    public interface INutricionistaRepository : IRepositoryBase<NutricionistaEntity, NutricionistaEvent>
    {
    }
}