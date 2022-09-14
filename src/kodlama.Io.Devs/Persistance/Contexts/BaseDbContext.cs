using Core.Security.Entities;
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

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


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


            modelBuilder.Entity<User>(u => {
                u.ToTable("Users").HasKey(k => k.Id);
                u.Property(p => p.Id).HasColumnName("Id");
                u.Property(p => p.FirstName).HasColumnName("FirstName");
                u.Property(p => p.LastName).HasColumnName("LastName");
                u.Property(p => p.Email).HasColumnName("Email");
                u.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                u.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                u.Property(p => p.Status).HasColumnName("Status");
                u.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
                           
                u.HasMany(p=> p.UserOperationClaims);
                u.HasMany(p=> p.RefreshTokens);
            });

            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(c => c.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(c => c.UserId).HasColumnName("UserId");
                a.Property(c => c.OperationClaimId).HasColumnName("OperationClaimId");

                a.HasOne(c => c.OperationClaim);
                a.HasOne(c => c.User);
            });



            ProgrammingLanguage[] programmingLanguagesEntitySeeds = { new(1, "Python", "3.15"), new(2, "C#", "10"),new (3,"Java","18"),new(4,"Javascript","ES6") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguagesEntitySeeds);

            Technology[] tecnologyEntitySeeds = { new(1, 1, "Django", "4.1.1"), new(2, 2, "WPF", "4.6"), new(3, 3, "Spring", "5.3.22"), new(4, 4, "React", "18.2.0") };
            modelBuilder.Entity<Technology>().HasData(tecnologyEntitySeeds);

            OperationClaim[] operationClaimsEntitySeeds = { new(1,"admin"),new(2,"user"),new(3,"add,get,update") };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimsEntitySeeds);
        }

    }
}
