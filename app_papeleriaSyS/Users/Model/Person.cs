using System;
using System.Numerics;

namespace app_papeleriaSyS.Users.Model
{
    public class Person
    {
        #region attributes
        private BigInteger id;
        private string name;
        private string surname;
        private string email;
        private BigInteger phone;
        private DateTime birthdate;
        #endregion
        #region constructor
        public Person()
        {
            this.Email = "";
        }
        public Person(BigInteger id, string name, string surname, BigInteger phone)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Phone = phone;

        }
        #endregion
        #region getter and setter
        public BigInteger Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Email { get => email; set => email = value; }
        public BigInteger Phone { get => phone; set => phone = value; }
        public DateTime Birthdate { get => birthdate; set => birthdate = value; }
        #endregion
    }
}
