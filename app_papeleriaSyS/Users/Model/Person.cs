namespace app_papeleriaSyS.Users.Model
{
    internal class Person
    {
        #region attributes
        private int id;
        private string name;
        private string surname;
        private string email;
        private int phone;
        private string birthdate;
        #endregion
        #region constructor
        public Person()
        {
            this.Email = "";
            this.Birthdate = "";
        }
        public Person(int id, string name, string surname, int phone)
        {
            Id = id;
            Name = name;
            Surname = surname;

            Phone = phone;

        }
        #endregion
        #region getter and setter
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Email { get => email; set => email = value; }
        public int Phone { get => phone; set => phone = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
        #endregion
    }
}
