using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homework1.models
{
    public class Ifo
    {
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Birth { get; set; }
        public string Height { get; set; }
        public string Interest { get; set; }
        public string Profession { get; set; }
        public string Sex { get; set; }
        public string Sexorien { get; set; }


    }
}
