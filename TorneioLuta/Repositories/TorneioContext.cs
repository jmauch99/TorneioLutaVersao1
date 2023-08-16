using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TorneioLuta.Models;

namespace TorneioLuta
{
    public class TorneioContext : DbContext
    {
        public TorneioContext(DbContextOptions options) : base(options) { }

        public DbSet<Lutador> Lutadores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lutador>()
                .Property(l => l.EstilosDeLutaList)
                .HasConversion(
                    v => string.Join(",", v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                )
                .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()
                ));

            base.OnModelCreating(modelBuilder);
        }
    }
}
