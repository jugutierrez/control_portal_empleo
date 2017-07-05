using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace control_portal_empleo.Models
{
    [Table("documentos")]
    public class documentos
    {
        [Key]
        [Column(Order = 1)]
        public int id_documento { get; set; }

        public string nombre_documento { get; set; }
    }
}