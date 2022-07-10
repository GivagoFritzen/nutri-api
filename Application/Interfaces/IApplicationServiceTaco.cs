using Application.ViewModel.Taco;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationServiceTaco
    {
        Task<TacoPaginationViewModel> GetTacoByPagination(string descricao, int paginaAtual, int tamanhoPagina);
    }
}