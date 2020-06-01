using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidades;

namespace capaNegocio
{
    public class logicaNegocioCuentas
    {

        accesoDatosCuentas datos_cuentas = new accesoDatosCuentas();
        public int insertarCuentas(Cuentas cuent)
        {
            return datos_cuentas.insertarCuentas(cuent);
        }

        public List<Cuentas> listarCuentas()
        {
            return datos_cuentas.listarCuentas();
        }

        public int eliminarCuentas(int idCuent)
        {
            return datos_cuentas.eliminarCuenta(idCuent);
        }

        public int editarCuentas(Cuentas cuent)
        {
            return datos_cuentas.editarCuentas(cuent);
        }

        public List<Cuentas> buscarCuentas(string dato)
        {
            return datos_cuentas.buscarCuenta(dato);
        }
    }
}
