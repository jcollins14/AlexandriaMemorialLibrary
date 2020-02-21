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
        //public List<Enum> Genre = new List<Enum>();
        public Status Status { get; set; }
        //public DateTime DueDate { get; set; }

        public Book(string title, string author, ulong isbn, Status status)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
            //this.Genre = genre;
            this.Status = status;
            //this.DueDate = dueDate;
        }
        public Book()
        {

        }


    }
}
