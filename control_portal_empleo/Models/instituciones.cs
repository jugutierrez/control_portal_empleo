﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace control_portal_empleo.Models
{
    [Table("instituciones")]
    public class instituciones
    {
        [Key]
        [Column(Order = 1)]
        public int id_institucion { get; set; }

        public string nombre_institucion { get; set; }

    }
}
