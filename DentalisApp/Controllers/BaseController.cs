using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DentalisApp.Web.Controllers
{
[Authorize]
    public abstract class BaseController : Controller
    {
       protected bool IsUserAuthenticated => User.Identity?.IsAuthenticated ?? false;
       
       protected string? GetUserId() 
       {
            if (!IsUserAuthenticated)
            {
                return null;
            }
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
        
    }
}
