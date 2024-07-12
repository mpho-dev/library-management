using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementConsole.Model
{
    internal class Base
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public Base()
        {
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }

    }
}
