using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomsClient
{
    class Program
    {
        enum Commands
        {
            QUIT,
            PRINT_USERS,
            ADD_USER,
            CREATE_ROOM,
            SEND_MESSAGE,
            NONE
        }

        static void Main(string[] args)
        {
            Commands cmd = Commands.NONE;
            while(cmd != Commands.QUIT)
            {
                var cmdLine = Console.ReadLine();
                var cmdArguments = cmdLine.Split(' ');

                if (cmdArguments[0].Equals("-q"))
                    cmd = Commands.QUIT;
                else if (cmdArguments[0].Equals("-p"))
                    cmd = Commands.PRINT_USERS;
                else if (cmdArguments[0].Equals("-a"))
                    cmd = Commands.ADD_USER;
                else if (cmdArguments[0].Equals("-c"))
                    cmd = Commands.CREATE_ROOM;
                else if (cmdArguments[0].Equals("-m"))
                    cmd = Commands.SEND_MESSAGE;

                int i = 1;

                switch (cmd)
                {
                    case Commands.PRINT_USERS:
                        PrintOutUsers();
                        cmd = Commands.NONE;
                        break;
                    case Commands.ADD_USER:
                        AddUser(cmdArguments[i++]);
                        cmd = Commands.NONE;
                        break;
                    case Commands.CREATE_ROOM:
                        var admin = cmdArguments[i++];
                        var roomName = cmdArguments[i++];
                        var invitees = new List<string>();
                        for (int restArgs = i; restArgs < cmdArguments.Length; restArgs++)
                            invitees.Add(cmdArguments[restArgs]);
                        CreateRoom(admin, roomName, invitees);
                        cmd = Commands.NONE;
                        break;
                }
            }
        }

        static void CreateRoom(string adminAlias, string roomName, List<string> inviteesAliases)
        {
            using (ChatRoomsService.ChatRoomsServiceClient proxy = new ChatRoomsService.ChatRoomsServiceClient())
            {
                ChatRoomsDataTypes.User admin = null;
                List<ChatRoomsDataTypes.User> invitees = new List<ChatRoomsDataTypes.User>();
                foreach(var user in proxy.AllUsers())
                {
                    if (user.Alias.Equals(adminAlias))
                        admin = user;
                    else if (inviteesAliases.Contains(user.Alias))
                        invitees.Add(user);

                }
                proxy.CreateRoom(admin, roomName, invitees);
            }
        }

        static void AddUser(string alias)
        {
            using (ChatRoomsService.ChatRoomsServiceClient proxy = new ChatRoomsService.ChatRoomsServiceClient())
            {
                proxy.CreateUser(alias);
            }
        }

        static void PrintOutUsers()
        {
            using (ChatRoomsService.ChatRoomsServiceClient proxy = new ChatRoomsService.ChatRoomsServiceClient())
            {
                foreach (var user in proxy.AllUsers())
                {
                    Console.WriteLine("User: " + user.Alias);
                    Console.WriteLine("Attended rooms:");
                    foreach (var room in user.Rooms)
                    {
                        Console.WriteLine("\t" + room.Name + ";");
                        foreach (var message in room.Messages)
                        {
                            Console.WriteLine("\t\t" + message.UserId + ":" + message.Created + ": " + message.Text);
                        }
                    }
                }
            }
        }
    }
}
