using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libreria_Clases;

namespace AdministracionXD
{
    public partial class Mantenimiento_Producto : MANTENIMIENTO
    {
        public Mantenimiento_Producto()
        {
            InitializeComponent();
        }

        public override Boolean Guardar()
        {
            try {
                string cmd = string.Format("EXEC ActualizarProducto '{0}','{1}','{2}'", txtidproducto.Text.Trim(), txtnombreproducto.Text.Trim(), txtprecioproducto.Text.Trim());
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("Se han guardado los datos correctamente...");
                return true;
            }
            catch (Exception error){
                MessageBox.Show("Ha ocurrido un error..." + error.Message);
                return false;
            }
            
        }

        public override void Eliminar()
        {
            try
            {
                string cmd = string.Format("EXEC EliminarProducto '{0}'", txtidproducto.Text.Trim());
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("Se ha eliminado el producto...");
            } catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error..." + error.Message);
            }
        }

        private void Mantenimiento_Producto_Load(object sender, EventArgs e)
        {

        }
    }
}
