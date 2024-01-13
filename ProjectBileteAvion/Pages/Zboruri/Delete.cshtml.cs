﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectASPNet.Model;
using ProjectBileteAvion.Data;

namespace ProjectBileteAvion.Pages.Zboruri
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectBileteAvion.Data.ProjectBileteAvionContext _context;

        public DeleteModel(ProjectBileteAvion.Data.ProjectBileteAvionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Zbor Zbor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zbor = await _context.Zbor.FirstOrDefaultAsync(m => m.ID == id);

            if (zbor == null)
            {
                return NotFound();
            }
            else
            {
                Zbor = zbor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zbor = await _context.Zbor.FindAsync(id);
            if (zbor != null)
            {
                Zbor = zbor;
                _context.Zbor.Remove(Zbor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
