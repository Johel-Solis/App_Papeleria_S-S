using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_papeleriaSyS.Customers.Model
{
    internal class Customer
    {
        #region attribute 
        private readonly int nit;
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
            this.nit = nit;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.State = state;
        }
        #endregion

        #region getter and setter
        public int Nit => nit;

        public string Name { get => name; set => name = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public bool State { get => state; set => state = value; }
        #endregion


    }
}
