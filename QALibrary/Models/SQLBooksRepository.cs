using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QALibrary.Models
{
    public class SQLBooksRepository:IBooksRepository
    {
        BooksEntities db;
        public SQLBooksRepository()
        {
            db = new BooksEntities();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return db.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return db.Books.Single(b => b.BookID == id);
        }
    }
}