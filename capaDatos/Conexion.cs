using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace capaDatos
{
    public class Conexion
    {
        public SqlConnection conectar()
        {
            SqlConnection conexion = new SqlConnection();

            conexion.ConnectionString = "Data Source=.;Initial Catalog=bd_ger;Integrated Security=True";
            return conexion;
        }
    }
}
