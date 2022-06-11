using Domain.DTO.Taco;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface ITacoRepository
    {
        Task<TacoPaginationDTO> GetDescricao(string descricao, int paginaAtual, int tamanhoPagina);
    }
}