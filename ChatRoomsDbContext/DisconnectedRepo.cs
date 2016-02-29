using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatRoomsDataTypes;

namespace ChatRoomsDbContext
{
    public class DisconnectedRepo
    {
        public List<User> GetAllUsers()
        {
            using (var context = new Context())
            {
                return context.Users.AsNoTracking().ToList();
            }
        }

        public User CreateUser(String alias)
        {
            using (var context = new Context())
            {
                var user = new User { Alias = alias };
                context.Users.Add(user);
                context.SaveChanges();

                return user;
            }
        }

        public User GetUserById(int Id)
        {
            using (var context = new Context())
            {
                return context.Users.Find(Id);
            }
        }

        public Room CreateRoom(User admin, String name, List<User> invitees)
        {
            using (var context = new Context())
            {
                Room room = new Room();
                room.User = admin;
                room.UserId = admin.Id;
                room.Users = invitees;
                room.Name = name;

                context.Rooms.Add(room);
                foreach (var user in invitees)
                {
                    user.Rooms.Add(room);
                }
                context.SaveChanges();

                return room;
            }
        }

        public void InviteUsers(Room room, List<User> invitees)
        {
            using (var context = new Context())
            {
                room.Users.AddRange(invitees);
                foreach(var user in invitees)
                {
                    user.Rooms.Add(room);
                }
                context.SaveChanges();
            }
        }

        public void PostMessage(User user, Room room, String text)
        {
            using (var context = new Context())
            {
                room.Messages.Add(new Message { UserId = user.Id, RoomId = room.Id, Text = text });
                context.SaveChanges();
            }
        }
    }
}
