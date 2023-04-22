// CRUD dll

using MySql.Data.MySqlClient;

using System;

 namespace CRUD
 {
 	public interface iCRUD
 	{
 		void AddAccount();
 		void ShowAccounts();
 		void TransferMoney();
 		void DeleteAccount();
 		void SearchAccount();
 		void Exit();
 	}

 	public class cCRUDMySQL : iCRUD
 	{
 		MySqlConnection dbConnection = null;
 		// String TableName;
 		public cCRUDMySQL()
 		{
 			String ConnectionString = "server = 138.68.140.83; user = Prudhvi; password = Prudhvi@2004; database = dbPrudhvi";
 			dbConnection = new  MySqlConnection(ConnectionString);
            dbConnection.Open();
 			// TableName = "BankAccounts";
 		}
 		public void AddAccount() {
 			Console.Write("Enter Account Number: ");
 			String AccountNumber = Console.ReadLine();
 			Console.Write("Enter Account Holder Name: ");
 			String AccountHolder = Console.ReadLine();
 			Console.Write("Enter Balance: ");
 			int Balance = Convert.ToInt32(Console.ReadLine());
 			String InsertQuery = "INSERT INTO BankAccounts VALUES ('" + AccountNumber + "','" + AccountHolder + "'," + Balance + ")";
 			MySqlCommand Command = new MySqlCommand(InsertQuery, dbConnection);
 			Command.ExecuteNonQuery();
 		}

        public void ShowAccounts() {
            String SelectQuery = "SELECT *FROM BankAccounts";
            MySqlCommand Command = new MySqlCommand(SelectQuery, dbConnection);
            // MySqlDataReader dr = Command.ExecuteReader();
            // while (dr.Read()) {
            //     Console.Write(dr.GetString(0) + " ");
            //     Console.Write(dr.GetString(1) + " ");
            //     Console.WriteLine(dr.GetInt32(2));
            // }
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter(Command);
            DataTable table = new DataTable();
            MySqlAdapter.Fill(table);
            foreach (DataRow row in table.Rows) {
                Console.WriteLine($"row['AccountNumber']\trow['AccountHolder']\trow['Balance']");
            }
        }

        public void TransferMoney() {
            Console.Write("Enter Your Account Number: ");
            String SenderAccountNumber = Console.ReadLine();
            Console.Write("Enter Reciever Account Number: ");
            String RecieverAccountNumber = Console.ReadLine();
            String CheckQuery = "SELECT COUNT(*) FROM BankAccounts WHERE AccountNumber = '" + SenderAccountNumber + "' OR AccountNumber = '" + RecieverAccountNumber +"'";
            MySqlCommand Command = new MySqlCommand(CheckQuery, dbConnection);
            Object result = Command.ExecuteScalar();
            if (result.ToString() == "2") {
                Console.Write("How much amount you want to transfer? ");
                int Amount = Convert.ToInt32(Console.ReadLine());
                String SenderUpdateQuery = "UPDATE BankAccounts SET Balance = Balance - " + Amount +" WHERE AccountNumber = '" + SenderAccountNumber +"'";
                Command = new MySqlCommand(SenderUpdateQuery, dbConnection);
                Command.ExecuteNonQuery();
                String RecieverUpdateQuery = "UPDATE BankAccounts SET Balance = Balance + " + Amount +" WHERE AccountNumber = '" + RecieverAccountNumber +"'";
                Command = new MySqlCommand(RecieverUpdateQuery, dbConnection);
                Command.ExecuteNonQuery();
                // MessageBox.Show("Money Successfully Transfered!!");
            }
            else {
                Console.WriteLine("Invalid Details. Please Check Once!!!");
            }
        }

        public void DeleteAccount() {
            Console.Write("Enter AccountNumber: ");
            String AccountNumber = Console.ReadLine();
            String CheckQuery = "SELECT COUNT(*) FROM BankAccounts WHERE AccountNumber = '" + AccountNumber +"'";
            MySqlCommand Command = new MySqlCommand(CheckQuery, dbConnection);
            Object result = Command.ExecuteScalar();
            if (result.ToString() == "1") {
                String DeleteQuery = "DELETE FROM BankAccounts WHERE AccountNumber = '"+ AccountNumber +"'";
                Command = new MySqlCommand(DeleteQuery, dbConnection);
                Command.ExecuteNonQuery();
            }
            else {
                Console.WriteLine("Invalid Details Found. Please Check Once !!!");
            }
        }

        public void SearchAccount() {
            Console.Write("Enter AccountNumber: ");
            String AccountNumber = Console.ReadLine();
            String CheckQuery = "SELECT COUNT(*) FROM BankAccounts WHERE AccountNumber = '" + AccountNumber +"'";
            MySqlCommand Command = new MySqlCommand(CheckQuery, dbConnection);
            Object result = Command.ExecuteScalar();
            if (result.ToString() == "1") {
                String SearchQuery = "SELECT *FROM BankAccounts WHERE AccountNumber = '" + AccountNumber +"'";
                Command = new MySqlCommand(SearchQuery, dbConnection);
                MySqlDataReader dr = Command.ExecuteReader();
                dr.Read();
                Console.WriteLine("Account Number: " + dr.GetString(0));
                Console.WriteLine("Account Holder: " + dr.GetString(1));
                Console.WriteLine("Balance: " + dr.GetInt32(2));
            }
            else {
                Console.WriteLine("Invalid Details Found. Please Check Once!!!");
            }
        }

        public void Exit() {
            Console.Write("Thank You. Bye!");
 			dbConnection.Close();
            Environment.Exit(0);
        }
 	}
 }