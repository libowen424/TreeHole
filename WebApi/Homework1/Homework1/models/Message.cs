using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework1.models
{
    public class Message
    {
        public long Id { get; set; }
        public string Channel { get; set; }
        public long UserId1 { get; set; }
        public long UserId2 { get; set; }
        public string Content { get; set; }
    }
}
