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

        DbSet<Message> Messages
        {
            get;
            set;
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
