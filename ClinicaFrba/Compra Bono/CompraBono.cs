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
    public partial class CompraBono : Form
    {
        Compra_Bono.VerBonos formBono;
        string idAfiliado;
        string idPlan;
        public CompraBono(Compra_Bono.VerBonos formBono, string idAfiliado)
        {
            InitializeComponent();
            this.formBono = formBono;
            this.idAfiliado = idAfiliado;
            textBox2.Text = idAfiliado;

            DataTable especialidades = Login.login.consultaSQL("select Descripcion from DR_HIBBERT.ESPECIALIDADES");
            for (int i = 0; i < especialidades.Rows.Count; i++)
            {
                comboBox1.Items.Add(especialidades.Rows[i][0]);
            }
            DataTable datos = Login.login.consultaSQL("select P.Precio_bono_consulta,P.Descripcion,P.id_plan  from DR_HIBBERT.AFILIADOS A inner join DR_HIBBERT.PLANES P on A.Id_plan = p.Id_plan WHERE Id_afiliado = '" + idAfiliado + "'");
            textBox3.Text = datos.Rows[0][1].ToString();
            textBox4.Text = datos.Rows[0][0].ToString();
            idPlan = datos.Rows[0][2].ToString();

        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {

        }

        private void rectangleShape2_Click(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int cantidad = 0;
            int precio = 0;
            int total = 0;
            if (!int.TryParse(textBox1.Text, out cantidad) && textBox1.Text != "")
            {
                MessageBox.Show("Verificar cantidad");
                textBox1.Text = null;
                return;
            }
            if (!int.TryParse(textBox4.Text, out precio))
            {
                total = cantidad * precio;
                textBox5.Text = total.ToString();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            formBono.Visible = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login.login.consultaSQL("insert into dr_hibbert.COMPRAS_BONOS VALUES ('" + idAfiliado + "'," + textBox1.Text + "," + textBox5.Text + ")");
            string fecha = DateTime.Now.ToString("MM/dd/yyyy");
            int especialidad = (int)Login.login.consultaSQL("select id_especialidad from dr_hibbert.especialidades where descripcion = '" + comboBox1.SelectedItem.ToString() + "'").Rows[0][0];
            int idGrupoFamiliar = (int)Login.login.consultaSQL("select id_grupo from dr_hibbert.afiliados where id_afiliado = '" + textBox2.Text + "'").Rows[0][0];
            int cantidad = int.Parse(textBox1.Text);
            for (int i = 0; i < cantidad; i++)
            {
                Login.login.consultaSQL("insert into dr_hibbert.BONOS(Id_afiliado,Id_plan,Id_tipo,Estado,Fecha_compra,Fecha_uso,numero_consulta,id_afiliado_uso_bono,id_especialidad,id_grupo) " +
                   " values ('" + idAfiliado + "'," + idPlan + ",1,'Pendiente', convert(varchar(30),cast('" + fecha + "' as datetime),121),null,null,null,"+especialidad+","+idGrupoFamiliar+")");
            }
            textBox1.Text = "";
            comboBox1.ResetText();
            comboBox1.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CompraBono_Load(object sender, EventArgs e)
        {

        }
    }

}


