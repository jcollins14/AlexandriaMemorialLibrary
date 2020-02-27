using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandriaMemorialLibrary
{
   class Book:IComparable<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public ulong ISBN { get; set; }

        public List<Genre> Genre = new List<Genre>();
        public Status Status { get; set; }
        public DateTime DueDate { get; set; }

        public Book()
        {
        }
        public Book(string title, string author, ulong isbn, Status status, List<Genre> genre)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
            this.Genre = genre;
            this.Status = status;
            this.DueDate = new DateTime(1800, 1, 1);
            
        }
        public Book(string title, string author, ulong isbn, Status status, List<Genre> genre, DateTime dueDate)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
            this.Genre = genre;
            this.Status = status;
            this.DueDate = dueDate;
        }
        
        //set status to checked out and set due date to two weeks from today
        public void CheckOut()
        {
                this.Status = Status.CheckedOut;
                this.DueDate = DateTime.Now.AddDays(14);
        }

        //reset book status to OnShelf;
        public void Return()
        {
            this.Status = Status.OnShelf;
        }

        //allows comparing books by title
        public int CompareTo(Book other)
        {
            return Title.CompareTo(other.Title);
        }
    }
}
