using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidades;

namespace capaNegocio
{
    public class logicaNegocioSolicitud
    {
        accesoDatosSolicitud datos_solicitud = new accesoDatosSolicitud();

        public int insertarSolicitud(Solicitud solicit)
        {
            return datos_solicitud.insertarSolicitud(solicit);
        }

        public List< Solicitud > listarSolicitudes()
        {
            return datos_solicitud.listarSolicitud();
        }

        public int eliminarSolicitud(int idSolicitud)
        {
            return datos_solicitud.eliminarSolicitud(idSolicitud);
        }

        public int editarSolicitud(Solicitud solicit)
        {
            return datos_solicitud.editarSolicitud(solicit);
        }

        public List < Solicitud > buscarSolicitud(string dato)
        {
            return datos_solicitud.buscarSolicitud(dato);
        }
    }
}
