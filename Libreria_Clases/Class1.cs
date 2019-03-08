using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Libreria_Clases
{
    public class Utilidades
    {
        public static DataSet Ejecutar(string cmd)
        {
            SqlConnection conectardb = new SqlConnection(Properties.Settings.Default.conexion);
            conectardb.Open();

            DataSet DS = new DataSet();
            SqlDataAdapter DP = new SqlDataAdapter(cmd, conectardb);

            DP.Fill(DS);
            conectardb.Close();

            return DS;
        }

        public static Boolean ValidarForm(Control Objeto, ErrorProvider ErrorProvider)
        {
            Boolean HayErrores = false;

            foreach (Control Item in Objeto.Controls)
            {
                if (Item is ErrorTxtBox)
                {
                    ErrorTxtBox Obj = (ErrorTxtBox)Item;

                    if (Obj.validar == true)
                    {
                        if (string.IsNullOrEmpty(Obj.Text.Trim()))
                        {
                            ErrorProvider.SetError(Obj, "Este campo no puede estar vacio...");
                            HayErrores = true;
                        }
                        if (Obj.SoloNumero == true)
                        {
                            int cont = 0, LetrasEncontradas = 0;

                            foreach (char letra in Obj.Text.Trim())
                            {
                                if (char.IsLetter(Obj.Text.Trim(), cont))
                                {
                                    LetrasEncontradas++;
                                }

                                cont++;
                            }

                            if (LetrasEncontradas !=0)
                            {
                                HayErrores = true;
                                ErrorProvider.SetError(Obj, "Solo Numeros");
                            }
                        }
                    }
                }
            }

            return HayErrores;
        }
        
    }
}
