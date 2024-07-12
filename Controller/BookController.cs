using LibraryManagementConsole.Model;
using System.Data.Common;

namespace LibraryManagementConsole.Controller
{
    internal class BookController : GenericController<Book>
    {
        public static Book GetByISBN(string ISBN)
        {
            return new Book();
        }
    }
}
