using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class Usuarios
    {
        public int id_usuario { get; set; }
        public string cedula { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
    }
}
