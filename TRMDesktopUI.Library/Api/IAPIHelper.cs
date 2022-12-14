using System.Net.Http;
using System.Threading.Tasks;
using TRMdesktopUI.Models;
using TRMDesktopUI.Library.Models;

namespace TRMdesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}