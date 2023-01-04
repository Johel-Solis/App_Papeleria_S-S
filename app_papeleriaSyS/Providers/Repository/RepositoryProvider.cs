﻿using app_papeleriaSyS.Users.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_papeleriaSyS.Providers.Model;

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
            string query = "INSERT INTO providers (nit, name , email , phoneNumber , bank, accountNumber, satate) VALUES (@nit, @name ,@email , @phoneNumber , @bank , @accountNumber, @state)";
            try
            {
                // abre la conexion
                conn.Open();
                //crea la sentencia 
                cmd = new SqlCommand(query, conn);
                //agrega los parametros 
                cmd.Parameters.AddWithValue("@nit", provider.Nit);
                cmd.Parameters.AddWithValue("@name", provider.Name);
                cmd.Parameters.AddWithValue("email",provider.Email);
                cmd.Parameters.AddWithValue("@phoneNumber", provider.PhoneNumber);
                cmd.Parameters.AddWithValue("@bank", provider.Bank );
                cmd.Parameters.AddWithValue("@acountNumber", provider.AccountNumber );
                cmd.Parameters.AddWithValue("@state", (provider.State) ? 1 : 0);
                //ejecuta la sentencia
                cmd.ExecuteNonQuery();
                // cierra la conexion
                conn.Close();

                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool updateProvider(Provider provider)
        {
            string query = "UPDATE provider  SET nit = @nit ,name = @name , email = @email , phoneNumber= @phoneNumber, bakn = @bank, acountNumber = @accountNumber, state = @state  WHERE nit=@nit";

            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);

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
            string query = " SELECT * FROM providers";
            // unicializa la lista de usuarios
            List<Provider> providers = new List<Provider>();
            try
            {
                //abre la conexion
                conn.Open();
                //crea la variable que selecciona todos los registros.
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.Text;//tipo del comando
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
                    provider.State = ((int)rdr["state"])==1? true: false;
                    providers.Add(provider);
                }
                //cierra la conexion;
                conn.Close();
                //retorna la lista 
                return providers;
            }
            catch
            { return null; }

        }
        public List<Provider> listProvidersState(int state)
        {
            //crea la instruccion sql
            string query = " SELECT * FROM providers Where state = @state";
            // unicializa la lista de usuarios
            List<Provider> providers = new List<Provider>();
            try
            {
                //abre la conexion
                conn.Open();
                //crea la variable que selecciona todos los registros.
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@state", state);
                cmd.CommandType = System.Data.CommandType.Text;//tipo del comando
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
                //retorna la lista de usuarios
                return providers;
            }
            catch
            { return null; }





        }
        public Provider vewUser(int nit)
        {
            string query = "SELECT * FROM providers WHERE  nit = @nit";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
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
            string query = "DELETE FROM providers WHERE nit = @nit";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nit", nit);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch { return false; }

        }
    }
}
