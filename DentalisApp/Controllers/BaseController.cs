using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DentalisApp.Web.Controllers
{
[Authorize]
    public abstract class BaseController : Controller
    {
        protected string? GetUserId()
        {
            return User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        protected bool IsUserAuthenticated => User?.Identity?.IsAuthenticated ?? false;

    }
}
