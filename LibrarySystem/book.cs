using System;
using System.Collections.Generic; 

public class Book {

	public string title;
	public string authorName;
	public PrimaryGenre primaryGenre;
	public List<AdditionalGenre> additionalGenres = new List<AdditionalGenre>();
	public int ddcID;
	public int numberOfPages;
	public bool available = true;
	public string summary;
	public DateTime dueDate = new DateTime(2000, 1, 1, 12, 0, 0);

	public enum PrimaryGenre {
		Null,
		General,
		Philosophy,
		Psychology,
		Religion,
		SocialSciences,
		Language,
		NaturalSciences,
		Mathematics,
		Technology,
		Arts,
		LiteratureRhetorics,
		History,
		Geography
	}

	public enum AdditionalGenre {
		Null,
		Finished,
		Fantasy,
		ScienceFiction,
		Mystery,
		Horror,
		Suspense,
		HistoricalFiction,
		Romance,
		GraphicNovel,
		YoungAdult,
		Children,
		Comedy,
		NonFiction
	}
	
	public Book CreateBook() {

		Book createdBook = new Book();
		
		Console.WriteLine("Please provide the following information. Type 'Cancel' at any time to cancel this process");
			
		Console.WriteLine("Name of the book:");
		createdBook.title = Console.ReadLine();

		Console.WriteLine("Name of the author");
		createdBook.authorName = Console.ReadLine();

		createdBook.primaryGenre = PrimaryGenre.Null;
		while(createdBook.primaryGenre == PrimaryGenre.Null) {
			createdBook.primaryGenre = SelectPrimaryGenre();
		}

		Console.WriteLine("You will now select additional genres you think apply to the book.");
		while(!createdBook.additionalGenres.Contains(AdditionalGenre.Finished)) {
			createdBook.additionalGenres.Add(SelectAdditionalGenres(createdBook));
			if(createdBook.additionalGenres.Contains(AdditionalGenre.Null)) {
				createdBook.additionalGenres.Remove(AdditionalGenre.Null);
			}
		}
		createdBook.additionalGenres.Remove(AdditionalGenre.Finished);

		Console.WriteLine("Write a basic summary of the book");
		createdBook.summary = Console.ReadLine();

		Console.WriteLine("Enter the number of pages.");
		try {
			createdBook.numberOfPages = Int32.Parse(Console.ReadLine());
		} catch(FormatException) {
			Console.WriteLine("Invalid number. Try setting this number later.");
			numberOfPages = 0;
		}

		createdBook = FinalChanges(createdBook);
		ddcID = CreateIdentification(createdBook);
		Console.WriteLine("You have created a new book!");
		return createdBook;
			
	}

	bool CheckForCancel() {
		if(Console.ReadLine().ToLower() == "cancel") {
			return true;
		} else {
			return false;
		}
	}

	PrimaryGenre SelectPrimaryGenre() {
		PrimaryGenre selectedPrimary;
		Console.WriteLine("Please select the genre you would associate the most with the book. Additional genres can be added in a moment. If none of the genres fit, please type 'general'.");
		Console.WriteLine();
		Console.WriteLine("Options: \nPhilosophy \nPsychology \nReligion \nSocial Sciences \nLanguages \nNatural Sciences \nMathematics \nTechnology \nArts \nLiterature and Rhetorics \nHistory \nGeography");
		
		string chosenPrimaryGenre = Console.ReadLine().ToLower();
		switch(chosenPrimaryGenre) {

		case "general":
			selectedPrimary = PrimaryGenre.General;
			break;
			
		case "philosophy":
			selectedPrimary = PrimaryGenre.Philosophy;
			break;

		case "psychology":
			selectedPrimary = PrimaryGenre.Psychology;
			break;

		case "religion":
			selectedPrimary = PrimaryGenre.Religion;
			break;

		case "social sciences":
			selectedPrimary = PrimaryGenre.SocialSciences;
			break;

		case "languages":
			selectedPrimary = PrimaryGenre.Language;
			break;

		case "natural sciences":
			selectedPrimary = PrimaryGenre.NaturalSciences;
			break;

		case "mathematics":
			selectedPrimary = PrimaryGenre.Mathematics;
			break;

		case "technology":
			selectedPrimary = PrimaryGenre.Technology;
			break;

		case "arts":
			selectedPrimary = PrimaryGenre.Arts;
			break;

		case "literature and rhetorics":
			selectedPrimary = PrimaryGenre.LiteratureRhetorics;
			break;

		case "history":
			selectedPrimary = PrimaryGenre.History;
			break;

		case "geography":
			selectedPrimary = PrimaryGenre.Geography;
			break;

		default:
			Console.WriteLine("There seems to have been an error somewhere. Please try again");
			return PrimaryGenre.Null;
		}

		Console.WriteLine("You have chosen " + chosenPrimaryGenre + " as your primary genre. Type 'no' to reselect. Otherwise, type and enter any key to continue.");
		if(Console.ReadLine().ToLower() == "no") {
			return PrimaryGenre.Null;
		} else {
			return selectedPrimary;
		}

	}

