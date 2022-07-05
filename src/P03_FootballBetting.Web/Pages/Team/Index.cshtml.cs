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
    public class IndexModel : PageModel
    {
        private readonly P03_FootballBetting.Data.FootballBettingContext _context;

        public IndexModel(P03_FootballBetting.Data.FootballBettingContext context)
        {
            _context = context;
        }

        public IList<Color> Color { get;set; }

        public async Task OnGetAsync()
        {
            Color = await _context.Colors.ToListAsync();
        }
    }
}
