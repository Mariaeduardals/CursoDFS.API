using System.Threading.Tasks;

namespace WebApplication.Dominio.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}