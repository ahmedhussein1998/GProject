using Gproject.Domain.MenuAggregate;
using Gproject.Domain.MenuAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Infrastruct.Persistance
{
    public class GProjectDbContext :DbContext
    {
        public GProjectDbContext(DbContextOptions<GProjectDbContext> options):base(options)
        { 

        }
        public DbSet<Menu> Menus { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfigurationsFromAssembly(typeof(GProjectDbContext).Assembly);
            base.OnModelCreating(modelbuilder);
        }
        
    }
}
