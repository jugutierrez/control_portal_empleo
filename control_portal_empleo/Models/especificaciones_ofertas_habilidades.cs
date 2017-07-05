﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace control_portal_empleo.Models
{
    
        [Table("especificaciones_ofertas_habilidades")]
        public class especificaciones_ofertas_habilidades
        {
            [Key]
            [Column(Order = 1)]
            public int id_especificacion_oferta_habilidad { get; set; }

            public int id_habilidad { get; set; }
           
            public virtual habilidades habilidades { get; set; }

            public int id_especificacion_oferta { get; set; }
            public virtual especificaciones_ofertas especificaciones_ofertas { get; set; }

            public int id_grado_habilidad { get; set; }
            
            public virtual grado_habilidades grado_habilidades { get; set; }

        public int id_nivel_importancia { get; set; }
        public virtual nivel_importancia nivel_importancia { get; set; }
    }
    
}