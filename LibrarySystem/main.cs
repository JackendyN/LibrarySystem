using System;
using System.Collections.Generic; 

class Program {
	public static void Main (string[] args) {

		Library.CreateSampleBooks();
		Console.WriteLine("User or Manager");
		string selection = Console.ReadLine().ToLower();
		if(selection == "user") {
			User.UserMainMenu();
		} else if (selection == "manager") {
			Manager.ManagerAuthorization();
		} else {
			Console.WriteLine("Try selecting again");
			Main(args);
		}
		
	}
	
}

