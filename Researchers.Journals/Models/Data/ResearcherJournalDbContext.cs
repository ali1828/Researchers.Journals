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

        DbSet<Journals> Journals { get; set; }

        DbSet<Researcher> Researchers { get; set; }

        DbSet<Subscribers> Subscribers { get; set; }

        DbSet<Login> Logins { get; set; }


        protected override void OnModelCreating(ModelBuilder model)
        {

        }
    }
}
