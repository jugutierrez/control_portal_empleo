﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace control_portal_empleo.Models
{
   
        [Table("tipo_habilidades")]
        public class tipo_habilidades
        {
            [Key]
            [Column(Order = 1)]
            public int id_tipo_habilidad { get; set; }

            public string nombre_tipo_habilidad { get; set; }
        }
    
}
