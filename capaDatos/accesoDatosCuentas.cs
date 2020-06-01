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
    public class accesoDatosCuentas
    {
        SqlConnection conexion; //Conexion
        Cuentas cuenta = new Cuentas(); //CapaEntidades
        Conexion _conexion = new Conexion(); // Conexion
        SqlCommand comandos_sql = null; // sql comandos

        int indicador = 0; // Variable indicador para comprobar CRUD
        SqlDataReader data_reader = null;
        List<Cuentas> listaCuentas = null;

        /*Insertar cuentas*/

        public int insertarCuentas(Cuentas cuent)
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Cuentas", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 1); // Valores que toman los parámetros
                comandos_sql.Parameters.AddWithValue("@idcuenta", "");
                comandos_sql.Parameters.AddWithValue("@nombreuser", cuent.nombre_user);
                comandos_sql.Parameters.AddWithValue("@clave", cuent.clave);
                comandos_sql.Parameters.AddWithValue("@rol", cuent.rol);
                comandos_sql.Parameters.AddWithValue("@idusuario", cuent.id_usuario);

                comandos_sql.CommandType = CommandType.StoredProcedure; // Tipo de comando sql ejecutado
                conexion.Open();
                comandos_sql.ExecuteNonQuery(); // Ejecución de consulta
                indicador = 1;
            } catch(Exception error)
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

        /* Método listar cuentas */
        public List <Cuentas> listarCuentas()
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Cuentas", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 3);
                comandos_sql.Parameters.AddWithValue("@idcuenta", "");
                comandos_sql.Parameters.AddWithValue("@nombreuser", "");
                comandos_sql.Parameters.AddWithValue("@clave", "");
                comandos_sql.Parameters.AddWithValue("@rol", "");
                comandos_sql.Parameters.AddWithValue("@idusuario", "");

                comandos_sql.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                data_reader = comandos_sql.ExecuteReader();

                while (data_reader.Read())
                {
                    cuenta.id_cuenta = Convert.ToInt32(data_reader["idcuenta"].ToString());
                    cuenta.nombre_user = data_reader["nombreuser"].ToString();
                    cuenta.clave = data_reader["clave"].ToString();
                    cuenta.rol = data_reader["rol"].ToString();
                    cuenta.id_usuario = Convert.ToInt32(data_reader["idusuario"].ToString());

                    listaCuentas.Add(cuenta); // Agregar registros encontrados en la lista
                }
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

            return listaCuentas;
        }

        /* Método eliminar cuentas*/

        public int eliminarCuenta(int idCuent)
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Cuentas", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 2);
                comandos_sql.Parameters.AddWithValue("@idcuenta", idCuent);
                comandos_sql.Parameters.AddWithValue("@nombreuser", "");
                comandos_sql.Parameters.AddWithValue("@clave", "");
                comandos_sql.Parameters.AddWithValue("@rol", "");
                comandos_sql.Parameters.AddWithValue("@idusuario", "");

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
            finally { comandos_sql.Connection.Close(); }

            return indicador;
        }

        /* Método Actualizar*/

        public int editarCuentas (Cuentas cuent)
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Cuentas", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 4);
                comandos_sql.Parameters.AddWithValue("@idcuenta", cuent.id_cuenta);
                comandos_sql.Parameters.AddWithValue("@nombreuser", "");
                comandos_sql.Parameters.AddWithValue("@clave", cuent.clave);
                comandos_sql.Parameters.AddWithValue("@rol", cuent.rol);
                comandos_sql.Parameters.AddWithValue("@idusuario", "");

                comandos_sql.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                comandos_sql.ExecuteNonQuery();
                indicador = 1;

            } catch(Exception error)
            {
                error.Message.ToString();
                indicador = 0;
            }
            finally { comandos_sql.Connection.Close(); }

            return indicador;
        }

        /* Método buscar*/

        public List < Cuentas > buscarCuenta(string dato)
        {
            try
            {
                conexion = _conexion.conectar();

                comandos_sql = new SqlCommand("_Cuentas", conexion);

                comandos_sql.Parameters.AddWithValue("@b", 5);
                comandos_sql.Parameters.AddWithValue("@idcuenta", "");
                comandos_sql.Parameters.AddWithValue("@nombreuser", dato);
                comandos_sql.Parameters.AddWithValue("@clave", dato);
                comandos_sql.Parameters.AddWithValue("@rol", "");
                comandos_sql.Parameters.AddWithValue("@idusuario", "");

                comandos_sql.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                data_reader = comandos_sql.ExecuteReader();

                while (data_reader.Read())
                {
                    cuenta.id_cuenta = Convert.ToInt32(data_reader["idcuenta"].ToString());
                    cuenta.nombre_user = data_reader["nombreuser"].ToString();
                    cuenta.clave = data_reader["clave"].ToString();
                    cuenta.rol = data_reader["rol"].ToString();
                    cuenta.id_usuario = Convert.ToInt32(data_reader["idusuario"].ToString());

                    listaCuentas.Add(cuenta); 
                }
            } catch(Exception error)
            {
                error.Message.ToString();
                listaCuentas = null;
            }
            finally { comandos_sql.Connection.Close(); }

            return listaCuentas;
        }

    }
}
