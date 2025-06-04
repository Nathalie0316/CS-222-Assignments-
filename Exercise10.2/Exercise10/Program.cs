using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        string xml =
@"<?xml version='1.0' encoding='utf-8'?>
<customers>
  <customer>
    <name>Bob Smith</name>
    <creditcard>1234-5678-9012-3456</creditcard>
    <password>Pa$$w0rd</password>
  </customer>
</customers>";

        var doc = XDocument.Parse(xml);
        var customer = doc.Root.Element("customer");

        string creditCard = customer.Element("creditcard").Value;
        string password = customer.Element("password").Value;

        // Encrypt credit card
        (byte[] encryptedCard, byte[] key, byte[] iv) = EncryptString(creditCard);

        // Hash password
        (string hashedPassword, string salt) = HashPassword(password);

        // Update XML
        customer.SetElementValue("creditcard", Convert.ToBase64String(encryptedCard));
        customer.SetElementValue("password", hashedPassword);
        customer.Add(new XElement("salt", salt));
        customer.Add(new XElement("key", Convert.ToBase64String(key)));
        customer.Add(new XElement("iv", Convert.ToBase64String(iv)));

        Console.WriteLine(doc);
    }

    // AES Encryption
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

    // AES Decryption (optional)
    static string DecryptString(byte[] cipherText, byte[] key, byte[] iv)
    {
        using Aes aes = Aes.Create();
        ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);

        using var ms = new MemoryStream(cipherText);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        return sr.ReadToEnd();
    }

    // Password Hashing with Salt
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
