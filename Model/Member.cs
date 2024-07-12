using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementConsole.Model
{
    internal class Member : Base
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual List<Loan> Loans { get; set; }

        public Member() : base()
        {
        }

    }
}
