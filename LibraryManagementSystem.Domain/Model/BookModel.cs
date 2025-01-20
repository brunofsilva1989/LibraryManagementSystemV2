using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Model
{
    public class BookModel
    {
        public BookModel(int id, string title, string author, string isbn, int yearPublication)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = isbn;
            YearPublication = yearPublication;
        }

        public BookModel()
        {
            
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int YearPublication { get; set; }
    }
}
