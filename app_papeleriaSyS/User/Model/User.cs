using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace app_papeleriaSyS.model
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
        public User(string username, string password, string typeUser)
        {
            this.Username = username;
            this.Password = password;
            this.TypeUser = typeUser;
        }
        #endregion
        #region getter and setter
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string TypeUser { get => typeUser; set => typeUser = value; }
        #endregion

    }
