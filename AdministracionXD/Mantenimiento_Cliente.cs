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
    public partial class Mantenimiento_Cliente : MANTENIMIENTO
    {
        public Mantenimiento_Cliente()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public override Boolean Guardar()
        {
            if (Utilidades.ValidarForm(this, errorProvider1) == false)
            {
                try
                {
                    string cmd = string.Format("EXEC ActualizarCliente '{0}','{1}','{2}'", txtidcliente.Text.Trim(), txtnombrecliente.Text.Trim(), txtapellidocliente.Text.Trim());
                    Utilidades.Ejecutar(cmd);
                    MessageBox.Show("Se han guardado los datos correctamente...");
                    txtidcliente.Text = "";
                    txtapellidocliente.Text = "";
                    txtnombrecliente.Text = "";
                    return true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error..." + error.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public override void Eliminar()
        {
            try
            {
                string cmd = string.Format("EXEC EliminarCliente '{0}'", txtidcliente.Text.Trim());
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("Se ha eliminado el cliente...");               
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error..." + error.Message);
            }
        }

        private void txtidcliente_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
}
