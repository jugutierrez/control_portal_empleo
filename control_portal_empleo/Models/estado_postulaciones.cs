﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace control_portal_empleo.Models
{
    [Table("estado_postulaciones")]
    public class estado_postulaciones
    {
        [Key]
        [Column(Order = 1)]
        public int id_estado_postulacion { get; set; }

        public string nombre_estado_postulacion { get; set; }


    }
}
