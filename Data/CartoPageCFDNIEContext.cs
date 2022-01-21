#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CartoPageCFDNIE.Models;

namespace CartoPageCFDNIE.Data
{
    public class CartoPageCFDNIEContext : DbContext
    {
        public CartoPageCFDNIEContext (DbContextOptions<CartoPageCFDNIEContext> options)
            : base(options)
        {
        }

        public DbSet<CartoPageCFDNIE.Models.Map> Map { get; set; }
    }
}
