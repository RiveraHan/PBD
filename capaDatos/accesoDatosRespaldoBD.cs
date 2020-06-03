using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace capaDatos
{
    public class accesoDatosRespaldoBD
    {
        SqlConnection conexion; //Conexion
        Conexion _conexion = new Conexion(); // Conexion
        SqlCommand comandos_sql = null; // sql comandos

        int indicador = 0; // Variable indicador para comprobar CRUD

        public int respaldoBD()
        {
            try
            {
                conexion = _conexion.conectar(); // Conexion

                comandos_sql = new SqlCommand("RespaldoBD_GER", conexion);
                comandos_sql.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                comandos_sql.ExecuteNonQuery();
                indicador = 1;
            }
            catch(Exception error)
            {
                error.Message.ToString();
                indicador = 0;
            }
            finally
            {
                comandos_sql.Connection.Close();
            }

            return indicador;
        }
    }
}
