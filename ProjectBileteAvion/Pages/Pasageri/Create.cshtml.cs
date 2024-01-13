using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectASPNet.Model;
using ProjectBileteAvion.Data;

namespace ProjectBileteAvion.Pages.Pasageri
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
            return Page();
        }

        [BindProperty]
        public Pasager Pasager { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
           

            _context.Pasager.Add(Pasager);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
