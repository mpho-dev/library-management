using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementConsole.Model
{
    internal class Loan : Base
    {
        public virtual int BookId { get; set; }
        public virtual int MemberId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public virtual Book Book { get; set; }
        public virtual Member Member { get; set; }
        
        public Loan() : base()
        {
        }
    }
}
