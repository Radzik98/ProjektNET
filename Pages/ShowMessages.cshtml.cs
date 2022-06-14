using ProjektNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ProjektNET.Extensions;

namespace ProjektNET.Pages
{
    public class ShowMessagesModel : PageModel
    {
        private readonly Data.MessageDbContext _messageContext;

        private readonly Data.UserDbContext _userContext;
        
        public ShowMessagesModel(Data.MessageDbContext messageContext, Data.UserDbContext userContext)
        {
            _messageContext = messageContext;
            _userContext = userContext;
        }

        [BindProperty]
        public IEnumerable<Message>? Messages { get; set; }

        [BindProperty]
        public IEnumerable<User>? Users { get; set; }

        public async Task OnGetAsync(int? advertizerId)
        {

            Messages = await _messageContext.Message.Where(t => t.AdvertizerId == advertizerId).ToListAsync();

            List<int?> userList = new List<int?>();

            foreach(Message message in Messages)
            {
                userList.Add(message.ClientId);
            }

            Users = await _userContext.User.Where(o => userList.Contains(o.Id)).ToListAsync();
        }

        public async Task<IActionResult> OnPostMessageAsync(int? advertizerId, int? clientId)
        {
            return Redirect("~/Message/" + advertizerId + "/" + clientId);
        }
    }
}