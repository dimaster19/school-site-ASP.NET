using School43_ASP.NET.Models;

namespace School43_ASP.NET.Interface
{
    public interface IWorker
    {
        IEnumerable<Worker> GetAll();
        Worker GetOne(int id);
    }
}
