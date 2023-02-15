using System.Numerics;

namespace app_papeleriaSyS.Customers.Model
{
     class Customer
    {
        #region attribute 
        private  BigInteger nit;
        private string name;
        private BigInteger phoneNumber;
        private string email;
        private bool state;

        #endregion

        #region constructor
        public Customer()
        {
        }

        public Customer(BigInteger nit, string name, BigInteger phoneNumber, string email, bool state)
        {
            this.Nit = nit;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.State = state;
        }
        #endregion

        #region getter and setter
      
        public string Name { get => name; set => name = value; }
        public BigInteger PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public bool State { get => state; set => state = value; }
        public BigInteger Nit { get => nit; set => nit = value; }
        #endregion


    }
}
