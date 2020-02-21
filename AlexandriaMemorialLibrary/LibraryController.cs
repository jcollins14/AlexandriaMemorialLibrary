using System;
using System.Collections.Generic;
using System.Text;
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

    class LibraryController
    {
        private List<Book> Library { get; set; }
        private List<Book.Genre> genres { get; set; }
        
        

        public LibraryController()
        {
            var arrayOfEnums = Enum.GetValues(typeof(Genre));//.Cast<Genre>().ToList();
            Console.WriteLine(arrayOfEnums);
            Library = new List<Book>();
            //genres = new List<Book.Genre>();
            //genres.Add(Enum.GetNames (typeof(Genre)).Cast().ToList());
           // genres.Add(Genre.SciFi);
            Library.Add(new Book()
            {
                Title = "Dune",
                Author = "Frank Herbert",
                ISBN = 9780593099322,
                Status = Status.OnShelf,
                

        }
            ) ;
        }

        public void Run()
        {
            Console.WriteLine("Hello World");
            BookListView library = new BookListView(Library);
            library.Display();
            BookView view = new BookView(Library[0]);
            view.Display();
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
