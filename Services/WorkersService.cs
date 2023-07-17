using School43_ASP.NET.Interface;
using School43_ASP.NET.Models;

namespace School43_ASP.NET.Services
{
    public class WorkersService : IWorker
    {
      // private readonly IRank _ranks = new ;
        IEnumerable<Worker> IWorker.GetAll()
        {
            List<Worker> workers = new();

            return workers;
        }
        Worker IWorker.GetOne(int id)
        {
            Worker worker = null;

            return worker;
        }
    }
}
