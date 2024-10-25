using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudPVC.Entidades
{
    public class E_Productos
    {
        public int ID_Producto { get; set; }
        public string Descripcion_Prod {  get; set; }
        public string Marca_Prod { get; set; }
        public int ID_MEDIDA { get; set; }
        //public string Medida_Prod { get; set; }
        public float AltoProd { get; set; }
        public float AnchoProd { get; set; }
        public float Stock_Actual { get; set; }
        public int ID_Categoria {  get; set; }



    }
}
