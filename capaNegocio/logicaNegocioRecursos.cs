using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using capaDatos;

namespace capaNegocio
{
    public class logicaNegocioRecursos
    {
        accesoDatosRecursos datos_recursos = new accesoDatosRecursos();

        public int insertarRecurso(Recursos recurso)
        {
            return datos_recursos.insertarRecurso(recurso);
        }

        public List<Recursos> listarRecursos()
        {
            return datos_recursos.listarRecurso();
        }

        public int eliminarRecurso(int idRecurso)
        {
            return datos_recursos.eliminarRecurso(idRecurso);
        }

        public int editarRecurso(Recursos recurso)
        {
            return datos_recursos.editarRecurso(recurso);
        }

        public List<Recursos> buscarRecurso(string dato)
        {
            return datos_recursos.buscarRecurso(dato);
        }
    }
}
