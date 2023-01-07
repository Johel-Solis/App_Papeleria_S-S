using System;
using System.Security.Cryptography;
using System.Text;

namespace app_papeleriaSyS.Utillity
{
    internal class Encryption
    {



        // Encripta Contraseña
        public static string encryptKey(string cadena)
        {
            string key = "ABCDEFG54669525PQRSTUVWXYZabcdef852846opqrstuvwxyz";
            //arreglo de bytes donde guardamos la llave 
            byte[] keyArray;

            //arreglo de bytes donde guardamos el texto a encriptar
            byte[] Arregit_a_Cifrar = UTF8Encoding.UTF8.GetBytes(cadena);
            //se utilizan las clases de encriptacion provistas por el framework
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            //se guarda la llave para que se realise el hashing
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            // Algoritmo 3DAS
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();

            tripleDES.Key = keyArray;
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;

            // se empieza con la transformacion de la cadena
            ICryptoTransform cryptoTransform = tripleDES.CreateEncryptor();
            //arreglo de bytes donde se guarda la cadena cifrada

            byte[] arrayResult = cryptoTransform.TransformFinalBlock(Arregit_a_Cifrar, 0, Arregit_a_Cifrar.Length);
            tripleDES.Clear();

            //se regresa el resultado en forma de cadena
            return Convert.ToBase64String(arrayResult, 0, arrayResult.Length);

        }
        //DESENCRIPTA CONTRASEÑA
        public static string decryptKey(string clave)
        {
            string key = "ABCDEFG54669525PQRSTUVWXYZabcdef852846opqrstuvwxyz";
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar = Convert.FromBase64String(clave);
            //se llama a las clases que tienen los algoritmos  de encriptacion se le aplica el hashing
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = keyArray;
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cryptoTransform = tripleDES.CreateDecryptor();

            byte[] resultArray = cryptoTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);
            tripleDES.Clear();
            // se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(resultArray);

        }

    }
}
