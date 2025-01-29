using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ney_Nemovitost.web.Models.Entities;
using Ney_Nemovitost.web.Models.Identity;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;

namespace Ney_Nemovitost.web.Models.Database
{
    public class NemovitostDBContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<ModelNemovitost> Nemovitosts { get; set; }
        public DbSet<ModelAdresa> Adresas { get; set; }
        public DbSet<OptionNemovitost> NemovitostTyps { get; set; }
        public DbSet<DispoziceNemovitosti> dispoziceNemovitostis { get; set; }
        public DbSet<KostrukceNemovitosti> kostrukceNemovitostis { get; set; }
        public DbSet<EnerNarocnostNemovitosti> EnerNarocnostNemovitostis { get; set; }
        public DbSet<Najemnik> Najemniks { get; set; }
        public DbSet<ModelZavady> Zavadies { get; set; }

        public DbSet<FotoNem> FotoNemovitis { get; set; }
        public DbSet<Predvolby> Predvolbies { get; set; }
        public DbSet<ModelSmlouva> Smlouvy { get; set; }
        public DbSet<TypyDodatku> TypyDodatkus { get; set; }

        public DbSet<Dodatek> Dodateks { get; set; }
        public DbSet<MoznostiSluzeb> MoznostiSluzebs { get; set; }
        public DbSet<HistorieCen> HistorieCens { get; set; }

        public NemovitostDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().Replace("AspNet", String.Empty));
            }

            DatabaseInit databaseInit = new DatabaseInit();
            builder.Entity<ModelNemovitost>();
            builder.Entity<ModelAdresa>();
            builder.Entity<FotoNem>();
            builder.Entity<Najemnik>();
            builder.Entity<ModelSmlouva>();
            builder.Entity<ModelZavady>();
            builder.Entity<Dodatek>();
            builder.Entity<HistorieCen>();

            builder.Entity<OptionNemovitost>().HasData(databaseInit.CreateNemovitostOptions());
            builder.Entity<DispoziceNemovitosti>().HasData(databaseInit.CreateDispozitionOptions());
            builder.Entity<KostrukceNemovitosti>().HasData(databaseInit.CreateKonstrukceOptions());
            builder.Entity<EnerNarocnostNemovitosti>().HasData(databaseInit.CreateEnergetickaOptions());
            builder.Entity<Predvolby>().HasData(databaseInit.CreatePredvolby());
            builder.Entity<Role>().HasData(databaseInit.CreateRoles());
            builder.Entity<TypyDodatku>().HasData(databaseInit.CreateDodatky());
            builder.Entity<MoznostiSluzeb>().HasData(databaseInit.CreateMoznostiSluzeb());

        }
    }
}
