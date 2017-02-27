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
        public int idUser { set; get; }
        public string username { set; get; }
        public string password { set; get; }
    }
}
