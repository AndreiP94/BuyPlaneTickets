using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectASPNet.Model;
using ProjectBileteAvion.Data;

namespace ProjectBileteAvion.Pages.Zboruri
{
    public class CreateModel : PageModel
    {
        private readonly ProjectBileteAvion.Data.ProjectBileteAvionContext _context;

        public CreateModel(ProjectBileteAvion.Data.ProjectBileteAvionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DestinatieID"] = new SelectList(_context.Set<Destinatie>(), "ID", "Aeroport");
            return Page();
        }

        [BindProperty]
        public Zbor Zbor { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (Zbor.DataOraSosire <= Zbor.DataOraPlecare)
            {
                ModelState.AddModelError("Zbor.DataOraSosire", "Data și ora sosirii trebuie să fie după data și ora plecării.");
                return Page();

            }
            else
            {
                _context.Zbor.Add(Zbor);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
