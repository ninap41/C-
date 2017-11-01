using System;
using DbConnection;
using System.Collections.Generic;


namespace simpleCRUD
{
  	    public class Program
	    {
	        public static void Read()
	        {
	            List<Dictionary<string,object>> userInfo = DbConnector.Query("SELECT First_Name AS 'First Name', Last_Name AS 'Last Name', Favorite_Number AS 'Favorite Number', Data1 AS 'Race', Data3 AS 'Class' FROM users");
	            Console.WriteLine("User Info--");
	            foreach(var info in userInfo)
	            {
	                foreach(KeyValuePair<string,object> user in info)
	                {
	                Console.Write($"{ user.Key }: { user.Value }" + ", ");
	                }
	                Console.WriteLine();
	            }
	        }

	        public static void Insert()
	        {
	            string first = Console.ReadLine();
	            string last = Console.ReadLine();
	            string number = Console.ReadLine();
				string race = Console.ReadLine();
				string type = Console.ReadLine();
				string class_type = Console.ReadLine();
	            DbConnector.Execute($"INSERT INTO users (First_Name, Last_Name, Favorite_Number, Data1, Data2, Data3) VALUES ('{first}', '{last}', '{number}', '{race}','{type}','{class_type}')");
	        }

			public static void Delete(){
				Console.Write("Want to Delete a User?");
				string Ready_To_Delete = Console.ReadLYesine();
				if(Ready_To_Delete == "Yes"){
					Console.Write("Put in User ID to Delete? ");
					string deleteID = Console.ReadLine();
                    DbConnector.Execute($"DELETE FROM consoledb.users WHERE id = {deleteID}");
					}
			}
	        static void Main(string[] args)
	        {
	            // Read();
	            Insert();
				Delete();
				
				
	        }
	    }
	}
