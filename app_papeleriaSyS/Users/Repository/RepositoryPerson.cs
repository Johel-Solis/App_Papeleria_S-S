using app_papeleriaSyS.Users.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace app_papeleriaSyS.Users.Repository
{
    internal class RepositoryPerson
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader rdr;

        public RepositoryPerson()
        {
            conn = new SqlConnection(ConectionDB.Conection.GetConection());

        }
        // crea el usuario en la base de datos 
        public bool createPerson(Person person)
        {
            conn = new SqlConnection(ConectionDB.Conection.GetConection());
            //sentencia sql  para insertar  los datos del usuario en la base de datos 
            string query = "insertPerson";
            // try
            //{
            // abre la conexion
            conn.Open();
            //crea la sentencia 
            cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //agrega los parametros 
            cmd.Parameters.AddWithValue("@Id", person.Id);
            cmd.Parameters.AddWithValue("@name", person.Name);
            cmd.Parameters.AddWithValue("@surname", person.Surname);
            cmd.Parameters.AddWithValue("email", person.Email);
            cmd.Parameters.AddWithValue("@phoneNumber", person.Phone);
            cmd.Parameters.AddWithValue("@birthdate", person.Birthdate);
            //ejecuta la sentencia
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            if (result > 0)
            {
                return true;
            }
            return false;

            //}
            // catch
            //{
            //  return false;
            //    }
        }

        public bool updatePerson(Person person)
        {
            string query = "updatePerson";

            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", person.Id);
                cmd.Parameters.AddWithValue("@name", person.Name);
                cmd.Parameters.AddWithValue("@surname", person.Surname);
                cmd.Parameters.AddWithValue("@email", person.Email);
                cmd.Parameters.AddWithValue("@phoneNumber", person.Phone);
                cmd.Parameters.AddWithValue("@birthdate", person.Birthdate);

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
        /*metodo obtiene la lista de los usuarios de la base de datos */
        public List<Person> listPersons()
        {
            //crea la instruccion sql
            string query = " SELECT * FROM persons";
            // unicializa la lista de usuarios
            List<Person> persons = new List<Person>();
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
                    Person person = new Person();
                    person.Id = (int)rdr["Id"];
                    person.Name = (string)rdr["Name"];
                    person.Surname = (string)rdr["surname"];
                    person.Email = (string)rdr["email"];
                    person.Phone = (int)rdr["phoneNumber"];
                    person.Birthdate = (string)rdr["birthdate"];
                    persons.Add(person);
                }
                //cierra la conexion;
                conn.Close();
                //retorna la lista de usuarios
                return persons;
            }
            catch
            { return null; }





        }

        public Person vewUser(int id)
        {
            string query = "SELECT * FROM persons WHERE  Id = @Id";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Person person = new Person();
                    person.Id = (int)rdr["Id"];
                    person.Name = (string)rdr["Name"];
                    person.Surname = (string)rdr["surname"];
                    person.Email = (string)rdr["email"];
                    person.Phone = (int)rdr["phoneNumber"];
                    person.Birthdate = (string)rdr["birthdate"];
                    return person;
                }
                return null;

            }
            catch { return null; }

        }


        public bool deletePerson(int id)
        {
            string query = "DELETE FROM persons WHERE Id = @Id";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch { return false; }

        }



    }
}
