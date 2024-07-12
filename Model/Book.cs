using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementConsole.Model
{
    internal class Book : Base
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public virtual List<Author> Author { get; set; }
        public virtual List<Category> Categories { get; set; }

        public Book() : base()
        {
        }

    }
}
