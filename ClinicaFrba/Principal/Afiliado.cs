using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Principal
{
    
    
    public partial class Afiliado : Form
    {

        Login.login logueo;

        public Afiliado(Login.login logueo)
        {
            this.logueo = logueo;
            InitializeComponent();
        }

        //Pedir turno
        private void button1_Click(object sender, EventArgs e)
        {

        }
        //Cancelar turno
        private void button2_Click(object sender, EventArgs e)
        {

        }
        //Comprar bonos
        private void button3_Click(object sender, EventArgs e)
        {

        }
        //Editar perfil
        private void button4_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.Modificacion formModificacion = new Abm_Afiliado.Modificacion(this);
            formModificacion.Show();
            this.Hide();

        }
        //Desloguearse
        private void button5_Click(object sender, EventArgs e)
        {
            logueo.Show();
            this.Close();
        }
    }
}
