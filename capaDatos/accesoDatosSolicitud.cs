using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using capaEntidades;
using System.Data;

namespace capaDatos
{
    public class accesoDatosSolicitud
    {
        SqlConnection conexion; //Conexion
        Solicitud solicitud = new Solicitud(); //CapaEntidades
        Conexion _conexion = new Conexion(); // Conexion
        SqlCommand comandos_sql = null; // sql comandos

        int indicador = 0; // Variable indicador para comprobar CRUD
        SqlDataReader data_reader = null;
        List<Solicitud> listaSolicitud = null;

        /* Guardar solicitud*/

        public int insertarSolicitud (Solicitud solicit)
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Solicitud", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 1); // Valores que toman los parámetros
                comandos_sql.Parameters.AddWithValue("@idsolicitud", "");
                comandos_sql.Parameters.AddWithValue("@aula", solicit.aula);
                comandos_sql.Parameters.AddWithValue("@nivel", solicit.nivel);
                comandos_sql.Parameters.AddWithValue("@fechasolicitud", solicit.fecha_solicitud);
                comandos_sql.Parameters.AddWithValue("@fechauso", solicit.fecha_uso);
                comandos_sql.Parameters.AddWithValue("@horainicio", solicit.hora_inicio);
                comandos_sql.Parameters.AddWithValue("@horafinal", solicit.hora_final);
                comandos_sql.Parameters.AddWithValue("@carrera", solicit.carrera);
                comandos_sql.Parameters.AddWithValue("@asignatura", solicit.asignatura);
                comandos_sql.Parameters.AddWithValue("@idrecursos", solicit.id_recursos);
                comandos_sql.Parameters.AddWithValue("@idusuario", solicit.id_usuario);
                comandos_sql.Parameters.AddWithValue("@nombres", solicit.nombres);

                comandos_sql.CommandType = CommandType.StoredProcedure; // Tipo de comando sql ejecutado
                conexion.Open();
                comandos_sql.ExecuteNonQuery(); // Ejecución de consulta
                indicador = 1;
            }
            catch (Exception error)
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

        /* Método listar solicitud */
        public List< Solicitud > listarSolicitud()
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Solicitud", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 3);
                comandos_sql.Parameters.AddWithValue("@idsolicitud", "");
                comandos_sql.Parameters.AddWithValue("@aula", "");
                comandos_sql.Parameters.AddWithValue("@nivel", "");
                comandos_sql.Parameters.AddWithValue("@fechasolicitud", "");
                comandos_sql.Parameters.AddWithValue("@fechauso", "");
                comandos_sql.Parameters.AddWithValue("@horainicio", "");
                comandos_sql.Parameters.AddWithValue("@horafinal", "");
                comandos_sql.Parameters.AddWithValue("@carrera", "");
                comandos_sql.Parameters.AddWithValue("@asignatura", "");
                comandos_sql.Parameters.AddWithValue("@idrecursos", "");
                comandos_sql.Parameters.AddWithValue("@idusuario", "");
                comandos_sql.Parameters.AddWithValue("@nombres", "");

                comandos_sql.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                data_reader = comandos_sql.ExecuteReader();

                listaSolicitud = new List<Solicitud>();

