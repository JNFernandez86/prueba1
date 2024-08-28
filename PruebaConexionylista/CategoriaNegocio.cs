using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PruebaConexionylista
{
    public class CategoriaNegocio

    {
        string cadena = ("server=.;database=CATALOGO_DB; integrated security=true");
        private SqlConnection conexion;
        string ssql;
        SqlDataReader dr;

        public List<Categoria> Listar_Categorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            ssql = "SELECT Id, Descripcion FROM CATEGORIAS";
            conexion = new SqlConnection(cadena);
            try
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = ssql;

                conexion.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id_Cat = (int)dr["Id"];
                    aux.Descripcion = (string)dr["Descripcion"];
                    categorias.Add(aux);
                }
                return categorias;


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
