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
        


        public LibraryController()
        {
            
            
            Library = new List<Book>();
          
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
