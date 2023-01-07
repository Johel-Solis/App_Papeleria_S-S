using app_papeleriaSyS.Products.Model;

namespace app_papeleriaSyS.Bills.Model
{
    internal class SaleDetail
    {
        #region attrubute
        private int id;
        private readonly Product product;
        private int quantity;
        private float unit_price;
        private float total_price;
        #endregion
        #region constructor
        public SaleDetail()
        {
        }
        public SaleDetail(int id, Product product, int quantity, float unit_price, float total_price)
        {
            this.Id = id;
            this.product = product;
            this.Quantity = quantity;
            this.Unit_price = unit_price;
            this.Total_price = total_price;
        }
        #endregion
        #region getter and setter
        public int Id { get => id; set => id = value; }
        public Product Product => product;
        public int Quantity { get => quantity; set => quantity = value; }
        public float Unit_price { get => unit_price; set => unit_price = value; }
        public float Total_price { get => total_price; set => total_price = value; }
        #endregion
    }
}
