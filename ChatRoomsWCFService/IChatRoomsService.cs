using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ChatRoomsDataTypes;

namespace ChatRoomsWCFService
{
    [ServiceContract]
    public interface IChatRoomsService
    {
        [OperationContract]
        List<User> AllUsers();

        [OperationContract]
        List<Room> AllRooms();

        [OperationContract]
        User CreateUser(String alias);

        [OperationContract]
        Room CreateRoom(User user, String name, List<User> participants);

        [OperationContract]
        void InviteUsers(User user, Room room, List<User> users);

        [OperationContract]
        void PostMessage(User user, Room room, String message);
    }
}
