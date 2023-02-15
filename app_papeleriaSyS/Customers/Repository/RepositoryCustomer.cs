using app_papeleriaSyS.Customers.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace app_papeleriaSyS.Customers.Repository
{
     class RepositoryCustomer
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        public RepositoryCustomer()
        {
            conn = new SqlConnection(ConectionDB.Conection.GetConection());

        }
        // crea el usuario en la base de datos 
        public bool createCustomer(Customer customer)
        {
            //sentencia sql  para insertar  los datos del usuario en la base de datos 
            string query = "insertCustomer";
            try
            {
                // abre la conexion
                conn.Open();
                //crea la sentencia 
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //agrega los parametros 
                cmd.Parameters.AddWithValue("@nit", customer.Nit);
                cmd.Parameters.AddWithValue("@name", customer.Name);
                cmd.Parameters.AddWithValue("email", customer.Email);
                cmd.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@state", (customer.State) ? 1 : 0);
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

        public bool updateCustomer(Customer customer)
        {
            string query = "updatePerson";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nit", customer.Nit);
                cmd.Parameters.AddWithValue("@name", customer.Name);
                cmd.Parameters.AddWithValue("email", customer.Email);
                cmd.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@state", (customer.State) ? 1 : 0);

                cmd.ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch
            {
                return false;
            }






        }

        public List<Customer> listCustomers()
        {
            //crea la instruccion sql
            string query = " listCustomer";
            // unicializa la lista de usuarios
            List<Customer> customers = new List<Customer>();
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
                    Customer customer = new Customer();
                    customer.Nit = (BigInteger)rdr["nit"];
                    customer.Name = (string)rdr["Name"];
                    customer.Email = (string)rdr["email"];
                    customer.PhoneNumber = (int)rdr["phoneNumber"];

                    customer.State = ((int)rdr["state"]) == 1 ? true : false;
                    customers.Add(customer);
                }
                //cierra la conexion;
                conn.Close();
                rdr.Close();
                //retorna la lista 
                return customers;
            }
            catch
            { return null; }

        }
        public List<Customer> listCustomersState(int state)
        {
            //crea la instruccion sql
            string query = "ListSteteCustomer";
            // unicializa la lista de usuarios
            List<Customer> customers = new List<Customer>();
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
                    Customer customer = new Customer();
                    customer.Nit = (BigInteger)rdr["nit"];
                    customer.Name = (string)rdr["Name"];
                    customer.Email = (string)rdr["email"];
                    customer.PhoneNumber = (int)rdr["phoneNumber"];
                    customer.State = ((int)rdr["state"]) == 1 ? true : false;
                    customers.Add(customer);
                }
                //cierra la conexion;
                conn.Close();
                rdr.Close();
                //retorna la lista de usuarios
                return customers;
            }
            catch
            { return null; }





        }
        public Customer viewCustomer(BigInteger nit)
        {
            string query = "viewCustomer";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nit", nit);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Customer customer = new Customer();
                    customer.Nit = (BigInteger)rdr["nit"];
                    customer.Name = (string)rdr["Name"];
                    customer.Email = (string)rdr["email"];
                    customer.PhoneNumber = (int)rdr["phoneNumber"];
                    customer.State = ((int)rdr["state"]) == 1 ? true : false;
                    return customer;
                }
                return null;

            }
            catch { return null; }

        }


        public bool deleteCustomer(BigInteger nit)
        {
            string query = "deleteCustomer";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nit", nit);
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
    }
}
