﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Inventario
{
    public partial class ListadoDeProducto : DevExpress.XtraReports.UI.XtraReport
    {
        public ListadoDeProducto(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }

    }
}
