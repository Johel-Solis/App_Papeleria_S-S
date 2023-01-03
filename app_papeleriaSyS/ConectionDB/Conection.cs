using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace app_papeleriaSyS.ConectionDB
{
    internal class Conection
    {

        public static string GetConection()
        { string texconection = Properties.Settings.Default.Conection; 
        return texconection;
        }

    }
}
