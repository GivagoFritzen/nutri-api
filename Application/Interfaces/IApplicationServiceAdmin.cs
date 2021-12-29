using Application.ViewModel;
using Application.ViewModel.Admin;

namespace Application.Interfaces
{
    public interface IApplicationServiceAdmin
    {
        ResponseView Add(AdminAdicionarViewModel adminAdicionarViewModel);
    }
}
