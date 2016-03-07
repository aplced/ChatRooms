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
            List<User> result = null;
            using (var context = new Context())
            {
                result = context.Users.AsNoTracking().Include("Rooms.Messages.User").AsNoTracking().ToList();
            }

            return result;
        }

        public List<Room> GetAllRooms()
        {
            List<Room> result = null;
            using (var context = new Context())
            {
                result = context.Rooms.AsNoTracking().Include("Users").AsNoTracking().Include("Messages.User").AsNoTracking().ToList();
            }

            return result;
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

        public Room GetRoomById(int Id)
        {
            using (var context = new Context())
            {
                return context.Rooms.Find(Id);
            }
        }

        public Room CreateRoom(User adminId, String name, List<User> invitees)
        {
            using (var context = new Context())
            {
                var admin = context.Users.Find(adminId.Id);
                Room room = new Room();
                context.Rooms.Add(room);
                //room.User = admin;
                room.Name = name;
                admin.Rooms.Add(room);
                
                //room.Users.Add(admin);
                foreach (var userId in invitees)
                {
                    var user = GetUserById(userId.Id);
                    //room.Users.Add(user);
                    user.Rooms.Add(room);
                }
                context.SaveChanges();

                return room;
            }
        }

        public void InviteUsers(Room roomId, List<User> invitees)
        {
            using (var context = new Context())
            {
                var room = context.Rooms.Find(roomId.Id);
                foreach(var userId in invitees)
                {
                    var user = context.Users.Find(userId.Id);
                    //room.Users.Add(user);
                    user.Rooms.Add(room);
                }
                context.SaveChanges();
            }
        }

        public void PostMessage(User userId, Room roomId, String text)
        {
            using (var context = new Context())
            {
                var user = context.Users.Find(userId.Id);
                var room = context.Rooms.Find(roomId.Id);
                var msg = new Message();// { User = user, Room = room, Text = text };
                context.Messages.Add(msg);
                room.Messages.Add(msg);
                user.Messages.Add(msg);
                msg.Text = text;
                msg.User = user;
                msg.Room = room;
                context.SaveChanges();
            }
        }
    }
}
