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
    }
}
