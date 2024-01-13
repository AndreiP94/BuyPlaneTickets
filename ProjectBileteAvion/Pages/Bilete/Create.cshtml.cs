using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectASPNet.Model;
using ProjectBileteAvion.Data;

namespace ProjectBileteAvion.Pages.Bilete
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
            ViewData["PasagerID"] = new SelectList(
                    _context.Pasager.Select(p => new
                    {
                        ID = p.ID,
                        NumeComplet = p.Nume + " " + p.Prenume
                    }),
                    "ID",
                    "NumeComplet"
                ); ViewData["ZborID"] = new SelectList(_context.Zbor, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Bilet Bilet { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            string priceString = Request.Form["Bilet.Pret"].ToString();
            if (decimal.TryParse(priceString, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
            {
                Bilet.Pret = price;
            }
           
                _context.Bilet.Add(Bilet);
                await _context.SaveChangesAsync();
            
            return RedirectToPage("./Index");
        }
    }
}
