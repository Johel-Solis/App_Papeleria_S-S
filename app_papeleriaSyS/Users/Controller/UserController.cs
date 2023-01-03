using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using app_papeleriaSyS.Users.Model;
using app_papeleriaSyS.Utillity;


namespace app_papeleriaSyS.Users.Controller
{
    internal class UserController
    {

        public bool createUser(string username, string pass,string typeUser, int id, string name, string surname, int phone)
        {
            User user = new User(username,
                                 Encryption.encryptKey(pass),
                                 typeUser,
                                 id,
                                 name,
                                 surname,
                                 phone);



            return true;
                }
        

    }
}
