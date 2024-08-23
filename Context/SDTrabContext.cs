using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTrab.Models;

namespace SDTrab.Context
{
    public class SDTrabContext: DbContext
    {
         public SDTrabContext(DbContextOptions<SDTrabContext> options)
        : base(options)
    {
    }

    public DbSet<Penalidade> Penalidades { get; set; } = null!;
    public DbSet<Infracao> Infracoes { get; set; } = null!;
    }
}