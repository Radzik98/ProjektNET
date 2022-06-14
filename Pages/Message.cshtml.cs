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

        public async Task OnGetAsync()
        {
            Messages = await _context.Message.Where(t => t.).ToListAsync();
        }

        public async Task<IActionResult> OnPostRateAsync(int? id)
        {
            return Redirect("~/RateAdvertizer/" + id);
        }

        public async Task<IActionResult> OnPostShowOpinionsAsync(int? id)
        {
            return Redirect("~/ShowRates/" + id);
        }

        public async Task<IActionResult> OnPostMessageAsync(int? advertizerId, int? clientId)
        {
            return Redirect("~/Message/" + advertizerId + "/" + clientId);
        }
    }
}