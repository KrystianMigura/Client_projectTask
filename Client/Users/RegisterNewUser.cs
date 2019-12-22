using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Users
{
   class RegisterNewUser
    {
        public RegisterNewUser() { }

        protected string userName { get; set; }
        protected string pass { get; set; }

        public void catchData(String userName, string password, Client.Options.ConnectToServer clnt)
        {
            this.userName = userName;
            this.pass = password;
            clnt.sendMessage("#102~ " + this.userName + "/" + this.pass);
        }

    }
}
