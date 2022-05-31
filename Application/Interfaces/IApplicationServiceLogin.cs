using Application.ViewModel;
using Application.ViewModel.Login;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationServiceLogin
    {
        Task<ResponseView> Login(LoginNutricionistaViewModel user);
        ResponseView Refresh(LoginTokenViewModel loginTokenViewModel);
    }
}