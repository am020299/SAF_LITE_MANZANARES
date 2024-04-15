using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Presentacion.Formularios.Catalogos
{
    public partial class xfrm_Historico_clientesV3 : DevExpress.XtraEditors.XtraForm
    {
        DataTable Tabla_Clientes = new DataTable("Clientes");
        DataTable Tabla_Facturas=new DataTable("Facturas");
        DataTable Tabla_Detalles= new DataTable("Detalles");
        public xfrm_Historico_clientesV3( )
        {

            InitializeComponent();
            Tabla_Clientes.Columns.AddRange(
            new DataColumn[]
            {
                new DataColumn("id",typeof(int)),
                new DataColumn("ruc",typeof(string)),
                new DataColumn("nombre",typeof(string)),
                new DataColumn("telefono",typeof(string)),
                new DataColumn("celular",typeof(string)),
                new DataColumn("direccion",typeof(string)),
                new DataColumn("correo",typeof(string)),
            }
             );
            Tabla_Facturas.Columns.AddRange(
                new DataColumn[]
                {
                    new DataColumn("id_cliente",typeof(int)),
                    new DataColumn("id",typeof(int)),
                    new DataColumn("numero",typeof(string)),
                    new DataColumn("fecha",typeof(DateTime)),
                    new DataColumn("hora",typeof(DateTime)),
                    new DataColumn("total",typeof(decimal)),
                    new DataColumn("moneda_facturas",typeof(string)),
                    new DataColumn("empleado",typeof(string))
                }
                );
            Tabla_Detalles.Columns.AddRange(
                new DataColumn[]
                {
                    new DataColumn("id_venta",typeof(int)),
                    new DataColumn("CODIGO",typeof(string)),
                    new DataColumn("DESCRIPCION",typeof(string)),
                    new DataColumn("CANTIDAD",typeof(string)),
                    new DataColumn("TIPO PRECIO CLIENTE",typeof(string)),
                    new DataColumn("TIPO PRECIO VENTA",typeof(string)),
                    new DataColumn("PRECIO",typeof(string)),
                    new DataColumn("TOTAL",typeof(string)),

                }
                );
        }
        private DataTable Cargar( )
        {
            try
            {
                Tabla_Clientes.Clear();
                Tabla_Detalles.Clear();
                Tabla_Facturas.Clear();
                var Clientes= Negocio.ClasesCN.CatalogosCN.Cliente_Cargar_Historico_C();
                foreach(var C in Clientes)
                {
                    DataRow fila= Tabla_Clientes.NewRow();
                    fila[0] = C.id;
                    fila[1] = C.ruc;
                    fila[2] = C.nombre;
                    fila[3] = C.telefono;
                    fila[4] = C.celular;
                    fila[5] = C.direccion;
                    fila[6] = C.correo;
                    Tabla_Clientes.Rows.Add(fila);

                }
                var Facturas= Negocio.ClasesCN.VentasCN.Ventas_Select(1).Where(x => x.tipo_precio == 9 && x.Cambio_Precio_Cliente == 3 && x.fecha > Convert.ToDateTime("2020-09-11") && x.moneda == 1);
                foreach(var F in Facturas)
                {
                    DataRow Fila= Tabla_Facturas.NewRow();
                    Fila[0] = F.id_cliente;
                    Fila[1] = F.id;
                    Fila[2] = F.numero;
                    Fila[3] = F.fecha.Date;
                    Fila[4] = F.hora;
                    Fila[5] = F.total;
                    Fila[6] = F.moneda_factura;
                    Fila[7] = F.empleado;
                    Tabla_Facturas.Rows.Add(Fila);

                }
                var Detalles = Negocio.ClasesCN.VentasCN.Detalles_Todos();
                foreach(var D in Detalles)
                {
                    DataRow Fila= Tabla_Detalles.NewRow();
                    Fila[0] = D.id_venta;
                    Fila[1] = D.codigo;
                    Fila[2] = D.subgrupo_venta;
                    Fila[3] = D.cantidad;
                    Fila[4] = D.precio;
                    Fila[5] = D.precioCambio;
                    Fila[6] = D.precio1;
                    Fila[7] = D.total;
                    Tabla_Detalles.Rows.Add(Fila);
                }
                Tabla_Detalles.Columns[0].ColumnMapping = MappingType.Hidden;
                using(DataSet Ds = new DataSet())
                {
                    Ds.Tables.AddRange(new DataTable[] { Tabla_Clientes.Copy(),Tabla_Facturas.Copy(),Tabla_Detalles.Copy()});

                 ///   DataRelation relacion_cliente_Facturas =

                    Ds.Relations.AddRange( new DataRelation[]
                    {
                        new DataRelation("Clientes Facturas",Ds.Tables[0].Columns[0],Ds.Tables[1].Columns[0],false),
                        new DataRelation("Detalles Facturas",Ds.Tables[1].Columns[1],Ds.Tables[2].Columns[0],false)
                    }
                   );
                 return Ds.Tables[0];

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        private void xfrm_Historico_clientes_Load(object sender,EventArgs e)
        {
            gridClientes.DataSource = Cargar();
            //gviewDetalles.Columns[0];
        }

        private void bbi_actualizar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridClientes.DataSource = Cargar();
        }

        private void bbi_exportar_Excel_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraPrinting.XlsxExportOptionsEx o = new DevExpress.XtraPrinting.XlsxExportOptionsEx();
            o.ExportType = DevExpress.Export.ExportType.WYSIWYG;
           
            try
            {
                string ruta = "";
                SaveFileDialog openfile1 = new SaveFileDialog();
                openfile1.Filter = "Archivos Excel (.xls, .xlsx) |*.xlsx;*.xls";
                openfile1.Title = "Guardar el archivo";
                if(openfile1.ShowDialog() == DialogResult.OK)
                {
                    if(openfile1.FileName.Equals("") == false)
                    {
                        ruta = openfile1.FileName;
                    }
                    else
                    {
                        return;
                    }
                }
                if(!string.IsNullOrWhiteSpace(ruta))
                {
                    gview_Clientes.OptionsPrint.ExpandAllDetails = true;
                    gview_Clientes.OptionsPrint.PrintDetails = true;
                    gridClientes.ExportToXlsx(ruta, o);
                }
                else
                    return;

                System.Diagnostics.Process.Start(openfile1.FileName);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(string.Format("Error al exportar el archivo a excel.\nComuniquese con el administrador de sistema.\nError:{0}",ex.Message.ToString()),"Error de exportación",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            //new Clases.Exportar().Exportar_Grid_A_Excel(gridClientes);
        }
    }
    }
