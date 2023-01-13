using app_papeleriaSyS.Providers.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace app_papeleriaSyS.Providers.Repository
{
    internal class RepositoryProvider
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader rdr;

        public RepositoryProvider()
        {
            conn = new SqlConnection(ConectionDB.Conection.GetConection());

        }
        // crea el usuario en la base de datos 
        public bool createProvider(Provider provider)
        {
            //sentencia sql  para insertar  los datos del usuario en la base de datos 
            string query = "insertProvider";
            try
            {
                // abre la conexion
                conn.Open();
                //crea la sentencia 
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //agrega los parametros 
                cmd.Parameters.AddWithValue("@nit", provider.Nit);
                cmd.Parameters.AddWithValue("@name", provider.Name);
                cmd.Parameters.AddWithValue("email", provider.Email);
                cmd.Parameters.AddWithValue("@phoneNumber", provider.PhoneNumber);
                cmd.Parameters.AddWithValue("@bank", provider.Bank);
                cmd.Parameters.AddWithValue("@acountNumber", provider.AccountNumber);
                cmd.Parameters.AddWithValue("@state", (provider.State) ? 1 : 0);
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

        public bool updateProvider(Provider provider)
        {
            string query = "updatePerson";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query,conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nit", provider.Nit);
                cmd.Parameters.AddWithValue("@name", provider.Name);
                cmd.Parameters.AddWithValue("email", provider.Email);
                cmd.Parameters.AddWithValue("@phoneNumber", provider.PhoneNumber);
                cmd.Parameters.AddWithValue("@bank", provider.Bank);
                cmd.Parameters.AddWithValue("@acountNumber", provider.AccountNumber);
                cmd.Parameters.AddWithValue("@state", (provider.State) ? 1 : 0);

                cmd.ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch
            {
                return false;
            }






        }

        public List<Provider> listProviders()
        {
            //crea la instruccion sql
            string query = " listProvider";
            // unicializa la lista de usuarios
            List<Provider> providers = new List<Provider>();
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
                    Provider provider = new Provider();
                    provider.Nit = (int)rdr["nit"];
                    provider.Name = (string)rdr["Name"];
                    provider.Email = (string)rdr["email"];
                    provider.PhoneNumber = (int)rdr["phoneNumber"];
                    provider.Bank = (string)rdr["birthdate"];
                    provider.AccountNumber = (int)rdr["accountNumber"];
                    provider.State = ((int)rdr["state"]) == 1 ? true : false;
                    providers.Add(provider);
                }
                //cierra la conexion;
                conn.Close();
               rdr.Close();
                //retorna la lista 
                return providers;
            }
            catch
            { return null; }

        }
        public List<Provider> listProvidersState(int state)
        {
            //crea la instruccion sql
            string query = "ListSteteProvider";
            // unicializa la lista de usuarios
            List<Provider> providers = new List<Provider>();
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
                    Provider provider = new Provider();
                    provider.Nit = (int)rdr["nit"];
                    provider.Name = (string)rdr["Name"];
                    provider.Email = (string)rdr["email"];
                    provider.PhoneNumber = (int)rdr["phoneNumber"];
                    provider.Bank = (string)rdr["birthdate"];
                    provider.AccountNumber = (int)rdr["accountNumber"];
                    provider.State = ((int)rdr["state"]) == 1 ? true : false;
                    providers.Add(provider);
                }
                //cierra la conexion;
                conn.Close();
                rdr.Close();
                //retorna la lista de usuarios
                return providers;
            }
            catch
            { return null; }


            


        }
        public Provider viewProvider(int nit)
        {
            string query = "viewProvider";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nit", nit);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Provider provider = new Provider();
                    provider.Nit = (int)rdr["nit"];
                    provider.Name = (string)rdr["Name"];
                    provider.Email = (string)rdr["email"];
                    provider.PhoneNumber = (int)rdr["phoneNumber"];
                    provider.Bank = (string)rdr["birthdate"];
                    provider.AccountNumber = (int)rdr["accountNumber"];
                    provider.State = ((int)rdr["state"]) == 1 ? true : false;
                    return provider;
                }
                return null;

            }
            catch { return null; }

        }


        public bool deleteProvider(int nit)
        {
            string query = "deleteProvider";
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
