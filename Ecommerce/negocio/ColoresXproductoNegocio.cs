using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace negocio
{
    public class ColoresXproductoNegocio
    {

        public List<ColoresXproducto> listarL()
        {
            List<ColoresXproducto> lista = new List<ColoresXproducto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;


                comando.CommandText = "SELECT P.ID AS IDPRODUCTO, M.ID AS IDMARCA, M.NOMBRE AS NOMBREMARCA, C.STOCK, C.IDCOLOR FROM PRODUCTOS P INNER JOIN MARCAS M ON M.ID = P.IDMARCA INNER JOIN COLORES_X_PRODUCTO C ON C.IDPRODUCTO = P.ID";



                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    ColoresXproducto prod = new ColoresXproducto();
                    prod.Stock = (int)lector["STOCK"];

                    prod.Color = new Color();
                    prod.Color.Id = (int)lector["IDCOLOR"];

                    prod.Producto = new Producto();
                    prod.Producto.Id = (int)lector["IDPRODUCTO"];

                    prod.Producto.Marca = new Marca();
                    prod.Producto.Marca.Id = (int)lector["IDMARCA"];
                    prod.Producto.Marca.Nombre = (string)lector["NOMBREMARCA"];


                    lista.Add(prod);
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


        public void agregarSP(ColoresXproducto cxp)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_AGREGARCOLOR_x_PRODUCTO");
                datos.setearParametro("@IdProducto", cxp.Producto.Id);
                datos.setearParametro("@IdColor", cxp.Color.Id);
                datos.setearParametro("@Stock", cxp.Stock);


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
        public void modificarSP(ColoresXproducto cxp)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MODIFICARCOLOR_x_PRODUCTO");
                datos.setearParametro("@IdProducto", cxp.Producto.Id);
                datos.setearParametro("@IdColor", cxp.Color.Id);
                datos.setearParametro("@Stock", cxp.Stock);


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
        public List<ColoresXproducto> listarTodo()
        {
            List<ColoresXproducto> lista = new List<ColoresXproducto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT CXP.IDPRODUCTO,P.NOMBRE AS PRODUCTO, CXP.IDCOLOR,C.NOMBRE AS COLOR,CXP.STOCK FROM COLORES_X_PRODUCTO CXP INNER JOIN PRODUCTOS P ON P.ID=CXP.IDPRODUCTO INNER JOIN COLORES C ON C.ID= CXP.IDCOLOR";
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    ColoresXproducto cxp = new ColoresXproducto();

                    cxp.Producto = new Producto();
                    cxp.Producto.Id = (int)lector["IDPRODUCTO"];
                    cxp.Producto.Nombre = (string)lector["PRODUCTO"];

                    cxp.Color = new Color();
                    cxp.Color.Id = (int)lector["IDCOLOR"];
                    cxp.Color.Nombre = (string)lector["COLOR"];
                    cxp.Stock = (int)lector["STOCK"];

                    lista.Add(cxp);
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
        public ColoresXproducto Listar(Producto pr, Color color)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                ColoresXproducto cxp = new ColoresXproducto();
                datos.setearProcedimiento("SP_ListarStock");
                datos.setearParametro("@IdProducto", pr.Id);
                datos.setearParametro("@IdColor", color.Id);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    cxp.Producto = pr;
                    cxp.Color = color;
                    cxp.Stock = (int)datos.Lector["STOCK"];


                }
                return cxp;

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

        public int sumaStockXProducto(int idProducto) 
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select SUM(CXP.STOCK) from COLORES_X_PRODUCTO CXP WHERE IDPRODUCTO= " + idProducto;
                comando.Connection = conexion;
                conexion.Open();

                int result = (int)comando.ExecuteScalar();



                //conexion.Close();
                return result;
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


        //public void eliminarConSP(int ID)
        //{
        //    AccesoDatos datos = new AccesoDatos();
        //    try
        //    {
        //        Producto aux = new Producto();
        //        datos.setearProcedimiento("SP_EliminaMarca");
        //        datos.setearParametro("@Id", ID);

        //        datos.ejectutarAccion();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}


        public List<Color> listarColorXProducto(string idProducto)
        {
            List<Color> lista = new List<Color>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT C.ID as IDCOLOR, C.NOMBRE NOMBRECOLOR FROM COLORES_X_PRODUCTO CXP INNER JOIN COLORES C ON C.ID=CXP.IDCOLOR WHERE CXP.IDPRODUCTO = " + idProducto;


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

    }
}



