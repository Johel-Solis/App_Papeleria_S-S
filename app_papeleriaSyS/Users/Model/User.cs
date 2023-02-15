namespace app_papeleriaSyS.Users.Model
{
    public class User : Person
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
            this.state = true;
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