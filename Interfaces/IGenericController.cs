namespace LibraryManagementConsole.Interfaces
{
    internal interface IGenericController<T> where T : class
    {
        public abstract static T Get(int Id);
        public abstract static List<T> GetAll();
        public abstract static void Add(T entity);
        public abstract static void Remove(T entity);
        public abstract static void Update(int Id, T entity);
    }
}
