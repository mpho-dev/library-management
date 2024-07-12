using LibraryManagementConsole.Controller;
using LibraryManagementConsole.Interfaces;
using LibraryManagementConsole.Model;

namespace LibraryManagementConsole.Component
{
    internal class MemberComponent : IGenericComponent
    {
        public static void Manage()
        {
            int choice = 0;
            do
            {
                DisplayMenu();
                Console.WriteLine("Enter Option: ");
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
            Console.WriteLine("1. Display Members");
            Console.WriteLine("2. Add A New Member");
            Console.WriteLine("3. Update Member");
            Console.WriteLine("4. Remove Member");
            Console.WriteLine("5. Main Menu");
        }
        public static void DisplayAll()
        {
            MemberController.GetAll().ForEach(m => {
                Console.WriteLine($"# \t\t{m.Id}");
                Console.WriteLine($"First Name: \t{m.FirstName}");
                Console.WriteLine($"Last Name: \t{m.LastName}");
                Console.WriteLine($"Email: \t\t{m.Email}");
            });
        }

        public static void DisplaySingle(int Id)
        {
            Member member = MemberController.Get(Id);

            Console.WriteLine($"# \t\t{member.Id}");
            Console.WriteLine($"First Name: \t{member.FirstName}");
            Console.WriteLine($"Last Name: \t{member.LastName}");
            Console.WriteLine($"Email: \t\t{member.Email}");
        }

        public static void Add()
        {
            Member newMember = new Member();
            
            Console.Write("Enter the first name: ");
            newMember.FirstName = Console.ReadLine() ?? "";

            Console.Write("Enter the last name: ");
            newMember.LastName = Console.ReadLine() ?? "";
            
            Console.Write("Enter the email address: ");
            newMember.Email = Console.ReadLine() ?? "";

            newMember.Loans = [];
            MemberController.Add(newMember);

            Console.WriteLine($"{newMember.FirstName} has been successfully saved");
        }

        public static void Remove() 
        {
            Console.Write("Enter the ID of the member you wish to remove: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Member oldMember = MemberController.Get(Id);
            MemberController.Remove(oldMember);

            Console.WriteLine($"{oldMember.FirstName} has been succesfully removed");
        }

        public static void Update()
        {
            Console.WriteLine("Enter the ID of the member you wish to update: ");
            int Id = Convert.ToInt32(Console.ReadLine());

            Member oldMember = MemberController.Get(Id);

            Member newMember = oldMember;

            Console.Write("Do you want to update the first name? (yes/no): ");
            if(Console.ReadLine() == "yes")
            {
                Console.Write("Enter the First Name: ");
                newMember.FirstName = Console.ReadLine() ?? "";
            }

            Console.Write("Do you want to update the last name? (yes/no): ");
            if(Console.ReadLine() == "yes")
            {
                Console.Write("Enter the Last Name: ");
                newMember.LastName = Console.ReadLine() ?? "";
            }

            Console.Write("Do you want to update the email address? (yes/no): ");
            if(Console.ReadLine() == "yes")
            {
                Console.Write("Enter the Email Address: ");
                newMember.Email = Console.ReadLine() ?? "";
            }

            newMember.DateModified = DateTime.Now;

            MemberController.Update(Id, newMember);

            Console.WriteLine($"{newMember.FirstName} has been successfully updated");

        }
    }
}
