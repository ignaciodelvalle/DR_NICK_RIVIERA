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
        DataGridViewRow fila;

        public ConsultaModificacionAfiliado(Abm_Afiliado.ABMAfiliado abm, DataGridViewRow fila, Boolean check)
        {
            this.abm = abm;
            this.fila = fila;
            InitializeComponent();
            textBox1.Text = fila.Cells[6].Value.ToString();
            textBox2.Text = fila.Cells[7].Value.ToString();
            textBox3.Text = fila.Cells[5].Value.ToString();
            textBox4.Text = fila.Cells[3].Value.ToString();
            label7.Text = fila.Cells[1].Value.ToString() + " " + fila.Cells[2].Value.ToString();
            DataTable dataTable = Login.login.consultaSQL("select Descripcion from DR_HIBBERT.PLANES where Descripcion != '" + fila.Cells[3].Value.ToString() + "'");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                comboBox1.Items.Add(dataTable.Rows[i][0]);
            }
            if (check == false)
            { button3.Text = "Agregar"; }
            else
            { button3.Text = "Eliminar"; }

        }
        //Volver
        private void button1_Click(object sender, EventArgs e)
        {
            abm.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.ReadOnly = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //telefono
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //mail
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConsultaModificacionAfiliado_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Agregar")
            { Login.login.consultaSQL(" update DR_HIBBERT.USUARIOS set Activo = 1 where Documento =" + (int)fila.Cells[4].Value); }
            else
            { Login.login.consultaSQL(" update DR_HIBBERT.USUARIOS set Activo = 0 where Documento =" + (int)fila.Cells[4].Value); }
            abm.Show();
            this.Close();

        }

    }
}
