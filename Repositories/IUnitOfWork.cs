using RepoUoWdemo.Models;

namespace RepoUoWdemo.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        Task SaveAsync();
    }
}
