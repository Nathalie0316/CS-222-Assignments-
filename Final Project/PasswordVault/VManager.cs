using Microsoft.Data.Sqlite;

public class VManager
{
    private readonly string _connectionString = "Data Source=vault.db";
    private readonly string _masterPassword;

    public VManager(string masterPassword)
    {
        _masterPassword = masterPassword;
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        var tableCmd = conn.CreateCommand();
        tableCmd.CommandText =
        @"CREATE TABLE IF NOT EXISTS Vault (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Title TEXT NOT NULL,
            EncryptedPassword TEXT NOT NULL
        );";
        tableCmd.ExecuteNonQuery();
    }

    public void AddPassword(string title, string plainPassword)
    {
        var encrypted = PassEncryption.Encrypt(plainPassword, _masterPassword);

        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO Vault (Title, EncryptedPassword) VALUES ($title, $password);";
        cmd.Parameters.AddWithValue("$title", title);
        cmd.Parameters.AddWithValue("$password", encrypted);
        cmd.ExecuteNonQuery();
    }

    public void ViewPasswords()
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT Id, Title, EncryptedPassword FROM Vault;";
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            var id = reader.GetInt32(0);
            var title = reader.GetString(1);
            var encrypted = reader.GetString(2);
            var decrypted = PassEncryption.Decrypt(encrypted, _masterPassword);
            Console.WriteLine($"{id}: {title} - {decrypted}");
        }
    }

    public void DeletePassword(int id)
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = "DELETE FROM Vault WHERE Id = $id;";
        cmd.Parameters.AddWithValue("$id", id);
        cmd.ExecuteNonQuery();
    }
}
