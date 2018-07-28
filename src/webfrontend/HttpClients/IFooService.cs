using System.Threading.Tasks;

namespace webfrontend.HttpClients
{
    public interface IFooService
    {
        Task<string> GetResult();
    }
}