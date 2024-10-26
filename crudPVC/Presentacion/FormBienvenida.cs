using crudPVC.Datos;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crudPVC.Presentacion
{
    public partial class FormBienvenida : Form
    {
        public FormBienvenida()
        {
            InitializeComponent();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            // Abre el formulario de productos
            Presentacion.formProductos formProd = new Presentacion.formProductos();
            formProd.Show(); // Usar ShowDialog() si quieres que el formulario sea modal

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            // Abre el formulario de usuarios
            Presentacion.FormUsuarios formUsr = new Presentacion.FormUsuarios();
            formUsr.Show(); // Usar ShowDialog() si quieres que el formulario sea modal
        }

       
        private void btnSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;
            string rol  = rolBox.Text;

            D_Usuarios datosUsuarios = new D_Usuarios();
            if (ValidarUsuario(usuario, password) && rol.Equals("user"))
            {
                MessageBox.Show("Acceso concedido");
                // Abre el formulario de usuarios
                Presentacion.BienvenidaUsuario formUsr = new Presentacion.BienvenidaUsuario();
                formUsr.Show(); // Usar ShowDialog() si quieres que el formulario sea modal
                                // Código adicional para acceder al sistema

            }else
                if (ValidarUsuario(usuario, password) && rol.Equals("admin"))
                {
                    MessageBox.Show("Acceso concedido");
                    // Abre el formulario de usuarios
                    Presentacion.FormAdmin For = new Presentacion.FormAdmin();
                    For.Show(); // Usar ShowDialog() si quieres que el formulario sea modal
                                    // Código adicional para acceder al sistema
                
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private void ListadoRoles()
        {
            D_Usuarios Datos = new D_Usuarios();
            rolBox.DataSource = Datos.listadoRol();
            rolBox.ValueMember = "Id_Rol";
            rolBox.DisplayMember = "Descripcion_Rol";
        }

        public bool ValidarUsuario(string usuario, string password)
        {
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string query = "SELECT * FROM tb_usuarios WHERE nombre = :usuario AND ppassword = :password";
                OracleCommand Comando = new OracleCommand(query, SqlCon);
                Comando.CommandType = CommandType.Text;
                Comando.Parameters.Add(new OracleParameter(":usuario", usuario));
                Comando.Parameters.Add(new OracleParameter(":password", password));

                SqlCon.Open();
                int count = Convert.ToInt32(Comando.ExecuteScalar());
                return count > 0; // Retorna true si el usuario y contraseña existen
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

        private void FormBienvenida_Load(object sender, EventArgs e)
        {
            this.ListadoRoles();
        }
    }
}
