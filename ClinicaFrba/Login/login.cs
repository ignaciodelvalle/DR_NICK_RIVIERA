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
using ClinicaFrba;

namespace ClinicaFrba.Login
{

    

    public partial class login : Form
    {

        string idUsuario;

        public login()
        {
            InitializeComponent();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //Aceptar1
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                DataTable dataTable = login.consultaSQL("declare @resultado int; EXEC [DR_HIBBERT].[LOGUEO]" + textBox1.Text + "," + textBox2.Text + ",@resultado OUTPUT; SELECT	@resultado");
                int resultadoLogueo = (int)dataTable.Rows[0][0];
                switch (resultadoLogueo)
                {
                    case 1:
                        comboBox1.Items.Clear();
                        DataTable dataTable2 = login.consultaSQL("SELECT Descripcion_rol,U.id_usuario FROM DR_HIBBERT.ROL_USUARIO RU INNER JOIN DR_HIBBERT.USUARIOS U ON U.Id_usuario = RU.Id_usuario INNER JOIN DR_HIBBERT.ROLES R ON R.Id_rol = RU.Id_rol WHERE U.id_usuario = '" + textBox1.Text + "'");
                        for (int i = 0; i < dataTable2.Rows.Count; i++)
                        {
                            comboBox1.Items.Add(dataTable2.Rows[i][0]);
                        }

                        comboBox1.SelectedItem = dataTable2.Rows[0][0];
                        comboBox1.Enabled = true;
                        this.button2.Enabled = true;
                        this.idUsuario = dataTable2.Rows[0][1].ToString();
                        break;
                    case 0:
                        MessageBox.Show("Verificar Usuario y Clave");
                        break;
                    case 2:
                        MessageBox.Show("El usuario esta bloqueado");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Complete usuario y clave");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Aceptar2
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Profesional")
            {
                /*AbmRol.ABMROL form = new AbmRol.ABMROL();
                form.Show();
                this.Hide();
                Principal.Profesional formProfesional = new Principal.Profesional(this,);
                formProfesional.Show();
                this.Hide();*/
                Compra_Bono.CompraBono formBono = new Compra_Bono.CompraBono( new Compra_Bono.VerBonos(new Principal.Afiliado(this),textBox1.Text), textBox1.Text);
                formBono.Show();
                this.Hide();

            }

            if (comboBox1.SelectedItem.ToString() == "Afiliado")
            {
                Principal.Afiliado formAfiliado = new Principal.Afiliado(this);
                formAfiliado.Visible = true;
                this.Hide();
            }
            if (comboBox1.SelectedItem.ToString() == "Afiliado")
            {
                Principal.Administrativo formAdministrativo = new Principal.Administrativo(this);
                formAdministrativo.Show();
                this.Hide();
            }


        }


        private static SqlCommand cargarComando()
        {

            SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2016;Persist Security Info=True;User ID=gd;Password=gd2016");
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            return comando;
        }

        public static DataTable consultaSQL(string consulta)
        {
            SqlCommand comando = cargarComando();
            comando.Connection.Open();
            comando.CommandText = consulta;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            comando.Connection.Close();
            comando.Dispose();
            dataAdapter.Dispose();
            return dataTable;

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.ResetText();
            comboBox1.Enabled = false;
            button2.Enabled = false;
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.ResetText();
            comboBox1.Enabled = false;
            button2.Enabled = false;
        }

    }
}
