using LibraryManagementConsole.Interfaces;
using LibraryManagementConsole.Model;
using System.Data.Common;
namespace LibraryManagementConsole.Controller
{
    public class GenericController<T> : IGenericController<T> where T : class, new()
    {
        public static T Get(int Id)
        {
            using (var context = new LibDbContext())
            {
                try
                {
                    return context.Set<T>().Find(Id) ?? new T();
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

            return new T();
        }

        public static List<T> GetAll()
        {
            using (var context = new LibDbContext())
            {
                try
                {
                    return context.Set<T>().ToList();
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

            return new List<T>();
        }

        public static void Add(T entity)
        {
            using (var context = new LibDbContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public static void Remove(T entity)
        {
            using (var context = new LibDbContext())
            {
                try
                {
                    context.Set<T>().Remove(entity);
                    context.SaveChanges();
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
        }

        public static void Update(int Id, T entity)
        {

            using (var context = new LibDbContext())
            {
                try
                {
                    T tEntity = context.Set<T>().Find(Id);
                    if (tEntity != null)
                    {
                        tEntity = entity;
                        context.SaveChanges();
                    }
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
        }
    }

}
