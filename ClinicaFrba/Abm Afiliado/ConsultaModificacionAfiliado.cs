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

    public partial class ConsultaModificacionAfiliado : Form
    {
        Abm_Afiliado.ABMAfiliado abm;
        Principal.Afiliado modificacion;

        public ConsultaModificacionAfiliado(Abm_Afiliado.ABMAfiliado abm)
        {
            this.abm = abm;
            InitializeComponent();
        }
        public ConsultaModificacionAfiliado(Principal.Afiliado modificacion)
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
