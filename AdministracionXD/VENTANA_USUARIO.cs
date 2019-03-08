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
    public partial class VENTANA_USUARIO : Base
    {
        public VENTANA_USUARIO()
        {
            InitializeComponent();
        }

        private void VENTANA_USUARIO_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void VENTANA_USUARIO_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM Usuarios WHERE ID_USUARIO=" + LOGIN.codigo;
            DataSet DS = Utilidades.Ejecutar(cmd);

            lblnombreusuario.Text = DS.Tables[0].Rows[0]["NOMBRE_USUARIO"].ToString();
            lblusuariousuario.Text = DS.Tables[0].Rows[0]["CUENTA"].ToString();
            lblcodigousuario.Text = DS.Tables[0].Rows[0]["ID_USUARIO"].ToString();

            string urlfoto = DS.Tables[0].Rows[0]["FOTO"].ToString();
            pictureBox1.Image = Image.FromFile(urlfoto);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CONTENEDOR_PRINCIPAL ContenedorPrincipal = new CONTENEDOR_PRINCIPAL();
            this.Hide();
            ContenedorPrincipal.Show();
        }
    }
}
