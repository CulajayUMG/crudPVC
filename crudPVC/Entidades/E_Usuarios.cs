using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudPVC.Entidades
{
    public class E_Usuarios
    {

        


        public int Id_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }

        public string direccion { get; set; }
        public string ppassword { get; set; }
        public int Id_Ident { get; set; }
        public int idRol { get; set; }
        public string noIdent{ get; set; }


    }
}
