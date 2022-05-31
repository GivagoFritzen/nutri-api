using Domain.Event;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface ITokenRepository
    {
        void AddRefreshToken(TokenEvent evento);
        void DeleteRefreshToken(TokenEvent evento);
        void UpdateRefreshToken(TokenEvent evento, string olderRefreshToken);
        Task<bool> VerificarRefreshToken(string refreshToken);
    }
}