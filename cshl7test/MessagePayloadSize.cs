using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cshl7test
{
    public class MessagePayloadSize
    {
        public int Size { get; set; }
        public string Description { get; set; }
        public MessagePayloadSize(int size, string description)
        {
            Size = size;
            Description = description;
        }


    }
}
