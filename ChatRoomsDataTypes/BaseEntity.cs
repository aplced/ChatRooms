using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomsDataTypes
{
    [DataContract(IsReference = true)]
    public abstract class BaseEntity : ICreationTracking
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
    }
}
