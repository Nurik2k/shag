using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Создаем новый объект RSA.
        using (var rsa = new RSACryptoServiceProvider())
        {
            // Генерируем открытый и закрытый ключи RSA.
            var privateKey = rsa.ExportParameters(true);
            var publicKey = rsa.ExportParameters(false);

            // Шифрование сообщения с использованием открытого ключа RSA.
            string original = "Hello World";
            byte[] encrypted = Encrypt(Encoding.UTF8.GetBytes(original), publicKey);

            // Расшифрование сообщения с использованием закрытого ключа RSA.
            byte[] decrypted = Decrypt(encrypted, privateKey);
            string roundtrip = Encoding.UTF8.GetString(decrypted);

            // Вывод исходного сообщения и расшифрованного сообщения.
            Console.WriteLine("Original: {0}", original);
            Console.WriteLine("Encrypted:", Encrypt(Encoding.UTF8.GetBytes(original), publicKey));
            Console.WriteLine("Round Trip: {0}", roundtrip);
        }
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
