using System;

namespace AlexandriaMemorialLibrary
{
    class BookView
    {
        private Book ThisBook { get; set; }
        public BookView(Book book)
        {
            this.ThisBook = book;
        }
        //Display a single book
        public void Display()
        {
            Console.WriteLine("Title: " + ThisBook.Title);
            Console.WriteLine("Author: " + ThisBook.Author);
            Console.WriteLine("Status: " + ThisBook.Status);
            //display multiple genres in the same line
            Console.Write("Genre(s): ");
            foreach (Genre genre in ThisBook.Genre)
            {
                Console.Write(genre + " ");
            }
            Console.WriteLine();
            Console.WriteLine("ISBN: " + ThisBook.ISBN);
            //if book is checked out, display expected due date
            if (ThisBook.Status.Equals(Status.CheckedOut))
            {
                Console.WriteLine("Due Date: " + ThisBook.DueDate);
            }
            //checks due date to determine if book is overdue.
            if (ThisBook.DueDate < DateTime.Now && ThisBook.DueDate > new DateTime(1900,1,1))
            {
                Console.WriteLine("This book is Overdue.");
            }
        }
    }
}
