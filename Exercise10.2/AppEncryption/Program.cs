using System;
using System.Xml.Linq;
using Packt.Shared;

class Program
{
    static void Main()
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

        Console.Write("Enter a password to encrypt the credit card: ");
        string encryptionPassword = Console.ReadLine();

        string encryptedCard = Protector.Encrypt(creditCard, encryptionPassword);
        string salt = Protector.GenerateRandomSalt();
        string hashedPassword = Protector.SaltAndHashPassword(password, salt);

        customer.SetElementValue("creditcard", encryptedCard);
        customer.SetElementValue("password", hashedPassword);
        customer.Add(new XElement("salt", salt));

        Console.WriteLine("\nModified XML:\n");
        Console.WriteLine(doc);
    }
}
