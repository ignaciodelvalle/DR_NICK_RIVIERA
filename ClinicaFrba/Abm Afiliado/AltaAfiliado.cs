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
    public partial class AltaAfiliado : Form
    {
        Abm_Afiliado.ABMAfiliado abm;
        Abm_Afiliado.AltaAfiliado abmAlta;
        Boolean agregadoPorPariente;
        string idFamilia;
        int contadorFamiliares;

        public AltaAfiliado(Abm_Afiliado.ABMAfiliado abm)
        {
            this.abm = abm;
            this.contadorFamiliares = 0;
            InitializeComponent();
            DataTable dataTable = Login.login.consultaSQL("select Descripcion from DR_HIBBERT.PLANES");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                comboBox3.Items.Add(dataTable.Rows[i][0]);
            }
            agregadoPorPariente = false;
        }

         public AltaAfiliado(Abm_Afiliado.AltaAfiliado abmAlta,string idFamilia, int contadorFamiliares)
        {
            this.abmAlta = abmAlta;
            this.idFamilia = idFamilia;
            this.contadorFamiliares = contadorFamiliares;
            InitializeComponent();
            DataTable dataTable = Login.login.consultaSQL("select Descripcion from DR_HIBBERT.PLANES");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                comboBox3.Items.Add(dataTable.Rows[i][0]);
            }
            agregadoPorPariente = true;
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        //Aceptar
        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            if (textBox1.Text == "")
            { MessageBox.Show("Completar nombre"); return; }
            if (textBox2.Text == "")
            { MessageBox.Show("Completar apellido"); return; }
            if (textBox7.Text == "")
            { MessageBox.Show("Completar documento"); return; }
            if (!int.TryParse(textBox7.Text, out n))
            { MessageBox.Show("Documento debe ser numerico"); return; }
            if (textBox3.Text == "")
            { MessageBox.Show("Completar direccion"); return; }
            if (textBox4.Text == "")
            { MessageBox.Show("Completar telefono"); return; }
            if (!int.TryParse(textBox4.Text, out n))
            { MessageBox.Show("Telefono debe ser numerico"); return; }
            if (textBox5.Text == "")
            { MessageBox.Show("Completar Mail"); return; }
            if (textBox6.Text == "")
            { MessageBox.Show("Completar hijos"); return; }
            if (!int.TryParse(textBox6.Text, out n))
            { MessageBox.Show("Cantidad de hijos debe ser numerico"); return; }
            if (comboBox1.SelectedItem == null)
            { MessageBox.Show("Completar sexo"); return; }
            if (comboBox2.SelectedItem == null)
            { MessageBox.Show("Completar estado civil"); return; }
            if (comboBox3.SelectedItem == null)
            { MessageBox.Show("Completar plan medico"); return; }

            DataTable tablaDocumento = Login.login.consultaSQL("select id_usuario from dr_hibbert.usuarios where documento = '" + textBox7.Text + "'");
            if (tablaDocumento.Rows.Count > 0)
            { MessageBox.Show("Ya existe un usuarios con ese documento"); return; }

            string fecha = monthCalendar1.SelectionRange.Start.ToString("MM/dd/yyyy");

            Login.login.consultaSQL("INSERT INTO DR_HIBBERT.USUARIOS (id_usuario,nombre,apellido,documento,telefono,direccion,mail,Fecha_nacimiento,Sexo) "
                + " VALUES ('" + textBox7.Text + "0" + contadorFamiliares + "','" + textBox1.Text + "','" + textBox2.Text + "'," + textBox7.Text + ",'" + textBox4.Text + "','" + textBox3.Text + "','" + textBox5.Text +
                "',convert(varchar(30),cast('" + fecha + "' as datetime),121),'" + comboBox1.SelectedItem.ToString() + "')");

            if (agregadoPorPariente)
            {
                
                Login.login.consultaSQL("insert into DR_HIBBERT.AFILIADOS (Id_afiliado,Id_plan,id_grupo,Estado_civil, hijos_cargo) " +
                    "values ('" + textBox7.Text + "0" + contadorFamiliares + "',(select id_plan from DR_HIBBERT.PLANES where Descripcion = '" + comboBox3.SelectedItem.ToString() +
                    "'),'"+idFamilia+"','" + comboBox2.SelectedItem.ToString() + "'," + textBox6.Text + ")");
                DialogResult botoncito = MessageBox.Show("¿Agregar otro al grupo familiar?", "Grupo familiar", MessageBoxButtons.YesNo);
                if (botoncito == DialogResult.Yes)
                {
                    this.contadorFamiliares = contadorFamiliares + 1;
                    Abm_Afiliado.AltaAfiliado altaOtroPariente = new Abm_Afiliado.AltaAfiliado(this.abmAlta, idFamilia, contadorFamiliares);
                    altaOtroPariente.Visible = true;
                    this.Close();
                }
                else
                {
                    this.abmAlta.Visible = true;
                    abmAlta.deshabilitarBoton();
                    this.Close();

                }
            }
            else
            {
                Login.login.consultaSQL("insert into DR_HIBBERT.AFILIADOS (Id_afiliado,Id_plan,Estado_civil, hijos_cargo) " +
                    "values ('" + textBox7.Text + "0" + contadorFamiliares + "',(select id_plan from DR_HIBBERT.PLANES where Descripcion = '" + comboBox3.SelectedItem.ToString() +
                    "'),'" + comboBox2.SelectedItem.ToString() + "'," + textBox6.Text + ")");

                DialogResult botonApretado = MessageBox.Show("¿Agregar alguien al grupo familiar?", "Grupo familiar", MessageBoxButtons.YesNo);
                if (botonApretado == DialogResult.Yes)
                {
                    DataTable familia = Login.login.consultaSQL("Select id_grupo from DR_HIBBERT.AFILIADOS where id_afiliado = '" + textBox7.Text + "00" + "'");
                    string idFamilia = familia.Rows[0][0].ToString();
                    this.contadorFamiliares = contadorFamiliares + 1;
                    Abm_Afiliado.AltaAfiliado altaPariente = new Abm_Afiliado.AltaAfiliado(this, idFamilia, contadorFamiliares);
                    this.Hide();
                    altaPariente.Visible = true;
                }
                else
                {

                   button1.Enabled = false;
                }
            }
        }


        //Volver
        private void button2_Click(object sender, EventArgs e)
        {
            if (agregadoPorPariente)
            {
                abmAlta.Show();
                abmAlta.deshabilitarBoton();
                this.Close();
            }
            else
            {
                abm.Show();
                this.Close();
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AltaAfiliado_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        public void deshabilitarBoton()
        {
            this.button1.Enabled = false;
        }
    }
}
