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
        }

        public void Run()
        {
            BookListView library = new BookListView(Library);
            library.Display();
            Console.WriteLine();
            Book dune = Library[0];
            dune.CheckOut();
            Library[0] = dune;
            BookListView test = new BookListView(Library);
            test.Display();
        }

        public void Search()
        {
            Console.WriteLine("To Be Implemented");
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
