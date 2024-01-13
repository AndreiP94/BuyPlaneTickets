using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectASPNet.Model;
using ProjectBileteAvion.Data;

namespace ProjectBileteAvion.Pages.Destinatii
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectBileteAvion.Data.ProjectBileteAvionContext _context;

        public DetailsModel(ProjectBileteAvion.Data.ProjectBileteAvionContext context)
        {
            _context = context;
        }

        public Destinatie Destinatie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinatie = await _context.Destinatie.FirstOrDefaultAsync(m => m.ID == id);
            if (destinatie == null)
            {
                return NotFound();
            }
            else
            {
                Destinatie = destinatie;
            }
            return Page();
        }
    }
}
