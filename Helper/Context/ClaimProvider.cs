using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace mcq_backend.Helper.Context
{
    public class ClaimProvider
    {
        public int UserId { get; private set; }
        public ClaimProvider(IHttpContextAccessor accessor)
        {
            var userId = accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                UserId = int.Parse(userId);
            }
        }
    }
}