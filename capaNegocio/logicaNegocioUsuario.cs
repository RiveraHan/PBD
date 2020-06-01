using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using capaDatos;

namespace capaNegocio
{
    public class logicaNegocioUsuario
    {
        accesoDatosUsuarios datos_usuario = new accesoDatosUsuarios();

        public int insertarUsuario(Usuarios user)
        {
            return datos_usuario.insertarUsuario(user);
        }

        public List< Usuarios > listarUsuario()
        {
            return datos_usuario.listarUsuario();
        }

        public int eliminarUsuario(int idUsuario)
        {
            return datos_usuario.eliminarUsuario(idUsuario);
        }

        public int editarUsuario(Usuarios user)
        {
            return datos_usuario.editarUsuario(user);
        }

        public List< Usuarios > buscarUsuario(string dato)
        {
            return datos_usuario.buscarUsuario(dato);
        }
    }
}
