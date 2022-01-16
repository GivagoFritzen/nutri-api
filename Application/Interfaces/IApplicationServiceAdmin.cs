using Application.ViewModel;
using Application.ViewModel.Admin;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationServiceAdmin
    {
        Task<ResponseView> Add(AdminAdicionarViewModel adminAdicionarViewModel);
    }
}
