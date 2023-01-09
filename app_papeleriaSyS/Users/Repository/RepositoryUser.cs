using app_papeleriaSyS.Users.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace app_papeleriaSyS.Users.Repository
{
    internal class RepositoryUser
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader rdr;

        public RepositoryUser()
        {
            conn = new SqlConnection(ConectionDB.Conection.GetConection());

        }
        // crea el usuario en la base de datos 
        public bool createUser(User user)
        {
            conn = new SqlConnection(ConectionDB.Conection.GetConection());
            //sentencia sql  para insertar  los datos del usuario en la base de datos 
            string query = "insetUser";
             try
            {
            // abre la conexion
            conn.Open();
            //crea la sentencia 
            cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //agrega los parametros 
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@typeUser", user.TypeUser);
            cmd.Parameters.AddWithValue("@Id", user.Id);
            cmd.Parameters.AddWithValue("@state", 1);
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

        public bool updateUser(User user)
        {
            string query = "updateUser";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@typeUser", user.TypeUser);
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@state", (user.State ? 1 : 0));

                cmd.ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch
            {
                return false;
            }






        }
        /*metodo obtiene la lista de los usuarios de la base de datos */
        public List<User> listUsers()
        {
            //crea la instruccion sql
            //
            
            string query = "listUser";
            // unicializa la lista de usuarios
            List<User> users = new List<User>();
            try
            {
                //abre la conexion
                conn.Open();
                //crea la variable que selecciona todos los registros.
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = System.Data.CommandType.Text;//tipo del comando
                //ejecuta la instruccion sql
                rdr = cmd.ExecuteReader();
                //bucle para recorer cada registro
                while (rdr.Read())
                {
                    //  Crea un nuevo usuario y asigna lo datos del registro
                    User user = new User();
                    user.Username = (string)rdr["username"];
                    user.Password = (string)rdr["password"];
                    user.TypeUser = (string)rdr["typeUser"];
                    user.Id = (int)rdr["Id"];
                    user.State = ((int)rdr["state"]) == 1 ? true : false;
                    //se agrega el usuario a la lista
                    users.Add(user);
                }
                //cierra la conexion;
                conn.Close();
                rdr.Close();
                //retorna la lista de usuarios
                return users;
            }
            catch
            { return null; }

        }
        public List<User> listStateUsers(int state)
        {
            //crea la instruccion sql
            //

            string query = "listStateUser";
            // unicializa la lista de usuarios
            List<User> users = new List<User>();
            try
            {
                //abre la conexion
                conn.Open();
                //crea la variable que selecciona todos los registros.
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@state", state);
                //cmd.CommandType = System.Data.CommandType.Text;//tipo del comando
                //ejecuta la instruccion sql
                rdr = cmd.ExecuteReader();
                //bucle para recorer cada registro
                while (rdr.Read())
                {
                    //  Crea un nuevo usuario y asigna lo datos del registro
                    User user = new User();
                    user.Username = (string)rdr["username"];
                    user.Password = (string)rdr["password"];
                    user.TypeUser = (string)rdr["typeUser"];
                    user.Id = (int)rdr["Id"];
                    user.State = ((int)rdr["state"]) == 1 ? true : false;
                    //se agrega el usuario a la lista
                    users.Add(user);
                }
                //cierra la conexion;
                conn.Close();
                rdr.Close();
                //retorna la lista de usuarios
                return users;
            }
            catch
            { return null; }





        }
        public User vewUser(string username)
        {
            //string query = "SELECT * FROM users WHERE  username = @username";
            string query = "viewUser";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    User user = new User();
                    user.Id = (int)rdr["Id"];
                    user.Username = (string)rdr["username"];
                    user.Password = (string)rdr["password"];
                    user.TypeUser = (string)rdr["typeUser"];
                    user.State = ((int)rdr["state"]) == 1 ? true : false;
                    conn.Close();
                    rdr.Close();
                    return user;
                }
                return null;

            }
            catch { return null; }

        }


        public bool deleteUser(string username)
        {
            string query = "deleteUser";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.ExecuteNonQuery();
               
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
