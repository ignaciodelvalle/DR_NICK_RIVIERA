using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ABMAfiliado : Form
    {
        Login.login login;
        public ABMAfiliado()
        {
          
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.AltaAfiliado formAlta = new Abm_Afiliado.AltaAfiliado(this);
            formAlta.Show();
            this.Hide();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.ConsultaModificacionAfiliado formModificacion = new Abm_Afiliado.ConsultaModificacionAfiliado(this);
            formModificacion.Show();
            this.Hide();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.AltaAfiliado formAlta = new Abm_Afiliado.AltaAfiliado(this);
            formAlta.Show();
            this.Hide();


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
