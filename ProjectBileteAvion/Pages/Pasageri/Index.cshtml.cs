using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectASPNet.Model;
using ProjectBileteAvion.Data;

namespace ProjectBileteAvion.Pages.Pasageri
{
    public class IndexModel : PageModel
    {
        private readonly ProjectBileteAvion.Data.ProjectBileteAvionContext _context;

        public IndexModel(ProjectBileteAvion.Data.ProjectBileteAvionContext context)
        {
            _context = context;
        }

        public IList<Pasager> Pasager { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Pasager = await _context.Pasager.ToListAsync();
        }
    }
}
