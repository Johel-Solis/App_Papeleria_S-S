namespace app_papeleriaSyS.Customers.Model
{
    internal class Customer
    {
        #region attribute 
        private  int nit;
        private string name;
        private int phoneNumber;
        private string email;
        private bool state;

        #endregion

        #region constructor
        public Customer()
        {
        }

        public Customer(int nit, string name, int phoneNumber, string email, bool state)
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
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public bool State { get => state; set => state = value; }
        public int Nit { get => nit; set => nit = value; }
        #endregion


    }
}
