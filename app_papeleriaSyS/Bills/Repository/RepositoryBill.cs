using app_papeleriaSyS.Bills.Model;
using app_papeleriaSyS.Products.Model;
using app_papeleriaSyS.Products.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_papeleriaSyS.Bills.Repository
{
    internal class RepositoryBill
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader rdr;

        public RepositoryBill()
        {
            conn = new SqlConnection(ConectionDB.Conection.GetConection());

        }
        // crea el usuario en la base de datos 
        public bool createBill(Bill bill)
        {
            //sentencia sql  para insertar  los datos del usuario en la base de datos 
            string query = "insertBill";
            try
            {
                // abre la conexion
                conn.Open();
                //crea la sentencia 
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //agrega los parametros 
                cmd.Parameters.AddWithValue("@customer_id", bill.Customer.Nit);
                cmd.Parameters.AddWithValue("@total", bill.Total);
                cmd.Parameters.AddWithValue("@date_bill", bill.Billdate);
                cmd.Parameters.AddWithValue("@state", (bill.State) ? 1 : 0);
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

        public bool updateCategory(Bill bill)
        {
            string query = "updatePerson";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer_id", bill.Customer.Nit);
                cmd.Parameters.AddWithValue("@total", bill.Total);
                cmd.Parameters.AddWithValue("@date_bill", bill.Billdate);
                cmd.Parameters.AddWithValue("@state", (bill.State) ? 1 : 0);

                cmd.ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch
            {
                return false;
            }


        }

        public List<Bill> listBills()
        {
            //crea la instruccion sql
            string query = " listBill";
            // unicializa la lista de usuarios
            List<Bill> bills = new List<Bill>();
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
                    Bill bill = new Bill();
                    bill.Id = (int)rdr["Id"];
                    //bill.= (int)rdr["customer_id"];
                    bill.Total = (float)rdr["total"];
                    bill.Billdate = (DateTime)rdr["date_bill"];
                    bill.State = ((int)rdr["state"]) == 1 ? true : false;
                    bills.Add(bill);
                }
                //cierra la conexion;
                conn.Close();
                rdr.Close();
                //retorna la lista 
                return bills;
            }
            catch
            { return null; }

        }
        public List<Bill> listBillState(int state)
        {
            //crea la instruccion sql
            string query = "ListSteteBill";
            // unicializa la lista de usuarios
            List<Bill> bills = new List<Bill>();
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
                    Bill bill = new Bill();
                    bill.Id = (int)rdr["Id"];
                    //bill.= (int)rdr["customer_id"];
                    bill.Total = (float)rdr["total"];
                    bill.Billdate = (DateTime)rdr["date_bill"];
                    bill.State = ((int)rdr["state"]) == 1 ? true : false;
                    bills.Add(bill);
                }
                //cierra la conexion;
                conn.Close();
                rdr.Close();
                //retorna la lista de usuarios
                return bills;
            }
            catch
            { return null; }


        }
        public List<Bill> listBillBill(DateTime dateBill)
        {
            //crea la instruccion sql
            string query = "ListBillDate";
            // unicializa la lista de usuarios
            List<Bill> bills = new List<Bill>();
            try
            {
                //abre la conexion
                conn.Open();
                //crea la variable que selecciona todos los registros.
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@date_bill", dateBill);
                cmd.CommandType = CommandType.StoredProcedure;//tipo del comando
                //ejecuta la instruccion sql
                rdr = cmd.ExecuteReader();
                //bucle para recorer cada registro
                while (rdr.Read())
                {
                    //  Crea un nuevo usuario y asigna lo datos del registro
                    Bill bill = new Bill();
                    bill.Id = (int)rdr["Id"];
                    //bill.= (int)rdr["customer_id"];
                    bill.Total = (float)rdr["total"];
                    bill.Billdate = (DateTime)rdr["date_bill"];
                    bill.State = ((int)rdr["state"]) == 1 ? true : false;
                    bills.Add(bill);
                }
                //cierra la conexion;
                conn.Close();
                rdr.Close();
                //retorna la lista de usuarios
                return bills;
            }
            catch
            { return null; }


        }
        public Bill viewBill(int id)
        {
            string query = "viewBill";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Bill bill = new Bill();
                    bill.Id = (int)rdr["Id"];
                    //bill.= (int)rdr["customer_id"];
                    bill.Total = (float)rdr["total"];
                    bill.Billdate = (DateTime)rdr["date_bill"];
                    bill.State = ((int)rdr["state"]) == 1 ? true : false;
                    return bill;
                }
                return null;

            }
            catch { return null; }

        }

        public bool deleteBill(int id)
        {
            string query = "deleteBill";
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
