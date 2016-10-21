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
        int check = 0;

        public ABMAfiliado()
        {

            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].Visible = false;
            checkBox1.Checked = true;
        }


        //Volver
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        //Buscar
        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = "and nombre like '%" + textBox1.Text + "%'";
            string apellido = "and apellido like '%" + textBox2.Text + "%'";
            string documento = "and documento like '%" + textBox3.Text + "%'";
            string activo = "and activo =" + check;
            DataTable dataTable = Login.login.consultaSQL("select Nombre,Apellido,P.descripcion as Plan_Medico, Documento,A.ID_AFILIADO AS Numero_Afiliado , Direccion,Mail, Telefono, A.Estado_Civil , A.Hijos_Cargo,A.ID_GRUPO AS Grupo_Familiar from DR_HIBBERT.USUARIOS U "
             + " inner join DR_HIBBERT.AFILIADOS A on U.Id_usuario = A.Id_afiliado INNER JOIN DR_HIBBERT.PLANES P on A.Id_plan = P.Id_plan"
             + " where nombre is not null " + nombre + apellido + documento + activo);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Visible = true;
        }

        //Limpiar
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            checkBox1.Checked = true;
            dataGridView1.DataSource = null;
            dataGridView1.Columns[0].Visible = false;
        }

        //Agregar afiliado
        private void button3_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.AltaAfiliado formAlta = new Abm_Afiliado.AltaAfiliado(this);
            this.Hide();
            formAlta.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                check = 1;
            }
            else
            {
                check = 0;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                Abm_Afiliado.ConsultaModificacionAfiliado formModificacion = new Abm_Afiliado.ConsultaModificacionAfiliado(this, fila,checkBox1.Checked);
                this.Hide();
                formModificacion.Visible = true;
                

            }
        }

        private void dataGridView1_buttonClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ABMAfiliado_Load(object sender, EventArgs e)
        {

        }

      

    }
}
