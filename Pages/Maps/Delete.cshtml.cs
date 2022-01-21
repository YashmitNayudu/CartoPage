#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CartoPageCFDNIE.Data;
using CartoPageCFDNIE.Models;

namespace CartoPageCFDNIE.Pages.Maps
{
    public class DeleteModel : PageModel
    {
        private readonly CartoPageCFDNIE.Data.CartoPageCFDNIEContext _context;

        public DeleteModel(CartoPageCFDNIE.Data.CartoPageCFDNIEContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Map = await _context.Map.FindAsync(id);

            if (Map != null)
            {
                _context.Map.Remove(Map);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
