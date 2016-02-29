using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomsDataTypes
{
    [DataContract]
    public class Message : ICreationTracking
    {
        [DataMember]
        public DateTime Created
        {
            get;
            set;
        }

        [DataMember]
        public int Id
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
        public int RoomId
        {
            get;
            set;
        }

        [DataMember]
        public String Text
        {
            get;
            set;
        }
    }
}
