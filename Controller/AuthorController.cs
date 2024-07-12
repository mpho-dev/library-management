using LibraryManagementConsole.Model;
using System.Data.Common;


namespace LibraryManagementConsole.Controller
{
    internal class AuthorController : GenericController<Author>
    {
        public static Author Get(string FirstName, string LastName)
        {
            using (var context = new LibDbContext())
            {
                try
                {
                    return context.Authors.FirstOrDefault(author => author.FirstName.ToLower() == FirstName.ToLower() && author.LastName.ToLower() == LastName.ToLower()) ?? new Author();
                }
                catch (DbException dbEx)
                {
                    Console.WriteLine($"DB Error: {dbEx.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return new Author();
        }
    }
}
