using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementConsole.Interfaces
{
    internal interface IGenericComponent
    {
        public abstract static void Manage();
        public abstract static void DisplayMenu();
        public abstract static void DisplayAll();
        public abstract static void DisplaySingle(int Id);
        public abstract static void Add();
        public abstract static void Remove();
        public abstract static void Update();
    }
}
