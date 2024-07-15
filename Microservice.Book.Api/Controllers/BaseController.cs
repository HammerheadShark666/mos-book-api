using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Web.Http;

namespace Microservice.Book.Api.Controllers;

[ApiController]
public class BaseController : ApiController
{
   protected Guid GetUserId()
   {
        try
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            return new Guid(userId);
        } catch {
            throw new Exception("Unable to get user id."); 
        }
   }
}