using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class SolicitudDevolucionNegocio
    {


        public void cancelarSolicitudDevolucion(SolicitudDevolucion solicitud)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearProcedimiento("SP_CANCELARSOLICITUDEVOLUCION");
                datos.setearParametro("@IDSOLICITUD", solicitud.Id);


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
        public void agregarSolicitud(SolicitudDevolucion solicitud)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearProcedimiento("SP_InsertaSolicitudDevolucion");

                datos.setearParametro("@IdVenta", solicitud.IdVenta);
                datos.setearParametro("@IdProducto", solicitud.producto.Id);
                datos.setearParametro("@IdColor", solicitud.color.Id);
                datos.setearParametro("@IdUsuario", solicitud.usuario.Id);
                datos.setearParametro("@Motivo", solicitud.motivo);
                datos.setearParametro("@Cantidad", solicitud.cantidad);


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

        public List<SolicitudDevolucion> listaSolicitudes()
        {
            List<SolicitudDevolucion> lista = new List<SolicitudDevolucion>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT DEV.ID as IDPEDIDO, DEV.IDVENTA,U.ID AS IDUSUARIO, U.NOMBRE AS NOMBREUSUARIO,U.APELLIDO as APELLIDOUSUARIO,U.EMAIL AS EMAILUSUARIO,PR.ID AS IDPRODUCTO, PR.NOMBRE AS NOMBREPRODUCTO,C.ID AS IDCOLOR, C.NOMBRE AS NOMBRECOLOR, DEV.MOTIVO, DEV.CANTIDAD FROM DEVOLUCIONES DEV INNER JOIN PRODUCTOS PR ON PR.ID=DEV.IDPRODUCTO INNER JOIN COLORES C ON C.ID=DEV.IDCOLOR INNER JOIN USUARIOS U ON U.ID=DEV.IDUSUARIO WHERE DEVUELTO = 0";


                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    SolicitudDevolucion sd = new SolicitudDevolucion();
                    sd.Id = (int)lector["IDPEDIDO"];
                    sd.IdVenta = (int)lector["IDVENTA"];
                    sd.producto = new Producto();
                    sd.producto.Id = (int)lector["IDPRODUCTO"];
                    sd.producto.Nombre = (string)lector["NOMBREPRODUCTO"];

                    sd.color = new Color();
                    sd.color.Id = (int)lector["IDCOLOR"];
                    sd.color.Nombre = (string)lector["NOMBRECOLOR"];

                    sd.usuario = new Usuario();
                    sd.usuario.Id = (int)lector["IDUSUARIO"];
                    sd.usuario.Nombre = (string)lector["NOMBREUSUARIO"];
                    sd.usuario.Apellido = (string)lector["APELLIDOUSUARIO"];
                    sd.usuario.Email = (string)lector["EMAILUSUARIO"];

                    sd.motivo = (string)lector["MOTIVO"];
                    sd.cantidad = (int)lector["CANTIDAD"];


                    lista.Add(sd);
                }


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

        public void ActualizaTablaCompra(int IdVenta, int IdProducto, int IdColor, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ACTUALIZARCOMPRA");
                datos.setearParametro("@IdVenta", IdVenta);
                datos.setearParametro("@IdProducto", IdProducto);
                datos.setearParametro("@IdColor", IdColor);
                datos.setearParametro("@Cantidad", cantidad);


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
        public void DevolucionAceptada(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ActualizaEstadoTablaDevolucion");
                datos.setearParametro("@Id", id);


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

        public void sumoStock(int idProducto, int idColor, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_SumoStock");
                datos.setearParametro("@idProducto", idProducto);
                datos.setearParametro("@idColor", idColor);
                datos.setearParametro("@cantidadDevuelto", cantidad);


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
