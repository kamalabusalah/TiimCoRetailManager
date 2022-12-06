using System.Threading.Tasks;
using TRMdesktopUI.Models;
using TRMDesktopUI.Library.Models;

namespace TRMdesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}