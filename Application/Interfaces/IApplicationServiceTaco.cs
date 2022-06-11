using Application.ViewModel;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationServiceTaco
    {
        Task<ResponseView> GetTacoByPagination(string descricao, int paginaAtual, int tamanhoPagina);
    }
}