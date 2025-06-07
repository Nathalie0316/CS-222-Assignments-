/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 4 (Exercise 10.2)
June 7th, 2025
*/

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Packt.Shared
{
    public static class Protector
    {
        // Hardcoded salt for key derivation
        private static readonly byte[] salt = Encoding.Unicode.GetBytes("7BANANAS");
        // Number of iterations 
        private static readonly int iterations = 2000;

        // Encrypting a plain text string using AES with a key derived from a password
        public static string Encrypt(string plainText, string password)
        {
            // Converting the plaintext string to a byte array using Unicode 
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);

            // Creating a new AES instance
            Aes aes = Aes.Create();

            // Generating a key and IV using PBKDF2 from the password, salt, and iterations
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);

            // Creating a memory stream to hold encrypted data
            using var ms = new MemoryStream();
            // Creating a crypto stream to write encrypted data into memory stream
            using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                // Writing the plaintext bytes into crypto stream
                cs.Write(plainBytes, 0, plainBytes.Length);
            }

            // Converting  the encrypted byte array to a Base64 string for easier storage
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string cryptoText, string password)
        {
             // Converting the encrypted Base64 string back to a byte array
            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);

            // Creating another AES instance
            Aes aes = Aes.Create();

            // Deriving the same key and IV from the password using PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);

            // Creating a memory stream to receive decrypted data
            using var ms = new MemoryStream();
             // Creating a crypto stream for decryption
            using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                // Writing the encrypted data into the stream to decrypt it
                cs.Write(cryptoBytes, 0, cryptoBytes.Length);
            }

            // Converting the decrypted bytes back to a Unicode string
            return Encoding.Unicode.GetString(ms.ToArray());
        }

        // Combining a password and salt, hashing the result using SHA256, and returning the hash as Base64
        public static string SaltAndHashPassword(string password, string salt)
        {
            var sha = SHA256.Create();
            var saltedPassword = password + salt;
            return Convert.ToBase64String(
                sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
        }

        // Generating a random 16-byte salt encoded as a Base64 string
        public static string GenerateRandomSalt()
        {
            byte[] saltBytes = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }
    }
}

