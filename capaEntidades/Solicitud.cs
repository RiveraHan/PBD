using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class Solicitud
    {
        public int id_solicitud { get; set; }
        public string aula { get; set; }
        public string nivel { get; set; }
        public DateTime fecha_solicitud { get; set; }
        public DateTime fecha_uso { get; set; }
        public DateTime hora_inicio { get; set; }
        public DateTime hora_final { get; set; }
        public string carrera { get; set; }
        public string asignatura { get; set; }
        public int id_recursos { get; set; }
        public int id_usuario { get; set; }
        public string nombres { get; set; }
    }
}
