﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace control_portal_empleo.Models
{
    [Table("contrato_ofertas")]
    public class contrato_ofertas
    {
        [Key]
        [Column(Order = 1)]


        public int id_contrato_oferta { get; set; }

        public string nombre_contrato_oferta { get; set; }
    }
}