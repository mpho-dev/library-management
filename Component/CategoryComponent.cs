using LibraryManagementConsole.Controller;
using LibraryManagementConsole.Interfaces;
using LibraryManagementConsole.Model;

namespace LibraryManagementConsole.Component
{
    internal class CategoryComponent : IGenericComponent
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
                        Console.WriteLine("Navigating back to Main Menu");
                        break;
                    default:
                        Console.WriteLine("Invalid option entered");
                        break;
                }
                Program.SystemPause();
            } while (choice != 5);
        }

        public static void DisplayMenu()
        {
            Program.Header();
            Console.WriteLine("1. Display Categories");
            Console.WriteLine("2. Add A New Category");
            Console.WriteLine("3. Update Category");
            Console.WriteLine("4. Remove Category");
            Console.WriteLine("5. Main Menu");
        }

        public static void DisplayAll()
        {
            CategoryController.GetAll().ForEach(c => {
                Console.WriteLine($"# \t\t{c.Id}");
                Console.WriteLine($"Name: \t\t{c.Name}");
                Console.WriteLine($"Date Created: \t{c.DateCreated}");
                Console.WriteLine($"Date Modified: \t{c.DateModified}");
            });
        }
        public static void DisplaySingle(int Id)
        {
            Category category = CategoryController.Get(Id);

            Console.WriteLine($"# \t\t{category.Id}");
            Console.WriteLine($"Name: \t\t{category.Name}");
            Console.WriteLine($"Date Created: \t{category.DateCreated}");
            Console.WriteLine($"Date Modified: \t{category.DateModified}");
        }

        public static void Add()
        {
            Category newCategory = new Category();

            Console.Write("Enter the name of the new Category: ");
            newCategory.Name = Console.ReadLine() ?? "";

            newCategory.DateCreated = DateTime.Now;
            newCategory.DateModified = DateTime.Now;

            CategoryController.Add(newCategory);

            Console.WriteLine($"{newCategory.Name} has been successfully saved");
        }

        public static void Remove()
        {
            Console.Write("Enter the ID of the category you wish to remove: ");
            int Id = Convert.ToInt32(Console.ReadLine()); 
            Category oldCategory = CategoryController.Get(Id);

            CategoryController.Remove(oldCategory);

            Console.WriteLine($"{oldCategory.Name} has been successfully removed");
        }

        public static void Update()
        {
            Category newCategory = new Category();
            Console.WriteLine("Enter the ID of the category you wish to update: ");
            int Id = Convert.ToInt32(Console.ReadLine());

            Category oldCategory = CategoryController.Get(Id);
            newCategory = oldCategory;

            Console.Write("Enter the name of the category: ");
            newCategory.Name = Console.ReadLine() ?? "";
            newCategory.DateModified = DateTime.Now;

            CategoryController.Update(Id, newCategory);

            Console.WriteLine($"{newCategory.Name} has been successfully updated");
        }
    }
}
