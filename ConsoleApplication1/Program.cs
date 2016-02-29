using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatRoomsDataTypes;
using System.ServiceModel;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ChatRoomsDbContext.DisconnectedRepo repo = new ChatRoomsDbContext.DisconnectedRepo();

            //var users = repo.GetAllUsers();
            //if (users.Count == 0)
            //{
            //    var chocho = repo.CreateUser("chocho");
            //    var poko = repo.CreateUser("poko");

            //    var room = repo.CreateRoom(chocho, "Kruchma", new List<User> { poko });

            //    repo.PostMessage(chocho, room, "Hello");
            //    repo.PostMessage(poko, room, "World");
            //}
            //else
            //{
            //    foreach(var user in users)
            //    {
            //        foreach(var room in user.AttendedRooms)
            //        {
            //            repo.PostMessage(user, room, user.Alias + " has been here!");
            //        }
            //    }
            //}

            ServiceHost host = new ServiceHost(typeof(ChatRoomsWCFService.ChatRoomsService));
            host.Open();

            Console.ReadKey();
        }
    }
}
