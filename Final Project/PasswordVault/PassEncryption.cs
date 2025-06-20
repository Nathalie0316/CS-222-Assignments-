/*
Nathalie C. Lezama
CS 222 C# Programming
Final Project Assignment
June 20th, 2025
*/ 

using System.Security.Cryptography;
using System.Text;

// Methods to encrypt and decrypt text using AES
public static class PassEncryption
{
    // Salt value used to generate encryption key 
    private static readonly byte[] Salt = Encoding.UTF8.GetBytes("MyFixedSalt123");

    // Encrypting a plain string using AES and a password
    public static string Encrypt(string plainText, string password)
    {
        using var aes = Aes.Create();
        // Derive encryption key and IV from password + salt
        var key = new Rfc2898DeriveBytes(password, Salt, 10000);
        aes.Key = key.GetBytes(32);
        aes.IV = key.GetBytes(16);

        using var ms = new MemoryStream();
        using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs)) sw.Write(plainText);

        // Returning encrypted result as Base64 string
        return Convert.ToBase64String(ms.ToArray());
    }

    // Decrypting an AES-encrypted string using the same password
    public static string Decrypt(string cipherText, string password)
    {
        var buffer = Convert.FromBase64String(cipherText);
        using var aes = Aes.Create();
        var key = new Rfc2898DeriveBytes(password, Salt, 10000);
        aes.Key = key.GetBytes(32);
        aes.IV = key.GetBytes(16);

        using var ms = new MemoryStream(buffer);
        using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        
        // Return the original plain text
        return sr.ReadToEnd();
    }
}
