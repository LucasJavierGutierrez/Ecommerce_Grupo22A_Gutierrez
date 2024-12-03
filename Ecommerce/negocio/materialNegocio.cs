using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class materialNegocio
    {
        public List<Material> listar()
        {
            List<Material> lista = new List<Material>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT ID, NOMBRE FROM MATERIALES";
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Material material = new Material();
                    material.Id = (int)lector["ID"];
                    if (!(lector["NOMBRE"] is DBNull))
                        material.Nombre = (string)lector["NOMBRE"];


                    lista.Add(material);
                }

                //conexion.Close();
                return lista;
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

        public void agregar(Material nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values('" + nuevo.Nombre + "')";

                datos.setearConsulta("insert into Materiales (Nombre) " + valores);

                datos.ejectutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void ModificarSP(int id, Material nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MODIFICAMATERIAL");
                datos.setearParametro("@Id", id);
                datos.setearParametro("@Nombre", nueva.Nombre);

                datos.ejectutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void eliminarConSP(int ID)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                Producto aux = new Producto();
                datos.setearProcedimiento("SP_EliminaMaterial");
                datos.setearParametro("@Id", ID);

                datos.ejectutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

    }
}
