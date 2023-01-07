namespace app_papeleriaSyS.Products.Model
{
    internal class Category
    {
        #region attribute 
        private int id;
        private string name;
        private string description;
        private bool state;

        #endregion
        #region constructor
        public Category()
        {
        }


        public Category(int id, string name, string description, bool state)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.State = state;
        }

        #endregion
        #region getter and setter
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public bool State { get => state; set => state = value; }
        #endregion


    }
}
