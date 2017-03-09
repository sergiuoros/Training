﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Training.Dtos
{
    public class SessionCredentialsDto
    {
        [Key]
        public int IdSession { set; get; }
        [ForeignKey("Event")]
        public int IdEvent { set; get; }
        public string Name { set; get; }
        public string Duration { set; get; }
        public string Difficulty { set; get; }
        public string Description { set; get; }
    }
}
