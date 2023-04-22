// Greet Friend

using MySql.Data.MySqlClient;

using System;

class cGreet
{
	public static void Main(String[] args)
	{
		String ConnectionString = "server = 138.68.140.83; user = Prudhvi; password = Prudhvi@2004; database = dbPrudhvi";
		MySqlConnection dbConnection = new MySqlConnection(ConnectionString);
		dbConnection.Open();
		String Query = "SELECT *FROM BankAccounts";
		MySqlCommand Command = new MySqlCommand(Query, dbConnection);
		MySqlDataReader rdr = Command.ExecuteReader();
		while (rdr.Read()) {
			Console.WriteLine(rdr[0] + " " + rdr[1] + " " + rdr[2]);
		}
		rdr.Close();
		dbConnection.Close();
		Console.WriteLine("Done");
	}
}