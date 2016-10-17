using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Login
{
    public partial class login : Form
    {
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
        private void button1_Click(object sender, EventArgs e)
        {
            //chequearLogueo
            //mostrarOpciones 
            if (this.textBox1.Text == "Martin" && this.textBox2.Text == "Salerno")
                this.button2.Enabled = true;
            else
                MessageBox.Show("Verifique usuario y password");
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
        private void button2_Click(object sender, EventArgs e)
        {
            //prueba 
            Principal.Afiliado formAfiliado = new Principal.Afiliado(this);
            formAfiliado.Show();
            this.Hide();
            
        }
    }
}
