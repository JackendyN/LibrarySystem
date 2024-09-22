using System;
using System.Collections.Generic; 

class Manager {
	
	public static void ManagerMainMenu() {
		Console.WriteLine();
		Console.WriteLine("What would you like to do?");
		Console.WriteLine("Add a new book");
		Console.WriteLine("Remove a book");
		Console.WriteLine("Update a books information");
		Console.WriteLine("Switch to user");

		switch(Console.ReadLine().ToLower()) {
			
		case "add a new book":
			Book newBook = new Book();
			Library.AddBook(newBook.CreateBook());
			ManagerMainMenu();
			break;

		case "update a books information":
			UpdateBook();
			break;

		case "switch to user":
			User.UserMainMenu();
			break;

		case "remove a book":
			RemoveBook();
			break;

		default:
			Console.WriteLine("Try again.");
			ManagerMainMenu();
			break;
			
		}
	}

	public static void ManagerAuthorization() {
		string password = "LMana";
		Console.WriteLine("Please enter the correct password to access the manager menu.");
		if(Console.ReadLine() == password) {
			ManagerMainMenu();
		} else {
			Console.WriteLine("Incorrect Password");
			User.UserMainMenu();
		}
	}

	public static void UpdateBook() {
		Console.WriteLine("Please type the title of the book you would like to update:");
		foreach(Book book in Library.bookCollection) { Console.WriteLine(book.title); }

		string bookTitle = Console.ReadLine().ToLower();
		bool foundBook = false;
		foreach(Book book in Library.bookCollection) {
			if(book.title.ToLower() == bookTitle) {
				Library.bookCollection.Remove(book);
				Book changedBook = book.FinalChanges(book);
				Library.AddBook(changedBook);
				foundBook = true;
				break;
			}
		}

		if(foundBook) {
			Console.WriteLine($"You have changed the information on {bookTitle}.");
			ManagerMainMenu();
		} else {
			Console.WriteLine("Try again.");
			UpdateBook();
		}
		
	}

	public static void RemoveBook() {
		Console.WriteLine("Please type the title of the book you would like to remove:");
		foreach(Book book in Library.bookCollection) { Console.WriteLine(book.title); }

		string bookTitle = Console.ReadLine().ToLower();
		bool foundBook = false;
		foreach(Book book in Library.bookCollection) {
			if(book.title.ToLower() == bookTitle) {
				Library.bookCollection.Remove(book);
				foundBook = true;
				break;
			}
		}

		if(foundBook) {
			Console.WriteLine($"You have removed {bookTitle} from the library.");
			ManagerMainMenu();
		} else {
			Console.WriteLine("Try again.");
			RemoveBook();
		}
	}
	
}
