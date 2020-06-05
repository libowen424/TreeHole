using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homework1.models
{
    public class User
    {
        public long Id { get; set; }
        public string LoginId { get; set; }
        public string LoginPwd { get; set; }
        public string Nickname { get; set; }

    }
}
