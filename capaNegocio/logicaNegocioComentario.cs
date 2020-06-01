using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using capaDatos;

namespace capaNegocio
{
    public class logicaNegocioComentarios
    {
        accesoDatosComentarios datos_comentarios = new accesoDatosComentarios();

        public int insertarComentario(Comentarios coment)
        {
           return datos_comentarios.insertarComentarios(coment);
        }

        public List < Comentarios > listarComentarios()
        {
            return datos_comentarios.listarComentario();
        }

        public int eliminarComentario(int idComent)
        {
            return datos_comentarios.eliminarComentarios(idComent);
        }

        public int editarComentario(Comentarios coment)
        {
            return datos_comentarios.editarComentarios(coment);
        }

        public List < Comentarios > buscarComentario(string dato)
        {
            return datos_comentarios.buscarComentarios(dato);
        }
    }
}
