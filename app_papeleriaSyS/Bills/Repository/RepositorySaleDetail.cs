using app_papeleriaSyS.Bills.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_papeleriaSyS.Products.Model;
using app_papeleriaSyS.Products.Repository;

namespace app_papeleriaSyS.Bills.Repository
{
     class RepositorySaleDetail
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader rdr;

        public RepositorySaleDetail()
        {
            conn = new SqlConnection(ConectionDB.Conection.GetConection());

        }
        // crea el usuario en la base de datos 
        public bool createSaleDetail(SaleDetail saleDetail)
        {
            //sentencia sql  para insertar  los datos del usuario en la base de datos 
            string query = "insertSaleDetail";
            try
            {
                // abre la conexion
                conn.Open();
                //crea la sentencia 
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //agrega los parametros 
                cmd.Parameters.AddWithValue("@product_id", saleDetail.Product.IdProduct);
                cmd.Parameters.AddWithValue("@quantity", saleDetail.Quantity);
                cmd.Parameters.AddWithValue("@unit_price", saleDetail.Unit_price);
                cmd.Parameters.AddWithValue("@total_price", saleDetail.Total_price);
                cmd.Parameters.AddWithValue("@bill_id", saleDetail.Id_bill);
                cmd.Parameters.AddWithValue("@state", (saleDetail.State) ? 1 : 0);
                //ejecuta la sentencia
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result > 0)
                {
                    return true;
                }
                return false;

            }
            catch
            {
                return false;
            }
        }

        public bool updateCategory(SaleDetail saleDetail)
        {
            string query = "updatePerson";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", saleDetail.Id);
                cmd.Parameters.AddWithValue("@product_id", saleDetail.Product.IdProduct);
                cmd.Parameters.AddWithValue("@quantity", saleDetail.Quantity);
                cmd.Parameters.AddWithValue("@unit_price", saleDetail.Unit_price);
                cmd.Parameters.AddWithValue("@total_price", saleDetail.Total_price);
                cmd.Parameters.AddWithValue("@bill_id", saleDetail.Id_bill);
                cmd.Parameters.AddWithValue("@state", (saleDetail.State) ? 1 : 0);

                cmd.ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch
            {
                return false;
            }


        }

        public List<SaleDetail> listSaleDetails()
        {
            //crea la instruccion sql
            string query = " listSaleDetail";
            // unicializa la lista de usuarios
            List<SaleDetail> saleDetails = new List<SaleDetail>();
            try
            {
                //abre la conexion
                conn.Open();
                //crea la variable que selecciona todos los registros.
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;//tipo del comando
                //ejecuta la instruccion sql
                rdr = cmd.ExecuteReader();
                //bucle para recorer cada registro
                while (rdr.Read())
                {
                    //  Crea un nuevo usuario y asigna lo datos del registro
                    SaleDetail saleDetail = new SaleDetail();
                    saleDetail.Id = (int)rdr["Id"];
                    saleDetail.Quantity = (int)rdr["quantity"];
                    saleDetail.Unit_price = (float)rdr["unit_price"];
                    saleDetail.Total_price = (float)rdr["total_price"];
                    saleDetail.Id_bill = (int)rdr["bill_id"];
                    saleDetail.Product = getProduct((int)rdr["product_id"]);
                    saleDetail.State = ((int)rdr["state"]) == 1 ? true : false;
                    saleDetails.Add(saleDetail);
                }
                //cierra la conexion;
                conn.Close();
                rdr.Close();
                //retorna la lista 
                return saleDetails;
            }
            catch
            { return null; }

        }
        public List<SaleDetail> listSaleDetailState(int state)
        {
            //crea la instruccion sql
            string query = "ListSteteSaleDetail";
            // unicializa la lista de usuarios
            List<SaleDetail> saleDetails = new List<SaleDetail>();
            try
            {
                //abre la conexion
                conn.Open();
                //crea la variable que selecciona todos los registros.
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@state", state);
                cmd.CommandType = CommandType.StoredProcedure;//tipo del comando
                //ejecuta la instruccion sql
                rdr = cmd.ExecuteReader();
                //bucle para recorer cada registro
                while (rdr.Read())
                {
                    //  Crea un nuevo usuario y asigna lo datos del registro
                    SaleDetail saleDetail = new SaleDetail();
                    saleDetail.Id = (int)rdr["Id"];
                    saleDetail.Quantity = (int)rdr["quantity"];
                    saleDetail.Unit_price = (float)rdr["unit_price"];
                    saleDetail.Total_price = (float)rdr["total_price"];
                    saleDetail.Id_bill = (int)rdr["bill_id"];
                    saleDetail.Product = getProduct((int)rdr["product_id"]);
                    saleDetail.State = ((int)rdr["state"]) == 1 ? true : false;
                    saleDetails.Add(saleDetail);
                }
                //cierra la conexion;
                conn.Close();
                rdr.Close();
                //retorna la lista de usuarios
                return saleDetails;
            }
            catch
            { return null; }


        }
        public List<SaleDetail> listSaleDetailBill(int bill_id)
        {
            //crea la instruccion sql
            string query = "ListSaleDetailBill";
            // unicializa la lista de usuarios
            List<SaleDetail> saleDetails = new List<SaleDetail>();
            try
            {
                //abre la conexion
                conn.Open();
                //crea la variable que selecciona todos los registros.
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bill_id", bill_id);
                cmd.CommandType = CommandType.StoredProcedure;//tipo del comando
                //ejecuta la instruccion sql
                rdr = cmd.ExecuteReader();
                //bucle para recorer cada registro
                while (rdr.Read())
                {
                    //  Crea un nuevo usuario y asigna lo datos del registro
                    SaleDetail saleDetail = new SaleDetail();
                    saleDetail.Id = (int)rdr["Id"];
                    saleDetail.Quantity = (int)rdr["quantity"];
                    saleDetail.Unit_price = (float)rdr["unit_price"];
                    saleDetail.Total_price = (float)rdr["total_price"];
                    saleDetail.Id_bill = (int)rdr["bill_id"];
                    saleDetail.Product = getProduct((int)rdr["product_id"]);
                    saleDetail.State = ((int)rdr["state"]) == 1 ? true : false;
                    saleDetails.Add(saleDetail);
                }
                //cierra la conexion;
                conn.Close();
                rdr.Close();
                //retorna la lista de usuarios
                return saleDetails;
            }
            catch
            { return null; }


        }
        public SaleDetail viewSaleDetail(int id)
        {
            string query = "viewSaleDetail";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    SaleDetail saleDetail = new SaleDetail();
                    saleDetail.Id = (int)rdr["Id"];
                    saleDetail.Quantity = (int)rdr["quantity"];
                    saleDetail.Unit_price = (float)rdr["unit_price"];
                    saleDetail.Total_price = (float)rdr["total_price"];
                    saleDetail.Id_bill = (int)rdr["bill_id"];
                    saleDetail.Product = getProduct((int)rdr["product_id"]);
                    saleDetail.State = ((int)rdr["state"]) == 1 ? true : false;
                    return saleDetail;
                }
                return null;

            }
            catch { return null; }

        }

        public bool deleteSaleDetail(int id)
        {
            string query = "deleteSaleDetail";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch { return false; }

        }

        private Product getProduct(int reference)
        {
            RepositoryProduct repositoryProduct = new RepositoryProduct();
            return repositoryProduct.viewProduct(reference);
        }
    }
}
