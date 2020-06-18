using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework1.models
{
    public class ThumbUp
    {
        public long Id { get; set; }
        public long TopicId { get; set; }
        public long UserId { get; set; }
    }
}
