using LibraryManagementConsole.Controller;
using LibraryManagementConsole.Interfaces;
using LibraryManagementConsole.Model;
using Microsoft.IdentityModel.Tokens;

namespace LibraryManagementConsole.Component
{
    internal class BookComponent : IGenericComponent
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
                        Console.WriteLine("Navigating to the Main Menu.........");
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
            Console.WriteLine("1. Display Books");
            Console.WriteLine("2. Add A New Book");
            Console.WriteLine("3. Update Book Information");
            Console.WriteLine("4. Remove Book");
            Console.WriteLine("5. Main Menu");
        }

        public static void DisplayAll()
        {
            List<Book> books = BookController.GetAll();
            books.ForEach(book => {
                Console.WriteLine($"ISBN: \t\t{book.ISBN}");
                Console.WriteLine($"Title: \t\t{book.Title}");
                Console.WriteLine($"Publication Year: \t{book.PublicationYear.ToString()}");
                Console.WriteLine($"Author: \t\t{book.Author.First().FirstName}");
                Console.WriteLine($"Category: \t\t{book.Categories.First().Name}");
                Console.WriteLine();
            });
        }
        public static void DisplaySingle(int Id)
        {
            Book book = BookController.Get(Id);
            Console.WriteLine($"ISBN: \t\t{book.ISBN}");
            Console.WriteLine($"Title: \t\t{book.Title}");
            Console.WriteLine($"Publication Year: \t{book.PublicationYear.ToString()}");
            Console.WriteLine($"Author: \t\t{book.Author.First().FirstName}");
            Console.WriteLine($"Category: \t\t{book.Categories.First().Name}");
        }

        public static void Add()
        {
            Book book = new Book();

            Console.Write("Enter the ISBN for the book: ");
            book.ISBN = Console.ReadLine() ?? "";

            Console.Write("Enter the Title: ");
            book.Title = Console.ReadLine() ?? "";


            Console.Write("Enter the Publication Year: ");
            book.PublicationYear = Convert.ToInt32(Console.ReadLine());

            book.DateCreated = DateTime.Now;
            book.DateModified = DateTime.Now;


            Console.Write("Is the Author existing in the database? (yes/no): ");
            if (Console.ReadLine() == "yes")
            {
                //Handle retrieval of author
                Console.Write("Enter the first name of the author: ");
                string fName = Console.ReadLine() ?? "";

                Console.Write("Enter the last name of the author: ");
                string lName = Console.ReadLine() ?? "";

                Author author = AuthorController.Get(fName, lName);
                if (!author.FirstName.IsNullOrEmpty())
                {
                    book.Author.Add(author);
                } else
                {
                    Console.WriteLine("Could not find the author specified");
                }

            } else
            {
                Console.Write("Do you want to create a new author entry and link to book? (yes/no): ");
                if (Console.ReadLine() == "yes")
                {
                    Author author = new Author();
                    Console.Write("Enter the first name: ");
                    author.FirstName = Console.ReadLine() ?? "";
                    Console.Write("Enter the last name: ");
                    author.LastName = Console.ReadLine() ?? "";
                    book.Author = [];
                    book.Author.Add(author);
                }
            }

            Console.Write("Is there an existing category for the book? (yes/no): ");
            if (Console.ReadLine() == "yes")
            {
                Console.Write("Enter the category name: ");
                string CatName = Console.ReadLine() ?? "";

                Category category = CategoryController.Get(CatName);
                if (!category.Id.ToString().IsNullOrEmpty())
                {
                    book.Categories.Add(category);
                } else
                {
                    Console.WriteLine("Could not find Category specified");
                }
            } else
            {
                Console.Write("Would you like to add a new category? (yes/no): ");
                if (Console.ReadLine() == "yes")
                {
                    Category category = new Category();
                    Console.Write("Enter the name for the category: ");
                    string catName = Console.ReadLine() ?? "";
                    category.Name = catName;
                    book.Categories = [];
                    book.Categories.Add(category);
                }
            }

            BookController.Add(book);
        }

        public static void Remove()
        {
            Console.Write("Enter the ISBN for the book you wish to remove: ");
            string isbn = Console.ReadLine() ?? "";
            Book book = BookController.GetByISBN(isbn);

            if (book != null)
            {
                BookController.Remove(book);
            } else
            {
                Console.WriteLine("Could not find book linked to ISBN");
            }
        }

        public static void Update()
        {
            Console.Write("Enter the ISBN for the book you wish to remove: ");
            string isbn = Console.ReadLine() ?? "";
            Book book = BookController.GetByISBN(isbn);

            Console.Write("Would you like to update the title? (yes/no): ");
            if (Console.ReadLine() == "yes")
            {
                Console.Write("Enter the new title: ");
                book.Title = Console.ReadLine() ?? "";
            }

            Console.Write("Would you like to update the publication year? (yes/no): ");
            if (Console.ReadLine() == "yes")
            {
                Console.Write("Enter the new publication year: ");
                book.PublicationYear = Convert.ToInt32(Console.ReadLine());
            }

            //Implement function to update the author and category of the book
        }

    }
}
