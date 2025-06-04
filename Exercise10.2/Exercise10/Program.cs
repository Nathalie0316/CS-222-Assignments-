using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Encryption and Hashing Setup Complete.");
    }

    // AES encryption
    static (byte[] EncryptedData, byte[] Key, byte[] IV) EncryptString(string plainText)
    {
        using Aes aes = Aes.Create();
        ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        byte[] encrypted;

        using var ms = new MemoryStream();
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs))
            sw.Write(plainText);

        encrypted = ms.ToArray();
        return (encrypted, aes.Key, aes.IV);
    }

    // AES decryption
    static string DecryptString(byte[] cipherText, byte[] key, byte[] iv)
    {
        using Aes aes = Aes.Create();
        ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);

        using var ms = new MemoryStream(cipherText);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        return sr.ReadToEnd();
    }

    // Hashing with salt
    static (string Hash, string Salt) HashPassword(string password)
    {
        byte[] salt = new byte[16];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(salt);

        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(32);

        return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
    }
}

