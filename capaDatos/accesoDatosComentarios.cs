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
    public class accesoDatosComentarios
    {
        SqlConnection conexion;// Conexión
        Comentarios comentario = new Comentarios(); //Capa Entidades

        Conexion _conexion = new Conexion();// Conexión
        SqlCommand comandos_sql = null; // Comandos SQL

        int indicador = 0; // Variable indicador para comprobar CRUD

        SqlDataReader data_reader = null;// Para cargar los datos
        List <Comentarios> listaComentarios = null;

        /*Método para la inserción de datos para comentarios*/

        public int insertarComentarios(Comentarios coment)
        {
            try
            {
                conexion = _conexion.conectar(); // Conexiòn

                comandos_sql = new SqlCommand("Comentar", conexion);// Nombre del procedimiento SQL

                comandos_sql.Parameters.AddWithValue("@b", 1); // Valores que toman los parámetros
                comandos_sql.Parameters.AddWithValue("@idcomentario", "");
                comandos_sql.Parameters.AddWithValue("@nombres", coment.nombres);
                comandos_sql.Parameters.AddWithValue("@correo", coment.correo);
                comandos_sql.Parameters.AddWithValue("@telefono", coment.telefono);
                comandos_sql.Parameters.AddWithValue("@mensaje", coment.mensaje);

                comandos_sql.CommandType = CommandType.StoredProcedure;// Tipo de comando ejecutado
                conexion.Open(); // Abrir conexión de BD
                comandos_sql.ExecuteNonQuery();// Ejecución de consulta
                indicador = 1; // Valor del indicador
                    
            }
            catch(Exception error)
            {
                error.Message.ToString();// Mostrar mensaje en  caso de error
                indicador = 1;
            }
            finally
            {
                comandos_sql.Connection.Close();// Cierre de conexión
            }
            return indicador;
        }

        /* Método listar comentarios */

        public List < Comentarios > listarComentario()
        {
            try
            {
                conexion = _conexion.conectar();
                comandos_sql = new SqlCommand("Comentar", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 3);
                comandos_sql.Parameters.AddWithValue("@idcomentario", "");
                comandos_sql.Parameters.AddWithValue("@nombres", "");
                comandos_sql.Parameters.AddWithValue("@correo", "");
                comandos_sql.Parameters.AddWithValue("@telefono", "");
                comandos_sql.Parameters.AddWithValue("@mensaje", "");

                comandos_sql.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                data_reader = comandos_sql.ExecuteReader();

                listaComentarios = new List<Comentarios>();

                while (data_reader.Read())// Recorrer cada registro
                {
                    Comentarios comentario = new Comentarios();
                    comentario.id_comentario = Convert.ToInt32(data_reader["idcomentario"].ToString());
                    comentario.nombres = data_reader["nombres"].ToString();
                    comentario.correo = data_reader["correo"].ToString();
                    comentario.telefono = data_reader["telefono"].ToString();
                    comentario.mensaje = data_reader["mensaje"].ToString();

                    listaComentarios.Add(comentario);
                }
            }
            catch(Exception error)
            {
                error.Message.ToString();
                listaComentarios = null;
            }
            finally
            {
                comandos_sql.Connection.Close();
            }

            return listaComentarios;
        }

        /* Método eliminar comentario*/

        public int eliminarComentarios(int idComent)
        {
            try
            {
                conexion = _conexion.conectar();
                comandos_sql = new SqlCommand("Comentar", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 2);
                comandos_sql.Parameters.AddWithValue("@idcomentario", idComent);// Parámetro del proced.Almacenado
                comandos_sql.Parameters.AddWithValue("@nombres", "");
                comandos_sql.Parameters.AddWithValue("@correo", "");
                comandos_sql.Parameters.AddWithValue("@telefono", "");
                comandos_sql.Parameters.AddWithValue("@mensaje", "");

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
            finally
            {
                comandos_sql.Connection.Close();
            }

            return indicador;
        }

        /*Método para actualizar datos en comentarios*/

        public int editarComentarios(Comentarios coment)
        {
            try
            {
                conexion = _conexion.conectar(); // Conexiòn

                comandos_sql = new SqlCommand("Comentar", conexion);// Nombre del procedimiento SQL

                comandos_sql.Parameters.AddWithValue("@b", 4); // Valores que toman los parámetros
                comandos_sql.Parameters.AddWithValue("@idcomentario", coment.id_comentario);
                comandos_sql.Parameters.AddWithValue("@nombres", coment.nombres);
                comandos_sql.Parameters.AddWithValue("@correo", coment.correo);
                comandos_sql.Parameters.AddWithValue("@telefono", coment.telefono);
                comandos_sql.Parameters.AddWithValue("@mensaje", coment.mensaje);

                comandos_sql.CommandType = CommandType.StoredProcedure;// Tipo de comando ejecutado
                conexion.Open(); // Abrir conexión de BD
                comandos_sql.ExecuteNonQuery();// Ejecución de consulta
                indicador = 1; // Valor del indicador

            }
            catch (Exception error)
            {
                error.Message.ToString();// Mostrar mensaje en  caso de error
                indicador = 0;
            }
            finally
            {
                comandos_sql.Connection.Close();// Cierre de conexión
            }
            return indicador;
        }

        /* Método buscar comentarios */

        public List<Comentarios> buscarComentarios(string dato)
        {
            try
            {
                conexion = _conexion.conectar();
                comandos_sql = new SqlCommand("Comentar", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 5);
                comandos_sql.Parameters.AddWithValue("@idcomentario", "");
                comandos_sql.Parameters.AddWithValue("@nombres", dato);
                comandos_sql.Parameters.AddWithValue("@correo", "");
                comandos_sql.Parameters.AddWithValue("@telefono", "");
                comandos_sql.Parameters.AddWithValue("@mensaje", "");

                comandos_sql.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                data_reader = comandos_sql.ExecuteReader();
                listaComentarios = new List<Comentarios>(); ;// Lista de comentarios

                while (data_reader.Read())// Recorrer cada registro
                {
                    Comentarios comentario = new Comentarios();
                    comentario.id_comentario = Convert.ToInt32(data_reader["idcomentario"].ToString());
                    comentario.nombres = data_reader["nombres"].ToString();
                    comentario.correo = data_reader["correo"].ToString();
                    comentario.telefono = data_reader["telefono"].ToString();
                    comentario.mensaje = data_reader["mensaje"].ToString();

                    listaComentarios.Add(comentario);
                }
            }
            catch (Exception error)
            {
                error.Message.ToString();
                listaComentarios = null;
            }
            finally
            {
                comandos_sql.Connection.Close();
            }

            return listaComentarios;// Regresar lista
        }


    }


}
