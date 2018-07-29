using System.Threading.Tasks;

namespace WebFrontend.HttpClients
{
    public interface IFooService
    {
        Task<string> GetResult();
    }
}