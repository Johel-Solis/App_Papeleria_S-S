using app_papeleriaSyS.Products.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_papeleriaSyS.Providers.Model;
using app_papeleriaSyS.Providers.Repository;

namespace app_papeleriaSyS.Products.Repository
{
    internal class RepositoryProduct
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        

        public RepositoryProduct()
        {
            conn = new SqlConnection(ConectionDB.Conection.GetConection());

        }
        // crea el usuario en la base de datos 
        public bool createProduct(Product product)
        {
            //sentencia sql  para insertar  los datos del usuario en la base de datos 
            string query = "insertProduct";
            try
            {
                // abre la conexion
                conn.Open();
                //crea la sentencia 
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //agrega los parametros 
                cmd.Parameters.AddWithValue("@refecrence", product.IdProduct);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@stock", product.Stock);
                cmd.Parameters.AddWithValue("@brand", product.Brand);
                cmd.Parameters.AddWithValue("@category_id", product.Category.Id);
                cmd.Parameters.AddWithValue("@sale_price", product.Sale_price);
                cmd.Parameters.AddWithValue("@purchase_price", product.Purchase_price);
                cmd.Parameters.AddWithValue("@provedor_id", product.Provider.Nit);
                cmd.Parameters.AddWithValue("@state", (product.State) ? 1 : 0);
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

        public bool updateProvider(Product product)
        {
            string query = "updatePerson";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@refecrence", product.IdProduct);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@stock", product.Stock);
                cmd.Parameters.AddWithValue("@brand", product.Brand);
                cmd.Parameters.AddWithValue("@category_id", product.Category.Id);
                cmd.Parameters.AddWithValue("@sale_price", product.Sale_price);
                cmd.Parameters.AddWithValue("@purchase_price", product.Purchase_price);
                cmd.Parameters.AddWithValue("@provedor_id", product.Provider.Nit);
                cmd.Parameters.AddWithValue("@state", (product.State) ? 1 : 0);

                cmd.ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch
            {
                return false;
            }


        }

        public List<Product> listProducts()
        {
            //crea la instruccion sql
            string query = " listProduct";
            // unicializa la lista de usuarios
            List<Product> products = new List<Product>();
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
                    Product product = new Product();
                    product.IdProduct = (int)rdr["reference"];
                    product.Name = (string)rdr["name"];
                    product.Description = (string)rdr["description"];
                    product.Purchase_price = (float)rdr["purchase´_price"];
                    product.Sale_price = (float)rdr["sale_price"];
                    product.Stock = (int)rdr["stock"];
                    product.Brand = (string)rdr["brand"];
                    product.Category = GetCategory((int)rdr["category_id"]);
                    product.Provider = getPorvider((int)rdr["provider_id"]);
                    product.State = ((int)rdr["state"]) == 1 ? true : false;
                    products.Add(product);
                }
                //cierra la conexion;
                conn.Close();
                rdr.Close();
                //retorna la lista 
                return products;
            }
            catch
            { return null; }

        }
        public List<Product> listProductsState(int state)
        {
            //crea la instruccion sql
            string query = "ListSteteProduct";
            // unicializa la lista de usuarios
            List<Product> products = new List<Product>();
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
                    
                    Product product = new Product();
                    product.IdProduct = (int)rdr["reference"];
                    product.Name = (string)rdr["name"];
                    product.Description = (string)rdr["description"];
                    product.Purchase_price = (float)rdr["purchase´_price"];
                    product.Sale_price = (float)rdr["sale_price"];
                    product.Stock = (int)rdr["stock"];
                    product.Brand = (string)rdr["brand"];
                    product.Category = GetCategory((int)rdr["category_id"]);
                    product.Provider = getPorvider((int)rdr["provider_id"]);
                    product.State = ((int)rdr["state"]) == 1 ? true : false;
                    products.Add(product);
                }
                //cierra la conexion;
                conn.Close();
                rdr.Close();
                //retorna la lista de usuarios
                return products;
            }
            catch
            { return null; }


        }
        public Product viewProduct(int reference)
        {
            string query = "viewProduct";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", reference);
                rdr = cmd.ExecuteReader();
                conn.Close();
                if (rdr.Read())
                {
                    Product product = new Product();
                    product.IdProduct = (int)rdr["reference"];
                    product.Name = (string)rdr["name"];
                    product.Description = (string)rdr["description"];
                    product.Purchase_price = (float)rdr["purchase´_price"];
                    product.Sale_price = (float)rdr["sale_price"];
                    product.Stock = (int)rdr["stock"];
                    product.Brand = (string)rdr["brand"];

                    product.Category = GetCategory((int)rdr["category_id"]);
                    product.Provider = getPorvider((int)rdr["provider_id"]);
                    product.State = ((int)rdr["state"]) == 1 ? true : false;
                    rdr.Close();
                    return product;
                }
                rdr.Close();
                return null;

            }
            catch { return null; }

        }

        public bool deleteProduct(int reference)
        {
            string query = "deleteProduct";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@reference", reference);
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
        private Category GetCategory(int id)
        {
            RepositoryCategory repositoryCategory= new RepositoryCategory();
            return repositoryCategory.viewCategory(id);
            

        }

        private Provider getPorvider(int nit)
        {
            RepositoryProvider repositoryProvider= new RepositoryProvider();
            return repositoryProvider.viewProvider(nit);
        }
    }
}
