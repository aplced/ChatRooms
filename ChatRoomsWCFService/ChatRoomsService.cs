using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatRoomsDataTypes;
using ChatRoomsDbContext;
using System.ServiceModel;

namespace ChatRoomsWCFService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ChatRoomsService : IChatRoomsService
    {
        DisconnectedRepo repo = new DisconnectedRepo();

        public List<User> AllUsers()
        {
            return repo.GetAllUsers();    
        }

        public List<Room> AllRooms()
        {
            return repo.GetAllRooms();
        }

        public Room CreateRoom(User user, string name, List<User> participants)
        {
            return repo.CreateRoom(user, name, participants);
        }

        public User CreateUser(string alias)
        {
            return repo.CreateUser(alias);
        }

        public void InviteUsers(User user, Room room, List<User> users)
        {
            repo.InviteUsers(room, users);
        }

        public void PostMessage(User user, Room room, string message)
        {
            repo.PostMessage(user, room, message);
        }
    }
}
