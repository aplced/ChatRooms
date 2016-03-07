using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomsDataTypes
{
    public class User : BaseEntity
    {
        public User()
        {
            Rooms = new List<Room>();
            Messages = new List<Message>();
        }

        public String Alias
        {
            get;
            set;
        }

        public ICollection<Room> Rooms
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
