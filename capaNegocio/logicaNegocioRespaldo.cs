using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocio
{
    public class logicaNegocioRespaldo
    {
        accesoDatosRespaldoBD backupBD = new accesoDatosRespaldoBD();

        public int respaldoBD()
        {
            return backupBD.respaldoBD();
        }
    }
}
