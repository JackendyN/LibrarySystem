using System;
using System.Collections.Generic; 

public class Library {
	
	public static List<Book> bookCollection = new List<Book>();

	public static void AddBook(Book addedBook) {
		bookCollection.Add(addedBook);	
	}

	public static void CreateSampleBooks() {
		Book sampleBookOne = new Book();
		sampleBookOne.title = "Electricity & Electronics";
		sampleBookOne.authorName = "Gerrish, Dugger, Roberts";
		sampleBookOne.primaryGenre = Book.PrimaryGenre.Technology;
		sampleBookOne.additionalGenres.Add(Book.AdditionalGenre.NonFiction);
		sampleBookOne.ddcID = sampleBookOne.CreateIdentification(sampleBookOne);
		sampleBookOne.numberOfPages = 447;
		sampleBookOne.summary = "A bright outlook for the electronics industry in the future translates to opportunities for specialized education and a lifetime of challenging and rewarding employment. The world of electricity and electronics is a fascinating one and we are pleased that you have chosen to explore it with us.";
		AddBook(sampleBookOne);
		
		Book sampleBookTwo = new Book();
		sampleBookTwo.title = "No Impact Man";
		sampleBookTwo.authorName = "Colin Beavan";
		sampleBookTwo.primaryGenre = Book.PrimaryGenre.SocialSciences;
		sampleBookTwo.additionalGenres.Add(Book.AdditionalGenre.NonFiction);
		sampleBookTwo.ddcID = sampleBookTwo.CreateIdentification(sampleBookTwo);
		sampleBookTwo.numberOfPages = 275;
		sampleBookTwo.summary = "Colin Beavan attempts to live eco-effectively and make zero impact on the environment";
		AddBook(sampleBookTwo);

		Book sampleBookThree = new Book();
		sampleBookThree.title = "The Greatest Stories Never Told";
		sampleBookThree.authorName = "Rick Beyer";
		sampleBookThree.primaryGenre = Book.PrimaryGenre.History;
		sampleBookThree.additionalGenres.Add(Book.AdditionalGenre.NonFiction);
		sampleBookThree.ddcID = sampleBookThree.CreateIdentification(sampleBookThree);
		sampleBookThree.numberOfPages = 214;
		sampleBookThree.summary = "100 tales from history to astonish, bewilder, and stupefy";
		AddBook(sampleBookThree);

		Book sampleBookFour = new Book();
		sampleBookFour.title = "Bear Island";
		sampleBookFour.authorName = "Alistair MacLean";
		sampleBookFour.primaryGenre = Book.PrimaryGenre.General;
		sampleBookFour.additionalGenres.Add(Book.AdditionalGenre.Horror);
		sampleBookFour.additionalGenres.Add(Book.AdditionalGenre.Mystery);
		sampleBookFour.ddcID = sampleBookFour.CreateIdentification(sampleBookFour);
		sampleBookFour.numberOfPages = 288;
		sampleBookFour.summary = "Five people are stranded on an island with a pathological killer.";
		AddBook(sampleBookFour);

		Book sampleBookFive = new Book();
		sampleBookFive.title = "What Great Teachers Do Differently";
		sampleBookFive.authorName = "Todd Whitaker";
		sampleBookFive.primaryGenre = Book.PrimaryGenre.Psychology;
		sampleBookFive.additionalGenres.Add(Book.AdditionalGenre.NonFiction);
		sampleBookFive.ddcID = sampleBookFive.CreateIdentification(sampleBookFive);
		sampleBookFive.numberOfPages = 130;
		sampleBookFive.summary = "The beliefs and behaviors that set great teachers apart";
		AddBook(sampleBookFive);
		
	}
	
}
