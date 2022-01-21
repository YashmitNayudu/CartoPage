#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CartoPageCFDNIE.Data;
using CartoPageCFDNIE.Models;

namespace CartoPageCFDNIE.Pages.Maps
{
    public class CreateModel : PageModel
    {
        private readonly CartoPageCFDNIE.Data.CartoPageCFDNIEContext _context;

        public CreateModel(CartoPageCFDNIE.Data.CartoPageCFDNIEContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Map Map { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Map.Add(Map);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
