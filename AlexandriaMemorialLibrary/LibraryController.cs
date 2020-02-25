using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using static AlexandriaMemorialLibrary.Book;

namespace AlexandriaMemorialLibrary
{
    
    enum Status
    {
        OnShelf,
        CheckedOut,
        Processing,
        Unavailable
    }

    enum Genre
    {
        Fantasy,
        SciFi,
        Mystery,
        Thriller,
        Romance,
        Manga,
        SelfHelp,
        Travel,
        Adventure,
        GraphicNovel,
        Philosophy,
        Biography
    }

    class LibraryController
    {
        private List<Book> Library { get; set; }
        


        public LibraryController()
        {
            if (!File.Exists("library.txt"))
            {
                File.Create("library.txt");
            }
            StreamReader read = new StreamReader("library.txt");
            
            Library = new List<Book>();

            //loads default library if unable to read file
            if (read.ReadLine() == null)
            {
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
                    Title = "World War Z",
                    Author = "Max Brooks",
                    ISBN = 9780307346612,
                    Status = Status.OnShelf,
                    Genre = new List<Genre>() { Genre.SciFi, Genre.Adventure, Genre.Thriller },
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
                Title = "Journey to the Center of the Earth",
                Author = "Jules Verne",
                ISBN = 9780553213973,
                Status = Status.OnShelf,
                Genre = new List<Genre> { Genre.SciFi, Genre.Adventure },
                DueDate = new DateTime(1800, 1, 1)
            });
            }
        }

        public void Run()
        {
            BookListView listview = new BookListView(Library);
            listview.Display();
        }

        public List<Book> Search(List<Book> library)
        {
            //instantiate new book list for search results to add to
            List<Book> searchResults = new List<Book>();
            //create list of items to remove from titles, etc (punctuation, spaces)
            List<char> delimiter = new List<char>() { ' ', ',', '\'', '?', '.', '!', '"', ':', '-', '&' };
            Console.Clear();

            Console.WriteLine("Welcome to the Alexandria Memorial Library Database \nPress any key to continue");
            Console.ReadKey();
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
            BookListView listDisplay = new BookListView(library);
            //user picks an attribute of the Book object to search for
            Console.WriteLine("_____________________________________________");
            switch (selection)
            {
               
                case 1:
                    Console.WriteLine("Please enter a title to search for: ");
                    break;
                case 2:
                    Console.WriteLine("Please enter an author to search for: ");
                    break;
                case 3:
                    Console.WriteLine("Please enter an ISBN to search for: ");
                    break;
                case 4:
                    Console.WriteLine("Please enter an available genre from the list below: ");
                    foreach (var item in Enum.GetNames(typeof(Genre)))
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case 5:
                    listDisplay.Display();
                    break;
            }
            Console.WriteLine("_____________________________________________");
        

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
                    foreach (Book book in library)
                    {
                        ulong check = 0;
                        ulong isbn = book.ISBN;
                        try
                        {
                            check = ulong.Parse(compare);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please only input numbers.");
                        }
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
                            string check = genre.ToString().ToLower();
                            if (book.Genre.Contains(genre))
                            {
                                if (check == compare)
                                {
                                    searchResults.Add(book);
                                }
                            }
                        }
                    }
                    break;
            }
           // Book checkout = new Book();
            //checkout.CheckOut();
            //selection = UserInput();
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
                Console.WriteLine("I'm sorry, please select a valid integer.");
            }

            return output;
        }

        public void Load()
        {
            string line;
            StreamReader read = new StreamReader("library.txt");
            while ((line = read.ReadLine()) != null)
            {
                //splits attribute fields into separate strings
                string[] construct = line.Split('@');

                string title = construct[0];

                string author = construct[1];

                ulong isbn = ulong.Parse(construct[2]);

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
                DateTime dueDate = DateTime.Parse(construct[5]);

                //Constructs new Book object and adds it to the library
                Book add = new Book(title, author, isbn, status, genre, dueDate);
                Library.Add(add);
            }
        }
        public void Save()
        {
            StreamWriter write = new StreamWriter("library.txt");

            //writes out each attribute field using '@' as a delimiter for separation later upon load.
            foreach (Book book in Library)
            {
                write.Write(book.Title);
                write.Write("@");
                write.Write(book.Author);
                write.Write("@");
                write.Write(book.ISBN);
                write.Write("@");
                write.Write(book.Status);
                write.Write("@");
                foreach (Genre category in book.Genre)
                {
                    write.Write(category);
                    write.Write(" ");
                }
                write.Write("@");
                write.Write(book.DueDate.ToString());

                //separates each object on its own line
                write.WriteLine();
            }
            //closes and saves file
            write.Close();
        }

        public void Burn()
        {
            //delete all books in library and clear out library db text file
            //to be implemented
        }

        public void Donate()
        {
            //adds a book to library. asks user for input for each field
            //checks against current library for matches so duplication doesnt occur
            //to be implemented
        }
    }
}
