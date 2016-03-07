using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomsDataTypes
{
    public class Room : BaseEntity
    {
        public Room()
        {
            //Users = new List<User>();
            Messages = new List<Message>();
        }

        public String Name
        {
            get;
            set;
        }

        //[DataMember]
        //public User Admin
        //{
        //    get;
        //    set;
        //}

        public ICollection<User> Users
        {
            get;
            set;
        }

        public ICollection<Message> Messages
        {
            get;
            set;
        }
    }
}
