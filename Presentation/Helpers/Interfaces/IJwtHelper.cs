using Common.Views.Authetication.Response;

namespace Presentation.Helpers.Interfaces
{
    public interface IJwtHelper
    {
        ResponseGenerateJwtAuthenticationView GenerateJwtToken(ResponseGetUserItemView userModel);
        ResponseGenerateJwtAuthenticationView RefreshToken(ResponseGenerateJwtAuthenticationView model);
        string CheckTokenValidation(ResponseGenerateJwtAuthenticationView model);
    }
}
