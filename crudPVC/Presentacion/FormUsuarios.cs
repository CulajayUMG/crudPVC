using crudPVC.Datos;
using crudPVC.Entidades;
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
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }
        int nIdUsuario = 0;
        int nEstGuardar = 0;
        private void LimpTexto()
        {

            txtBuscar.Clear();
            txtnombre.Clear();
            txtapellido.Clear();
            cboxIdentificacion.Text = "";
            txtcorreo.Clear();
            txtDireccion.Clear();
            txttelefono.Clear();
            txtPassword.Clear();
            txtnoIdentificacion.Clear();
            rolBox.Text = "";


        }

        private void EstadoText(bool lEstado)
        {
            txtnombre.Enabled = lEstado;
            txtapellido.Enabled = lEstado;
            txtcorreo.Enabled = lEstado;
            txtDireccion.Enabled = lEstado;
            txtnoIdentificacion.Enabled = lEstado;
            txtPassword.Enabled = lEstado;
            txttelefono.Enabled = lEstado;
            cboxIdentificacion.Enabled = lEstado;
            rolBox.Enabled = lEstado;
        }


        private void ListadoRoles()
        {
            D_Usuarios Datos = new D_Usuarios();
            rolBox.DataSource = Datos.listadoRol();
            rolBox.ValueMember = "Id_Rol";
            rolBox.DisplayMember = "Descripcion_Rol";
        }
        private void ListadoI()
        {
            D_Usuarios Datos = new D_Usuarios();
            cboxIdentificacion.DataSource = Datos.listadoIdent();
            cboxIdentificacion.ValueMember = "Id_Ident";
            cboxIdentificacion.DisplayMember = "Descripcion_Ident";
        }

        private void EstadoBtns(bool lEstado)
        {

            btnCancelar.Visible = lEstado;
            btnGuardar.Visible = lEstado;

        }

        private void estadoBtsPrincipales(bool lEstado)
        {

            btnNuevo.Enabled = lEstado;
            btnModificar.Enabled = lEstado;
            btnEliminar.Enabled = lEstado;
            btnReporte.Enabled = lEstado;
       
        }

        private void FormatoDGVUs()
        {

            dgvUsuarios.Columns[0].Width = 35;
            dgvUsuarios.Columns[0].HeaderText = "ID";
            dgvUsuarios.Columns[1].Width = 120;
            dgvUsuarios.Columns[1].HeaderText = "Nombre";
            dgvUsuarios.Columns[2].Width = 75;
            dgvUsuarios.Columns[2].HeaderText = "Apellido";
            dgvUsuarios.Columns[3].Width = 75;
            dgvUsuarios.Columns[3].HeaderText = "Correo";
            dgvUsuarios.Columns[4].Width = 75;
            dgvUsuarios.Columns[4].HeaderText = "Telefono";
            dgvUsuarios.Columns[5].Width = 75;
            dgvUsuarios.Columns[5].HeaderText = "Direccion";
            dgvUsuarios.Columns[6].Width = 80;
            dgvUsuarios.Columns[6].HeaderText = "password";
            dgvUsuarios.Columns[7].Width = 50;
            dgvUsuarios.Columns[7].HeaderText = "Tipo Id";
            dgvUsuarios.Columns[8].Width = 50;
            dgvUsuarios.Columns[8].HeaderText = "Rol";
            dgvUsuarios.Columns[9].Width = 100;
            dgvUsuarios.Columns[9].HeaderText = "No Identificacion";
        }
        private void ListadorUsers(string cTexto)
        {
            D_Usuarios Datos = new D_Usuarios();
            dgvUsuarios.DataSource = Datos.listadoUs(cTexto);
            this.FormatoDGVUs();
        }

        private void SelecItem()
        {
            if (string.IsNullOrEmpty(dgvUsuarios.CurrentRow.Cells["Id_Usuario"].Value.ToString()))
            {
                MessageBox.Show("NO HAS SELECCIONADO UN ITEM", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // Asignamos los valores seleccionados a las variables correspondientes para el formulario de usuario
                nIdUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Id_Usuario"].Value);
                txtnombre.Text = Convert.ToString(dgvUsuarios.CurrentRow.Cells["nombre"].Value);
                txtapellido.Text = Convert.ToString(dgvUsuarios.CurrentRow.Cells["apellido"].Value);
                txtcorreo.Text = Convert.ToString(dgvUsuarios.CurrentRow.Cells["correo"].Value);
                txttelefono.Text = Convert.ToString(dgvUsuarios.CurrentRow.Cells["telefono"].Value);
                txtDireccion.Text = Convert.ToString(dgvUsuarios.CurrentRow.Cells["direccion"].Value);
                txtPassword.Text = Convert.ToString(dgvUsuarios.CurrentRow.Cells["ppassword"].Value);
                cboxIdentificacion.Text = Convert.ToString(dgvUsuarios.CurrentRow.Cells["Descripcion_Ident"].Value);
                rolBox.Text = Convert.ToString(dgvUsuarios.CurrentRow.Cells["Descripcion_Rol"].Value);
                txtnoIdentificacion.Text = Convert.ToString(dgvUsuarios.CurrentRow.Cells["NoIdent"].Value);

            }
        }


        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            this.ListadoRoles();
            this.ListadoI();
            this.ListadorUsers("%");

        }








        private void btnModificar_Click(object sender, EventArgs e)
        {
            nEstGuardar = 2;
            this.EstadoText(true);
            this.EstadoBtns(true);
            this.estadoBtsPrincipales(false);
            txtnombre.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nEstGuardar = 1;
            //DGVListadoProd.Enabled = false;
            this.LimpTexto();
            this.EstadoText(true);
            this.EstadoBtns(true);
            this.estadoBtsPrincipales(false);
            txtnombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            nEstGuardar = 0;
            this.LimpTexto();
            this.EstadoText(false);
            this.EstadoBtns(false);
            this.estadoBtsPrincipales(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == String.Empty || txtapellido.Text == string.Empty || txtcorreo.Text == string.Empty ||
                txttelefono.Text == string.Empty || txtDireccion.Text == string.Empty || txtPassword.Text == string.Empty
                || cboxIdentificacion.Text == string.Empty || rolBox.Text == string.Empty || txtnoIdentificacion.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Datos Correctos", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            { //guardamos informacion
                E_Usuarios oUsu = new E_Usuarios();
                string Rpta = "";
                oUsu.Id_usuario = nIdUsuario;
                oUsu.nombre = txtnombre.Text;
                oUsu.apellido = txtapellido.Text;
                oUsu.correo = txtcorreo.Text;
                oUsu.telefono = txttelefono.Text;
                oUsu.direccion = txtDireccion.Text;
                oUsu.ppassword = txtPassword.Text;
                oUsu.Id_Ident= Convert.ToInt32(cboxIdentificacion.SelectedValue);
                oUsu.idRol = Convert.ToInt32(rolBox.SelectedValue);
                oUsu.noIdent = txtnoIdentificacion.Text;

                D_Usuarios Datos = new D_Usuarios();
                Rpta = Datos.GuardarUs(nEstGuardar, oUsu);


                if (Rpta.Equals("OK"))
                {
                    nIdUsuario = 0;
                    this.LimpTexto();
                    this.EstadoText(false);
                    this.EstadoBtns(false);
                    this.estadoBtsPrincipales(true);
                    this.ListadorUsers("%");
                    MessageBox.Show("Usuario Guardado", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }






        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.ListadorUsers(txtBuscar.Text.Trim());
        }

        private void dgvUsuarios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecItem();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.Rows.Count > 0)
            {
                string Rpta = "";
                D_Usuarios Datos = new D_Usuarios();
                Rpta = Datos.EliminarUs(Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Id_Usuario"].Value));
                if (Rpta.Equals("OK"))
                {
                    this.LimpTexto();
                    this.ListadorUsers("%");
                    MessageBox.Show("El Registro ha sido eliminado", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

       
    }
}
