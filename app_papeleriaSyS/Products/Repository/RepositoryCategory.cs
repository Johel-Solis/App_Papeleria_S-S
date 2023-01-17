using app_papeleriaSyS.Products.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_papeleriaSyS.Products.Repository
{
    internal class RepositoryCategory
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader rdr;

        public RepositoryCategory()
        {
            conn = new SqlConnection(ConectionDB.Conection.GetConection());

        }
        // crea el usuario en la base de datos 
        public bool createCategory(Category category)
        {
            //sentencia sql  para insertar  los datos del usuario en la base de datos 
            string query = "insertCategory";
            try
            {
                // abre la conexion
                conn.Open();
                //crea la sentencia 
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //agrega los parametros 
                cmd.Parameters.AddWithValue("@id", category.Id);
                cmd.Parameters.AddWithValue("@name", category.Name);
                cmd.Parameters.AddWithValue("@description", category.Description);
                cmd.Parameters.AddWithValue("@state", (category.State) ? 1 : 0);
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

        public bool updateCategory(Category category)
        {
            string query = "updatePerson";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", category.Id);
                cmd.Parameters.AddWithValue("@name", category.Name);
                cmd.Parameters.AddWithValue("description", category.Description);
                cmd.Parameters.AddWithValue("@state", (category.State) ? 1 : 0);

                cmd.ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch
            {
                return false;
            }


        }

        public List<Category> listCategory()
        {
            //crea la instruccion sql
            string query = " listCategory";
            // unicializa la lista de usuarios
            List<Category> categories = new List<Category>();
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
                    Category category = new Category();
                    category.Id = (int)rdr["Id"];
                    category.Name = (string)rdr["name"];
                    category.Description = (string)rdr["description"];
                    category.State = ((int)rdr["state"]) == 1 ? true : false;
                    categories.Add(category);
                }
                //cierra la conexion;
                conn.Close();
                rdr.Close();
                //retorna la lista 
                return categories;
            }
            catch
            { return null; }

        }
        public List<Category> listCategorysState(int state)
        {
            //crea la instruccion sql
            string query = "ListSteteCategory";
            // unicializa la lista de usuarios
            List<Category> categories = new List<Category>();
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
                    Category category = new Category();
                    category.Id = (int)rdr["Id"];
                    category.Name = (string)rdr["name"];
                    category.Description = (string)rdr["description"];
                    category.State = ((int)rdr["state"]) == 1 ? true : false;
                    categories.Add(category);
                }
                //cierra la conexion;
                conn.Close();
                rdr.Close();
                //retorna la lista de usuarios
                return categories;
            }
            catch
            { return null; }


        }
        public Category viewCategory(int id)
        {
            string query = "viewCategory";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Category category = new Category();
                    category.Id = (int)rdr["Id"];
                    category.Name = (string)rdr["name"];
                    category.Description = (string)rdr["description"];
                    category.State = ((int)rdr["state"]) == 1 ? true : false;
                    return category;
                }
                return null;

            }
            catch { return null; }

        }

        public bool deleteCategory(int id)
        {
            string query = "deleteCategory";
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

    }
}
