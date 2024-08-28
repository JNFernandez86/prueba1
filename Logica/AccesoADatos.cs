using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Logica
{
    public class AccesoADatos
    {
        private string basedatos = ("server=.;database=CATALOGO_DB; integrated security=true");
        private SqlConnection conexion;
        private SqlCommand cmd;
        private SqlDataReader lector;

        public AccesoADatos()
            {
            conexion = new SqlConnection(basedatos);
            cmd = new SqlCommand();
            }
        public SqlDataReader da
        {
            get { return lector; }
        }

        public void abrirConexion()
        {
            
            cmd.Connection = conexion;
            if(conexion.State == ConnectionState.Closed)
                conexion.Open();
        }
        public void cerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
        }
        
        public void cargarConsulta(string ssql)
        {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = ssql;
        }

        public void leerDatos()
        {
            abrirConexion();
            lector = cmd.ExecuteReader();
        }


    }
}
