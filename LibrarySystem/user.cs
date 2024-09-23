using System;
using System.Collections.Generic; 

class User {

	public static void UserMainMenu() {
		Console.WriteLine();
		Console.WriteLine();
		Console.WriteLine("What would you like to do?");
		Console.WriteLine("Search the Library");
		Console.WriteLine("View checked out books");
		Console.WriteLine("Switch to manager");

		switch(Console.ReadLine().ToLower()) {
			
		case "search the library":
			Console.WriteLine();
			Search.SearchLibrary();
			break;

		case "view checked out books":
			Console.WriteLine();
			ViewBooks();
			break;

		case "switch to manager":
			Console.WriteLine();
			Manager.ManagerAuthorization();
			break;

		default:
			Console.WriteLine("Try again.");
			Console.WriteLine();
			UserMainMenu();
			break;
			
		}
	}

	public static void ViewBooks() {
		List<Book> bookList = new List<Book>();
		
		foreach(Book book in Library.bookCollection) {
			if(!book.available) {
				Console.WriteLine(book.title);
				Console.WriteLine($"Due Date: {book.dueDate.Date.ToString("d")}");
				if(book.dueDate.CompareTo(DateTime.Now) < 0) { Console.WriteLine("This book is due!"); }
				bookList.Add(book);
				Console.WriteLine();
			}
		}

		if(bookList.Count == 0) {
			Console.WriteLine("There are no books checked out.");
			UserMainMenu();
		} else {
			Console.WriteLine("If you like to check in a book, type in the book's name. Otherwise, enter any key.");
			string bookName = Console.ReadLine().ToLower();
			foreach(Book book in bookList) {
				if(bookName == book.title.ToLower()) {
					Console.WriteLine($"You have checked in {book.title}!");
					book.available = true;
				}
			}
			UserMainMenu();
		}
		
	}
	
}
