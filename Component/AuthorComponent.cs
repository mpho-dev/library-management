using LibraryManagementConsole.Controller;
using LibraryManagementConsole.Interfaces;
using LibraryManagementConsole.Model;

namespace LibraryManagementConsole.Component
{
    internal class AuthorComponent : IGenericComponent
    {
        public static void Manage()
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
                        DisplayAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Remove();
                        break;
                    case 5:
                        Console.WriteLine("Navigating to Main Menu ");
                        break;
                    default:
                        Console.WriteLine("Invalid option entered");
                        break;
                }
                Program.SystemPause();
            } while (choice != 4);
        }

        public static void DisplayMenu()
        {
            Program.Header();
            Console.WriteLine("1. Display all Authors");
            Console.WriteLine("2. Add A New Author");
            Console.WriteLine("3. Update Author's Information");
            Console.WriteLine("4. Remove an Author");
            Console.WriteLine("5. Main Menu");
        }

        public static void DisplayAll()
        {
            AuthorController.GetAll().ForEach(author => {
                Console.WriteLine($"ID: \t\t{author.Id}");
                Console.WriteLine($"First Name: \t{author.FirstName}");
                Console.WriteLine($"Last Name: \t{author.LastName}");
                Console.WriteLine();
            });
        }

        public static void DisplaySingle(int Id)
        {
            Author author = AuthorController.Get(Id);

            Console.WriteLine($"ID: \t\t{author.Id}");
            Console.WriteLine($"First Name: \t{author.FirstName}");
            Console.WriteLine($"Last Name: \t{author.LastName}");
        }

        public static void Add()
        {
            Author newAuthor = new Author();
            
            Console.Write("Enter the First Name: ");
            newAuthor.FirstName = Console.ReadLine() ?? "";

            Console.Write("Enter the Last Name: ");
            newAuthor.LastName = Console.ReadLine() ?? "";

            AuthorController.Add(newAuthor);

            Console.WriteLine($"{newAuthor.FirstName} has been successfully saved");

        }
        public static void Remove()
        {
            Console.WriteLine("Enter the ID of the Author you wish to remove: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Author oldAuthor = AuthorController.Get(Id);

            AuthorController.Remove(oldAuthor);

            Console.WriteLine($"{oldAuthor.FirstName} has been successfully removed");
        }

        public static void Update()
        {
            Console.Write("Enter the ID of the Author you wish to update: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Author oldAuthor = AuthorController.Get(Id);

            Author newAuthor = oldAuthor;

            Console.Write("Do you want to update the first name? (yes/no): ");
            if (Console.ReadLine() == "yes")
            {
                Console.Write("Enter the First Name: ");
                newAuthor.FirstName = Console.ReadLine() ?? "";
            }

            Console.Write("Do you want to update the last name? (yes/no): ");
            if (Console.ReadLine() == "yes")
            {
                Console.Write("Enter the Last Name: ");
                newAuthor.LastName = Console.ReadLine() ?? "";
            }

            AuthorController.Update(Id, newAuthor);

            Console.WriteLine($"{newAuthor.FirstName} has been successfully updated");
        }
    }
}
