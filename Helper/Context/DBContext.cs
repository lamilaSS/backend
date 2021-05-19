using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using mcq_backend.Model;
using mcq_backend.Model.DefaultModel;
using Microsoft.EntityFrameworkCore;

namespace mcq_backend.Helper.Context
{
    public class DBContext : DbContext
    {
        private readonly int _userId;

        public DBContext(DbContextOptions options, ClaimProvider provider) : base(options)
        {
            _userId = provider.UserId;
        }

        public DbSet<Idoru> Idoru { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Idoru>().HasData
            // (
            //     new Idoru() {Age = 17, Gender = false, Name = "Trần Suisei"}
            // );
        }

        /**
         * This method use for adding time at creation
         * or update time of an entity if created
         */
        private void UpdateOrCreatedTime()
        {
            // set create or update date time
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is DefaultEntity && (
                    e.State is EntityState.Added or EntityState.Modified));
            foreach (var entityEntry in entries)
            {
                ((DefaultEntity) entityEntry.Entity).LastUpdated = DateTime.UtcNow;
                if (entityEntry.State == EntityState.Added)
                {
                    ((DefaultEntity) entityEntry.Entity).Created = DateTime.UtcNow;
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateOrCreatedTime();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            UpdateOrCreatedTime();
            return base.SaveChanges();
        }
    }
}