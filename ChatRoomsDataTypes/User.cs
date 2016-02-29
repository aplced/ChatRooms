using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomsDataTypes
{
    [DataContract]
    public class User : ICreationTracking
    {
        public User()
        {
            Rooms = new List<Room>();
        }

        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public String Alias
        {
            get;
            set;
        }

        [DataMember]
        public List<Room> Rooms
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
