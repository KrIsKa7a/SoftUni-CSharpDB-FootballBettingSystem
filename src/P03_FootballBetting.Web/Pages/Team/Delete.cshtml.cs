using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Web.Pages.Team
{
    public class DeleteModel : PageModel
    {
        private readonly P03_FootballBetting.Data.FootballBettingContext _context;

        public DeleteModel(P03_FootballBetting.Data.FootballBettingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Color Color { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Color = await _context.Colors.FirstOrDefaultAsync(m => m.ColorId == id);

            if (Color == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Color = await _context.Colors.FindAsync(id);

            if (Color != null)
            {
                _context.Colors.Remove(Color);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