	AdditionalGenre SelectAdditionalGenres(Book currentBook) {
		AdditionalGenre selectedAddition;
		Console.WriteLine("Select an additional genre from the options below. If you are satisfied with your choices, type 'finished'");
		Console.WriteLine();
		Console.WriteLine("Options: \nFantasy \nScience Fiction \nMystery \nHorror \nSuspense \nHistorical Fiction \nRomance \nGraphic Novel \nYoung Adult \nChildren \nComedy \nNonFiction");

		string chosenAdditionalGenre = Console.ReadLine().ToLower();
		switch(chosenAdditionalGenre) {

		case "fantasy":
			if(!currentBook.additionalGenres.Contains(AdditionalGenre.Fantasy)) {
				selectedAddition = AdditionalGenre.Fantasy;
				break;
			} else {
				Console.WriteLine("You have already selected this.");
				return AdditionalGenre.Null;
			}

		case "science fiction":
			if(!currentBook.additionalGenres.Contains(AdditionalGenre.ScienceFiction)) {
				selectedAddition = AdditionalGenre.ScienceFiction;
				break;
			} else {
				Console.WriteLine("You have already selected this.");
				return AdditionalGenre.Null;
			}

		case "mystery":
			if(!currentBook.additionalGenres.Contains(AdditionalGenre.Mystery)) {
				selectedAddition = AdditionalGenre.Mystery;
				break;
			} else {
				Console.WriteLine("You have already selected this.");
				return AdditionalGenre.Null;
			}

		case "horror":
			if(!currentBook.additionalGenres.Contains(AdditionalGenre.Horror)) {
				selectedAddition = AdditionalGenre.Horror;
				break;
			} else {
				Console.WriteLine("You have already selected this.");
				return AdditionalGenre.Null;
			}

		case "suspense":
			if(!currentBook.additionalGenres.Contains(AdditionalGenre.Suspense)) {
				selectedAddition = AdditionalGenre.Suspense;
				break;
			} else {
				Console.WriteLine("You have already selected this.");
				return AdditionalGenre.Null;
			}

		case "historical fiction":
			if(!currentBook.additionalGenres.Contains(AdditionalGenre.HistoricalFiction)) {
				selectedAddition = AdditionalGenre.HistoricalFiction;
				break;
			} else {
				Console.WriteLine("You have already selected this.");
				return AdditionalGenre.Null;
			}

		case "romance":
			if(!currentBook.additionalGenres.Contains(AdditionalGenre.Romance)) {
				selectedAddition = AdditionalGenre.Romance;
				break;
			} else {
				Console.WriteLine("You have already selected this.");
				return AdditionalGenre.Null;
			}

		case "graphic novel":
			if(!currentBook.additionalGenres.Contains(AdditionalGenre.GraphicNovel)) {
				selectedAddition = AdditionalGenre.GraphicNovel;
				break;
			} else {
				Console.WriteLine("You have already selected this.");
				return AdditionalGenre.Null;
			}

		case "young adult":
			if(!currentBook.additionalGenres.Contains(AdditionalGenre.YoungAdult)) {
				selectedAddition = AdditionalGenre.YoungAdult;
				break;
			} else {
				Console.WriteLine("You have already selected this.");
				return AdditionalGenre.Null;
			}

		case "children":
			if(!currentBook.additionalGenres.Contains(AdditionalGenre.Children)) {
				selectedAddition = AdditionalGenre.Children;
				break;
			} else {
				Console.WriteLine("You have already selected this.");
				return AdditionalGenre.Null;
			}

		case "comedy":
			if(!currentBook.additionalGenres.Contains(AdditionalGenre.Comedy)) {
				selectedAddition = AdditionalGenre.Comedy;
				break;
			} else {
				Console.WriteLine("You have already selected this.");
				return AdditionalGenre.Null;
			}

		case "nonfiction":
			if(!currentBook.additionalGenres.Contains(AdditionalGenre.NonFiction)) {
				selectedAddition = AdditionalGenre.NonFiction;
				break;
			} else {
				Console.WriteLine("You have already selected this.");
				return AdditionalGenre.Null;
			}

		case "finished":
			return AdditionalGenre.Finished;

		default:
			Console.WriteLine("There seems to have been an error somewhere. Please try again");
			return AdditionalGenre.Null;
		}

		Console.WriteLine("You have chosen " + chosenAdditionalGenre + " as an additional genre. Type 'no' to reselect. Otherwise, type and enter any key to continue.");
		if(Console.ReadLine().ToLower() == "no") {
			return AdditionalGenre.Null;
		} else {
			return selectedAddition;
		}
		
	}

