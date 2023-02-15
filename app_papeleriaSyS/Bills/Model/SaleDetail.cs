using app_papeleriaSyS.Products.Model;
using System.Numerics;

namespace app_papeleriaSyS.Bills.Model
{
     class SaleDetail
    {
        #region attrubute
        private BigInteger id;
        private Product product;
        private int quantity;
        private float unit_price;
        private float total_price;
        private BigInteger id_bill;
        private bool state;
        #endregion
        #region constructor
        public SaleDetail()
        {
        }

        public SaleDetail(BigInteger id, Product product, int quantity, float unit_price, float total_price, BigInteger id_bill, bool state)
        {
            this.id = id;
            this.product = product;
            this.quantity = quantity;
            this.unit_price = unit_price;
            this.total_price = total_price;
            this.Id_bill = id_bill;
            this.State = state;
        }

        #endregion
        #region getter and setter
        public BigInteger Id { get => id; set => id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public float Unit_price { get => unit_price; set => unit_price = value; }
        public float Total_price { get => total_price; set => total_price = value; }
        public BigInteger Id_bill { get => id_bill; set => id_bill = value; }
        public bool State { get => state; set => state = value; }
        internal Product Product { get => product; set => product = value; }
        #endregion
    }
}
