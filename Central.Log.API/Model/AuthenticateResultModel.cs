using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Central.Log.API.Model
{
    public class AuthenticateResultModel
    {
        public Nullable<int> Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
