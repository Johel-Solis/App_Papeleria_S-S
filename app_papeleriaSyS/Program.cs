using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            string pass = Encryption.encryptKey("hola mundo");
            Console.WriteLine("pass cifrada"+pass);
            Console.WriteLine("pass decifrada : "+Encryption.decryptKey(pass));

        }
    }
}
