using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Zawody_projekt
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model")
        {
        }

        public virtual DbSet<trenerzy> trenerzies { get; set; }
        public virtual DbSet<uczestnictwo> uczestnictwoes { get; set; }
        public virtual DbSet<zawodnicy> zawodnicies { get; set; }
        public virtual DbSet<zawody> zawodies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<trenerzy>()
                .Property(e => e.imie_t)
                .IsUnicode(false);

            modelBuilder.Entity<trenerzy>()
                .Property(e => e.nazwisko_t)
                .IsUnicode(false);

            modelBuilder.Entity<zawodnicy>()
                .Property(e => e.imie)
                .IsUnicode(false);

            modelBuilder.Entity<zawodnicy>()
                .Property(e => e.nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<zawodnicy>()
                .Property(e => e.kraj)
                .IsUnicode(false);

            modelBuilder.Entity<zawody>()
                .Property(e => e.nazwa)
                .IsUnicode(false);
        }
    }
}
