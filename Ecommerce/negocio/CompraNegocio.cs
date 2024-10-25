using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CompraNegocio
    {
        public void registroCompra( carritoCompra carrito, int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_AgregarCompra");
                datos.setearParametro("@Id", carrito.Id);
                datos.setearParametro("@IdUsuario", id);
                //datos.setearParametro("@FechaCompra", carrito.FechaCompra);
                datos.setearParametro("@Total", carrito.total);

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

        //listarXfiltroFecha
        public List<carritoCompra> listarXfiltroFecha(string desde, string hasta)
        {

            List<carritoCompra> lista = new List<carritoCompra>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT V.ID, U.ID AS IDUSUARIO,U.NOMBRE AS NOMBREUSUARIO, U.APELLIDO AS APELLIDOUSUARIO,U.EMAIL AS EMAILUSUARIO,FECHAVENTA ,PRECIOTOTAL FROM VENTAS V INNER JOIN USUARIOS U ON V.IDUSUARIO = U.ID WHERE FORMAT(FECHAVENTA, 'yyyy-MM-dd') between '"+desde+"' and '"+hasta+"'";



                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    carritoCompra carrito = new carritoCompra();
                    carrito.Id = (int)lector["ID"];

                    carrito.usuario = new Usuario();
                    carrito.usuario.Id = (int)lector["IDUSUARIO"];
                    carrito.usuario.Nombre = (string)lector["NOMBREUSUARIO"];
                    carrito.usuario.Apellido = (string)lector["APELLIDOUSUARIO"];
                    carrito.usuario.Email = (string)lector["EMAILUSUARIO"];

                    if (!(lector["FECHAVENTA"] is DBNull))
                        carrito.FechaCompra = (DateTime)lector["FECHAVENTA"];

                    if (!(lector["PRECIOTOTAL"] is DBNull))
                        carrito.total = (decimal)lector["PRECIOTOTAL"];


                    lista.Add(carrito);
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

        public List<carritoCompra>  listar(string IdUsuario="")
        {

            List<carritoCompra> lista = new List<carritoCompra>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT V.ID, U.ID AS IDUSUARIO,U.NOMBRE AS NOMBREUSUARIO, U.APELLIDO AS APELLIDOUSUARIO,U.EMAIL AS EMAILUSUARIO,FECHAVENTA ,PRECIOTOTAL FROM VENTAS V INNER JOIN USUARIOS U ON V.IDUSUARIO = U.ID";
                if (IdUsuario != "")
                {
                    comando.CommandText += " WHERE U.ID = "+ IdUsuario+ " AND GETDATE()-FECHAVENTA<5"; 
                }



                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    carritoCompra carrito = new carritoCompra();
                    carrito.Id = (int)lector["ID"];

                    carrito.usuario = new Usuario();
                    carrito.usuario.Id = (int)lector["IDUSUARIO"];
                    carrito.usuario.Nombre = (string)lector["NOMBREUSUARIO"];
                    carrito.usuario.Apellido = (string)lector["APELLIDOUSUARIO"];
                    carrito.usuario.Email = (string)lector["EMAILUSUARIO"];

                    if (!(lector["FECHAVENTA"] is DBNull))
                        carrito.FechaCompra = (DateTime)lector["FECHAVENTA"];

                    if (!(lector["PRECIOTOTAL"] is DBNull))
                        carrito.total = (decimal)lector["PRECIOTOTAL"];


                    lista.Add(carrito);
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

        public void agregarDetalleXventa(itemCarrito item, int id)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_agregarDetalleVenta");
                datos.setearParametro("@Id", id);
                datos.setearParametro("@IdProducto", item.id);
                datos.setearParametro("@IdColor", item.color.Id);
                datos.setearParametro("@Cantidad", item.cantidad);
                datos.setearParametro("@Precio", item.subtotal);

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



        public List<Color> listaColoresXVentaXProducto(string idVenta, string idProducto)
        {


            List<Color> lista = new List<Color>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT C.ID AS IDCOLOR, C.NOMBRE AS NOMBRECOLOR FROM DETALLE_VENTA INNER JOIN COLORES C ON C.ID = IDCOLOR WHERE IDVENTA=" + idVenta + " AND IDPRODUCTO= " + idProducto;


                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {

                    Color color = new Color();
                    color.Id = (int)lector["IDCOLOR"];
                    color.Nombre = (string)lector["NOMBRECOLOR"];



                    lista.Add(color);
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



        public List<itemCarrito> listarXVenta(string idVenta)
        {


            List<itemCarrito> lista = new List<itemCarrito>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select DV.IDVENTA, PR.ID AS IDPRODUCTO, PR.NOMBRE AS NOMBREPRODUCTO,C.ID as IDCOLOR, C.NOMBRE as NOMBRECOLOR, DV.CANTIDAD, DV.PRECIO from DETALLE_VENTA DV INNER JOIN PRODUCTOS PR ON PR.ID = DV.IDPRODUCTO INNER JOIN COLORES C ON C.ID = DV.IDCOLOR WHERE DV.IDVENTA= " + idVenta;


                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    itemCarrito carrito = new itemCarrito();
                    carrito.id = (int)lector["IDVENTA"];
                    carrito.cantidad = (int)lector["CANTIDAD"];
                    carrito.subtotal = (decimal)lector["PRECIO"];
                        
                    carrito.color = new Color();
                    carrito.color.Id = (int)lector["IDCOLOR"];
                    carrito.color.Nombre = (string)lector["NOMBRECOLOR"];

                    carrito.item = new Producto();
                    carrito.item.Id = (int)lector["IDPRODUCTO"];
                    carrito.item.Nombre = (string)lector["NOMBREPRODUCTO"];



                    lista.Add(carrito);
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



    }
}
