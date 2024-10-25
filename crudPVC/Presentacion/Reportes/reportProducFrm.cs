using crudPVC.Datos;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crudPVC.Presentacion.Reportes
{
    public partial class reportProducFrm : Form
    {
        public reportProducFrm()
        {
            InitializeComponent();
        }
        #region
        private void Listado()
        {
            try {
            
            D_Productos Datos = new D_Productos();
                string cTexto = textBox1.Text;
                DataTable miTabla = new DataTable();
                miTabla = Datos.listadoProd(cTexto);
                ReportDataSource fuente = new ReportDataSource("DataSet1",miTabla);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(fuente);
                reportViewer1.LocalReport.ReportEmbeddedResource = "crudPVC.Presentacion.Reportes.Rpt_Productos.rdlc";
                reportViewer1.LocalReport.Refresh();
                reportViewer1.Refresh();
                reportViewer1.RefreshReport();
                
            
            }catch (Exception ex){

                throw ex;
            }
        
        }


        #endregion

        private void reportProducFrm_Load(object sender, EventArgs e)
        {
            this.Listado();
            //this.reportViewer1.RefreshReport();
        }
    }
}
