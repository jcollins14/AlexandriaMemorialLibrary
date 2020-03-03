using System;
using System.Collections.Generic;

namespace AlexandriaMemorialLibrary
{
    class BookListView
    {
        private List<Book> Library = new List<Book>();
        public BookListView(List<Book> library)
        {
            this.Library = library;
        }
        //Display all books in the passed paramater book list
        public void Display()
        {
            int i = 1;
            Library.Sort();
            //iterate through each book recorded in the library to display all books
            foreach (Book currentBook in Library)
            {
                string listing = i + ": " + currentBook.Title + ", by " + currentBook.Author;
                //add "<CHECKED OUT>" to book string if the book isnt available
                if (currentBook.Status.Equals(Status.CheckedOut))
                {
                    listing += " <CHECKED OUT>";
                }
                i++;
                Console.WriteLine(listing);
            }
        }
    }
}
