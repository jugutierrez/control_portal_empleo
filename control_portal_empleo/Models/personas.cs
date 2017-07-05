using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace control_portal_empleo.Models
{
    [Table("personas")]
   public class personas
    {
        [Key]
        [Column(Order = 1)]
        public int id_persona { get; set; }

        public string nombre_persona { get; set; }

        public string apellido_paterno_persona { get; set; }

        public string apellido_materno_persona { get; set; }

        public string correo_electronico_persona { get; set; }

        public DateTime fecha_nacimiento_persona { get; set; }

        public DateTime fecha_creacion_persona { get; set; }

        public DateTime fecha_modificacion_persona { get; set; }

        public string identificacion_persona { get; set; }

        public string clave_persona { get; set; }

        public int id_tipo_persona { get; set; }
        //public virtual tipo_personas tipo_personas { get; set; }

        public int id_estado_persona { get; set; }
        //public virtual estado_personas estado_personas { get; set; }

        public int id_curriculum { get; set; }
        //public virtual curriculums curriculums { get; set; }

        public int id_comuna { get; set; }
       // public virtual comunas comunas { get; set; }


        public int id_tipo_identificacion_persona { get; set; }
        //public virtual tipo_identificacion_personas tipo_identificacion_personasv { get; set; }

    }
}