	public int CreateIdentification(Book identifiedBook) {
		var random = new Random();
		switch(identifiedBook.primaryGenre) {
			
		case PrimaryGenre.General:
			return random.Next(0, 99);

		case PrimaryGenre.Philosophy:
			return random.Next(100, 199);

		case PrimaryGenre.Psychology:
			return random.Next(100, 199);

		case PrimaryGenre.Religion:
			return random.Next(200, 299);

		case PrimaryGenre.SocialSciences:
			return random.Next(300, 399);

		case PrimaryGenre.Language:
			return random.Next(400, 499);

		case PrimaryGenre.NaturalSciences:
			return random.Next(500, 599);

		case PrimaryGenre.Mathematics:
			return random.Next(500, 599);

		case PrimaryGenre.Technology:
			return random.Next(600, 699);

		case PrimaryGenre.Arts:
			return random.Next(700, 799);

		case PrimaryGenre.LiteratureRhetorics:
			return random.Next(800, 899);

		case PrimaryGenre.History:
			return random.Next(900, 999);

		case PrimaryGenre.Geography:
			return random.Next(900, 999);
			
		}

		return 0;

	}

	public Book FinalChanges(Book book) {
		Console.WriteLine("Review the following information below. If you would like to change something, please type what you would like to change. Otherwise, type 'finished'");
		Console.WriteLine();

		Console.WriteLine($"Title: {book.title}");
		Console.WriteLine($"Author: {book.authorName}");
		Console.WriteLine($"Number of Pages: {book.numberOfPages}");
		Console.WriteLine($"Summary: {book.summary}");
		Console.WriteLine($"Primary Genre: {book.primaryGenre.ToString()}");
		
		Console.WriteLine("Additional Genres:");
		foreach(AdditionalGenre genre in book.additionalGenres) {
			Console.WriteLine(genre.ToString());
		}

		switch(Console.ReadLine().ToLower()) {
			
		case "title":
			Console.WriteLine("Enter a new name.");
			book.title = Console.ReadLine();
			FinalChanges(book);
			break;

		case "author":
			Console.WriteLine("Enter a new author.");
			book.authorName = Console.ReadLine();
			FinalChanges(book);
			break;

		case "number of pages":
			Console.WriteLine("Enter the number of pages.");
			try {
				book.numberOfPages = Int32.Parse(Console.ReadLine());
				FinalChanges(book);
				break;
			} catch(FormatException) {
				Console.WriteLine("Invalid number. Try setting this number again.");
				FinalChanges(book);
				break;
			}

		case "summary":
			Console.WriteLine("Enter a new summary.");
			book.summary = Console.ReadLine();
			FinalChanges(book);
			break;

		case "primary genre":
			book.primaryGenre = SelectPrimaryGenre();
			FinalChanges(book);
			break;

		case "additional genres":
			while(!book.additionalGenres.Contains(AdditionalGenre.Finished)) {
				book.additionalGenres.Add(SelectAdditionalGenres(book));
				if(book.additionalGenres.Contains(AdditionalGenre.Null)) {
					book.additionalGenres.Remove(AdditionalGenre.Null);
				}
			}
			book.additionalGenres.Remove(AdditionalGenre.Finished);
			FinalChanges(book);
			break;

		case "finished":
			bool bookExists = false;
			foreach(Book existingBook in Library.bookCollection) {
				if(book.title == existingBook.title) {
					bookExists = true;
				}
			}

			if(bookExists) {
				Console.WriteLine("A book with this title already exists. This library cannot currently hold more than one copy of a book. Please change the book's title before continuing");
				FinalChanges(book);
				break;
			} else {
				return book;
			}

		default:
			Console.WriteLine("Something went wrong. Try again.");
			FinalChanges(book);
			break;
		}

		return book;

	}
	
	
}

