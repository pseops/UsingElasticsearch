using System.Collections.Generic;

namespace Common.Views.Authetication.Response
{
    public class ResponseGetUsersView
    {
        public ICollection<ResponseGetUserItemView> Items =
          new List<ResponseGetUserItemView>();
    }
}
