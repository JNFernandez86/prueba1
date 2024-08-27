using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PruebaConexionylista
{
    class MarcaNegocio
    {
        private SqlConnection conexion;
        private SqlCommand cmd;
        private SqlDataReader lector;
        private string server = ("server=.;database=CATALOGO_DB; integrated security=true");
        private string ssql;
        public List<Marca> listar()
        {
            List<Marca> nuevo = new List<Marca>();

            //ssql = ;
            try
            {
                conexion = new SqlConnection(server);
                cmd = new SqlCommand();
                //conexion.ConnectionString = server;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = ("Select Id, Descripcion FROM Marcas;");
                cmd.Connection = conexion;
                conexion.Open();

                lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    Marca aux = new Marca();

                    aux.Id = (int)lector["Id"];
                    aux.Descripcion = (string)lector["Descripcion"];

                    nuevo.Add(aux);


                }

                return nuevo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                conexion.Close();
            }


          
        }
    }
}
