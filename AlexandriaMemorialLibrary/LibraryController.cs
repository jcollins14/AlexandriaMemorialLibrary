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
            List<Book> search = SearchTitle(Library);
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

        public List<Book> SearchTitle(List<Book> library)
        {
            List<Book> searchResults = new List<Book>();

            string search = Console.ReadLine().ToLower().Trim();

            foreach (Book book in library)
            {
                string title = book.Title;
                List<char> delimiter = new List<char>() { ' ', ',', '\'', '?', '.', '!', '"', ':', '-', '&' };
                for (int i = 0; i < title.Length; i++)
                {
                    if (delimiter.Contains(title[i]))
                    {
                        title = title.Remove(i,1);
                    }
                }
                title = title.ToLower();
                if (title.Contains(search))
                {
                    searchResults.Add(book);
                }
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
