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

namespace ClinicaFrba.Abm_Profesional
{
    public partial class ConsultaModificacionProfesional : Form
    {
        string check;

        public ConsultaModificacionProfesional()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)


        {
            SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2016;Persist Security Info=True;User ID=gd;Password=gd2016");

            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT Id_usuario, Nombre, Apellido, Documento, Mail, Fecha_nacimiento, Estado FROM DR_HIBBERT.Consulta_Profesionales";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
            DataTable dataTable  = new DataTable();
            dataAdapter.Fill(dataTable);
            //dispose

           



            /*
            if (checkBox1.Checked)
                check = "Activo";
            else
                check = "Inactivo";
            try
            {   ClinicaFrba.GD2C2016DataSet.Consulta_ProfesionalesDataTable tabla = this.gD2C2016DataSet.Consulta_Profesionales;
                this.consulta_ProfesionalesTableAdapter.FillBy2(tabla, textBox1.Text, textBox2.Text, ((int)(System.Convert.ChangeType(textBox4.Text, typeof(int)))), check);
                this.dataGridView1.DataSource = tabla.DefaultView;
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
           */
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ConsultaModificacionProfesional_Load(object sender, EventArgs e)
        {
  
// TODO: esta línea de código carga datos en la tabla 'gD2C2016DataSet1.Consulta_Profesionales' Puede moverla o quitarla según sea necesario.
            this.consulta_ProfesionalesTableAdapter.FillBy2(this.gD2C2016DataSet.Consulta_Profesionales, textBox1.Text, textBox2.Text, ((int)(System.Convert.ChangeType(textBox4.Text, typeof(int)))), check);
  
           

        }


        private void consultaProfesionales1ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.consulta_ProfesionalesTableAdapter.FillBy2(this.gD2C2016DataSet.Consulta_Profesionales, textBox1.Text, textBox2.Text, ((int)(System.Convert.ChangeType(textBox4.Text, typeof(int)))), check);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.consulta_ProfesionalesTableAdapter.FillBy2(this.gD2C2016DataSet.Consulta_Profesionales, textBox1.Text, textBox2.Text, ((int)(System.Convert.ChangeType(textBox4.Text, typeof(int)))), check);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton_Click_2(object sender, EventArgs e)
        {
            try
            {
                this.consulta_ProfesionalesTableAdapter.FillBy2(this.gD2C2016DataSet.Consulta_Profesionales, textBox1.Text, textBox2.Text, ((int)(System.Convert.ChangeType(textBox4.Text, typeof(int)))), check);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void profesionalesToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.consulta_ProfesionalesTableAdapter.FillBy2(this.gD2C2016DataSet.Consulta_Profesionales, textBox1.Text, textBox2.Text, ((int)(System.Convert.ChangeType(textBox4.Text, typeof(int)))), check);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton_Click_3(object sender, EventArgs e)
        {
            try
            {
                this.consulta_ProfesionalesTableAdapter.FillBy2(this.gD2C2016DataSet.Consulta_Profesionales, textBox1.Text, textBox2.Text, ((int)(System.Convert.ChangeType(textBox4.Text, typeof(int)))), check);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.consulta_ProfesionalesTableAdapter.FillBy2(this.gD2C2016DataSet.Consulta_Profesionales, textBox1.Text, textBox2.Text, ((int)(System.Convert.ChangeType(textBox4.Text, typeof(int)))), check);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
                    }

        private void fillBy2ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.consulta_ProfesionalesTableAdapter.FillBy2(this.gD2C2016DataSet.Consulta_Profesionales,textBox1.Text ,textBox2.Text , ((int)(System.Convert.ChangeType(textBox4.Text , typeof(int)))), check);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}

