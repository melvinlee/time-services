using System.Threading.Tasks;

namespace WebFrontend.HttpClients
{
    public interface IBarService
    {
        Task<string> GetResult();
    }
}