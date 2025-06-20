using System.Data;

class Program
{
    static void Main()
    {
        Console.Write("Enter master password: ");
        var masterPassword = Console.ReadLine();

        var vault = new VManager (masterPassword);

        while (true)
        {
            Console.WriteLine("\n1. Add password");
            Console.WriteLine("2. View passwords");
            Console.WriteLine("3. Delete password");
            Console.WriteLine("4. Exit");
            Console.Write("Choose: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Title: ");
                    var title = Console.ReadLine();
                    Console.Write("Password: ");
                    var pw = Console.ReadLine();
                    vault.AddPassword(title, pw);
                    Console.WriteLine("Password saved.");
                    break;
                case "2":
                    vault.ViewPasswords();
                    break;
                case "3":
                    Console.Write("ID to delete: ");
                    var id = int.Parse(Console.ReadLine());
                    vault.DeletePassword(id);
                    Console.WriteLine("Deleted.");
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
