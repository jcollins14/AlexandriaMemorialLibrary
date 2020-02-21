using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandriaMemorialLibrary
{
    class BookView
    {
        private Book ThisBook { get; set; }

        public BookView(Book book)
        {
            this.ThisBook = book;
        }

        public void Display()
        {
            Console.WriteLine("Title: " + ThisBook.Title);
            Console.WriteLine("Author: " + ThisBook.Author);
            Console.WriteLine("Status: " + ThisBook.Status.ToString());

            //Console.Write("Genre(s): ");
            //foreach (Genre genre in ThisBook.Genre)
            //{
            //    Console.Write(genre + " ");
            //}

            Console.WriteLine(ThisBook.ISBN);

            if (ThisBook.Status.Equals(Status.CheckedOut))
            {
                Console.WriteLine("Due Date: " + ThisBook.DueDate);
            }
        }
    }
}
