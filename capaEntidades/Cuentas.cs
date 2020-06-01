using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class Cuentas
    {
        public int id_cuenta { get; set; }
        public string nombre_user { get; set; }
        public string clave { get; set; }
        public string rol { get; set; }
        public int id_usuario { get; set; }
    }
}
