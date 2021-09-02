using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Researchers.Journals.Models.Data
{
    public class ResearcherJournalDbContext : DbContext
    {

        public ResearcherJournalDbContext(DbContextOptions<ResearcherJournalDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Journals> Journals { get; set; }

        public DbSet<Researcher> Researchers { get; set; }

        public DbSet<Subscribers> Subscribers { get; set; }

        public DbSet<Login> Logins { get; set; }


        protected override void OnModelCreating(ModelBuilder model)
        {

        }
    }
}
