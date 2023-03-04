using community_institute_API.Data.Domin;
using Microsoft.AspNetCore.Identity;

namespace community_institute_API.Serves
{
    public interface ITookenServiice
    {
        Task<string> CreateToken(Appuser user, UserManager<Appuser> userManager);

    }
}
