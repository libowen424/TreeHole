using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework1.models
{
    public class Concern
    {
        public long Id { get; set; }
        //1是主动  2是被动
        public long UserId1 { get; set; }
        public long UserId2 { get; set; }
    }
}
