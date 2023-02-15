using app_papeleriaSyS.Customers.Model;
using app_papeleriaSyS.Users.Model;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace app_papeleriaSyS.Bills.Model
{
    class Bill
    {
        #region attribute
        private BigInteger id;
        private User seller;
        private Customer customer;
        private float total;
        private bool state;
        private DateTime billdate;
        private List<SaleDetail> saledetail;
        #endregion
        #region constructor
        public Bill()
        {
        }

        public Bill(BigInteger id, User seller, Customer customer, float total, bool state, DateTime billdate, List<SaleDetail> saledetail)
        {
            this.Id = id;
            this.Seller = seller;
            this.Customer = customer;
            this.Total = total;
            this.State = state;
            this.Billdate = billdate;
            this.Saledetail = saledetail;
        }
        #endregion
        #region getter and setter
        public BigInteger Id { get => id; set => id = value; }
        public float Total { get => total; set => total = value; }
        public bool State { get => state; set => state = value; }
        public DateTime Billdate { get => billdate; set => billdate = value; }
        internal User Seller { get => seller; set => seller = value; }
        internal Customer Customer { get => customer; set => customer = value; }
        internal List<SaleDetail> Saledetail { get => saledetail; set => saledetail = value; }
        #endregion
    }
}
