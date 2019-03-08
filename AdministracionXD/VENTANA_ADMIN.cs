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
    public partial class VENTANA_ADMIN : Base
    {
        public VENTANA_ADMIN()
        {
            InitializeComponent();
        }

        private void VENTANA_ADMIN_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM Usuarios WHERE ID_USUARIO=" + LOGIN.codigo;
            DataSet DS = Utilidades.Ejecutar(cmd);

            lblnombreadmin.Text = DS.Tables[0].Rows[0]["NOMBRE_USUARIO"].ToString();
            lblusuarioadmin.Text = DS.Tables[0].Rows[0]["CUENTA"].ToString();
            lblcodigoadmin.Text = DS.Tables[0].Rows[0]["ID_USUARIO"].ToString();

            string urlfoto = DS.Tables[0].Rows[0]["FOTO"].ToString();
            pictureBox1.Image = Image.FromFile(urlfoto);
        }

        private void VENTANA_ADMIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CONTENEDOR_PRINCIPAL ContenedorPrincipal = new CONTENEDOR_PRINCIPAL();
            this.Hide();
            ContenedorPrincipal.Show();
        }
    }
}
