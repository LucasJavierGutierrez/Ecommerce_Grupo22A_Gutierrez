using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace negocio
{
    public class OrificiosXproductoNegocio
    {

        public List<OrificiosXproducto> listarL()
        {
            List<OrificiosXproducto> lista = new List<OrificiosXproducto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;


                comando.CommandText = "SELECT P.ID AS IDPRODUCTO, M.ID AS IDMATERIAL, M.NOMBRE AS NOMBREMATERIAL, C.STOCK, C.IDORIFICIOS FROM PRODUCTOS P INNER JOIN MATERIALES M ON M.ID = P.IDMATERIAL INNER JOIN ORIFICIOS_X_PRODUCTO C ON C.IDPRODUCTO = P.ID";



                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    OrificiosXproducto prod = new OrificiosXproducto();
                    prod.Stock = (int)lector["STOCK"];

                    prod.Orificios = new Orificios();
                    prod.Orificios.Id = (int)lector["IDCOLOR"];

                    prod.Producto = new Producto();
                    prod.Producto.Id = (int)lector["IDPRODUCTO"];

                    prod.Producto.Material = new Material();
                    prod.Producto.Material.Id = (int)lector["IDMATERIAL"];
                    prod.Producto.Material.Nombre = (string)lector["NOMBREMATERIAL"];


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


        public void agregarSP(OrificiosXproducto cxp)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_AGREGARORIFICIOS_x_PRODUCTO");
                datos.setearParametro("@IdProducto", cxp.Producto.Id);
                datos.setearParametro("@IdOrificios", cxp.Orificios.Id);
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
        public void modificarSP(OrificiosXproducto cxp)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MODIFICARORIFICIOS_x_PRODUCTO");
                datos.setearParametro("@IdProducto", cxp.Producto.Id);
                datos.setearParametro("@IdOrificios", cxp.Orificios.Id);
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
        public List<OrificiosXproducto> listarTodo()
        {
            List<OrificiosXproducto> lista = new List<OrificiosXproducto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT CXP.IDPRODUCTO,P.NOMBRE AS PRODUCTO, CXP.IDORIFICIOS,C.NOMBRE AS ORIFICIOS,CXP.STOCK FROM ORIFICIOS_X_PRODUCTO CXP INNER JOIN PRODUCTOS P ON P.ID=CXP.IDPRODUCTO INNER JOIN ORIFICIOS C ON C.ID= CXP.IDORIFICIOS";
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    OrificiosXproducto cxp = new OrificiosXproducto();

                    cxp.Producto = new Producto();
                    cxp.Producto.Id = (int)lector["IDPRODUCTO"];
                    cxp.Producto.Nombre = (string)lector["PRODUCTO"];

                    cxp.Orificios = new Orificios();
                    cxp.Orificios.Id = (int)lector["IDORIFICIOS"];
                    cxp.Orificios.Nombre = (string)lector["ORIFICIOS"];
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
        public OrificiosXproducto Listar(Producto pr, Orificios Orificios)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                OrificiosXproducto cxp = new OrificiosXproducto();
                datos.setearProcedimiento("SP_ListarStock");
                datos.setearParametro("@IdProducto", pr.Id);
                datos.setearParametro("@IdOrificios", Orificios.Id);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    cxp.Producto = pr;
                    cxp.Orificios = Orificios;
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
                comando.CommandText = "Select SUM(CXP.STOCK) from ORIFICIOS_X_PRODUCTO CXP WHERE IDPRODUCTO= " + idProducto;
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


        public List<Orificios> listarOrificiosXProducto(string idProducto)
        {
            List<Orificios> lista = new List<Orificios>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT C.ID as IDORIFICIOS, C.NOMBRE ORIFICIOS FROM ORIFICIOS_X_PRODUCTO CXP INNER JOIN ORIFICIOS C ON C.ID=CXP.IDORIFICIOS WHERE CXP.IDPRODUCTO = " + idProducto;


                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Orificios Orificios = new Orificios();
                    Orificios.Id = (int)lector["IDORIFICIOS"];
                    Orificios.Nombre = (string)lector["ORIFICIOS"];

                    lista.Add(Orificios);
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



