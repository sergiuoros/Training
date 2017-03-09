using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Training.Models
{
    public class User
    {   
        [Key]
        public int Id { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
    }
}
