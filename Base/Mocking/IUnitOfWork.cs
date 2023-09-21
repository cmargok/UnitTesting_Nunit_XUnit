namespace Base.Mocking
{
    public interface IUnitOfWork
    {
        IQueryable<T> Query<T>();
    }


}