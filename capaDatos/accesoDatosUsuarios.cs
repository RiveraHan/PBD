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
    public class accesoDatosUsuarios
    {
        SqlConnection conexion; //Conexion
        Usuarios usuarios = new Usuarios(); //CapaEntidades
        Conexion _conexion = new Conexion(); // Conexion
        SqlCommand comandos_sql = null; // sql comandos

        int indicador = 0; // Variable indicador para comprobar CRUD
        SqlDataReader data_reader = null;
        List < Usuarios > listaUsuarios = null;

        /*Guardar usero*/

        public int insertarUsuario(Usuarios user)
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Usuarios", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 1); // Valores que toman los parámetros
                comandos_sql.Parameters.AddWithValue("@idusuario", "");
                comandos_sql.Parameters.AddWithValue("@cedula", user.cedula);
                comandos_sql.Parameters.AddWithValue("@nombres", user.nombres);
                comandos_sql.Parameters.AddWithValue("@apellidos", user.apellidos);
                comandos_sql.Parameters.AddWithValue("@email", user.email);
                comandos_sql.Parameters.AddWithValue("@telefono", user.telefono);

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

        /* Método listar usero */
        public List < Usuarios > listarUsuario()
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Usuarios", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 3);
                comandos_sql.Parameters.AddWithValue("@idusuario", "");
                comandos_sql.Parameters.AddWithValue("@cedula", "");
                comandos_sql.Parameters.AddWithValue("@nombres", "");
                comandos_sql.Parameters.AddWithValue("@apellidos", "");
                comandos_sql.Parameters.AddWithValue("@email", "");
                comandos_sql.Parameters.AddWithValue("@telefono", "");

                comandos_sql.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                data_reader = comandos_sql.ExecuteReader();

                listaUsuarios = new List<Usuarios>();

                while (data_reader.Read())
                {
                    Usuarios usuarios = new Usuarios();
                    usuarios.id_usuario = Convert.ToInt32(data_reader["idusuario"].ToString());
                    usuarios.cedula = data_reader["cedula"].ToString();
                    usuarios.nombres = data_reader["nombres"].ToString();
                    usuarios.apellidos = data_reader["apellidos"].ToString();
                    usuarios.email = data_reader["email"].ToString();
                    usuarios.telefono = data_reader["telefono"].ToString();

                    listaUsuarios.Add(usuarios); // Agregar registros encontrados en la lista
                }
            }
            catch (Exception error)
            {
                error.Message.ToString();
                listaUsuarios = null;
                
            }
            finally
            {
                comandos_sql.Connection.Close();
            }

            return listaUsuarios;
        }

        /* Método eliminar usero*/

        public int eliminarUsuario(int iduser)
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Usuarios", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 2);
                comandos_sql.Parameters.AddWithValue("@idusuario", iduser);
                comandos_sql.Parameters.AddWithValue("@cedula", "");
                comandos_sql.Parameters.AddWithValue("@nombres", "");
                comandos_sql.Parameters.AddWithValue("@apellidos", "");
                comandos_sql.Parameters.AddWithValue("@email", "");
                comandos_sql.Parameters.AddWithValue("@telefono", "");

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

        public int editarUsuario(Usuarios user)
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Usuarios", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 4);
                comandos_sql.Parameters.AddWithValue("@idusuario", user.id_usuario);
                comandos_sql.Parameters.AddWithValue("@cedula", user.cedula);
                comandos_sql.Parameters.AddWithValue("@nombres", user.nombres);
                comandos_sql.Parameters.AddWithValue("@apellidos", user.apellidos);
                comandos_sql.Parameters.AddWithValue("@email", user.email);
                comandos_sql.Parameters.AddWithValue("@telefono", user.telefono);

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

        public List<Usuarios> buscarUsuario(string dato)
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Usuarios", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 5);
                comandos_sql.Parameters.AddWithValue("@idusuario", "");
                comandos_sql.Parameters.AddWithValue("@cedula", dato);
                comandos_sql.Parameters.AddWithValue("@nombres", "");
                comandos_sql.Parameters.AddWithValue("@apellidos", "");
                comandos_sql.Parameters.AddWithValue("@email", "");
                comandos_sql.Parameters.AddWithValue("@telefono", "");

                comandos_sql.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                data_reader = comandos_sql.ExecuteReader();

                listaUsuarios = new List<Usuarios>();

                while (data_reader.Read())
                {
                    Usuarios usuarios = new Usuarios();
                    usuarios.id_usuario = Convert.ToInt32(data_reader["idusuario"].ToString());
                    usuarios.cedula = data_reader["cedula"].ToString();
                    usuarios.nombres = data_reader["nombres"].ToString();
                    usuarios.apellidos = data_reader["apellidos"].ToString();
                    usuarios.email = data_reader["email"].ToString();
                    usuarios.telefono = data_reader["telefono"].ToString();

                    listaUsuarios.Add(usuarios); // Agregar registros encontrados en la lista
                }
            }
            catch (Exception error)
            {
                error.Message.ToString();
                listaUsuarios = null;

            }
            finally
            {
                comandos_sql.Connection.Close();
            }

            return listaUsuarios;
        }
    }
}
