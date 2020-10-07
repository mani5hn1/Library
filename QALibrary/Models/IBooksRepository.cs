using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QALibrary.Models
{
    public interface IBooksRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
    }
}
