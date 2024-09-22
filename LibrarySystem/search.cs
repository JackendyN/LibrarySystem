using System;
using System.Collections.Generic; 

public class Search {
	
	public static void SearchLibrary() {
		Console.WriteLine("What would you like to see? Choose from the options below. If you are done searching, type 'done'");
		Console.WriteLine();

		Console.WriteLine("Every book in the library");
		Console.WriteLine("Every book that is available");
		Console.WriteLine("Books by a specific genre");

		switch(Console.ReadLine().ToLower()) {
			
		case "every book in the library":
			SearchAllBooks(false);
			break;

		case "every book that is available":
			SearchAllBooks(true);
			break;

		case "books by a specific genre":
			SearchGenres();
			break;

		case "done":
			User.UserMainMenu();
			break;

		default:
			Console.WriteLine("Try again.");
			break;
			
		}
		
	}

	static void BookInformation(Book book) {
		Console.WriteLine();
		Console.WriteLine($"Title: {book.title}");
		Console.WriteLine($"Author: {book.authorName}");
		Console.WriteLine($"Number of Pages: {book.numberOfPages}");
		Console.WriteLine("Genres:");
		Console.WriteLine(book.primaryGenre.ToString());
		foreach(Book.AdditionalGenre genre in book.additionalGenres) { Console.WriteLine(genre); }
		Console.WriteLine($"Summary: {book.summary}");
		Console.WriteLine();

		if(book.available) {
			Console.WriteLine("Would you like to check out this book? If so, type 'checkout'");
			if(Console.ReadLine().ToLower() == "checkout") {
				Console.WriteLine($"You have checked out {book.title}!");
				book.available = false;
				book.dueDate = DateTime.Now.AddDays(21);
				SearchLibrary();
			}
		} else {
			Console.WriteLine("This book is currently unavailable for checkout.");
			SearchLibrary();
		}
	}

	static void SearchAllBooks(bool checkAvailable) {
		foreach(Book book in Library.bookCollection) {
			if(checkAvailable) {
				if(book.available) {
					Console.WriteLine(book.title);
				}
			} else {
				Console.WriteLine(book.title);
			}
		}

		Console.WriteLine("If you would like to see additional information on a book, provide the books name. Otherwise, type and enter any letter. Please make sure to type the book's name correctly.");
		bool foundBook = false;

		string request = Console.ReadLine().ToLower();
		foreach(Book book in Library.bookCollection) {
			if(book.title.ToLower() == request) {
				BookInformation(book);
				foundBook = true;
			}
		}

		if(!foundBook) {
			SearchLibrary();
		}
		
	}

	static void SearchGenres() {
		List<Book.PrimaryGenre> genreList1 = new List<Book.PrimaryGenre>();
		Book.PrimaryGenre genre1;
		List<Book.AdditionalGenre> genreList2 = new List<Book.AdditionalGenre>();
		Book.AdditionalGenre genre2;
		
		Console.WriteLine("Select genres from the list below. Type 'done' when you are done selecting. Capitalize exactly how it is listed, and do not include any spaces.");
		Console.WriteLine();
		Console.WriteLine("Options: \nPhilosophy \nPsychology \nReligion \nSocial Sciences \nLanguages \nNatural Sciences \nMathematics \nTechnology \nArts \nLiterature and Rhetorics \nHistory \nGeography  \nFantasy \nScience Fiction \nMystery \nHorror \nSuspense \nHistorical Fiction \nRomance \nGraphic Novel \nYoung Adult \nChildren \nComedy \nNonFiction");


		bool doneSelecting = false;
		while(!doneSelecting) {
			string selection = Console.ReadLine();
			if(Enum.TryParse(selection, out genre1)) {
				if(!genreList1.Contains(genre1)) {
					genreList1.Add(genre1);
					Console.WriteLine($"You have selected {genre1.ToString()}");
				}
			} else if(Enum.TryParse(selection, out genre2)) {
				if(!genreList2.Contains(genre2)) {
					genreList2.Add(genre2);
					Console.WriteLine($"You have selected {genre2.ToString()}");
				}
			} else if(selection.ToLower() == "done") {
				doneSelecting = true;
			} else {
				Console.WriteLine("Try again.");
			}
		}
		
		

		foreach(Book book in Library.bookCollection) {
			bool validBook = false;
			
			foreach(Book.PrimaryGenre pGenre in genreList1) {
				if(pGenre == book.primaryGenre) {
					validBook = true;
				}
			}

			int hits = 0;
			int numberOfGenres = genreList2.Count;

			if(genreList2.Count != 0) {
				foreach(Book.AdditionalGenre aGenre in genreList2) {
					if(book.additionalGenres.Contains(aGenre)) {
						hits++;
					}
				}

				if(hits == numberOfGenres) {
					validBook = true;
				}
				
			}

			if(validBook) {
				Console.WriteLine(book.title);
			}
			
		}

		Console.WriteLine("If you would like to see additional information on a book, provide the books name. Otherwise, type and enter any letter. Please make sure to type the book's name correctly.");
		bool foundBook = false;

		string request = Console.ReadLine().ToLower();
		foreach(Book book in Library.bookCollection) {
			if(book.title.ToLower() == request) {
				BookInformation(book);
				foundBook = true;
			}
		}

		if(!foundBook) {
			SearchLibrary();
		}
		
	}
	
}
