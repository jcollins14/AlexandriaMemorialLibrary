using System;
using System.Collections.Generic;
using System.Text;

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
        Philosophy
    }

    class LibraryController
    {
        private List<Book> Library { get; set; }

        public LibraryController()
        {
            Library = new List<Book>();
            Library.Add(new Book()
            {
                Title = "Dune",
                Author = "Frank Herbert",
                ISBN = 9780593099322,
                Status = Status.OnShelf,
                //Genre = new List<Genre>() { Genre.SciFi, Genre.Adventure, Genre.Fantasy }
                DueDate = new DateTime(1800,1,1)
            }
            );
            Library.Add(new Book()
            {
                Title = "Radicalized",
                Author = "Cory Doctorow",
                ISBN = 9781250228598,
                Status = Status.OnShelf,
                //Genre = new List<Genre>() { Genre.SciFi, Genre.Adventure, Genre.Fantasy }
                DueDate = new DateTime(1800, 1, 1)
            }
            );
            Library.Add(new Book()
            {
                Title = "Every Tool's a Hammer",
                Author = "Adam Savage",
                ISBN = 9781471185113,
                Status = Status.OnShelf,
                //Genre = new List<Genre>() { Genre.SciFi, Genre.Adventure, Genre.Fantasy }
                DueDate = new DateTime(1800, 1, 1)
            }
            );
            Library.Add(new Book()
            {
                Title = "Mud, Sweat, and Tears",
                Author = "Bear Grylls",
                ISBN = 9780062124135,
                Status = Status.OnShelf,
                //Genre = new List<Genre>() { Genre.SciFi, Genre.Adventure, Genre.Fantasy }
                DueDate = new DateTime(1800, 1, 1)
            }
            );
            Library.Add(new Book()
            {
                Title = "World War Z",
                Author = "Max Brooks",
                ISBN = 9780307346612,
                Status = Status.OnShelf,
                //Genre = new List<Genre>() { Genre.SciFi, Genre.Adventure, Genre.Fantasy }
                DueDate = new DateTime(1800, 1, 1)
            }
            );
        }

        public void Run()
        {
            List<Book> search = Search(Library);
            BookListView list = new BookListView(search);
            if (search.Count == 0)
            {
                Console.WriteLine("I'm sorry, there were no results found.");
            }
            else
            {
                list.Display();
            }

        }

        public List<Book> Search(List<Book> library)
        {
            List<Book> searchResults = new List<Book>();
            List<char> delimiter = new List<char>() { ' ', ',', '\'', '?', '.', '!', '"', ':', '-', '&' };
            Console.Clear();
            Console.WriteLine("Which Attribute would you like to Search for?");
            Console.WriteLine("1: Title");
            Console.WriteLine("2: Author");
            Console.WriteLine("3: ISBN");

            int selection = 0;

            while (selection == 0)
            {
                selection = UserInput();

                if (selection <= 0 || selection > 3)
                {
                    Console.WriteLine("Please select a valid option.");
                    selection = 0;
                }
            }
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
            }
            string compare = Console.ReadLine().ToLower().Trim();
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
            }
            
            return searchResults;
        }

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
    }
}
