using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class OrificiosNegocio
    {
        public List<Orificios> listar(int idProducto) // en detalle productos muestra los colores disponibles
        {
            List<Orificios> lista = new List<Orificios>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT C.ID, C.NOMBRE FROM ORIFICIOS_X_PRODUCTO CXP INNER JOIN ORIFICIOS C ON CXP.IDORIFICIOS=C.ID WHERE CXP.IDPRODUCTO = " + idProducto + " AND CXP.STOCK > 0";
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Orificios Orificios = new Orificios();
                    Orificios.Id = (int)lector["ID"];
                    if (!(lector["NOMBRE"] is DBNull))
                        Orificios.Nombre = (string)lector["NOMBRE"];

                    lista.Add(Orificios);
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


        public List<Orificios> listarTodos() // en el agregar Producto, tengo que mostrar TODOS los orificios para que indique cual quiere agregar
        {
            List<Orificios> lista = new List<Orificios>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT C.ID, C.NOMBRE FROM ORIFICIOS C ";
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Orificios Orificios = new Orificios();
                    Orificios.Id = (int)lector["ID"];
                    if (!(lector["NOMBRE"] is DBNull))
                        Orificios.Nombre = (string)lector["NOMBRE"];
                    lista.Add(Orificios);
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
    }

}

