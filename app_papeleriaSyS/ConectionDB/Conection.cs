namespace app_papeleriaSyS.ConectionDB
{
     public class Conection
    {


        public static string GetConection()
        {
            string texconection = Properties.Settings.Default.Conection;
            return texconection;
        }

    }
}
