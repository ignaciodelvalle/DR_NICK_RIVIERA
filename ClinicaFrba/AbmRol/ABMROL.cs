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

namespace ClinicaFrba.AbmRol
{
    public partial class ABMROL : Form
    {
        public ABMROL()
        {
            InitializeComponent();
            cargarRoles();
            dataGridView1.RowHeadersVisible = false;
          }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            actualizarCombos();
            dataGridView1.DataSource = null; 

        }

        //Ver funcionalidades
        private void button1_Click(object sender, EventArgs e)
        {
            
            DataTable dataTable = Login.login.consultaSQL("SELECT Descripcion_func as Funcionalidad FROM DR_HIBBERT.FUNCIONALIDADES F INNER JOIN DR_HIBBERT.ROL_FUNCIONALIDAD RF ON F.Id_func = RF.Id_func INNER JOIN DR_HIBBERT.ROLES R ON R.Id_rol = RF.Id_rol WHERE Descripcion_rol = '" + comboBox1.SelectedItem.ToString() + "'");
            dataGridView1.DataSource = dataTable;

        }

        //confirmar 2 quitar 
        private void button5_Click(object sender, EventArgs e)
        {
            Login.login.consultaSQL("delete from DR_HIBBERT.ROL_FUNCIONALIDAD " +
   "where Id_rol = (select Id_rol from DR_HIBBERT.ROLES where Descripcion_rol = '"+ comboBox1.SelectedItem.ToString() +"') " +
  " and Id_func = (select Id_func from DR_HIBBERT.FUNCIONALIDADES where Descripcion_func = '"+ comboBox3.SelectedItem.ToString() +"')");
            actualizarCombos();
            button1.PerformClick();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        //confirmar 1 agregar
        private void button3_Click(object sender, EventArgs e)
        {
            Login.login.consultaSQL("insert into DR_HIBBERT.ROL_FUNCIONALIDAD (Id_rol,Id_func) "+
                                    "select (select Id_rol from DR_HIBBERT.ROLES where Descripcion_rol = '"+ comboBox1.SelectedItem.ToString() +"')," +
                                    "(select id_func from DR_HIBBERT.FUNCIONALIDADES where Descripcion_func = '" + comboBox2.SelectedItem.ToString() +"')");
            actualizarCombos();
            button1.PerformClick();
        }

        //confirmar 3 cambiar nombre
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""){
                MessageBox.Show("Ingrese un nombre valido");
            }
            else{
                Login.login.consultaSQL("update DR_HIBBERT.ROLES set Descripcion_rol = '" + textBox1.Text + "' " + 
                                         "where Descripcion_rol = '"+comboBox1.SelectedItem.ToString() +"'");
                cargarRoles();
                comboBox1.SelectedIndex = comboBox1.FindString(textBox1.Text);
                textBox1.Clear();
            }
        }

        //Agregar funcionalidad
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //quitar funcionalidad
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void actualizarCombos()
        {

            comboBox2.Items.Clear();
            comboBox2.ResetText();
            comboBox3.Items.Clear();
            comboBox3.ResetText();
            string nombreRol = comboBox1.SelectedItem.ToString();
            DataTable dataTableComboAgregar = Login.login.consultaSQL("select Descripcion_func from DR_HIBBERT.FUNCIONALIDADES F " +
                 " WHERE F.Id_func NOT IN (SELECT Id_func FROM DR_HIBBERT.ROL_FUNCIONALIDAD RF2 INNER JOIN DR_HIBBERT.ROLES R2 on RF2.Id_rol = R2.Id_rol WHERE R2.Descripcion_rol = '" + nombreRol + "')");

            for (int i = 0; i < dataTableComboAgregar.Rows.Count; i++)
            {
                comboBox2.Items.Add(dataTableComboAgregar.Rows[i][0]);
            }


            DataTable dataTableComboQuitar = Login.login.consultaSQL("SELECT Descripcion_func as Funcionalidad FROM DR_HIBBERT.FUNCIONALIDADES F INNER JOIN DR_HIBBERT.ROL_FUNCIONALIDAD RF ON F.Id_func = RF.Id_func " +
            " INNER JOIN DR_HIBBERT.ROLES R ON R.Id_rol = RF.Id_rol WHERE R.Descripcion_rol = '" + nombreRol + "'");

            for (int i = 0; i < dataTableComboQuitar.Rows.Count; i++)
            {
                comboBox3.Items.Add(dataTableComboQuitar.Rows[i][0]);
            }
            
        }

        public void cargarRoles()
        {
            comboBox1.Items.Clear();
            DataTable dataTable = Login.login.consultaSQL("select Descripcion_rol from DR_HIBBERT.ROLES");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                comboBox1.Items.Add(dataTable.Rows[i][0]);
            }
            comboBox1.SelectedItem = dataTable.Rows[0][0];
        }

        //Nuevo rol
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmRol.NuevoRol formRol = new AbmRol.NuevoRol(this);
            formRol.Show();
        }

        //Volver
        private void button7_Click(object sender, EventArgs e)
        {

        }
    }

}

