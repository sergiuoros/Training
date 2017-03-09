using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Training.Models
{
    public class Event
    {
        [Key]
        public int IdEvent { set; get; }
        public string Name { set; get; }
        public DateTime Date { set; get; }
        public double Price { set; get; }
        public string Location { set; get; }
    }
}
