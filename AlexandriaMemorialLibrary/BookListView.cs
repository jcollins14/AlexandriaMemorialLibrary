using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandriaMemorialLibrary
{
    class BookListView
    {
        private List<Book> Library = new List<Book>();

        public BookListView(List<Book> library)
        {
            this.Library = library;
        }

        public void Display()
        {
            int i = 1;

            //iterate through each book recorded in the library to display all books
            foreach (Book currentBook in Library)
            {
                string listing = i + ": " + currentBook.Title + ", by " + currentBook.Author;

                //add "<CHECKED OUT>" to book string if the book isnt available
                if (currentBook.Status.Equals(Status.CheckedOut))
                {
                    if (i < 10)
                    {
                        listing = listing.Insert(2, " <CHECKED OUT>");
                    }
                    else if (i < 100)
                    {
                        listing.Insert(3, " <CHECKED OUT>");
                    }
                    else if (i < 1000)
                    {
                        listing.Insert(4, " <CHECKED OUT>");
                    }

                }
                i++;
                Console.WriteLine(listing);
            }
        }
    }
}
