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
        public List<string> genres = new List<string>();
        public enum Genre {
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
        public Status Status { get; set; }
        

        public Book(string title, string author, ulong isbn, Status status)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
            this.Status = status;
            
        }
        public Book()
        {

        }


    }
}
