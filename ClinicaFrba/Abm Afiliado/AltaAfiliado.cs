﻿using System;
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

        public AltaAfiliado(Abm_Afiliado.ABMAfiliado abm)
        {
            this.abm = abm;
            InitializeComponent();
        }
    }
}
