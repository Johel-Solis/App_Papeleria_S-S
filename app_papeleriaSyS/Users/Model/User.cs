using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using app_papeleriaSyS.Users.Model;

namespace app_papeleriaSyS.Users.Model
{
    internal class User : Person
    {
        #region attributes
        private string username;
        private string password;
        private string typeUser;
        #endregion
        #region contructor
        public User()
        {
        }
        public User(string username, string password, string typeUser, int id, string name, string surname, int phone) : base(id, name, surname, phone)
        {
            Username = username;
            Password = password;
            TypeUser = typeUser;


        }
        #endregion
        #region getter and setter
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string TypeUser { get => typeUser; set => typeUser = value; }

        #endregion

    }
}