using System.Threading.Tasks;

namespace webfrontend.HttpClients
{
    public interface IBarService
    {
        Task<string> GetResult();
    }
}