using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandriaMemorialLibrary
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public ulong ISBN { get; set; }
        public List<Genre> Genre = new List<Genre>();
        public Status Status { get; set; }
        public DateTime DueDate { get; set; }

        public Book(string title, string author, ulong isbn, Status status, List<Genre> genre, DateTime dueDate)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
            this.Genre = genre;
            this.Status = status;
            this.DueDate = dueDate;
        }
        public Book()
        {

        }

        public void CheckOut()
        {
            this.Status = Status.CheckedOut;
            this.DueDate = DateTime.Now.AddDays(14);
        }

        public void Return()
        {
            this.Status = Status.OnShelf;
        }
    }
}
