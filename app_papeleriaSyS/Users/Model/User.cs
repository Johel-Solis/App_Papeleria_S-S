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
        private bool state;
        #endregion
        #region contructor
        public User()
        {
            this.state= true;
        }

        public User(string username, string password, string typeUser)
        {
            this.username = username;
            this.password = password;
            this.typeUser = typeUser;
            this.State = true;
          
        }

        #endregion
        #region getter and setter
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string TypeUser { get => typeUser; set => typeUser = value; }
        public bool State { get => state; set => state = value; }

        #endregion

    }
}