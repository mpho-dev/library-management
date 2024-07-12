using LibraryManagementConsole.Model;
using System.Data.Common;

namespace LibraryManagementConsole.Controller
{
    internal class CategoryController : GenericController<Category>
    {
        public static Category Get(string name)
        {
            using (var context = new LibDbContext())
            {
                try
                {
                    return context.Categories.FirstOrDefault(cat => cat.Name.ToLower() == name.ToLower()) ?? new Category();
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

            return new Category() { Name = name };
        }
    }
}
