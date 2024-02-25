using Domain.Entities.Identity;

namespace API.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
