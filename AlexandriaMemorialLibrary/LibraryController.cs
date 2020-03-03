using System;
using System.Collections.Generic;
using System.IO;

namespace AlexandriaMemorialLibrary
{
    //Defined book statuses for the book object
    enum Status
    {
        OnShelf,
        CheckedOut,
        Processing,
        Unavailable
    }
    //Defined book genres for the book object
    enum Genre
    {
        Fantasy,
        SciFi,
        Mystery,
        Thriller,
        Travel,
        Adventure,
        GraphicNovel,
        Biography,
        SelfHelp
    }
    class LibraryController
    {
        //Main list of book objects utilized by the controller.
        private List<Book> Library { get; set; }
        //Global bool variable that determines whether or not the application continues. Used to restart after completing an action
        private bool Loop { get; set; }
        public LibraryController()
        {
            Library = new List<Book>();
            Loop = true;
            //If the library was burned previously, generates a book to display this and stores it in the library
            if (File.Exists("Charred Remains.txt"))
            {
                var savefile = File.Create("library.txt");
                savefile.Close();
                StreamWriter write = new StreamWriter("library.txt");
                write.WriteLine("Charred Remains|Julius Caesar|0|Unavailable|SelfHelp|1/1/1800 12:00:00 AM");
                write.Close();
            }
            //if the library file hasn't been created yet, creates a library file
            else if (!File.Exists("library.txt"))
            {
                var savefile = File.Create("library.txt");
                savefile.Close();
            }
            StreamReader read = new StreamReader("library.txt");
            //loads default library if unable to read file
            if (read.ReadLine() == null)
            {
                Library.Add(new Book()
                {
                    Title = "Best of Bar Harbor",
                    Author = "Greg Hartford",
                    ISBN = 9780892727940,
                    Status = Status.OnShelf,
                    Genre = new List<Genre> { Genre.Travel },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "Dune",
                    Author = "Frank Herbert",
                    ISBN = 9780593099322,
                    Status = Status.OnShelf,
                    Genre = new List<Genre>() { Genre.SciFi, Genre.Adventure, Genre.Fantasy },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "Every Tool's a Hammer",
                    Author = "Adam Savage",
                    ISBN = 9781471185113,
                    Status = Status.OnShelf,
                    Genre = new List<Genre>() { Genre.Biography },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "Excelsior!: The Amazing Life of Stan Lee",
                    Author = "Stan Lee",
                    ISBN = 9780684873053,
                    Status = Status.OnShelf,
                    Genre = new List<Genre> { Genre.Biography},
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "The Food Lab: Better Home Cooking Through Science",
                    Author = "J. Kenji López-Alt",
                    ISBN = 9780393081084,
                    Status = Status.OnShelf,
                    Genre = new List<Genre> { Genre.SelfHelp },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "The Hobbit: Or There and Back Again",
                    Author = "J.R.R. Tolkien",
                    ISBN = 9781594130052,
                    Status = Status.OnShelf,
                    Genre = new List<Genre> { Genre.Adventure, Genre.Fantasy },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "The Institute",
                    Author = "Stephen King",
                    ISBN = 9781982110567,
                    Status = Status.OnShelf,
                    Genre = new List<Genre> { Genre.Thriller },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "Journey to the Center of the Earth",
                    Author = "Jules Verne",
                    ISBN = 9780553213973,
                    Status = Status.OnShelf,
                    Genre = new List<Genre> { Genre.SciFi, Genre.Adventure },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "The Line Between",
                    Author = "Tosca Lee",
                    ISBN = 9781476798622,
                    Status = Status.OnShelf,
                    Genre = new List<Genre> { Genre.SciFi, Genre.Thriller },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "The Martian",
                    Author = "Andy Weir",
                    ISBN = 9780553418026,
                    Status = Status.OnShelf,
                    Genre = new List<Genre> { Genre.SciFi, Genre.Adventure },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "Mud, Sweat, and Tears",
                    Author = "Bear Grylls",
                    ISBN = 9780062124135,
                    Status = Status.OnShelf,
                    Genre = new List<Genre>() { Genre.Biography },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "Murder on the Orient Express",
                    Author = "Agatha Christie",
                    ISBN = 9781579126230,
                    Status = Status.OnShelf,
                    Genre = new List<Genre> { Genre.Mystery},
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "Permanent Record",
                    Author = "Edward Snowden",
                    ISBN = 9781250237231,
                    Status = Status.OnShelf,
                    Genre = new List<Genre> { Genre.Biography },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "Radicalized",
                    Author = "Cory Doctorow",
                    ISBN = 9781250228598,
                    Status = Status.OnShelf,
                    Genre = new List<Genre>() { Genre.SciFi, },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "The Secrets of Ireland",
                    Author = "Kevin Eyres",
                    ISBN = 9780760782811,
                    Status = Status.OnShelf,
                    Genre = new List<Genre> { Genre.Travel },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
               Library.Add(new Book()
                {
                    Title = "Shoe Dog",
                    Author = "Phil Knight",
                    ISBN = 9781501135927,
                    Status = Status.OnShelf,
                    Genre = new List<Genre> { Genre.Biography },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "Spartan Gold",
                    Author = "Clive Cussler",
                    ISBN = 9780425236291,
                    Status = Status.OnShelf,
                    Genre = new List<Genre> { Genre.Adventure },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "Turn Right At Machu Picchu",
                    Author = "Mark Adams",
                    ISBN = 9780452297982,
                    Status = Status.OnShelf,
                    Genre = new List<Genre> { Genre.Travel },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "Watchmen",
                    Author = "Alan Moore",
                    ISBN = 9781779501129,
                    Status = Status.OnShelf,
                    Genre = new List<Genre>() { Genre.GraphicNovel, Genre.Mystery, Genre.SciFi },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
                Library.Add(new Book()
                {
                    Title = "World War Z",
                    Author = "Max Brooks",
                    ISBN = 9780307346612,
                    Status = Status.OnShelf,
                    Genre = new List<Genre>() { Genre.SciFi, Genre.Adventure, Genre.Thriller },
                    DueDate = new DateTime(1800, 1, 1)
                }
                );
            }
            read.Close();
        }
        //Main method used to run the application
        public void Run()
        {
            Console.WriteLine("____________________________________________________");
            Console.WriteLine("Welcome to the Alexandria Memorial Library Database. \nPress any key to continue");
            Console.WriteLine("____________________________________________________");
            Console.ReadKey();
            Console.Clear();
            while (Loop)
            {
                Console.WriteLine("_____________________________________________");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1: Search for a book\n2: Donate a book\n3: Burn the Library\n4: Exit Application");
                Console.WriteLine("_____________________________________________");
                int selection = UserInput();
                while (selection > 4 || selection == 9999999)
                {
                    Console.WriteLine("I'm sorry, please select an option from the menu.");
                    Console.WriteLine();
                    selection = UserInput();
                }
                switch (selection)
                {
                    case 1:
                        List<Book> searchResults = Search(Library);
                        if (searchResults.Count > 0)
                        {
                            BookListView list = new BookListView(searchResults);
                            Console.Clear();
                            Console.WriteLine("_____________________________________________");
                            Console.WriteLine("Here are the books we found for your search.");
                            Console.WriteLine("_____________________________________________");
                            list.Display();
                            Console.WriteLine("_____________________________________________");
                            Console.WriteLine();
                            Console.WriteLine("Which book would you like to select?");
                            selection = UserInput();
                            while (selection < 1 || selection > searchResults.Count)
                            {
                                Console.WriteLine("I'm sorry, please select an option from the menu.");
                                Console.WriteLine();
                                selection = UserInput();
                            }
                            selection--;
                            Book interact = searchResults[selection];
                            BookView bookAction = new BookView(interact);
                            Console.Clear();
                            Console.WriteLine("_____________________________________________");
                            bookAction.Display();
                            Console.WriteLine("_____________________________________________");
                            Console.WriteLine();
                            Console.WriteLine("_____________________________________________");
                            if (interact.Status == Status.OnShelf)
                            {
                                Console.WriteLine("Would you like to check out this book? (y/n)");
                            }
                            else if (interact.Status == Status.CheckedOut)
                            {
                                Console.WriteLine("Would you like to return this book? (y/n)");
                            }
                            Console.WriteLine("_____________________________________________");
                            string response = Console.ReadLine().Trim().ToLower();
                            while (response != "y" && response != "n")
                            {
                                Console.WriteLine("I didn't understand that. Please try again.");
                                response = Console.ReadLine().Trim().ToLower();
                            }
                            if (response == "n")
                            {
                                Console.WriteLine();
                                break;
                            }
                            else if (response == "y" && interact.Status == Status.OnShelf)
                            {
                                interact.CheckOut();
                                Console.WriteLine();
                                Console.WriteLine("_____________________________________________");
                                Console.WriteLine("Thank you for checking out " + interact.Title + ".");
                                Console.WriteLine("It is due on " + interact.DueDate + ".");
                                Console.WriteLine("_____________________________________________");
                                Console.WriteLine();
                            }
                            else if (response == "y" && interact.Status == Status.CheckedOut)
                            {
                                interact.Return();
                                Console.WriteLine();
                                Console.WriteLine("_____________________________________________");
                                Console.WriteLine("Thank you for returning " + interact.Title + ".");
                                //overdue check
                                if (interact.DueDate < DateTime.Now && interact.DueDate > new DateTime(1900, 1, 1))
                                {
                                    Console.WriteLine("As a courtesy, your fee has been waived.");
                                    Console.WriteLine("Please return books before they are overdue in the future.");
                                }
                                Console.WriteLine("_____________________________________________");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("_____________________________________________");
                            Console.WriteLine("No books were found for your search.");
                            Console.WriteLine("_____________________________________________");
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        Donate();
                        break;
                    case 3:
                        Burn();
                        break;
                    case 4:
                        Exit();
                        break;
                }
                Console.WriteLine("Would you like to perform another action? (y/n)");
                string choice = Console.ReadLine().Trim().ToLower();
                while (choice != "y" && choice != "n")
                {
                    Console.WriteLine("I didn't understand that. Please try again.");
                    choice = Console.ReadLine().Trim().ToLower();
                }
                if (choice == "n")
                {
                    Loop = false;
                }
                Console.Clear();
            }
            Exit();
        }
        //Deletes all books from the library, creates 'Charred Remains.txt' to indicate a previous fire on future boots, and exits the application
        public void Burn()
        {
            Console.Clear();
            Console.WriteLine("_________________________________________________________");
            Console.WriteLine("WARNING: This action cannot be undone.");
            Console.WriteLine("This will set back human civilization centuries.");
            Console.WriteLine("Are you sure you'd like to continue?");
            Console.WriteLine("If yes, please type \'HAIL CAESAR\' to confirm.");
            Console.WriteLine("_________________________________________________________");
            string confirm = Console.ReadLine().ToLower().Trim();
            if (confirm == "hail caesar")
            {
                File.Delete("library.txt");
                this.Library = new List<Book>();
                var savefile = File.Create("Charred Remains.txt");
                savefile.Close();
                Exit();
            }
          else
          {
            Console.WriteLine("Thank you for not burning down the library again.");
          }
        }
        //Allows the user to input information, constructs a book object from this information and adds it to the library
        public void Donate()
        {
            //adds a book to library. asks user for input for each field
            Console.Clear();
            Console.WriteLine("____________________________________________________________");
            Console.WriteLine("Please enter the title of the book you would like to donate.");
            Console.WriteLine("____________________________________________________________");
            string title = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine("Please enter the author of the book you would like to donate.");
            Console.WriteLine("_____________________________________________________________");
            string author = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("_______________________________________________________________________");
            Console.WriteLine("Please enter the ISBN (13-digits) of the book you would like to donate.");
            Console.WriteLine("_______________________________________________________________________");
            //input validation for ISBN to be a 13 digit number
            ulong isbn = 0;
            while (isbn < 1000000000000 || isbn > 9999999999999)
            {
                try
                {
                    string i = Console.ReadLine().Trim();
                    isbn = ulong.Parse(i);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please only input a 13-digit number.");
                    Console.WriteLine();
                    isbn = 0;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Please only input a 13-digit number.");
                    Console.WriteLine();
                    isbn = 0;
                }
                if (isbn < 1000000000000 || isbn > 9999999999999)
                {
                    Console.WriteLine("Please only input a 13-digit number.");
                    Console.WriteLine();
                }
            }
            Console.Clear();
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine("Please select the genre of the book you would like to donate.");
            Console.WriteLine("Separate multiple genres with a space.");
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("_____________________________________________________________");
            foreach (var item in Enum.GetNames(typeof(Genre)))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("_____________________________________________________________");
            string a = Console.ReadLine().Trim().ToLower();
            Console.Clear();
            string[] genre = a.Split(' ');
            List<Genre> genres = new List<Genre>();
            foreach (string compare in genre)
            {
                foreach (Genre check in Enum.GetValues(typeof(Genre)))
                {
                    if (check.ToString().Trim().ToLower() == compare)
                    {
                        genres.Add(check);
                    }
                }
            }
            bool present = false;
            string bookTitle = title.Trim().ToLower();
            //checks against current library for matches so duplication doesnt occur
            for (int d = 0; d < Library.Count; d++)
            {
                Book book = Library[d];
                List<char> delimiter = new List<char>() { ' ', ',', '\'', '?', '.', '!', '"', ':', '-', '&' };
                string original = book.Title.Trim().ToLower();
                for (int b = 0; b < original.Length; b++)
                {
                    if (delimiter.Contains(original[b]))
                    {
                        original = original.Remove(b, 1);
                    }
                }
                for (int c = 0; c < bookTitle.Length; c++)
                {
                    if (delimiter.Contains(bookTitle[c]))
                    {
                        bookTitle = bookTitle.Remove(c, 1);
                    }
                }
                if (bookTitle == original)
                {
                    present = true;
                }
            }
            if (!present)
            {
                Book add = new Book(title, author, isbn, Status.OnShelf, genres);
                Library.Add(add);
            }
            else
            {
                Console.WriteLine("The library already has a copy of this book. Thank you for your generosity.");
            }
        }
        //Exits the application and calls the save method
        public void Exit()
        {
            Console.Clear();
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine("Thank you for using the Alexandria Memorial Library. Goodbye.");
            Console.WriteLine("_____________________________________________________________");
            Save();
            Environment.Exit(1);
        }
        //Loads Book objects from a text file and inserts them into the Library
        public void Load()
        {
            string line;
            StreamReader read = new StreamReader("library.txt");
            while ((line = read.ReadLine()) != null)
            {
                //splits attribute fields into separate strings
                string[] construct = line.Split('|');
                string title = construct[0];
                string author = construct[1];
                 ulong.TryParse(construct[2],out ulong isbn);
                //compares status string to Status enum to get proper Enum set
                string build = construct[3];
                Status status = Status.Unavailable;
                foreach (Status measure in Enum.GetValues(typeof(Status)))
                {
                    if (measure.ToString().Trim() == build)
                    {
                        status = measure;
                    }
                }
                //similar process for Genres, except adds to list for multiple Genres
                string[] genres = construct[4].Split(' ');
                List<Genre> genre = new List<Genre>();
                foreach (string check in genres)
                {
                    foreach (Genre compare in Enum.GetValues(typeof(Genre)))
                    {
                        if (compare.ToString().Trim() == check)
                        {
                            genre.Add(compare);
                        }
                    }
                }
                //parses Date string into proper DateTime type
                DateTime dueDate = new DateTime(1800, 1, 1);
                try
                {
                     dueDate = DateTime.Parse(construct[5]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error Loading Date for " + title + "! Setting to default due date.");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Error Loading Date for " + title + "! Setting to default due date.");
                }
                
                //Constructs new Book object and adds it to the library
                Book add = new Book(title, author, isbn, status, genre, dueDate);
                Library.Add(add);
            }
            read.Close();
        }
        //Saves current library to a text file
        public void Save()
        {
            StreamWriter write = new StreamWriter("library.txt");
            //writes out each attribute field using '|' as a delimiter for separation later upon load.
            char delimiter = '|';
            foreach (Book book in Library)
            {
                write.Write(book.Title);
                write.Write(delimiter);
                write.Write(book.Author);
                write.Write(delimiter);
                write.Write(book.ISBN);
                write.Write(delimiter);
                write.Write(book.Status);
                write.Write(delimiter);
                foreach (Genre category in book.Genre)
                {
                    write.Write(category);
                    write.Write(" ");
                }
                write.Write(delimiter);
                write.Write(book.DueDate.ToString());
                //separates each object on its own line
                write.WriteLine();
            }
            //closes and saves file
            write.Close();
        }
        //Searches a given library for a specific attriubute. Returns a new list of books
        public List<Book> Search(List<Book> library)
        {
            //instantiate new book list for search results to add to
            List<Book> searchResults = new List<Book>();
            //create list of items to remove from titles, etc (punctuation, spaces)
            List<char> delimiter = new List<char>() { ' ', ',', '\'', '?', '.', '!', '"', ':', '-', '&' };
            Console.Clear();
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("How would you like to search for a book?");
            Console.WriteLine("1: Title \n2: Author \n3: ISBN \n4: Genre \n5: Display All Books");
            Console.WriteLine("_____________________________________________");
            int selection = 0;
            while (selection == 0)
            {
                selection = UserInput();
                if (selection <= 0 || selection > 5)
                {
                    Console.WriteLine("Please select a valid option.");
                    selection = 0;
                }
            }
            //user picks an attribute of the Book object to search for
            Console.WriteLine("_____________________________________________");
            switch (selection)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("_____________________________________________");
                    Console.WriteLine("Please enter a title to search for: ");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("_____________________________________________");
                    Console.WriteLine("Please enter an author to search for: ");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("_____________________________________________");
                    Console.WriteLine("Please enter an ISBN to search for: ");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("_____________________________________________");
                    Console.WriteLine("Please enter an available genre from the list below: ");
                    Console.WriteLine("_____________________________________________");
                    Console.WriteLine();
                    Console.WriteLine("_____________________________________________");
                    foreach (var item in Enum.GetNames(typeof(Genre)))
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case 5:
                    foreach (Book book in library)
                    {
                        searchResults.Add(book);
                    }
                    return searchResults;
            }
            Console.WriteLine("_____________________________________________");
            Console.WriteLine();
            string compare = Console.ReadLine().ToLower().Trim();
            //second switch case uses intial option to keep consistency
            switch (selection)
            {
                case 1:
                    foreach (Book book in library)
                    {
                        string title = book.Title;
                        for (int i = 0; i < title.Length; i++)
                        {
                            if (delimiter.Contains(title[i]))
                            {
                                title = title.Remove(i, 1);
                            }
                        }
                        title = title.ToLower();
                        if (title.Contains(compare))
                        {
                            searchResults.Add(book);
                        }
                    }
                    break;
                case 2:
                    foreach (Book book in library)
                    {
                        string author = book.Author;
                        for (int i = 0; i < author.Length; i++)
                        {
                            if (delimiter.Contains(author[i]))
                            {
                                author = author.Remove(i, 1);
                            }
                        }
                        author = author.ToLower();
                        if (author.Contains(compare))
                        {
                            searchResults.Add(book);
                        }
                    }
                    break;
                case 3:
                    ulong check = 0;
                    while (check == 0)
                    {
                        try
                        {
                            check = ulong.Parse(compare);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please only input numbers.");
                            compare = Console.ReadLine().Trim();
                        }
                    }
                    foreach (Book book in library)
                    {
                        ulong isbn = book.ISBN;

                        if (isbn == check)
                        {
                            searchResults.Add(book);
                        }
                    }
                    break;
                case 4:
                    foreach (Book book in library)
                    {
                        foreach (Genre genre in Enum.GetValues(typeof(Genre)))
                        {
                            string genreCheck = genre.ToString().ToLower();
                            if (book.Genre.Contains(genre))
                            {
                                if (genreCheck == compare)
                                {
                                    searchResults.Add(book);
                                }
                            }
                        }
                    }
                    break;
            }
            return searchResults;
        }
        //used for exception catching and input validation. returns 9999999 on an error.
        public int UserInput()
        {
            int output = 0;

            string input = Console.ReadLine().Trim().ToLower();
            try
            {
                output = int.Parse(input);
            }
            catch (FormatException)
            {
                output = 9999999;
            }
            return output;
        }
    }
}