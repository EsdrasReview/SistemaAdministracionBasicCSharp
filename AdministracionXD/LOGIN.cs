using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Libreria_Clases;

namespace AdministracionXD
{
    public partial class LOGIN : Base
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        public static String codigo = "";

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                string consola = string.Format("Select * FROM Usuarios WHERE CUENTA='{0}' AND CONTRASEÑA='{1}'", txtUsuario.Text.Trim(), txtContraseña.Text.Trim());
                DataSet ds = Utilidades.Ejecutar(consola);

                codigo = ds.Tables[0].Rows[0]["ID_USUARIO"].ToString().Trim();

                string cuenta = ds.Tables[0].Rows[0]["CUENTA"].ToString().Trim();
                string contraseña = ds.Tables[0].Rows[0]["CONTRASEÑA"].ToString().Trim();

                if (cuenta == txtUsuario.Text.Trim() && contraseña == txtContraseña.Text.Trim())
                {
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["STATUS_ADM"]) == true)
                    {
                        VENTANA_ADMIN VentanaAdmin = new VENTANA_ADMIN();
                        this.Hide();
                        VentanaAdmin.Show();
                    } else
                    {
                        VENTANA_USUARIO VentanaUsuario = new VENTANA_USUARIO();
                        this.Hide();
                        VentanaUsuario.Show();
                    }
                } 
            }
            catch (Exception error)
            {
                MessageBox.Show("Los datos ingresados no coinciden.. Intente nuevamente..." + error.Message);
                txtContraseña.Text = "";
                txtUsuario.Text = "";
            }

        }

        private void LOGIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
           
        }
    }

  
}
