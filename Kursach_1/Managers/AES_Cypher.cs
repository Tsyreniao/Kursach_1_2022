using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Kursach_1.Managers
{
    internal class AES_Cypher
    {
        public string Encrypt_AES(string plainText, string Password, byte[] IV)
        {
            byte[] Key = Encoding.ASCII.GetBytes(Password);

            AesManaged aesAlg = new AesManaged();
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            MemoryStream msEncrypt = new MemoryStream();
            CryptoStream csEncrypt = new CryptoStream(msEncrypt, aesAlg.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] inputBytes = Encoding.ASCII.GetBytes(plainText);
            csEncrypt.Write(inputBytes, 0, inputBytes.Length);
            csEncrypt.FlushFinalBlock();

            byte[] encrypted = msEncrypt.ToArray();
            return Convert.ToBase64String(encrypted);
        }

        public string Decrypt_AES(string plainText, string Password, byte[] IV)
        {
            byte[] Key = Encoding.ASCII.GetBytes(Password);

            AesManaged aesAlg = new AesManaged();
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            MemoryStream msDecrypt = new MemoryStream();
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, aesAlg.CreateDecryptor(), CryptoStreamMode.Write);

            byte[] inputBytes = Convert.FromBase64String(plainText);
            csDecrypt.Write(inputBytes, 0, inputBytes.Length);
            csDecrypt.FlushFinalBlock();

            byte[] decrypted = msDecrypt.ToArray();
            return UTF8Encoding.ASCII.GetString(decrypted, 0, decrypted.Length);
        }
    }
}