                while (data_reader.Read())
                {
                    Solicitud solicitud = new Solicitud();
                    solicitud.id_solicitud = Convert.ToInt32(data_reader["idsolicitud"].ToString());                    
                    solicitud.aula = data_reader["aula"].ToString();
                    solicitud.nivel = data_reader["nivel"].ToString();
                    solicitud.fecha_solicitud = Convert.ToDateTime(data_reader["fechasolicitud"].ToString());
                    solicitud.fecha_uso = Convert.ToDateTime(data_reader["fechauso"].ToString());
                    solicitud.hora_inicio = Convert.ToDateTime(data_reader["horainicio"].ToString());
                    solicitud.hora_final = Convert.ToDateTime(data_reader["horafinal"].ToString());
                    solicitud.carrera = data_reader["carrera"].ToString();
                    solicitud.asignatura = data_reader["asignatura"].ToString();
                    solicitud.id_recursos = Convert.ToInt32(data_reader["idrecursos"].ToString());
                    solicitud.id_usuario = Convert.ToInt32(data_reader["idusuario"].ToString());

                    listaSolicitud.Add(solicitud); // Agregar registros encontrados en la lista
                }
            }
            catch (Exception error)
            {
                error.Message.ToString();
                listaSolicitud = null;
            }
            finally
            {
                comandos_sql.Connection.Close();
            }

            return listaSolicitud;
        }

        /* Método eliminar solicitud*/

        public int eliminarSolicitud(int idSolicit)
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Solicitud", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 2);
                comandos_sql.Parameters.AddWithValue("@idsolicitud", idSolicit);
                comandos_sql.Parameters.AddWithValue("@aula", "");
                comandos_sql.Parameters.AddWithValue("@nivel", "");
                comandos_sql.Parameters.AddWithValue("@fechasolicitud", "");
                comandos_sql.Parameters.AddWithValue("@fechauso", "");
                comandos_sql.Parameters.AddWithValue("@horainicio", "");
                comandos_sql.Parameters.AddWithValue("@horafinal", "");
                comandos_sql.Parameters.AddWithValue("@carrera", "");
                comandos_sql.Parameters.AddWithValue("@asignatura", "");
                comandos_sql.Parameters.AddWithValue("@idrecursos", "");
                comandos_sql.Parameters.AddWithValue("@idusuario", "");
                comandos_sql.Parameters.AddWithValue("@nombres", "");

                comandos_sql.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                comandos_sql.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception error)
            {
                error.Message.ToString();
                indicador = 0;
            }
            finally { comandos_sql.Connection.Close(); }

            return indicador;
        }

        /* Método Actualizar*/

        public int editarSolicitud(Solicitud solicit)
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Solicitud", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 4); // Valores que toman los parámetros
                comandos_sql.Parameters.AddWithValue("@idsolicitud", solicit.id_solicitud);
                comandos_sql.Parameters.AddWithValue("@aula", solicit.aula);
                comandos_sql.Parameters.AddWithValue("@nivel", solicit.nivel);
                comandos_sql.Parameters.AddWithValue("@fechasolicitud", solicit.fecha_solicitud);
                comandos_sql.Parameters.AddWithValue("@fechauso", solicit.fecha_uso);
                comandos_sql.Parameters.AddWithValue("@horainicio", solicit.hora_inicio);
                comandos_sql.Parameters.AddWithValue("@horafinal", solicit.hora_final);
                comandos_sql.Parameters.AddWithValue("@carrera", solicit.carrera);
                comandos_sql.Parameters.AddWithValue("@asignatura", solicit.asignatura);
                comandos_sql.Parameters.AddWithValue("@idrecursos", solicit.id_recursos);
                comandos_sql.Parameters.AddWithValue("@idusuario", solicit.id_usuario);
                comandos_sql.Parameters.AddWithValue("@nombres", solicit.nombres);

                comandos_sql.CommandType = CommandType.StoredProcedure; // Tipo de comando sql ejecutado
                conexion.Open();
                comandos_sql.ExecuteNonQuery(); // Ejecución de consulta
                indicador = 1;
            }
            catch (Exception error)
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

        /* Método buscar*/

        public List< Solicitud > buscarSolicitud(string dato)
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Solicitud", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 5);
                comandos_sql.Parameters.AddWithValue("@idsolicitud", "");
                comandos_sql.Parameters.AddWithValue("@aula", dato);
                comandos_sql.Parameters.AddWithValue("@nivel", "");
                comandos_sql.Parameters.AddWithValue("@fechasolicitud", "");
                comandos_sql.Parameters.AddWithValue("@fechauso", "");
                comandos_sql.Parameters.AddWithValue("@horainicio", "");
                comandos_sql.Parameters.AddWithValue("@horafinal", "");
                comandos_sql.Parameters.AddWithValue("@carrera", "");
                comandos_sql.Parameters.AddWithValue("@asignatura", "");
                comandos_sql.Parameters.AddWithValue("@idrecursos", "");
                comandos_sql.Parameters.AddWithValue("@idusuario", "");
                comandos_sql.Parameters.AddWithValue("@nombres", "");

                comandos_sql.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                data_reader = comandos_sql.ExecuteReader();

                listaSolicitud = new List<Solicitud>();

                while (data_reader.Read())
                {
                    Solicitud solicitud = new Solicitud();
                    solicitud.id_solicitud = Convert.ToInt32(data_reader["idsolicitud"].ToString());
                    solicitud.aula = data_reader["aula"].ToString();
                    solicitud.nivel = data_reader["nivel"].ToString();
                    solicitud.fecha_solicitud = Convert.ToDateTime(data_reader["fechasolicitud"].ToString());
                    solicitud.fecha_uso = Convert.ToDateTime(data_reader["fechauso"].ToString());
                    solicitud.hora_inicio = Convert.ToDateTime(data_reader["horainicio"].ToString());
                    solicitud.hora_final = Convert.ToDateTime(data_reader["horafinal"].ToString());
                    solicitud.carrera = data_reader["carrera"].ToString();
                    solicitud.asignatura = data_reader["asignatura"].ToString();
                    solicitud.id_recursos = Convert.ToInt32(data_reader["idrecursos"].ToString());
                    solicitud.id_usuario = Convert.ToInt32(data_reader["idusuario"].ToString());

                    listaSolicitud.Add(solicitud); // Agregar registros encontrados en la lista
                }
            }
            catch (Exception error)
            {
                error.Message.ToString();
                listaSolicitud = null;
            }
            finally
            {
                comandos_sql.Connection.Close();
            }

            return listaSolicitud;
        }
    }
}
