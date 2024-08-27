using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaConexionylista
{
    public class ArticuloNegocio
    {
        private string basedatos = ("server=.;database=CATALOGO_DB; integrated security=true");
        public List<Articulo> listarart()
        {
            List<Articulo> articulos = new List<Articulo>();
            SqlConnection conexion = new SqlConnection(basedatos);

            try
            {
               
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = ("select codigo, nombre, descripcion, precio from ARTICULOS;");

                conexion.Open();
                SqlDataReader lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    Articulo negocio = new Articulo();

                    negocio.Codigo = (string)lector["Codigo"];
                    negocio.Nombre = (string)lector["Nombre"];
                    negocio.Descripcion = (string)lector["Descripcion"];
                    negocio.Precio = (decimal)lector["Precio"];
                    articulos.Add(negocio);
                }
                return articulos;

                //SqlConnection conexion 

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
