using System;
using System.Security.Cryptography;
using System.Text;

namespace RSA
{
    

    class RSA
    {
        //static void Main(string[] args)
        //{
        //    // Создаем новый объект RSA.
        //    using (var rsa = new RSACryptoServiceProvider())
        //    {
        //        // Генерируем открытый и закрытый ключи RSA.
        //        var privateKey = rsa.ExportParameters(true);
        //        var publicKey = rsa.ExportParameters(false);

        //        // Шифрование сообщения с использованием открытого ключа RSA.
        //        string original = "Hello World";
        //        byte[] encrypted = Encrypt(Encoding.UTF8.GetBytes(original), publicKey);

        //        // Расшифрование сообщения с использованием закрытого ключа RSA.
        //        byte[] decrypted = Decrypt(encrypted, privateKey);
        //        string roundtrip = Encoding.UTF8.GetString(decrypted);

        //        // Вывод исходного сообщения и расшифрованного сообщения.
        //        Console.WriteLine("Original: {0}", original);
        //        Console.WriteLine("Round Trip: {0}", roundtrip);
        //    }
        //}
        public byte[] ERSA(string original)
        {
                using (var rsa = new RSACryptoServiceProvider())
                {
                    var publicKey = rsa.ExportParameters(false);
                    byte[] encrypted = Encrypt(Encoding.UTF8.GetBytes(original), publicKey);
                    
                    return encrypted;
                }
            
            
            
        }
        public string DRSA(byte[] encrypted)
        {
            try
            {
                using (var rsa = new RSACryptoServiceProvider())
                {
                    var privateKey = rsa.ExportParameters(true);
                    byte[] decrypted = Decrypt(encrypted, privateKey);
                    return decrypted.ToString();
                }
            }
            catch (Exception ex) { return ex.Message; }
            
        }

        static byte[] Encrypt(byte[] data, RSAParameters publicKey)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(publicKey);
                return rsa.Encrypt(data, true);
            }
        }

        static byte[] Decrypt(byte[] data, RSAParameters privateKey)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(privateKey);
                return rsa.Decrypt(data, true);
            }
        }
    }

}
