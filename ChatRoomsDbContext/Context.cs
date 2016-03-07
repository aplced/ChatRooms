using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatRoomsDataTypes;

namespace ChatRoomsDbContext
{
    class Context : DbContext
    {
        public DbSet<User> Users
        {
            get;
            set;
        }

        public DbSet<Room> Rooms
        {
            get;
            set;
        }

        public DbSet<Message> Messages
        {
            get;
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Room>()
            //    .HasRequired(t => t.Admin)
            //    .WithRequiredDependent();

            //modelBuilder.Entity<Room>().HasMany(p => p.Users).WithMany(t => t.Rooms);

            //modelBuilder.Entity<Message>()
            //    .HasRequired(t => t.User)
            //    .WithRequiredPrincipal();

            //modelBuilder.Entity<Message>()
            //    .HasRequired(t => t.Room)
            //    .WithRequiredPrincipal();

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var history in this.ChangeTracker.Entries().Where(e => e.Entity is ICreationTracking && (e.State == EntityState.Added)).Select(e => e.Entity as ICreationTracking))
            {
                history.Created = DateTime.Now;
            }
            return base.SaveChanges();
        }
    }
}
