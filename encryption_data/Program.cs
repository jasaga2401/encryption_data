using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string for the SQL Server database
        string connectionString = "Data Source=Amaze\\SQLEXPRESS;Initial Catalog=things_to_do;Integrated Security=True";

        // Data to be encrypted
        string plainTextData = "pass123";

        // Encryption passphrase
        string passphrase = "PassWordPhrase";

        // SQL query to encrypt data using EncryptByPassPhrase
        string sqlQuery = $"UPDATE dbo.tbl_user SET passwd = EncryptByPassPhrase(@Passphrase, @PlainTextData);";

        // Create a SqlConnection and execute the query
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                // Add parameters to the query
                command.Parameters.AddWithValue("@Passphrase", passphrase);
                command.Parameters.AddWithValue("@PlainTextData", plainTextData);

                // Execute the query
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows Affected: {rowsAffected}");
            }
        }
    }
}

