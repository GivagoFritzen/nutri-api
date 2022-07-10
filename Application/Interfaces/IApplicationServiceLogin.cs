using Application.ViewModel;
using Application.ViewModel.Login;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationServiceLogin
    {
        Task<BaseViewModel> Login(LoginNutricionistaViewModel user);
        BaseViewModel Refresh(LoginTokenViewModel loginTokenViewModel);
    }
}