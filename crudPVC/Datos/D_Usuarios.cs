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
        public class D_Usuarios
        {
            public DataTable listadoIdent()
            {
                OracleDataReader Resultado;
                DataTable Tabla = new DataTable();
                OracleConnection SqlCon = new OracleConnection();
                try
                {
                    SqlCon = Conexion.getInstancia().CrearConexion();
                    OracleCommand Comando = new OracleCommand("select descripcion_Ident, id_ident from tb_identificacion", SqlCon);
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
        public DataTable listadoRol()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("select descripcion_Rol, id_rol from tb_Rol", SqlCon);
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
        public DataTable listadoUs(string cTexto)
            {
                OracleDataReader Resultado;
                DataTable Tabla = new DataTable();
                OracleConnection SqlCon = new OracleConnection();
                try
                {
                    cTexto = "%" + cTexto + "%";
                    SqlCon = Conexion.getInstancia().CrearConexion();
                    OracleCommand Comando = new OracleCommand("select * from VISTA_USUARIOS where nombre like'" + cTexto + "' order by Id_usuario", SqlCon);
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

            public string GuardarUs(int nOpcion, E_Usuarios oUsu)
            {
                string Rpta;
                OracleConnection OracleCon = new OracleConnection();

                try
                {
                    OracleCon = Conexion.getInstancia().CrearConexion();
                    OracleCommand Comando = new OracleCommand("P_GuardarUs", OracleCon);
                    Comando.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    Comando.Parameters.Add("pOpcion", OracleDbType.Int32).Value = nOpcion;
                    Comando.Parameters.Add("pIdUs", OracleDbType.Int32).Value = oUsu.Id_usuario;
                    Comando.Parameters.Add("pNombre", OracleDbType.Varchar2).Value = oUsu.nombre;
                    Comando.Parameters.Add("pApellido", OracleDbType.Varchar2).Value = oUsu.apellido;
                    Comando.Parameters.Add("pCorreo", OracleDbType.Varchar2).Value = oUsu.correo;
                    Comando.Parameters.Add("pTelefono", OracleDbType.Varchar2).Value = oUsu.telefono;
                    Comando.Parameters.Add("pDireccion", OracleDbType.Varchar2).Value = oUsu.direccion;
                    Comando.Parameters.Add("pPassword", OracleDbType.Varchar2).Value = oUsu.ppassword;
                    Comando.Parameters.Add("pIdIdent", OracleDbType.Int32).Value = oUsu.Id_Ident;
                    Comando.Parameters.Add("pRol", OracleDbType.Int32).Value = oUsu.idRol;
                    Comando.Parameters.Add("pnoIdent", OracleDbType.Varchar2).Value = oUsu.noIdent;

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


            public string EliminarUs(int nIdUs)
            {
                string Rpta = "";
                OracleConnection OracleCon = new OracleConnection();

                try
                {
                    OracleCon = Conexion.getInstancia().CrearConexion();
                    OracleCommand Comando = new OracleCommand("P_EliminarUsuario", OracleCon);
                    Comando.CommandType = CommandType.StoredProcedure;

                    // Parámetro del procedimiento almacenado
                    Comando.Parameters.Add("nIdUs", OracleDbType.Int32).Value = nIdUs;

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
