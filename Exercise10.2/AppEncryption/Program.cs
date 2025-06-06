/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 4 (Exercise 10.2)
June 6th, 2025
*/

using System;
using System.Xml.Linq;
using Packt.Shared;

class Program
{
    static void Main()
    {
    // Defining an XML string 
    string xml =
@"<?xml version='1.0' encoding='utf-8'?>
<customers>
  <customer>
    <name>Bob Smith</name>
    <creditcard>1234-5678-9012-3456</creditcard>
    <password>Pa$$w0rd</password>
  </customer>
</customers>";

        // Parsing the XML string into an XDocument object so we can manipulate it
        var doc = XDocument.Parse(xml);
        // Getting the <customer> element from the XML
        var customer = doc.Root.Element("customer");
        
        // Extracting the credit card number and password values from the XML
        string creditCard = customer.Element("creditcard").Value;
        string password = customer.Element("password").Value;

        // Prompting users to enter a password to use for encrypting 
        Console.Write("Enter a password to encrypt the credit card: ");
        string encryptionPassword = Console.ReadLine();
        
        // Encrypting the credit card number using our Protector class and the password entered by the user
        string encryptedCard = Protector.Encrypt(creditCard, encryptionPassword);
        string salt = Protector.GenerateRandomSalt();
        string hashedPassword = Protector.SaltAndHashPassword(password, salt);

        // Updating the XML by replacing plaintext credit card and password with the encrypted version
        customer.SetElementValue("creditcard", encryptedCard);
        customer.SetElementValue("password", hashedPassword);

        // Adding a new <salt> element to store the generated salt
        customer.Add(new XElement("salt", salt));

        // Displaying the modified XML
        Console.WriteLine("\nModified XML:\n");
        Console.WriteLine(doc);
    }
}
