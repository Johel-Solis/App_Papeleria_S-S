namespace app_papeleriaSyS.Providers.Model
{
    internal class Provider
    {
        #region attribute 
        private int nit;
        private string name;
        private string email;
        private int phoneNumber;
        private string bank;
        private int accountNumber;
        private bool state;

        #endregion
        #region
        public Provider()
        {
        }

        public Provider(int nit, string name, string email, int phoneNumber, string bank, int accountNumber, bool state)
        {
            this.nit = nit;
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.bank = bank;
            this.accountNumber = accountNumber;
            this.state = state;
        }





        #endregion

        #region getter an setter
        public int Nit { get => nit; set => nit = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Bank { get => bank; set => bank = value; }
        public int AccountNumber { get => accountNumber; set => accountNumber = value; }
        public bool State { get => state; set => state = value; }
        #endregion
    }
}
