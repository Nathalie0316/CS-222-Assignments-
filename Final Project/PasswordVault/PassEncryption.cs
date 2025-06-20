using System.Security.Cryptography;
using System.Text;

public static class PassEncryption
{
    private static readonly byte[] Salt = Encoding.UTF8.GetBytes("MyFixedSalt123");

    public static string Encrypt(string plainText, string password)
    {
        using var aes = Aes.Create();
        var key = new Rfc2898DeriveBytes(password, Salt, 10000);
        aes.Key = key.GetBytes(32);
        aes.IV = key.GetBytes(16);

        using var ms = new MemoryStream();
        using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs)) sw.Write(plainText);

        return Convert.ToBase64String(ms.ToArray());
    }

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
        return sr.ReadToEnd();
    }
}
