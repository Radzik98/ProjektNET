using ProjektNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ProjektNET.Extensions;

namespace ProjektNET.Pages
{
    public class MessageModel : PageModel
    {
        private readonly Data.MessageDbContext _context;
        public MessageModel(Data.MessageDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IEnumerable<Message>? Messages { get; set; }

        [BindProperty]
        public string value { get; set; }

        [BindProperty]
        public int? specialId { get; set; }

        public int? AdvertizerId { get; set; }

        public int? ClientId { get; set; }

        public async Task OnGetAsync(int? advertizerId, int? clientId)
        {
            Messages = await _context.Message.Where(t => t.ClientId == clientId).ToListAsync();
            specialId = clientId;
            AdvertizerId = advertizerId;
            ClientId = clientId;
        }

        public async Task<IActionResult> OnPostClientMessageAsync(int? advertizerId, int? clientId)
        {
            var message = new Message { Value = value, AdvertizerId = advertizerId, ClientId = clientId, SenderId = clientId };
            _context.Add(message);
            await _context.SaveChangesAsync();
            Messages = await _context.Message.Where(t => t.ClientId == clientId).ToListAsync();
            return Redirect("~/Message/" + advertizerId + "/" + clientId);
        }

        public async Task<IActionResult> OnPostAdvertizerMessageAsync(int? advertizerId, int? clientId)
        {
            var message = new Message { Value = value, AdvertizerId = advertizerId, ClientId = clientId, SenderId = advertizerId };
            _context.Add(message);
            await _context.SaveChangesAsync();
            Messages = await _context.Message.Where(t => t.ClientId == clientId).ToListAsync();
            return Redirect("~/Message/" + advertizerId + "/" + clientId);
        }
    }
}