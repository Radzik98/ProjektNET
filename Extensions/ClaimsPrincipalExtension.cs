using System.Linq;
using System.Security.Claims;
using ProjektNET.Models;

namespace ProjektNET.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static int GetUserId(ClaimsPrincipal user)
        {
            ClaimsPrincipal currentUser = user;
            var nameIdClaim = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var nameId = int.TryParse(nameIdClaim, out var id) ? id : 0;
            return nameId;
        }
    }
}