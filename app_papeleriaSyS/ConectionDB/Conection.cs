namespace app_papeleriaSyS.ConectionDB
{
    internal class Conection
    {


        public static string GetConection()
        {
            string texconection = Properties.Settings.Default.Conection;
            return texconection;
        }

    }
}
