using CentraLog.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralLog.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<LogAplicacaoEntity>(table => { table.ToTable("LogAplicacao"); });

            base.OnModelCreating(builder);
        }
        public virtual DbSet<LogAplicacaoEntity> LogAplicacaoEntities { get; set; }
    }
}
