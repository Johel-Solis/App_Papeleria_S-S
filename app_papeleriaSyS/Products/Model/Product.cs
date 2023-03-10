using app_papeleriaSyS.Providers.Model;
using System.Numerics;

namespace app_papeleriaSyS.Products.Model
{
     class Product
    {
        #region attribute
        private BigInteger reference;
        private string name;
        private string description;
        private Category category;
        private int stock;
        private string brand;
        private float purchase_price;
        private float sale_price;
        private bool state;
        private Provider provider;


        #endregion
        #region constructor
        public Product()
        {
        }

        public Product(BigInteger idProduct, string name, string description, Category category, int stock, string brand, float purchase_price, float sale_price, bool state, Provider provider)
        {
            this.Provider = provider;
            this.reference = idProduct;
            this.Name = name;
            this.Description = description;
            this.Category = category;
            this.Stock = stock;
            this.Brand = brand;
            this.Purchase_price = purchase_price;
            this.Sale_price = sale_price;

            this.State = state;
        }

        #endregion
        #region getter and setter
        public BigInteger IdProduct { get => reference; set => reference = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int Stock { get => stock; set => stock = value; }
        public string Brand { get => brand; set => brand = value; }
        public float Purchase_price { get => purchase_price; set => purchase_price = value; }
        public float Sale_price { get => sale_price; set => sale_price = value; }
        public bool State { get => state; set => state = value; }
        internal Category Category { get => category; set => category = value; }
        internal Provider Provider { get => provider; set => provider = value; }
        #endregion
    }
}
