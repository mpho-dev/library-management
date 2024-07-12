using LibraryManagementConsole.Component;
using LibraryManagementConsole.Controller;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Xml.Serialization;

namespace LibraryManagementConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;

            do
            {
                DisplayMenu();
                Console.Write("Enter Option: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        Console.WriteLine("Navigating to Book Management");
                        SystemPause();
                        BookComponent.Manage();
                        break;
                    case 3:
                        Console.WriteLine("Navigating to Author Management");
                        SystemPause();
                        AuthorComponent.Manage();
                        break;
                    case 4:
                        Console.WriteLine("Navigating to Category Management");
                        SystemPause();
                        CategoryComponent.Manage();
                        break;
                    case 5:
                        Console.WriteLine("Navigating to Loans Management");
                        SystemPause();
                        LoanComponent.Manage();
                        break;
                    case 6:
                        Console.WriteLine("Navigating to Member Management");
                        SystemPause();
                        MemberComponent.Manage();
                        break;
                    case 7:
                        Console.WriteLine("Quiting Program");
                        break;
                    default:
                        Console.WriteLine("Invalid option entered");
                        break;
                }
                SystemPause();
            } while (choice != 7);
        }

        public static void Header()
        {
            Console.WriteLine("========================");
            Console.WriteLine("\tLibrary Management System\t");
            Console.WriteLine("========================");
        }
        
        public static void DisplayMenu()
        {
            Header();
            Console.WriteLine("1. Show Library listings");
            Console.WriteLine("2. Manage Books");
            Console.WriteLine("3. Manage Authors");
            Console.WriteLine("4. Manage Categories");
            Console.WriteLine("5. Manage Loans");
            Console.WriteLine("6. Manage Members");
            Console.WriteLine("7. Quit Program");
        }

        public static void SystemPause()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}
