using crudPVC.Datos;
using crudPVC.Entidades;
using crudPVC.Presentacion.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crudPVC.Presentacion
{
    public partial class formProductos : Form
    {
        public formProductos()
        {
            InitializeComponent();
        }

        #region "Variables"
        int nIdProd = 0;
        int nEstGuardar = 0;


        #endregion

        #region "Metodos"
        private void LimpTexto() {
        
        buscartxt.Clear();
        productotxt.Clear();
        marcatxt.Clear();
        boxMedida.Text = "";
        altoTxt.Clear();
        anchoTxt.Clear();
        stocktxt.Clear();
        categoriabox.Text = "";

        
        }


        private void EstadoText(bool lEstado) { 
            buscartxt.Enabled = lEstado;
            productotxt.Enabled = lEstado; 
            marcatxt.Enabled = lEstado;
            boxMedida.Enabled = lEstado;
            altoTxt.Enabled = lEstado;
            anchoTxt.Enabled = lEstado;
            stocktxt.Enabled = lEstado;
            categoriabox.Enabled = lEstado;
        }

        private void EstadoBtns (bool lEstado)
        {

            cancelarbtn.Visible = lEstado;
            guardarbtn.Visible = lEstado;

        }

        private void estadoBtsPrincipales(bool lEstado) { 
        
                nuevoBtn.Enabled = lEstado;
                Modificarbtn.Enabled = lEstado;
                Eliminarbtn.Enabled = lEstado;
                Reportebtn.Enabled = lEstado;
                btnSalir.Enabled = lEstado;
        }

        private void FormatoDGVProd() {

            DGVListadoProd.Columns[0].Width = 35;
            DGVListadoProd.Columns[0].HeaderText = "ID";
            DGVListadoProd.Columns[1].Width = 180;
            DGVListadoProd.Columns[1].HeaderText = "Producto";
            DGVListadoProd.Columns[2].Width = 75;
            DGVListadoProd.Columns[2].HeaderText = "Marca";
            DGVListadoProd.Columns[3].Width = 75;
            DGVListadoProd.Columns[3].HeaderText = "uMedida";
            DGVListadoProd.Columns[4].Width = 75;
            DGVListadoProd.Columns[4].HeaderText = "Altura";
            DGVListadoProd.Columns[5].Width = 75;
            DGVListadoProd.Columns[5].HeaderText = "Ancho";
            DGVListadoProd.Columns[6].Width = 80;
            DGVListadoProd.Columns[6].HeaderText = "Categoria";
            DGVListadoProd.Columns[7].Width = 50;
            DGVListadoProd.Columns[7].HeaderText = "Stock";
            DGVListadoProd.Columns[8].Visible = false;
        }

        private void ListadoCategorias() {
            D_Productos Datos = new D_Productos();
            categoriabox.DataSource = Datos.listadoCat();
            categoriabox.ValueMember = "ID_Categoria";
            categoriabox.DisplayMember = "Descripcion_Cat";

        }

        private void ListadoMedidas()
        {
            D_Productos Datos = new D_Productos();
            boxMedida.DataSource = Datos.listadoMed();
            boxMedida.ValueMember = "Id_Medida";
            boxMedida.DisplayMember = "Descripcion_Med";

        }

        private void ListadorProd(string cTexto) {
            D_Productos Datos = new D_Productos();
            DGVListadoProd.DataSource = Datos.listadoProd(cTexto);
            this.FormatoDGVProd();
        }

        private void SelecItem() {
            if (string.IsNullOrEmpty(DGVListadoProd.CurrentRow.Cells["ID_Producto"].Value.ToString())) {

                MessageBox.Show("NO HAS SELECCIONADO UN ITEM", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                nIdProd = Convert.ToInt32(DGVListadoProd.CurrentRow.Cells["ID_Producto"].Value);
                productotxt.Text = Convert.ToString(DGVListadoProd.CurrentRow.Cells["Descripcion_Prod"].Value);
                marcatxt.Text = Convert.ToString(DGVListadoProd.CurrentRow.Cells["Marca_prod"].Value);
                boxMedida.Text = Convert.ToString(DGVListadoProd.CurrentRow.Cells["Descripcion_Med"].Value);
                altoTxt.Text = Convert.ToString(DGVListadoProd.CurrentRow.Cells["AltoProd"].Value);
                anchoTxt.Text = Convert.ToString(DGVListadoProd.CurrentRow.Cells["AnchoProd"].Value);
                categoriabox.Text = Convert.ToString(DGVListadoProd.CurrentRow.Cells["Descripcion_cat"].Value);
                stocktxt.Text = Convert.ToString(DGVListadoProd.CurrentRow.Cells["stock_actual"].Value);
            }
        
        }


        #endregion

        private void nuevoBtn_Click(object sender, EventArgs e)
        {
            nEstGuardar = 1;
            //DGVListadoProd.Enabled = false;
            this.LimpTexto();
            this.EstadoText(true);
            this.EstadoBtns(true);
            this.estadoBtsPrincipales(false);
            productotxt.Focus();
        }

        private void cancelarbtn_Click(object sender, EventArgs e)
        {
            nEstGuardar = 0;
            this.LimpTexto();
            this.EstadoText(false);
            this.EstadoBtns(false);
            this.estadoBtsPrincipales(true);
        }

        private void formProductos_Load(object sender, EventArgs e)
        {
            this.ListadoCategorias();
            this.ListadoMedidas();
            this.ListadorProd("%");
        }

        private void guardarbtn_Click(object sender, EventArgs e)


        {
            //DGVListadoProd.Enabled = false;
            if (productotxt.Text==String.Empty|| marcatxt.Text==string.Empty|| altoTxt.Text==string.Empty||
                categoriabox.Text==string.Empty|| stocktxt.Text==string.Empty) {
                MessageBox.Show("Ingrese Datos Correctos","Aviso del sistema",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

            }
            else { //guardamos informacion
                    E_Productos oPro = new E_Productos();
                string Rpta = "";
                oPro.ID_Producto = nIdProd;
                oPro.Descripcion_Prod = productotxt.Text;
                oPro.Marca_Prod = marcatxt.Text;
                //oPro.Medida_Prod = altoTxt.Text;
                oPro.ID_MEDIDA = Convert.ToInt32(boxMedida  .SelectedValue);
                oPro.AltoProd = float.Parse(altoTxt.Text.Trim());
                oPro.AnchoProd = float.Parse(anchoTxt.Text.Trim());
                oPro.ID_Categoria = Convert.ToInt32(categoriabox.SelectedValue);
                oPro.Stock_Actual = float.Parse(stocktxt.Text.Trim());
                D_Productos Datos = new D_Productos();
                Rpta = Datos.GuardarProd(nEstGuardar, oPro);


                if (Rpta.Equals("OK"))
                {
                    nIdProd = 0;
                    this.LimpTexto();
                    this.EstadoText(false);
                    this.EstadoBtns(false);
                    this.estadoBtsPrincipales(true);
                    this.ListadorProd("%");
                    MessageBox.Show("Producto Guardado", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else {
                    MessageBox.Show(Rpta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void buscarbtn_Click(object sender, EventArgs e)
        {
            this.ListadorProd(buscartxt.Text.Trim());
        }

       

        private void DGVListadoProd_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecItem();
        }

        private void Modificarbtn_Click(object sender, EventArgs e)
        {
            nEstGuardar = 2;
            this.EstadoText(true);
            this.EstadoBtns(true);
            this.estadoBtsPrincipales(false);
            productotxt.Focus();
        }

        private void Eliminarbtn_Click(object sender, EventArgs e)
        {
            if (DGVListadoProd.Rows.Count > 0) {
                string Rpta = "";
            D_Productos Datos = new D_Productos();
                Rpta = Datos.EliminarProd(Convert.ToInt32(DGVListadoProd.CurrentRow.Cells["Id_Producto"].Value));
                if (Rpta.Equals("OK")){
                    this.LimpTexto();
                    this.ListadorProd("%");
                    MessageBox.Show("El Registro ha sido eliminado", "Aviso del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
                }
                else {
                    MessageBox.Show(Rpta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        


        }

        private void Reportebtn_Click(object sender, EventArgs e)
        {
            reportProducFrm oRpt = new reportProducFrm();
            oRpt.textBox1.Text= buscartxt.Text;
            oRpt.ShowDialog();
        }
    }
}
