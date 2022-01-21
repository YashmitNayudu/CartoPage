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
    public class IndexModel : PageModel
    {
        private readonly CartoPageCFDNIE.Data.CartoPageCFDNIEContext _context;

        public IndexModel(CartoPageCFDNIE.Data.CartoPageCFDNIEContext context)
        {
            _context = context;
        }

        public IList<Map> Map { get;set; }

        public async Task OnGetAsync()
        {
            Map = await _context.Map.ToListAsync();
        }
    }
}
