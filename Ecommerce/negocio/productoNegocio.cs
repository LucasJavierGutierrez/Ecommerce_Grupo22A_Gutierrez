using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class productoNegocio
    {
        public List<Producto> listarPlacasXfiltroSearch(string nombreProducto)
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT P.ID, P.NOMBRE, P.DESCRIPCION, T.ID AS IDTIPO, T.NOMBRE AS NOMBRETIPO, M.ID AS IDMATERIAL, M.NOMBRE AS NOMBREMATERIAL, P.LADO, P.TIPO_BLOQUEO, P.CANTIDAD_ORIFICIOS, P.DIAMETRO, P.IMAGEN1,P.IMAGEN2,P.IMAGEN3,P.IMAGEN4, P.PRECIO, P.ESTADO FROM PRODUCTOS P INNER JOIN TIPOS T ON T.ID= P.IDTIPO INNER JOIN MATERIALES M ON M.ID = P.IDMATERIAL WHERE ESTADO=1 AND T.NOMBRE LIKE 'PLACAS' AND P.NOMBRE LIKE '%" + nombreProducto.ToString() + "%' OR M.NOMBRE LIKE '%" + nombreProducto.ToString() + "%'";


                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Producto prod = new Producto();
                    prod.Id = (int)lector["ID"];
                    if (!(lector["NOMBRE"] is DBNull))
                        prod.Nombre = (string)lector["NOMBRE"];
                    if (!(lector["DESCRIPCION"] is DBNull))
                        prod.Descripcion = (string)lector["DESCRIPCION"];
                    if (!(lector["IMAGEN1"] is DBNull))
                        prod.Imagen1 = (string)lector["IMAGEN1"];
                    if (!(lector["IMAGEN2"] is DBNull))
                        prod.Imagen2 = (string)lector["IMAGEN2"];
                    if (!(lector["IMAGEN3"] is DBNull))
                        prod.Imagen3 = (string)lector["IMAGEN3"];
                    if (!(lector["IMAGEN4"] is DBNull))
                        prod.Imagen4 = (string)lector["IMAGEN4"];
                    if (!(lector["PRECIO"] is DBNull))
                        prod.Precio = (decimal)lector["PRECIO"];
                    if (!(lector["CANTIDAD_ORIFICIOS"] is DBNull))
                        prod.Cantidad_Orificios = (int)lector["CANTIDAD_ORIFICIOS"];
                    if (!(lector["DIAMETRO"] is DBNull))
                        prod.Diametro = (int)lector["DIAMETRO"];
                    if (!(lector["TIPO_BLOQUEO"] is DBNull))
                        prod.Tipo_Bloqueo = (string)lector["TIPO_BLOQUEO"];
                    if (!(lector["LADO"] is DBNull))
                        prod.Lado = (string)lector["LADO"];
                    if (!(lector["ESTADO"] is DBNull))
                        prod.Estado = (bool)lector["ESTADO"];

                    prod.Material = new Material();
                    prod.Material.Id = (int)lector["IDMATERIAL"];
                    prod.Material.Nombre = (string)lector["NOMBREMATERIAL"];


                    prod.Tipo = new Tipo();
                    prod.Tipo.Id = (int)lector["IDTIPO"];
                    //SI EL TIPO DE ARTICULO NO ES NULO LO LEE
                    if (!(lector["NOMBRETIPO"] is DBNull))
                        prod.Tipo.Nombre = (string)lector["NOMBRETIPO"];



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
        public List<Producto> listar(string id="")
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                if (id == "")
                {
                comando.CommandText = "SELECT P.ID, P.NOMBRE, P.DESCRIPCION, T.ID AS IDTIPO, T.NOMBRE AS NOMBRETIPO, M.ID AS IDMATERIAL, M.NOMBRE AS NOMBREMATERIAL, P.LADO, P.TIPO_BLOQUEO, P.CANTIDAD_ORIFICIOS, P.DIAMETRO, P.IMAGEN1,P.IMAGEN2,P.IMAGEN3,P.IMAGEN4 , P.PRECIO, P.LADO,P.ESTADO FROM PRODUCTOS P INNER JOIN TIPOS T ON T.ID= P.IDTIPO INNER JOIN MATERIALES M ON M.ID = P.IDMATERIAL WHERE ESTADO=1";

                }
                if (id != "")
                {
                    comando.CommandText = "SELECT P.ID, P.NOMBRE, P.DESCRIPCION, T.ID AS IDTIPO, T.NOMBRE AS NOMBRETIPO, M.ID AS IDMATERIAL, M.NOMBRE AS NOMBREMATERIAL, P.LADO, P.TIPO_BLOQUEO, P.CANTIDAD_ORIFICIOS, P.DIAMETRO, P.IMAGEN1,P.IMAGEN2,P.IMAGEN3,P.IMAGEN4, P.PRECIO,P.LADO, P.ESTADO FROM PRODUCTOS P INNER JOIN TIPOS T ON T.ID= P.IDTIPO INNER JOIN MATERIALES M ON M.ID = P.IDMATERIAL WHERE ESTADO=1 AND P.ID= " + id.ToString();

                }
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Producto prod = new Producto();
                    prod.Id = (int)lector["ID"];
                    if (!(lector["NOMBRE"] is DBNull))
                        prod.Nombre = (string)lector["NOMBRE"];
                    if (!(lector["DESCRIPCION"] is DBNull))
                        prod.Descripcion = (string)lector["DESCRIPCION"];
                    if (!(lector["IMAGEN1"] is DBNull))
                        prod.Imagen1 = (string)lector["IMAGEN1"];
                    if (!(lector["IMAGEN2"] is DBNull))
                        prod.Imagen2 = (string)lector["IMAGEN2"];
                    if (!(lector["IMAGEN3"] is DBNull))
                        prod.Imagen3 = (string)lector["IMAGEN3"];
                    if (!(lector["IMAGEN4"] is DBNull))
                        prod.Imagen4 = (string)lector["IMAGEN4"];
                    if (!(lector["PRECIO"] is DBNull))
                        prod.Precio = (decimal)lector["PRECIO"];
                    if (!(lector["CANTIDAD_ORIFICIOS"] is DBNull))
                        prod.Cantidad_Orificios = (int)lector["CANTIDAD_ORIFICIOS"];
                    if (!(lector["DIAMETRO"] is DBNull))
                        prod.Diametro = (int)lector["DIAMETRO"];
                    if (!(lector["TIPO_BLOQUEO"] is DBNull))
                        prod.Tipo_Bloqueo = (string)lector["TIPO_BLOQUEO"];
                    if (!(lector["LADO"] is DBNull))
                        prod.Lado = (string)lector["LADO"];

                    if (!(lector["ESTADO"] is DBNull))
                        prod.Estado = (bool)lector["ESTADO"];

                    prod.Material = new Material();
                    prod.Material.Id = (int)lector["IDMATERIAL"];
                    prod.Material.Nombre = (string)lector["NOMBREMATERIAL"];


                    prod.Tipo = new Tipo();
                    prod.Tipo.Id = (int)lector["IDTIPO"];
                    //SI EL TIPO DE ARTICULO NO ES NULO LO LEE
                    if (!(lector["NOMBRETIPO"] is DBNull))
                        prod.Tipo.Nombre = (string)lector["NOMBRETIPO"];



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

        public List<Producto> listarConFiltro(string nombreProducto)
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                if (nombreProducto != "")
                {
                    comando.CommandText = "SELECT P.ID, P.NOMBRE, P.DESCRIPCION, T.ID AS IDTIPO,T.NOMBRE AS NOMBRETIPO, M.ID AS IDMATERIAL, M.NOMBRE AS NOMBREMATERIAL, P.TIPO_BLOQUEO, P.CANTIDAD_ORIFICIOS, P.DIAMETRO, P.IMAGEN1,P.IMAGEN2,P.IMAGEN3,P.IMAGEN4, P.PRECIO,P.LADO,  P.ESTADO FROM PRODUCTOS P INNER JOIN TIPOS T ON T.ID= P.IDTIPO INNER JOIN MATERIALES M ON M.ID = P.IDMATERIAL WHERE ESTADO=1 AND P.NOMBRE LIKE '%" + nombreProducto.ToString()+ "%' OR M.NOMBRE LIKE '%" + nombreProducto.ToString() + "%'";

                }
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Producto prod = new Producto();
                    prod.Id = (int)lector["ID"];
                    if (!(lector["NOMBRE"] is DBNull))
                        prod.Nombre = (string)lector["NOMBRE"];
                    if (!(lector["DESCRIPCION"] is DBNull))
                        prod.Descripcion = (string)lector["DESCRIPCION"];
                    if (!(lector["IMAGEN1"] is DBNull))
                        prod.Imagen1 = (string)lector["IMAGEN1"];
                    if (!(lector["IMAGEN2"] is DBNull))
                        prod.Imagen2 = (string)lector["IMAGEN2"];
                    if (!(lector["IMAGEN3"] is DBNull))
                        prod.Imagen3 = (string)lector["IMAGEN3"];
                    if (!(lector["IMAGEN4"] is DBNull))
                        prod.Imagen4 = (string)lector["IMAGEN4"];
                    if (!(lector["PRECIO"] is DBNull))
                        prod.Precio = (decimal)lector["PRECIO"];
                    if (!(lector["CANTIDAD_ORIFICIOS"] is DBNull))
                        prod.Cantidad_Orificios = (int)lector["CANTIDAD_ORIFICIOS"];
                    if (!(lector["DIAMETRO"] is DBNull))
                        prod.Diametro = (int)lector["DIAMETRO"];
                    if (!(lector["TIPO_BLOQUEO"] is DBNull))
                        prod.Tipo_Bloqueo = (string)lector["TIPO_BLOQUEO"];
                    if (!(lector["LADO"] is DBNull))
                        prod.Lado = (string)lector["LADO"];
                    if (!(lector["ESTADO"] is DBNull))
                        prod.Estado = (bool)lector["ESTADO"];

                    prod.Material = new Material();
                    prod.Material.Id = (int)lector["IDMATERIAL"];
                    prod.Material.Nombre = (string)lector["NOMBREMATERIAL"];


                    prod.Tipo = new Tipo();
                    prod.Tipo.Id = (int)lector["IDTIPO"];
                    //SI EL TIPO DE ARTICULO NO ES NULO LO LEE
                    if (!(lector["NOMBRETIPO"] is DBNull))
                        prod.Tipo.Nombre = (string)lector["NOMBRETIPO"];



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
        public List<Producto> listarXFiltro(int tipoFiltro)
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT P.ID, P.NOMBRE, P.DESCRIPCION, T.ID AS IDTIPO, T.NOMBRE AS NOMBRETIPO, M.ID AS IDMATERIAL, M.NOMBRE AS NOMBREMATERIAL, P.TIPO_BLOQUEO, P.CANTIDAD_ORIFICIOS, P.DIAMETRO, P.IMAGEN1,P.IMAGEN2,P.IMAGEN3,P.IMAGEN4, P.PRECIO,P.LADO, P.ESTADO FROM PRODUCTOS P INNER JOIN TIPOS T ON T.ID= P.IDTIPO INNER JOIN MATERIALES M ON M.ID = P.IDMATERIAL WHERE ESTADO=1 ";

                switch (tipoFiltro)
                {
                    case 1:
                        comando.CommandText += "ORDER BY P.PRECIO ASC ";
                        break;
                    case 2:
                        comando.CommandText += "ORDER BY P.PRECIO DESC ";
                        break;
                    case 3:
                        comando.CommandText += "ORDER BY P.NOMBRE ASC";
                        break;
                    case 4:
                        comando.CommandText += "ORDER BY P.NOMBRE DESC";
                        break;

                }
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Producto prod = new Producto();
                    prod.Id = (int)lector["ID"];
                    if (!(lector["NOMBRE"] is DBNull))
                        prod.Nombre = (string)lector["NOMBRE"];
                    if (!(lector["DESCRIPCION"] is DBNull))
                        prod.Descripcion = (string)lector["DESCRIPCION"];
                    if (!(lector["IMAGEN1"] is DBNull))
                        prod.Imagen1 = (string)lector["IMAGEN1"];
                    if (!(lector["IMAGEN2"] is DBNull))
                        prod.Imagen2 = (string)lector["IMAGEN2"];
                    if (!(lector["IMAGEN3"] is DBNull))
                        prod.Imagen3 = (string)lector["IMAGEN3"];
                    if (!(lector["IMAGEN4"] is DBNull))
                        prod.Imagen4 = (string)lector["IMAGEN4"];
                    if (!(lector["PRECIO"] is DBNull))
                        prod.Precio = (decimal)lector["PRECIO"];
                    if (!(lector["CANTIDAD_ORIFICIOS"] is DBNull))
                        prod.Cantidad_Orificios = (int)lector["CANTIDAD_ORIFICIOS"];
                    if (!(lector["DIAMETRO"] is DBNull))
                        prod.Diametro = (int)lector["DIAMETRO"];
                    if (!(lector["TIPO_BLOQUEO"] is DBNull))
                        prod.Tipo_Bloqueo = (string)lector["TIPO_BLOQUEO"];
                    if (!(lector["LADO"] is DBNull))
                        prod.Lado = (string)lector["LADO"];
                    if (!(lector["ESTADO"] is DBNull))
                        prod.Estado = (bool)lector["ESTADO"];

                    prod.Material = new Material();
                    prod.Material.Id = (int)lector["IDMATERIAL"];
                    prod.Material.Nombre = (string)lector["NOMBREMATERIAL"];


                    prod.Tipo = new Tipo();
                    prod.Tipo.Id = (int)lector["IDTIPO"];
                    //SI EL TIPO DE ARTICULO NO ES NULO LO LEE
                    if (!(lector["NOMBRETIPO"] is DBNull))
                        prod.Tipo.Nombre = (string)lector["NOMBRETIPO"];



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

        public Producto listaProductoAgregado()
        {
            Producto lista = new Producto();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT TOP 1 P.ID, P.NOMBRE, P.DESCRIPCION, T.ID AS IDTIPO, T.NOMBRE NOMBRETIPO, M.ID AS IDMATERIAL, M.NOMBRE NOMBREMATERIAL, P.TIPO_BLOQUEO, P.CANTIDAD_ORIFICIOS, P.DIAMETRO, P.LADO, P.IMAGEN1,P.IMAGEN2, P.IMAGEN3,P.IMAGEN4, P.PRECIO  FROM PRODUCTOS P INNER JOIN TIPOS T ON T.ID= P.IDTIPO INNER JOIN MATERIALES M ON M.ID = P.IDMATERIAL ORDER BY P.ID desc";
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Producto prod = new Producto();
                    prod.Id = (int)lector["ID"];
                    if (!(lector["NOMBRE"] is DBNull))
                        prod.Nombre = (string)lector["NOMBRE"];
                    if (!(lector["DESCRIPCION"] is DBNull))
                        prod.Descripcion = (string)lector["DESCRIPCION"];
                    if (!(lector["IMAGEN1"] is DBNull))
                        prod.Imagen1 = (string)lector["IMAGEN1"];
                    if (!(lector["IMAGEN2"] is DBNull))
                        prod.Imagen2 = (string)lector["IMAGEN2"];
                    if (!(lector["IMAGEN3"] is DBNull))
                        prod.Imagen3 = (string)lector["IMAGEN3"];
                    if (!(lector["IMAGEN4"] is DBNull))
                        prod.Imagen4 = (string)lector["IMAGEN4"];
                    if (!(lector["PRECIO"] is DBNull))
                        prod.Precio = (decimal)lector["PRECIO"];
                    if (!(lector["CANTIDAD_ORIFICIOS"] is DBNull))
                        prod.Cantidad_Orificios = (int)lector["CANTIDAD_ORIFICIOS"];
                    if (!(lector["DIAMETRO"] is DBNull))
                        prod.Diametro = (int)lector["DIAMETRO"];
                    if (!(lector["TIPO_BLOQUEO"] is DBNull))
                        prod.Tipo_Bloqueo = (string)lector["TIPO_BLOQUEO"];
                    if (!(lector["LADO"] is DBNull))
                        prod.Lado = (string)lector["LADO"];
       

                    prod.Material = new Material();
                    prod.Material.Id = (int)lector["IDMATERIAL"];
                    prod.Material.Nombre = (string)lector["NOMBREMATERIAL"];


                    prod.Tipo = new Tipo();
                    prod.Tipo.Id = (int)lector["IDTIPO"];
                    //SI EL TIPO DE ARTICULO NO ES NULO LO LEE
                    if (!(lector["NOMBRETIPO"] is DBNull))
                        prod.Tipo.Nombre = (string)lector["NOMBRETIPO"];



                    return prod;
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

        public void agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_AGREGARPRODUCTO");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Tipo", nuevo.Tipo.Id);
                datos.setearParametro("@Material", nuevo.Material.Id);
                datos.setearParametro("@Cantidad_Orificios", nuevo.Cantidad_Orificios);
                datos.setearParametro("@Diametro", nuevo.Diametro);
                datos.setearParametro("@Tipo_Bloqueo", nuevo.Tipo_Bloqueo);
                datos.setearParametro("@lado", nuevo.Lado);
                datos.setearParametro("@Imagen1", nuevo.Imagen1);
                datos.setearParametro("@Imagen2", nuevo.Imagen2);
                datos.setearParametro("@Imagen3", nuevo.Imagen3);
                datos.setearParametro("@Imagen4", nuevo.Imagen4);
                datos.setearParametro("@Precio", nuevo.Precio);

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
        public void modificarConSP(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ModificaProducto");
                datos.setearParametro("@Id", nuevo.Id);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Tipo", nuevo.Tipo.Id);
                datos.setearParametro("@Material", nuevo.Material.Id);
                datos.setearParametro("@Cantidad_Orificios", nuevo.Cantidad_Orificios);
                datos.setearParametro("@Diametro", nuevo.Diametro);
                datos.setearParametro("@Tipo_Bloqueo", nuevo.Tipo_Bloqueo);
                datos.setearParametro("@Lado", nuevo.Lado);
                datos.setearParametro("@Imagen1", nuevo.Imagen1);
                datos.setearParametro("@Imagen2", nuevo.Imagen2);
                datos.setearParametro("@Imagen3", nuevo.Imagen3);
                datos.setearParametro("@Imagen4", nuevo.Imagen4);
                datos.setearParametro("@Precio", nuevo.Precio);

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
                datos.setearProcedimiento("SP_EliminaProducto");
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

        
        public List<Producto> listarCompusXOrden(int tipoFiltro)
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT P.ID, P.NOMBRE, P.DESCRIPCION, T.ID AS IDTIPO, T.NOMBRE AS NOMBRETIPO, M.ID AS IDMATERIAL, M.NOMBRE AS NOMBREMATERIAL, P.TIPO_BLOQUEO, P.CANTIDAD_ORIFICIOS, P.DIAMETRO, P.LADO, P.IMAGEN1,P.IMAGEN2,P.IMAGEN3,P.IMAGEN4 , P.PRECIO, P.ESTADO FROM PRODUCTOS P INNER JOIN TIPOS T ON T.ID= P.IDTIPO INNER JOIN MATERIALES M ON M.ID = P.IDMATERIAL WHERE ESTADO=1 AND T.NOMBRE = 'PLACAS' OR T.NOMBRE ='PLACA' ";

                switch (tipoFiltro)
                {
                    case 1:
                        comando.CommandText += "ORDER BY P.PRECIO ASC ";
                        break;
                    case 2:
                        comando.CommandText += "ORDER BY P.PRECIO DESC ";
                        break;
                    case 3:
                        comando.CommandText += "ORDER BY P.NOMBRE ASC";
                        break;
                    case 4:
                        comando.CommandText += "ORDER BY P.NOMBRE DESC";
                        break;

                }
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Producto prod = new Producto();
                    prod.Id = (int)lector["ID"];
                    if (!(lector["NOMBRE"] is DBNull))
                        prod.Nombre = (string)lector["NOMBRE"];
                    if (!(lector["DESCRIPCION"] is DBNull))
                        prod.Descripcion = (string)lector["DESCRIPCION"];
                    if (!(lector["IMAGEN1"] is DBNull))
                        prod.Imagen1 = (string)lector["IMAGEN1"];
                    if (!(lector["IMAGEN2"] is DBNull))
                        prod.Imagen2 = (string)lector["IMAGEN2"];
                    if (!(lector["IMAGEN3"] is DBNull))
                        prod.Imagen3 = (string)lector["IMAGEN3"];
                    if (!(lector["IMAGEN4"] is DBNull))
                        prod.Imagen4 = (string)lector["IMAGEN4"];
                    if (!(lector["PRECIO"] is DBNull))
                        prod.Precio = (decimal)lector["PRECIO"];
                    if (!(lector["CANTIDAD_ORIFICIOS"] is DBNull))
                        prod.Cantidad_Orificios = (int)lector["CANTIDAD_ORIFICIOS"];
                    if (!(lector["DIAMETRO"] is DBNull))
                        prod.Diametro = (int)lector["DIAMETRO"];
                    if (!(lector["TIPO_BLOQUEO"] is DBNull))
                        prod.Tipo_Bloqueo = (string)lector["TIPO_BLOQUEO"];
                    if (!(lector["LADO"] is DBNull))
                        prod.Lado = (string)lector["LADO"];
                    if (!(lector["ESTADO"] is DBNull))
                        prod.Estado = (bool)lector["ESTADO"];

                    prod.Material = new Material();
                    prod.Material.Id = (int)lector["IDMATERIAL"];
                    prod.Material.Nombre = (string)lector["NOMBREMATERIAL"];


                    prod.Tipo = new Tipo();
                    prod.Tipo.Id = (int)lector["IDTIPO"];
                    //SI EL TIPO DE ARTICULO NO ES NULO LO LEE
                    if (!(lector["NOMBRETIPO"] is DBNull))
                        prod.Tipo.Nombre = (string)lector["NOMBRETIPO"];



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


      
        /// HASTAA ACAAAAAAAAAAA
     
     
        public List<Producto> listarCompusXFiltro(string producto)
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT P.ID, P.NOMBRE, P.DESCRIPCION, T.ID AS IDTIPO, T.NOMBRE AS NOMBRETIPO, M.ID AS IDMARCA, M.NOMBRE AS NOMBREMARCA, P.MEMORIAINTERNA, P.MEMORIARAM, P.PROCESADOR, P.TIPODISCO, P.IMAGEN1,P.IMAGEN2,P.IMAGEN3,P.IMAGEN4 , P.PRECIO, P.ESTADO FROM PRODUCTOS P INNER JOIN TIPOS T ON T.ID= P.IDTIPO INNER JOIN MARCAS M ON M.ID = P.IDMARCA WHERE ESTADO=1 AND T.NOMBRE = 'PC' OR T.NOMBRE = 'NOTEBOOK' AND P.NOMBRE LIKE '%"+producto+ "%' OR M.NOMBRE LIKE '%"+producto+ "%'";

                
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Producto prod = new Producto();
                    prod.Id = (int)lector["ID"];
                    if (!(lector["NOMBRE"] is DBNull))
                        prod.Nombre = (string)lector["NOMBRE"];
                    if (!(lector["DESCRIPCION"] is DBNull))
                        prod.Descripcion = (string)lector["DESCRIPCION"];
                    if (!(lector["IMAGEN1"] is DBNull))
                        prod.Imagen1 = (string)lector["IMAGEN1"];
                    if (!(lector["IMAGEN2"] is DBNull))
                        prod.Imagen2 = (string)lector["IMAGEN2"];
                    if (!(lector["IMAGEN3"] is DBNull))
                        prod.Imagen3 = (string)lector["IMAGEN3"];
                    if (!(lector["IMAGEN4"] is DBNull))
                        prod.Imagen4 = (string)lector["IMAGEN4"];
                    if (!(lector["PRECIO"] is DBNull))
                        prod.Precio = (decimal)lector["PRECIO"];
                    if (!(lector["MEMORIAINTERNA"] is DBNull))
                        prod.Cantidad_Orificios = (int)lector["MEMORIAINTERNA"];
                    if (!(lector["MEMORIARAM"] is DBNull))
                        prod.Diametro = (int)lector["MEMORIARAM"];
                    if (!(lector["PROCESADOR"] is DBNull))
                        prod.Tipo_Bloqueo = (string)lector["PROCESADOR"];
                    if (!(lector["TIPODISCO"] is DBNull))
                        prod.Lado = (string)lector["TIPODISCO"];
                    if (!(lector["ESTADO"] is DBNull))
                        prod.Estado = (bool)lector["ESTADO"];

                    prod.Material = new Material();
                    prod.Material.Id = (int)lector["IDMARCA"];
                    prod.Material.Nombre = (string)lector["NOMBREMARCA"];


                    prod.Tipo = new Tipo();
                    prod.Tipo.Id = (int)lector["IDTIPO"];
                    //SI EL TIPO DE ARTICULO NO ES NULO LO LEE
                    if (!(lector["NOMBRETIPO"] is DBNull))
                        prod.Tipo.Nombre = (string)lector["NOMBRETIPO"];



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
        public List<Producto> listarCompus(string id = "")
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                if (id == "")
                {
                    comando.CommandText = "SELECT P.ID, P.NOMBRE, P.DESCRIPCION, T.ID AS IDTIPO, T.NOMBRE AS NOMBRETIPO, M.ID AS IDMARCA, M.NOMBRE AS NOMBREMARCA, P.MEMORIAINTERNA, P.MEMORIARAM, P.PROCESADOR, P.TIPODISCO, P.IMAGEN1,P.IMAGEN2,P.IMAGEN3,P.IMAGEN4 , P.PRECIO, P.ESTADO FROM PRODUCTOS P INNER JOIN TIPOS T ON T.ID= P.IDTIPO INNER JOIN MARCAS M ON M.ID = P.IDMARCA WHERE ESTADO=1 AND T.NOMBRE = 'PC' OR T.NOMBRE = 'NOTEBOOK'";

                }
                if (id != "")
                {
                    comando.CommandText = "SELECT P.ID, P.NOMBRE, P.DESCRIPCION, T.ID AS IDTIPO, T.NOMBRE AS NOMBRETIPO, M.ID AS IDMARCA, M.NOMBRE AS NOMBREMARCA, P.MEMORIAINTERNA, P.MEMORIARAM, P.PROCESADOR, P.TIPODISCO, P.IMAGEN1,P.IMAGEN2,P.IMAGEN3,P.IMAGEN4, P.PRECIO, P.ESTADO FROM PRODUCTOS P INNER JOIN TIPOS T ON T.ID= P.IDTIPO INNER JOIN MARCAS M ON M.ID = P.IDMARCA WHERE ESTADO=1 AND T.NOMBRE = 'COMPUTADORA' AND P.ID= " + id.ToString();

                }
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Producto prod = new Producto();
                    prod.Id = (int)lector["ID"];
                    if (!(lector["NOMBRE"] is DBNull))
                        prod.Nombre = (string)lector["NOMBRE"];
                    if (!(lector["DESCRIPCION"] is DBNull))
                        prod.Descripcion = (string)lector["DESCRIPCION"];
                    if (!(lector["IMAGEN1"] is DBNull))
                        prod.Imagen1 = (string)lector["IMAGEN1"];
                    if (!(lector["IMAGEN2"] is DBNull))
                        prod.Imagen2 = (string)lector["IMAGEN2"];
                    if (!(lector["IMAGEN3"] is DBNull))
                        prod.Imagen3 = (string)lector["IMAGEN3"];
                    if (!(lector["IMAGEN4"] is DBNull))
                        prod.Imagen4 = (string)lector["IMAGEN4"];
                    if (!(lector["PRECIO"] is DBNull))
                        prod.Precio = (decimal)lector["PRECIO"];
                    if (!(lector["MEMORIAINTERNA"] is DBNull))
                        prod.Cantidad_Orificios = (int)lector["MEMORIAINTERNA"];
                    if (!(lector["MEMORIARAM"] is DBNull))
                        prod.Diametro = (int)lector["MEMORIARAM"];
                    if (!(lector["PROCESADOR"] is DBNull))
                        prod.Tipo_Bloqueo = (string)lector["PROCESADOR"];
                    if (!(lector["TIPODISCO"] is DBNull))
                        prod.Lado = (string)lector["TIPODISCO"];
                    if (!(lector["ESTADO"] is DBNull))
                        prod.Estado = (bool)lector["ESTADO"];

                    prod.Material = new Material();
                    prod.Material.Id = (int)lector["IDMARCA"];
                    prod.Material.Nombre = (string)lector["NOMBREMARCA"];


                    prod.Tipo = new Tipo();
                    prod.Tipo.Id = (int)lector["IDTIPO"];
                    //SI EL TIPO DE ARTICULO NO ES NULO LO LEE
                    if (!(lector["NOMBRETIPO"] is DBNull))
                        prod.Tipo.Nombre = (string)lector["NOMBRETIPO"];



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

        public List<Producto> listarCelus(string id = "")
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                if (id == "")
                {
                    comando.CommandText = "SELECT P.ID, P.NOMBRE, P.DESCRIPCION, T.ID AS IDTIPO, T.NOMBRE AS NOMBRETIPO, M.ID AS IDMARCA, M.NOMBRE AS NOMBREMARCA, P.MEMORIAINTERNA, P.MEMORIARAM, P.PROCESADOR, P.TIPODISCO, P.IMAGEN1,P.IMAGEN2,P.IMAGEN3,P.IMAGEN4 , P.PRECIO, P.ESTADO FROM PRODUCTOS P INNER JOIN TIPOS T ON T.ID= P.IDTIPO INNER JOIN MARCAS M ON M.ID = P.IDMARCA WHERE ESTADO=1 AND T.NOMBRE = 'CELULAR'";

                }
                if (id != "")
                {
                    comando.CommandText = "SELECT P.ID, P.NOMBRE, P.DESCRIPCION, T.ID AS IDTIPO, T.NOMBRE AS NOMBRETIPO, M.ID AS IDMARCA, M.NOMBRE AS NOMBREMARCA, P.MEMORIAINTERNA, P.MEMORIARAM, P.PROCESADOR, P.TIPODISCO, P.IMAGEN1,P.IMAGEN2,P.IMAGEN3,P.IMAGEN4, P.PRECIO, P.ESTADO FROM PRODUCTOS P INNER JOIN TIPOS T ON T.ID= P.IDTIPO INNER JOIN MARCAS M ON M.ID = P.IDMARCA WHERE ESTADO=1 AND P.ID= " + id.ToString();

                }
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Producto prod = new Producto();
                    prod.Id = (int)lector["ID"];
                    if (!(lector["NOMBRE"] is DBNull))
                        prod.Nombre = (string)lector["NOMBRE"];
                    if (!(lector["DESCRIPCION"] is DBNull))
                        prod.Descripcion = (string)lector["DESCRIPCION"];
                    if (!(lector["IMAGEN1"] is DBNull))
                        prod.Imagen1 = (string)lector["IMAGEN1"];
                    if (!(lector["IMAGEN2"] is DBNull))
                        prod.Imagen2 = (string)lector["IMAGEN2"];
                    if (!(lector["IMAGEN3"] is DBNull))
                        prod.Imagen3 = (string)lector["IMAGEN3"];
                    if (!(lector["IMAGEN4"] is DBNull))
                        prod.Imagen4 = (string)lector["IMAGEN4"];
                    if (!(lector["PRECIO"] is DBNull))
                        prod.Precio = (decimal)lector["PRECIO"];
                    if (!(lector["MEMORIAINTERNA"] is DBNull))
                        prod.Cantidad_Orificios = (int)lector["MEMORIAINTERNA"];
                    if (!(lector["MEMORIARAM"] is DBNull))
                        prod.Diametro = (int)lector["MEMORIARAM"];
                    if (!(lector["PROCESADOR"] is DBNull))
                        prod.Tipo_Bloqueo = (string)lector["PROCESADOR"];
                    if (!(lector["TIPODISCO"] is DBNull))
                        prod.Lado = (string)lector["TIPODISCO"];
                    if (!(lector["ESTADO"] is DBNull))
                        prod.Estado = (bool)lector["ESTADO"];

                    prod.Material = new Material();
                    prod.Material.Id = (int)lector["IDMARCA"];
                    prod.Material.Nombre = (string)lector["NOMBREMARCA"];


                    prod.Tipo = new Tipo();
                    prod.Tipo.Id = (int)lector["IDTIPO"];
                    //SI EL TIPO DE ARTICULO NO ES NULO LO LEE
                    if (!(lector["NOMBRETIPO"] is DBNull))
                        prod.Tipo.Nombre = (string)lector["NOMBRETIPO"];



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
        public List<Producto> listarCelusXfiltroOrden(int tipoFiltro)
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT P.ID, P.NOMBRE, P.DESCRIPCION, T.ID AS IDTIPO, T.NOMBRE AS NOMBRETIPO, M.ID AS IDMARCA, M.NOMBRE AS NOMBREMARCA, P.MEMORIAINTERNA, P.MEMORIARAM, P.PROCESADOR, P.TIPODISCO, P.IMAGEN1,P.IMAGEN2,P.IMAGEN3,P.IMAGEN4 , P.PRECIO, P.ESTADO FROM PRODUCTOS P INNER JOIN TIPOS T ON T.ID= P.IDTIPO INNER JOIN MARCAS M ON M.ID = P.IDMARCA WHERE ESTADO=1 AND T.NOMBRE LIKE 'Celular' ";

                switch (tipoFiltro)
                {
                    case 1:
                        comando.CommandText += "ORDER BY P.PRECIO ASC ";
                        break;
                    case 2:
                        comando.CommandText += "ORDER BY P.PRECIO DESC ";
                        break;
                    case 3:
                        comando.CommandText += "ORDER BY P.NOMBRE ASC";
                        break;
                    case 4:
                        comando.CommandText += "ORDER BY P.NOMBRE DESC";
                        break;

                }
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Producto prod = new Producto();
                    prod.Id = (int)lector["ID"];
                    if (!(lector["NOMBRE"] is DBNull))
                        prod.Nombre = (string)lector["NOMBRE"];
                    if (!(lector["DESCRIPCION"] is DBNull))
                        prod.Descripcion = (string)lector["DESCRIPCION"];
                    if (!(lector["IMAGEN1"] is DBNull))
                        prod.Imagen1 = (string)lector["IMAGEN1"];
                    if (!(lector["IMAGEN2"] is DBNull))
                        prod.Imagen2 = (string)lector["IMAGEN2"];
                    if (!(lector["IMAGEN3"] is DBNull))
                        prod.Imagen3 = (string)lector["IMAGEN3"];
                    if (!(lector["IMAGEN4"] is DBNull))
                        prod.Imagen4 = (string)lector["IMAGEN4"];
                    if (!(lector["PRECIO"] is DBNull))
                        prod.Precio = (decimal)lector["PRECIO"];
                    if (!(lector["MEMORIAINTERNA"] is DBNull))
                        prod.Cantidad_Orificios = (int)lector["MEMORIAINTERNA"];
                    if (!(lector["MEMORIARAM"] is DBNull))
                        prod.Diametro = (int)lector["MEMORIARAM"];
                    if (!(lector["PROCESADOR"] is DBNull))
                        prod.Tipo_Bloqueo = (string)lector["PROCESADOR"];
                    if (!(lector["TIPODISCO"] is DBNull))
                        prod.Lado = (string)lector["TIPODISCO"];
                    if (!(lector["ESTADO"] is DBNull))
                        prod.Estado = (bool)lector["ESTADO"];

                    prod.Material = new Material();
                    prod.Material.Id = (int)lector["IDMARCA"];
                    prod.Material.Nombre = (string)lector["NOMBREMARCA"];


                    prod.Tipo = new Tipo();
                    prod.Tipo.Id = (int)lector["IDTIPO"];
                    //SI EL TIPO DE ARTICULO NO ES NULO LO LEE
                    if (!(lector["NOMBRETIPO"] is DBNull))
                        prod.Tipo.Nombre = (string)lector["NOMBRETIPO"];



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
    }
}
