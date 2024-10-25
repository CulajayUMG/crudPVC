using crudPVC.Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudPVC.Datos
{
    public class D_Productos
    {
        public DataTable listadoCat() {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("select descripcion_cat, id_categoria from tb_categoria", SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally { 
            if(SqlCon.State==ConnectionState.Open) SqlCon.Close();
            }
        
        }
        public DataTable listadoMed()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("select descripcion_med, id_medida from tb_medidas", SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

        }

        public DataTable listadoProd(string cTexto)
    {
        OracleDataReader Resultado;
        DataTable Tabla = new DataTable();
        OracleConnection SqlCon = new OracleConnection();
        try
        {
            cTexto = "%" + cTexto + "%";
            SqlCon = Conexion.getInstancia().CrearConexion();
            OracleCommand Comando = new OracleCommand("select * from VISTA_PRODUCTO where descripcion_prod like'"+cTexto+"' order by ID_Producto", SqlCon);
            Comando.CommandType = CommandType.Text;
            SqlCon.Open();
            Resultado = Comando.ExecuteReader();
            Tabla.Load(Resultado);
            return Tabla;
        }
        catch (Exception ex)
        {
            throw ex;

        }
        finally
        {
            if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
        }

    }

        public string GuardarProd(int nOpcion, E_Productos oPro) {
            string Rpta;
            
            OracleConnection OracleCon = new OracleConnection();
            try { 
                    OracleCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("P_GUARDARPROD", OracleCon);
                Comando.CommandType= CommandType.StoredProcedure;
                Comando.Parameters.Add("pOpcion",OracleDbType.Int32).Value = nOpcion;
                Comando.Parameters.Add("pIdProd", OracleDbType.Int32).Value = oPro.ID_Producto;
                Comando.Parameters.Add("pDescProd", OracleDbType.Varchar2).Value = oPro.Descripcion_Prod;
                Comando.Parameters.Add("pMarcaProd", OracleDbType.Varchar2).Value = oPro.Marca_Prod;
                Comando.Parameters.Add("pMedidaProd", OracleDbType.Varchar2).Value = oPro.ID_MEDIDA;
                Comando.Parameters.Add("pAltoProd", OracleDbType.Decimal).Value = oPro.AltoProd;
                Comando.Parameters.Add("pAnchoProd", OracleDbType.Decimal).Value = oPro.AnchoProd;
                Comando.Parameters.Add("pStock", OracleDbType.Decimal).Value = oPro.Stock_Actual;
                Comando.Parameters.Add("pIdCat", OracleDbType.Decimal).Value = oPro.ID_Categoria;
                OracleCon.Open();
                Comando.ExecuteNonQuery();
                Rpta = "OK";

            } catch(Exception ex) {
            Rpta = ex.Message;



            }
            finally
            {
                if (OracleCon.State == ConnectionState.Open) OracleCon.Close();
            }
            return Rpta;

        }

        public string EliminarProd(int nIdProd)
        {
            string Rpta="";
            OracleConnection OracleCon = new OracleConnection();
            try
            {
                OracleCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("P_Eliminar", OracleCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("nIdProd", OracleDbType.Int32).Value = nIdProd;
                
                OracleCon.Open();
                Comando.ExecuteNonQuery();
                Rpta = "OK";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;



            }
            finally
            {
                if (OracleCon.State == ConnectionState.Open) OracleCon.Close();
            }
            return Rpta;

        }



    }
}
