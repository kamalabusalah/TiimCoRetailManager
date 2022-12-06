using System.Threading.Tasks;
using TRMdesktopUI.Models;

namespace TRMdesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}