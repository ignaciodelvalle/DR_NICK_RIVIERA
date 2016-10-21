using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class NuevoRol : Form
    {
        AbmRol.ABMROL formRol;
        public NuevoRol(AbmRol.ABMROL formRol)
        {
            InitializeComponent();
            this.formRol = formRol;
            DataTable dataTable = Login.login.consultaSQL("select descripcion_func from DR_HIBBERT.FUNCIONALIDADES");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                checkedListBox1.Items.Add(dataTable.Rows[i][0]);
            }

        }

        //Cancelar
        private void button2_Click(object sender, EventArgs e)
        {
            formRol.Show();
            this.Close();

        }

        //Crear
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Login.login.consultaSQL("INSERT INTO DR_HIBBERT.ROLES VALUES ('" + textBox1.Text + "')");
                DataTable dataTable = Login.login.consultaSQL("select id_rol from DR_HIBBERT.ROLES where Descripcion_rol = '"+textBox1.Text+"'");
                int id_rol = (int)dataTable.Rows[0][0];
                string valoresSQL = null;
                int id_func;
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {
                    DataTable dataTableX = Login.login.consultaSQL("select Id_func from DR_HIBBERT.FUNCIONALIDADES where Descripcion_func = '" + checkedListBox1.CheckedItems[i].ToString() + "'");
                    id_func = (int)dataTableX.Rows[0][0];
                    valoresSQL = valoresSQL + " ('" + id_rol + "','" + id_func + "'),";
                }

                valoresSQL = valoresSQL.Remove(valoresSQL.Length - 1);
                Login.login.consultaSQL("INSERT INTO DR_HIBBERT.ROL_FUNCIONALIDAD (ID_ROL,ID_FUNC) VALUES" + valoresSQL);
                formRol.Show();
                formRol.cargarRoles();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ingrese Nombre");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
