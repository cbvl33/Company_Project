﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Helpers
{
    public class CookieGeneration
    {
        private const string SaltData = "rrttdFFF88u";
        private static readonly byte[] SaltBytes = GenerateKeyFromPassword(SaltData, 32);

        public static string Create(string key)
        {
            byte[] iv = GenerateRandomBytes(16);
            return EncryptStringAES(key, SaltBytes, iv);
        }

        public static string Validate(string value)
        {
            return DecryptStringAES(value, SaltBytes, SaltBytes);
        }

        public static string EncryptStringAES(string plainText, byte[] key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string DecryptStringAES(string encryptedText, byte[] key, byte[] iv)
        {
            byte[] cipherText = Convert.FromBase64String(encryptedText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        // Метод для генерации случайного массива байтов
        private static byte[] GenerateRandomBytes(int length)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);
                return randomBytes;
            }
        }

        // Метод для генерации ключа правильного размера из строки
        private static byte[] GenerateKeyFromPassword(string password, int keyBytes)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] key = sha256.ComputeHash(Encoding.ASCII.GetBytes(password));
                return key.Take(keyBytes).ToArray();
            }
        }
    }
}
