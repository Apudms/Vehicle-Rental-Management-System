namespace WebVRMS.Contracts
{
    public interface ICrud<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T GetById(string id);
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
