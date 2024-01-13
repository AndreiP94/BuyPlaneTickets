using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectASPNet.Model;
using ProjectBileteAvion.Data;

namespace ProjectBileteAvion.Pages.Bilete
{
    public class IndexModel : PageModel
    {
        private readonly ProjectBileteAvion.Data.ProjectBileteAvionContext _context;

        public IndexModel(ProjectBileteAvion.Data.ProjectBileteAvionContext context)
        {
            _context = context;
        }

        public IList<Bilet> Bilet { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Bilet = await _context.Bilet
                .Include(b => b.Pasager)
                .Include(b => b.Zbor).ToListAsync();
        }
    }
}
