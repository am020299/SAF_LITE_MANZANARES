﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Ventas
{
    public partial class Cotizacion : DevExpress.XtraReports.UI.XtraReport
    {
        public Cotizacion(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }

    }
}