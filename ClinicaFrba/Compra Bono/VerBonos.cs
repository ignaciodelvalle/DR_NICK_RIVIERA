using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Compra_Bono
{
    public partial class VerBonos : Form
    {
        Principal.Afiliado formAfiliado;
        string idAfiliado;
        int idGrupoFamiliar;

        public VerBonos(Principal.Afiliado formAfiliado, string idAfiliado)
        {
          
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;
            this.formAfiliado = formAfiliado;
            this.idAfiliado = idAfiliado;
            DataTable planes = Login.login.consultaSQL("select descripcion from dr_hibbert.planes");
            for (int i = 0; i < planes.Rows.Count; i++)
            {
                comboBox1.Items.Add(planes.Rows[i][0]);
            }
            DataTable especialidades = Login.login.consultaSQL("select Descripcion from DR_HIBBERT.ESPECIALIDADES");
            for (int j = 0; j < especialidades.Rows.Count; j++)
            {
                comboBox2.Items.Add(especialidades.Rows[j][0]);
            }
            idGrupoFamiliar = (int)Login.login.consultaSQL("select Id_grupo from DR_HIBBERT.AFILIADOS where Id_afiliado = '"+idAfiliado+"'").Rows[0][0];
            textBox1.Text = (string)Login.login.consultaSQL("select P.DESCRIPCION from DR_HIBBERT.PLANES P inner join DR_HIBBERT.AFILIADOS A on A.Id_plan = P.Id_plan where Id_afiliado = '" + idAfiliado + "'").Rows[0][0];

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //volver
        private void button3_Click(object sender, EventArgs e)
        {
            Compra_Bono.CompraBono formCompra = new Compra_Bono.CompraBono(this, idAfiliado);
            this.Hide();
            this.Close();
        }

        //Ver bonos
        private void button2_Click(object sender, EventArgs e)
        {
            int idPlan;
            int idEspecialidad;
            DataTable dataBonos; 
            if (comboBox1.SelectedItem != null)
            {
                idPlan = (int)Login.login.consultaSQL("select Id_plan from DR_HIBBERT.PLANES where Descripcion = '" + comboBox1.Text + "'").Rows[0][0];
                if (comboBox2.SelectedItem != null)
                {
                     idEspecialidad = (int)Login.login.consultaSQL("select Id_especialidad  from DR_HIBBERT.ESPECIALIDADES where Descripcion = '" + comboBox2.Text + "'").Rows[0][0];
                     dataBonos = Login.login.consultaSQL("select id_bono as Numero,P.Descripcion as 'Plan', B.Estado,E.Descripcion as Especialidad,B.Fecha_compra,B.Fecha_uso,B.id_afiliado_uso_bono as 'Usado por'  from DR_HIBBERT.BONOS B inner join DR_HIBBERT.PLANES P on B.Id_plan = P.Id_plan "
                        + " inner join DR_HIBBERT.ESPECIALIDADES E on b.id_especialidad = E.Id_especialidad where id_grupo = " + idGrupoFamiliar + " and E.Id_especialidad = " + idEspecialidad + "and B.ESTADO LIKE '%" + comboBox3.Text + "%' and P.Id_plan = " + idPlan);
                }
                else
                {
                     dataBonos = Login.login.consultaSQL("select id_bono as Numero,P.Descripcion as 'Plan', B.Estado,E.Descripcion as Especialidad,B.Fecha_compra,B.Fecha_uso,B.id_afiliado_uso_bono as 'Usado por'  from DR_HIBBERT.BONOS B inner join DR_HIBBERT.PLANES P on B.Id_plan = P.Id_plan "
                        + " inner join DR_HIBBERT.ESPECIALIDADES E on b.id_especialidad = E.Id_especialidad where id_grupo = " + idGrupoFamiliar + "and B.ESTADO LIKE '%" + comboBox3.Text + "%' and P.Id_plan = " + idPlan);
                }
            }
            else
            {
                if (comboBox2.SelectedItem != null)
                {
                     idEspecialidad = (int)Login.login.consultaSQL("select Id_especialidad  from DR_HIBBERT.ESPECIALIDADES where Descripcion = '" + comboBox2.Text + "'").Rows[0][0];
                     dataBonos = Login.login.consultaSQL("select id_bono as Numero,P.Descripcion as 'Plan', B.Estado,E.Descripcion as Especialidad,B.Fecha_compra,B.Fecha_uso,B.id_afiliado_uso_bono as 'Usado por'  from DR_HIBBERT.BONOS B inner join DR_HIBBERT.PLANES P on B.Id_plan = P.Id_plan "
                        + " inner join DR_HIBBERT.ESPECIALIDADES E on b.id_especialidad = E.Id_especialidad where id_grupo = " + idGrupoFamiliar + " and E.Id_especialidad = " + idEspecialidad + "and B.ESTADO LIKE '%" + comboBox3.Text + "%'");
                }
                else
                {
                     dataBonos = Login.login.consultaSQL("select id_bono as Numero,P.Descripcion as 'Plan', B.Estado,E.Descripcion as Especialidad,B.Fecha_compra,B.Fecha_uso,B.id_afiliado_uso_bono as 'Usado por'  from DR_HIBBERT.BONOS B inner join DR_HIBBERT.PLANES P on B.Id_plan = P.Id_plan "
                        + " inner join DR_HIBBERT.ESPECIALIDADES E on b.id_especialidad = E.Id_especialidad where id_grupo = " + idGrupoFamiliar + "and B.ESTADO LIKE '%" + comboBox3.Text + "%'");
                }
            }
             
            dataGridView1.DataSource = dataBonos;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Limpiar
        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.ResetText();
            comboBox1.SelectedIndex = -1;
            comboBox2.ResetText();
            comboBox2.SelectedIndex = -1;
            comboBox3.ResetText();
            comboBox3.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Compra_Bono.CompraBono formCompra = new Compra_Bono.CompraBono(this, idAfiliado);
            this.Hide();
            formCompra.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void VerBonos_Load(object sender, EventArgs e)
        {

        }
    }
}
