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

    public partial class Modificacion : Form
    {
        Abm_Afiliado.ABM abm;
        Principal.Afiliado modificacion;

        public Modificacion(Abm_Afiliado.ABM abm)
        {
            this.abm = abm;
            InitializeComponent();
        }
        public Modificacion(Principal.Afiliado modificacion)
        {
            this.modificacion = modificacion;
            InitializeComponent();
        }
        //Volver
        private void button1_Click(object sender, EventArgs e)
        {
            this.modificacion.Show();
            this.Close();
        }

    }
}
