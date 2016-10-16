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
    public partial class ABM : Form
    {
        Login.login login;
        public ABM()
        {
          
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.Alta formAlta = new Abm_Afiliado.Alta(this);
            formAlta.Show();
            this.Hide();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.Modificacion formModificacion = new Abm_Afiliado.Modificacion(this);
            formModificacion.Show();
            this.Hide();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.Alta formAlta = new Abm_Afiliado.Alta(this);
            formAlta.Show();
            this.Hide();


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
