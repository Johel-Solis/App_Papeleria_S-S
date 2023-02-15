using System.Numerics;

namespace app_papeleriaSyS.Providers.Model
{
     class Provider
    {
        #region attribute 
        private BigInteger nit;
        private string name;
        private string email;
        private BigInteger phoneNumber;
        private string bank;
        private BigInteger accountNumber;
        private bool state;

        #endregion
        #region
        public Provider()
        {
        }

        public Provider(BigInteger nit, string name, string email, BigInteger phoneNumber, string bank, BigInteger accountNumber, bool state)
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
        public BigInteger Nit { get => nit; set => nit = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public BigInteger PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Bank { get => bank; set => bank = value; }
        public BigInteger AccountNumber { get => accountNumber; set => accountNumber = value; }
        public bool State { get => state; set => state = value; }
        #endregion
    }
}
