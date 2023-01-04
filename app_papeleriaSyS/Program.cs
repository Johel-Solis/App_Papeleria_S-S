using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using app_papeleriaSyS.Users.Model;
using app_papeleriaSyS.Users.Repository;
using app_papeleriaSyS.Utillity;

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
            string pass = Encryption.encryptKey("admin123");
            Console.WriteLine("pass cifrada" + pass);
            Console.WriteLine("pass decifrada : " + Encryption.decryptKey(pass));
          
            RepositoryUser repositoryUser = new RepositoryUser();
            Person person = new Person();
            person.Name = "johel ";
            person.Surname = "solis";
            person.Id = 1;

            RepositoryPerson repositoryPerson = new RepositoryPerson();
            if(repositoryPerson.createPerson(person))
            { Console.WriteLine("se creo la persona correctamente"); }
            User user= new User();
            user.Username ="Johel27";
            user.Password= pass;
            user.TypeUser ="admin";
            user.Id= 1;
            if(repositoryUser.createUser(user)) { Console.WriteLine("se creo el usuario correctamente");
                Console.WriteLine(repositoryUser.vewUser(user.Username).TypeUser);
            }
            
           

        }
    }
}
