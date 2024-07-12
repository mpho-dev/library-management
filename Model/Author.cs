using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementConsole.Model
{
    internal class Author : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<Book> Books { get; set; }

        public Author() : base() 
        { 
        }
        
    }
}
