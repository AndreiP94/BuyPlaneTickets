using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectASPNet.Model;

namespace ProjectBileteAvion.Data
{
    public class ProjectBileteAvionContext : DbContext
    {
        public ProjectBileteAvionContext (DbContextOptions<ProjectBileteAvionContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectASPNet.Model.Zbor> Zbor { get; set; } = default!;
        public DbSet<ProjectASPNet.Model.Bilet> Bilet { get; set; } = default!;
        public DbSet<ProjectASPNet.Model.Destinatie> Destinatie { get; set; } = default!;
        public DbSet<ProjectASPNet.Model.Pasager> Pasager { get; set; } = default!;
    }
}
