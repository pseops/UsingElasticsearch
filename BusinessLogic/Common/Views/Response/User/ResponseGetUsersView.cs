using System.Collections.Generic;

namespace BusinessLogic.Common.Views.Response.User
{
    public class ResponseGetUsersView
    {
        public ICollection<ResponseGetUserItemView> Items =
          new List<ResponseGetUserItemView>();
    }
}
