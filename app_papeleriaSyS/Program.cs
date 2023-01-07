using app_papeleriaSyS.Users.Model;
using app_papeleriaSyS.Users.Repository;
using System;
using System.Collections.Generic;

namespace app_papeleriaSyS
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            RepositoryUser repositoryUser = new RepositoryUser();
            /*  string pass = Encryption.encryptKey("admin123");
              Console.WriteLine("pass cifrada : " + pass);
              Console.WriteLine("pass decifrada : " + Encryption.decryptKey(pass));


              Person person = new Person();
              person.Name = "andres ";
              person.Surname = "perez";
              person.Id = 3;

              RepositoryPerson repositoryPerson = new RepositoryPerson();
              if(repositoryPerson.createPerson(person))
              { Console.WriteLine("se creo la persona correctamente"); }
              User user= new User();
              user.Username ="andresp";
              user.Password= pass;
              user.TypeUser ="Admin";
              user.Id= 3;
              if(repositoryUser.createUser(user)) { Console.WriteLine("se creo el usuario correctamente");
                  Console.WriteLine(repositoryUser.vewUser(user.Username).TypeUser);
              }*/
            List<User> users = new List<User>();
            users = repositoryUser.listUsers();

            foreach (User s in users)

            { Console.WriteLine(s.Username); }
            //Console.WriteLine(repositoryUser.vewUser("cperez27").TypeUser);




        }
    }
}
