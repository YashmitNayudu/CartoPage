#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CartoPageCFDNIE.Data;
using CartoPageCFDNIE.Models;

namespace CartoPageCFDNIE.Pages.Maps
{
    public class EditModel : PageModel
    {
        private readonly CartoPageCFDNIE.Data.CartoPageCFDNIEContext _context;

        public EditModel(CartoPageCFDNIE.Data.CartoPageCFDNIEContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Map Map { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Map = await _context.Map.FirstOrDefaultAsync(m => m.ID == id);

            if (Map == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Map).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapExists(Map.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MapExists(int id)
        {
            return _context.Map.Any(e => e.ID == id);
        }
    }
}
