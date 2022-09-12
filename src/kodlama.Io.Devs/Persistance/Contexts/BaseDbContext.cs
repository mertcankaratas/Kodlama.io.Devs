using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Version).HasColumnName("Version");
                a.HasMany(p => p.Technologies);
            });

            modelBuilder.Entity<Technology>(t =>
            {
                t.ToTable("Technologies").HasKey(k => k.Id);
                t.Property(p => p.Id).HasColumnName("Id");
                t.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                t.Property(p => p.Name).HasColumnName("Name");
                t.Property(p => p.Version).HasColumnName("Version");
                t.HasOne(p => p.ProgrammingLanguage);
            });



            ProgrammingLanguage[] programmingLanguagesEntitySeeds = { new(1, "Python", "3.15"), new(2, "C#", "10"),new (3,"Java","18"),new(4,"Javascript","ES6") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguagesEntitySeeds);

            Technology[] tecnologyEntitySeeds = { new(1, 1, "Django", "4.1.1"), new(2, 2, "WPF", "4.6"), new(3, 3, "Spring", "5.3.22"), new(4, 4, "React", "18.2.0") };
            modelBuilder.Entity<Technology>().HasData(tecnologyEntitySeeds);
        }

    }
}
