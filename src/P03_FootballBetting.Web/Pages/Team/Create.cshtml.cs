using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using P03_FootballBetting.Data;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Web.Pages.Team
{
    public class CreateModel : PageModel
    {
        private readonly P03_FootballBetting.Data.FootballBettingContext _context;

        public CreateModel(P03_FootballBetting.Data.FootballBettingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Color Color { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Colors.Add(Color);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
