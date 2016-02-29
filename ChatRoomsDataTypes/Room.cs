using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomsDataTypes
{
    [DataContract]
    public class Room : ICreationTracking
    {
        public Room()
        {
            Users = new List<User>();
            Messages = new List<Message>();
        }

        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public String Name
        {
            get;
            set;
        }

        [DataMember]
        public int UserId
        {
            get;
            set;
        }

        [DataMember]
        public User User
        {
            get;
            set;
        }

        [DataMember]
        public List<User> Users
        {
            get;
            set;
        }

        [DataMember]
        public List<Message> Messages
        {
            get;
            set;
        }

        [DataMember]
        public DateTime Created
        {
            get;
            set;
        }
    }
}
