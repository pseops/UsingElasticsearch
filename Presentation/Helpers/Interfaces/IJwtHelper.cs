using BusinessLogic.Common.Views.Response.User;
using Presentation.Common.Response.Views;

namespace Presentation.Helpers.Interfaces
{
    public interface IJwtHelper
    {
        ResponseGenerateJwtAuthenticationView GenerateJwtToken(ResponseGetUserItemView userModel);
        string CheckTokenValidation(ResponseGenerateJwtAuthenticationView model);
    }
}
