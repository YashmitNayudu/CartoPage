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
    public class DetailsModel : PageModel
    {
        private readonly CartoPageCFDNIE.Data.CartoPageCFDNIEContext _context;

        public DetailsModel(CartoPageCFDNIE.Data.CartoPageCFDNIEContext context)
        {
            _context = context;
        }

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
    }
}
