using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_papeleriaSyS.ConectionDB;
using app_papeleriaSyS.Users.Model;

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
            //sentencia sql  para insertar  los datos del usuario en la base de datos 
            string query = "INSERT INTO users (username,password,typeUser,Id,state) VALUES (@username, @password, @ typeUser, @Id, @state )";
            try
            {
                // abre la conexion
                conn.Open();
                //crea la sentencia 
                cmd = new SqlCommand(query, conn);
                //agrega los parametros 
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@typeUser", user.TypeUser);
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@state", 1);
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

        public bool updateUser(User user)
        {
            string query = "UPDATE users  SET username = @username , password =@password, typeUser = @typeUser, Id=@Id , state =@state  WHERE username=@username";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);

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
            string query = " SELECT * FROM users";
           // unicializa la lista de usuarios
            List<User> users = new List<User>();
            try
            {
                //abre la conexion
                conn.Open();
                //crea la variable que selecciona todos los registros.
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.Text;//tipo del comando
                //ejecuta la instruccion sql
                rdr= cmd.ExecuteReader();  
                //bucle para recorer cada registro
                while(rdr.Read())
                {
                    //  Crea un nuevo usuario y asigna lo datos del registro
                    User user = new User();
                    user.Username = (string)rdr["username"];
                    user.Password = (string)rdr["password"];
                    user.TypeUser = (string)rdr["typeUser"];
                    user.Id= (int)rdr["Id"]; 
                    user.State = ((int)rdr["state"])==1? true : false;
                    //se agrega el usuario a la lista
                    users.Add(user);
                }
                //cierra la conexion;
                conn.Close();
                //retorna la lista de usuarios
                return users;
            }catch
            { return null; }
            
            



        }

        public User vewUser(string username);
        public bool deleteUser(string username);
        
    }
}
