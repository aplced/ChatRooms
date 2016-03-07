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
            PRINT_ROOMS,
            INVITE_USERS,
            NONE
        }

        static void Main(string[] args)
        {
            Commands cmd = Commands.NONE;
            while(cmd != Commands.QUIT)
            {
                Console.WriteLine("\n\nInput -[q]uit\n -[p]rint users\n -p[r]int rooms\n -[a]dd user <alias>\n -[c]create room <admin alias> <name> <attendee>\n -[i]nvite users to room <admin alias> <room name> <attendee>\n -[m]essage <sender alias> <room name> <message>");
                var cmdLine = Console.ReadLine();
                var cmdArguments = cmdLine.Split(' ');

                Console.Clear();

                if (cmdArguments[0].Equals("-q"))
                    cmd = Commands.QUIT;
                else if (cmdArguments[0].Equals("-p"))
                    cmd = Commands.PRINT_USERS;
                else if (cmdArguments[0].Equals("-r"))
                    cmd = Commands.PRINT_ROOMS;
                else if (cmdArguments[0].Equals("-a"))
                    cmd = Commands.ADD_USER;
                else if (cmdArguments[0].Equals("-c"))
                    cmd = Commands.CREATE_ROOM;
                else if (cmdArguments[0].Equals("-i"))
                    cmd = Commands.INVITE_USERS;
                else if (cmdArguments[0].Equals("-m"))
                    cmd = Commands.SEND_MESSAGE;

                int i = 1;

                switch (cmd)
                {
                    case Commands.PRINT_USERS:
                        PrintOutUsers();
                        cmd = Commands.NONE;
                        break;
                    case Commands.PRINT_ROOMS:
                        PrintOutRooms();
                        cmd = Commands.NONE;
                        break;
                    case Commands.ADD_USER:
                        AddUser(cmdArguments[i++]);
                        cmd = Commands.NONE;
                        break;
                    case Commands.CREATE_ROOM:
                        {
                            var admin = cmdArguments[i++];
                            var roomName = cmdArguments[i++];
                            var invitees = new List<string>();
                            for (int restArgs = i; restArgs < cmdArguments.Length; restArgs++)
                                invitees.Add(cmdArguments[restArgs]);
                            CreateRoom(admin, roomName, invitees);
                            cmd = Commands.NONE;
                        }
                        break;
                    case Commands.SEND_MESSAGE:
                        {
                            var admin = cmdArguments[i++];
                            var roomName = cmdArguments[i++];
                            StringBuilder message = new StringBuilder();
                            for (int restArgs = i; restArgs < cmdArguments.Length; restArgs++)
                                message.Append(cmdArguments[restArgs] + " ");
                            SendMessage(admin, roomName, message.ToString());
                            cmd = Commands.NONE;
                        }
                        break;
                    case Commands.INVITE_USERS:
                        {
                            var admin = cmdArguments[i++];
                            var roomName = cmdArguments[i++];
                            var invitees = new List<string>();
                            for (int restArgs = i; restArgs < cmdArguments.Length; restArgs++)
                                invitees.Add(cmdArguments[restArgs]);
                            InviteUsersToRoom(admin, roomName, invitees);
                            cmd = Commands.NONE;
                        }
                        break;
                }
            }
        }

        static void SendMessage(string alias, string roomName, string message)
        {
            using (ChatRoomsService.ChatRoomsServiceClient proxy = new ChatRoomsService.ChatRoomsServiceClient())
            {
                var user = proxy.AllUsers().Where(t => t.Alias == alias).FirstOrDefault();
                if (user != null)
                {
                    var room = user.Rooms.Where(t => t.Name == roomName).FirstOrDefault();
                    if (room != null)
                    {
                        proxy.PostMessage(user, room, message);
                    }
                    else
                        Console.WriteLine("Invalid room");
                }
                else
                    Console.WriteLine("Invalid user");
            }
        }

        static void InviteUsersToRoom(string adminAlias, string roomName, List<string> inviteesAliases)
        {
            using (ChatRoomsService.ChatRoomsServiceClient proxy = new ChatRoomsService.ChatRoomsServiceClient())
            {
                ChatRoomsDataTypes.User admin = null;
                List<ChatRoomsDataTypes.User> invitees = new List<ChatRoomsDataTypes.User>();
                foreach (var user in proxy.AllUsers())
                {
                    if (user.Alias.Equals(adminAlias))
                        admin = user;
                    else if (inviteesAliases.Contains(user.Alias))
                        invitees.Add(user);

                }
                if (admin != null)
                {
                    var room = admin.Rooms.Where(t => t.Name == roomName).FirstOrDefault();
                    if (room != null)
                    {
                        proxy.InviteUsers(admin, room, invitees);
                    }
                    else
                        Console.WriteLine("Invalid room");
                }
                else
                    Console.WriteLine("Invalid user");
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
                if (admin != null)
                    proxy.CreateRoom(admin, roomName, invitees);
                else
                    Console.WriteLine("Invalid user");
            }
        }

        static void AddUser(string alias)
        {
            using (ChatRoomsService.ChatRoomsServiceClient proxy = new ChatRoomsService.ChatRoomsServiceClient())
            {
                proxy.CreateUser(alias);
            }
        }

        static void PrintOutRooms()
        {
            using (ChatRoomsService.ChatRoomsServiceClient proxy = new ChatRoomsService.ChatRoomsServiceClient())
            {
                foreach (var room in proxy.AllRooms())
                {
                    Console.WriteLine("Room: " + room.Name);
                    Console.Write("Users: ");
                    foreach (var user in room.Users)
                    {
                        Console.Write(user.Alias + " ");
                    }
                    Console.WriteLine("");

                    foreach (var message in room.Messages)
                    {
                        Console.WriteLine("\t\t" + message.User.Alias + ":" + message.Created + ": " + message.Text);
                    }
                }
            }
        }

        static void PrintOutUsers()
        {
            using (ChatRoomsService.ChatRoomsServiceClient proxy = new ChatRoomsService.ChatRoomsServiceClient())
            {
                foreach (var user in proxy.AllUsers())
                {
                    Console.WriteLine("User: " + user.Alias);
                    Console.WriteLine("Attended rooms:\n");
                    foreach (var room in user.Rooms)
                    {
                        Console.WriteLine("\t" + room.Name + ";");
                        foreach (var message in room.Messages)
                        {
                            Console.WriteLine("\t\t" + message.User.Alias + ":" + message.Created + ": " + message.Text);
                        }
                        Console.WriteLine("\n");
                    }
                }
            }
        }
    }
}
