using API.Models;
using API.Models.Authentication.Login;

namespace NewsAPI.Repository
{
    public interface ILoginService
    {
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);

    }
}
