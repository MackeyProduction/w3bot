using w3bot.Core.Database.Repository;

namespace w3bot.Core.Database.Repository
{
    public interface IRepositoryService
    {
        IRepository CreateRepository(string repositoryName);
    }
}