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
    public class accesoDatosRecursos
    {
        SqlConnection conexion; //Conexion
        Recursos recursos = new Recursos(); //CapaEntidades
        Conexion _conexion = new Conexion(); // Conexion
        SqlCommand comandos_sql = null; // sql comandos

        int indicador = 0; // Variable indicador para comprobar CRUD
        SqlDataReader data_reader = null;
        List<Recursos> listaRecursos = null;

        /*Guardar recurso*/

        public int insertarRecurso(Recursos recurs)
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Recursos", conexion);

                if(recurs.nombre_recursos !=  "" && recurs.codigo != "")
                {
                    comandos_sql.Parameters.AddWithValue("@b", 1); // Valores que toman los parámetros
                    comandos_sql.Parameters.AddWithValue("@idrecursos", "");
                    comandos_sql.Parameters.AddWithValue("@nombrer", recurs.nombre_recursos);
                    comandos_sql.Parameters.AddWithValue("@codigo", recurs.codigo);
                    comandos_sql.Parameters.AddWithValue("@descripcion", recurs.descripcion);

                    comandos_sql.CommandType = CommandType.StoredProcedure; // Tipo de comando sql ejecutado
                    conexion.Open();
                    comandos_sql.ExecuteNonQuery(); // Ejecución de consulta
                    indicador = 1;
                }
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

        /* Método listar recurso */
        public List < Recursos > listarRecurso()
        {
            try
            {
                SqlConnection conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Recursos", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 3);
                comandos_sql.Parameters.AddWithValue("@idrecursos", "");
                comandos_sql.Parameters.AddWithValue("@nombrer", "");
                comandos_sql.Parameters.AddWithValue("@codigo", "");
                comandos_sql.Parameters.AddWithValue("@descripcion", "");

                comandos_sql.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                data_reader = comandos_sql.ExecuteReader();

                listaRecursos = new List <Recursos>();

                while (data_reader.Read())
                {
                    Recursos recursos = new Recursos();
                    recursos.id_recursos = Convert.ToInt32(data_reader["idrecursos"].ToString());
                    recursos.nombre_recursos = data_reader["nombrer"].ToString();
                    recursos.codigo = data_reader["codigo"].ToString();
                    recursos.descripcion = data_reader["descripcion"].ToString();

                    listaRecursos.Add(recursos); // Agregar registros encontrados en la lista
                }
            }
            catch (Exception error)
            {
                error.Message.ToString();
                listaRecursos = null;
            }
            finally
            {
                comandos_sql.Connection.Close();
            }

            return listaRecursos;
        }

        /* Método eliminar recurso*/

        public int eliminarRecurso(int idRecurs)
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Recursos", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 2);
                comandos_sql.Parameters.AddWithValue("@idrecursos", idRecurs);
                comandos_sql.Parameters.AddWithValue("@nombrer", "");
                comandos_sql.Parameters.AddWithValue("@codigo", "");
                comandos_sql.Parameters.AddWithValue("@descripcion", "");

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

        public int editarRecurso(Recursos recurs)
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Recursos", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 4);
                comandos_sql.Parameters.AddWithValue("@idrecursos", recurs.id_recursos);
                comandos_sql.Parameters.AddWithValue("@nombrer", recurs.nombre_recursos);
                comandos_sql.Parameters.AddWithValue("@codigo", recurs.codigo);
                comandos_sql.Parameters.AddWithValue("@descripcion", recurs.descripcion);

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

        /* Método buscar*/

        public List< Recursos > buscarRecurso(string dato)
        {
            try
            {
                SqlConnection conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Recursos", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 5);
                comandos_sql.Parameters.AddWithValue("@idrecursos", "");
                comandos_sql.Parameters.AddWithValue("@nombrer", dato);
                comandos_sql.Parameters.AddWithValue("@codigo", "");
                comandos_sql.Parameters.AddWithValue("@descripcion", "");

                comandos_sql.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                data_reader = comandos_sql.ExecuteReader();
                listaRecursos = new List<Recursos>();

                while (data_reader.Read())
                {
                    Recursos recursos = new Recursos();
                    recursos.id_recursos = Convert.ToInt32(data_reader["idrecursos"].ToString());
                    recursos.nombre_recursos = data_reader["nombrer"].ToString();
                    recursos.codigo = data_reader["codigo"].ToString();
                    recursos.descripcion = data_reader["descripcion"].ToString();

                    listaRecursos.Add(recursos);
                }
            }
            catch (Exception error)

            {
                error.Message.ToString();
                listaRecursos = null;
            }
            finally { comandos_sql.Connection.Close(); }

            return listaRecursos;
        }

    }
}

