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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;

namespace Presentacion.Formularios.Inventario
{
  
    public partial class xfrm_TrasladosBodega : DevExpress.XtraEditors.XtraForm
    {
        int ID_empleado;
        string usuario;
        string cargo;
        DataTable dtOrigen, dtDestino;
        public xfrm_TrasladosBodega()
        {
            InitializeComponent();
            ID_empleado = Clases.UsuarioLogueado.vID_Empleado;
            usuario = Clases.UsuarioLogueado.vNickName;
            cargo = Clases.UsuarioLogueado.vPuestoCargo;
        }
        private void xfrm_TrasladosBodega_Load(object sender, EventArgs e)
        {
            lookUpEditBodega1.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar();
            dtOrigen = new DataTable();
            dtOrigen.Columns.Add("codigo",typeof(string));
            dtOrigen.Columns.Add("id_producto",typeof(int));
            dtOrigen.Columns.Add("id_lote",typeof(string));
            dtOrigen.Columns.Add("ubicacion",typeof(string));
            dtOrigen.Columns.Add("descripcion",typeof(string));
            dtOrigen.Columns.Add("cantidad",typeof(int));
            dtDestino = new DataTable();
            dtDestino.Columns.Add("id",typeof(int));
            dtDestino.Columns.Add("id_lote_hasta",typeof(int));
            dtDestino.Columns.Add("ubicacion_hasta",typeof(string));
            dtDestino.Columns.Add("descripcion_hasta",typeof(string));
            dtDestino.Columns.Add("cantidad_hasta",typeof(int));
            repository_ubicacion.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_Select().Select(K => new { ubicacion = K.ubicacion}).Distinct().ToList();
            repository_lote.DataSource = Negocio.ClasesCN.CatalogosCN.Lotes_Cargar().Select(L => new { id_lote = L.id_lote,lote = L.lote,fecha_lote=L.fecha_lote }).ToList();
            repository_ubicacion_hasta.DataSource = repository_ubicacion.DataSource;
            repository_lote_hasta.DataSource = repository_lote.DataSource;
            binding_producto_hasta.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(x => x.habilitado == true);
            repository_producto_hasta.DataSource = binding_producto_hasta;
            grid_bodega_desde.DataSource = dtOrigen;
            grid_bodega_hasta.DataSource = dtDestino;
            txt_PersonaReferencia.Text = Clases.UsuarioLogueado.vNombreCompleto;
            date_fecha.DateTime = DateTime.Now.Date;
            bodegaEspecial();

        }

        private void repositoryItemLookUpEdit_Producto_EditValueChanged(object sender,EventArgs e)
        {
            try
            {
                LookUpEdit editor = (sender as LookUpEdit);
                var Fila_Producto=(Entidades.Kardex_SELECT_VENTA_Result)editor.GetSelectedDataRow();

                var query = Negocio.ClasesCN.InventarioCN.Producto_Select_Fila_Lote(Fila_Producto.id,Fila_Producto.id_bodega,Fila_Producto.id_lote??0).Where(U=>U.ubicacion==Fila_Producto.ubicacion && U.habilitado == true).FirstOrDefault();
               
                if(query != null)
                {
                    gview_bodega_desde.SetRowCellValue(gview_bodega_desde.FocusedRowHandle,col_id_lote_desde,query.id_lote);
                    gview_bodega_desde.SetRowCellValue(gview_bodega_desde.FocusedRowHandle,col_ubicacion_desde,query.ubicacion);
                    gview_bodega_desde.SetRowCellValue(gview_bodega_desde.FocusedRowHandle,col_descripcion_desde,query.descripcion);
                    gview_bodega_desde.SetRowCellValue(gview_bodega_desde.FocusedRowHandle,colCantidad_desde,0);
                    gview_bodega_desde.SetRowCellValue(gview_bodega_desde.FocusedRowHandle,col_id_producto_desde,query.id);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }
        private void gview_bodega_desde_ValidateRow(object sender,DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            try
            {

                var ubicacion =view.GetFocusedRowCellValue(col_ubicacion_desde).Equals(DBNull.Value) ? -1 : Convert.ToInt32(view.GetFocusedRowCellValue(col_ubicacion_desde));
                if(ubicacion == -1)
                {
                    e.Valid = false; view.SetColumnError(col_ubicacion_desde,"Campo requerido"); view.FocusedColumn = col_ubicacion_desde;
                }
                var vCantidad = view.GetFocusedRowCellValue(colCantidad_desde).Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue(colCantidad_desde));
                if(string.IsNullOrEmpty(vCantidad))
                {
                    e.Valid = false; view.SetColumnError(colCantidad_desde,"Campo requerido"); view.FocusedColumn = colCantidad_desde;
                }
                else
                {
                    int Mov = 2;
                    if(Mov == 2)
                    {
                        int bodega =Convert.ToInt32(lookUpEditBodega1.EditValue??0);
                        int producto = view.GetFocusedRowCellValue(col_id_producto_desde).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(col_id_producto_desde));
                        int id_lote = view.GetFocusedRowCellValue(col_id_lote_desde).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(col_id_lote_desde));
                        var Productos = Negocio.ClasesCN.InventarioCN.Producto_Select_Fila_Lote(producto, bodega,id_lote).Where(u=>u.ubicacion==ubicacion.ToString() && u.habilitado == true);
                        var query=Productos.Count()!=0?Productos.FirstOrDefault().stock:0;
                        if(Convert.ToDecimal(vCantidad) > query)
                        {
                            e.Valid = false; view.SetColumnError(colCantidad_desde,"Cantidad no puede ser mayor a " + String.Format("{0:n2}",query));
                            view.FocusedColumn = colCantidad_desde;
                        }
                   }
                    else if(Convert.ToDecimal(vCantidad) <= 0.00M) { e.Valid = false; view.SetColumnError(colCantidad_desde,"Cantidad no puede ser menor/igual a 0"); view.FocusedColumn = colCantidad_desde; }
                }
            }
            catch(Exception ex)
            {
                e.Valid = false;
                view.SetColumnError(colcodigo_desde,"Ha ocurrido un error al validar la fila");
                view.FocusedColumn = colcodigo_desde;
          
            }
            
        }

        void ValidacionTienda()
        {
            int id_bodega = Convert.ToInt32(lookUpEditBodega2.EditValue ?? 0);
            if (id_bodega == 4)
            {
                int bodega = Convert.ToInt32(lookUpEditBodega1.EditValue ?? 0);
                int producto = gview_bodega_desde.GetFocusedRowCellValue(col_id_producto_desde).Equals(DBNull.Value) ? 0 : Convert.ToInt32(gview_bodega_desde.GetFocusedRowCellValue(col_id_producto_desde));
                int id_lote = gview_bodega_desde.GetFocusedRowCellValue(col_id_lote_desde).Equals(DBNull.Value) ? 0 : Convert.ToInt32(gview_bodega_desde.GetFocusedRowCellValue(col_id_lote_desde));
                var ubicacion = gview_bodega_desde.GetFocusedRowCellValue(col_ubicacion_desde).Equals(DBNull.Value) ? -1 : Convert.ToInt32(gview_bodega_desde.GetFocusedRowCellValue(col_ubicacion_desde));
                decimal cantidad = gview_bodega_desde.GetFocusedRowCellValue(colCantidad_desde).Equals(DBNull.Value) ? -1 : Convert.ToDecimal(gview_bodega_desde.GetFocusedRowCellValue(colCantidad_desde));
                var Productos = Negocio.ClasesCN.InventarioCN.Producto_Select_Fila_Lote(producto, bodega, id_lote).Where(u => u.ubicacion == ubicacion.ToString() && u.habilitado == true).FirstOrDefault();

                int contador = 0;
                var Listado_productos_En_origen = dtOrigen.Select(string.Format("[id_producto] > '{0}'", 0)).ToList<DataRow>();
                var Listado_productos_En_Destinos = dtDestino.Select(string.Format("[id] > '{0}'", 0)).ToList<DataRow>();
                List<int> Codigos_origen = new List<int>();
                List<int> Codigos_Destinos = new List<int>();
                Dictionary<int, int> Codigos_Sumas_Origen = new Dictionary<int, int>();
                Dictionary<int, int> Codigos_Sumas_Destinos = new Dictionary<int, int>();

                foreach (var P in Listado_productos_En_origen)
                {
                    var ya_agregado = Codigos_origen.Any(O => O == Convert.ToInt32(P.ItemArray[1]));
                    if (!ya_agregado)
                        Codigos_origen.Add(Convert.ToInt32(P.ItemArray[1]));
                }

                foreach (var P in Listado_productos_En_Destinos)
                {
                    var ya_agregado = Codigos_Destinos.Any(O => O == Convert.ToInt32(P.ItemArray[0]));
                    if (!ya_agregado)
                        Codigos_Destinos.Add(Convert.ToInt32(P.ItemArray[0]));
                }
                foreach (var C in Codigos_origen)
                {
                    Codigos_Sumas_Origen.Add(C, dtOrigen.AsEnumerable().Where(W => Convert.ToInt32(W.ItemArray[1]) == C).Sum(x => x.Field<int>("cantidad")));
                }
                foreach (var CD in Codigos_Destinos)
                {
                    Codigos_Sumas_Destinos.Add(CD, dtDestino.AsEnumerable().Where(W => Convert.ToInt32(W.ItemArray[0]) == CD).Sum(x => x.Field<int>("cantidad_hasta")));
                }

                foreach (var D in Codigos_Sumas_Destinos)
                {
                    foreach (var O in Codigos_Sumas_Origen)
                    {
                        if (O.Key == D.Key)
                        {
                            contador++;
                        }
                    }
                }

                if (contador == 0)
                {
                    gview_bodega_hasta.AddNewRow();
                    gview_bodega_hasta.SetRowCellValue(gview_bodega_hasta.FocusedRowHandle, col_lote_hasta, 412);
                    gview_bodega_hasta.SetRowCellValue(gview_bodega_hasta.FocusedRowHandle, col_ubicacion_hasta, 0);
                    gview_bodega_hasta.SetRowCellValue(gview_bodega_hasta.FocusedRowHandle, col_descripcion_hasta, Productos.descripcion);
                    gview_bodega_hasta.SetRowCellValue(gview_bodega_hasta.FocusedRowHandle, col_cantidad_hasta, Convert.ToInt32(cantidad));
                    gview_bodega_hasta.SetRowCellValue(gview_bodega_hasta.FocusedRowHandle, col_id_producto_hasta, Productos.id);
                }
            }
        }

        private void gview_bodega_desde_InvalidValueException(object sender,InvalidValueExceptionEventArgs e)
        {
            GridView view = sender as GridView;

            switch(view.FocusedColumn.Name)
            {
                case "colCantidad_desde":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Cantidad no puede ser menor/igual a 0 o mayor a " + String.Format("{0:n2}",existencia);
                    e.ErrorText = "Cantidad no puede ser menor/igual a 0 o mayor a " + String.Format("{0:n2}",existencia);
                    break;
            }
        }
        private void gview_bodega_desde_InvalidRowException(object sender,DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
            e.WindowCaption = "Error en el valor ingresado";
            e.ErrorText = "Campo requerido";
        }
        private decimal existencia = 0.00M;
        private void gview_bodega_desde_ValidatingEditor(object sender,BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;

                switch(view.FocusedColumn.Name)
                {
                    case "colCantidad_desde":

                        int Mov = 2;
                        if(Mov == 2)
                        {
                            int bodega =Convert.ToInt32(lookUpEditBodega1.EditValue??0);
                            int idBodega2 = Convert.ToInt32(lookUpEditBodega2.EditValue ?? 0);
                            //int contador = 0;
                            int producto = view.GetFocusedRowCellValue(col_id_producto_desde).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(col_id_producto_desde));
                            int id_lote = view.GetFocusedRowCellValue(col_id_lote_desde).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(col_id_lote_desde));
                            var ubicacion =view.GetFocusedRowCellValue(col_ubicacion_desde).Equals(DBNull.Value) ? -1 : Convert.ToInt32(view.GetFocusedRowCellValue(col_ubicacion_desde));
                            var Productos = Negocio.ClasesCN.InventarioCN.Producto_Select_Fila_Lote(producto, bodega,id_lote).Where(u=>u.ubicacion==ubicacion.ToString() && u.habilitado == true);
                            var query=Productos.Count()!=0?Productos.FirstOrDefault().stock:0;
                            existencia = decimal.Parse(query.ToString());
                            if((Convert.ToInt32(e.Value) <= 0) || (Convert.ToDecimal(e.Value) > query))
                                e.Valid = false;
                            else
                            {
                                var cantidad_Filas= dtDestino.Select(string.Format("[id] = '{0}'",Productos.FirstOrDefault().id)).Count();
                                if(idBodega2 == 4)
                                {
                                    dtDestino.Select(string.Format("[id] = '{0}'", Productos.FirstOrDefault().id)).ToList<DataRow>().ForEach(r => r["cantidad_hasta"] = Convert.ToInt32(e.Value));//con esta vara se actualizan las filas que contengan ese codigo cuando cambien la cantidad
                                }
                                else
                                {
                                    dtDestino.Select(string.Format("[id] = '{0}'", Productos.FirstOrDefault().id)).ToList<DataRow>().ForEach(r => r["cantidad_hasta"] = 1);//con esta vara se actualizan las filas que contengan ese codigo cuando cambien la cantidad
                                }
                                
                            }

                            //if(idBodega2 == 4)
                            //{
                            //    int producto2 = view.GetFocusedRowCellValue(col_id_producto_desde).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(col_id_producto_desde));
                            //    int id_lote2 = view.GetFocusedRowCellValue(col_id_lote_desde).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(col_id_lote_desde));
                            //    var ubicacion2 = view.GetFocusedRowCellValue(col_ubicacion_desde).Equals(DBNull.Value) ? -1 : Convert.ToInt32(view.GetFocusedRowCellValue(col_ubicacion_desde));
                            //    var Productos2 = Negocio.ClasesCN.InventarioCN.Producto_Select_Fila_Lote(producto2, bodega, id_lote2).Where(u => u.ubicacion == ubicacion.ToString() && u.habilitado == true).FirstOrDefault();

                            //    var ListadoOrigen = dtOrigen.Select(string.Format("[id_producto] > '{0}'", 0)).ToList<DataRow>();
                            //    var ListadoDestino = dtDestino.Select(string.Format("[id] > '{0}'", 0)).ToList<DataRow>();

                            //    foreach(var origen in ListadoOrigen)
                            //    {
                            //        foreach(var destino in ListadoDestino)
                            //        {
                            //            if(origen.ItemArray[1].ToString() == destino.ItemArray[0].ToString())
                            //            {
                            //                contador++;
                            //                if (contador == 0)
                            //                {
                            //                    var Fila = dtDestino.NewRow();
                            //                    Fila[0] = Productos2.id;
                            //                    Fila[1] = 412;// 394;
                            //                    Fila[2] = 0.ToString();
                            //                    Fila[3] = Productos2.descripcion;
                            //                    Fila[4] = Convert.ToInt32(e.Value);


                            //                    dtDestino.Rows.Add(Fila);
                            //                    grid_bodega_hasta.DataSource = dtDestino;
                            //                }
                            //                contador = 0;
                            //            }
                            //        }
                            //    }
                            //}
                        }
                        else
                        {
                            if((Convert.ToInt32(e.Value) <= 0) || (Convert.ToDecimal(e.Value) > 1000000))
                                e.Valid = false;
                        }


                        break;

                }
            }
            
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
            

        }
        private void gview_bodega_desde_KeyDown(object sender,KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Delete)
                {
                    GridView view = sender as GridView;
                    int[] filas = view.GetSelectedRows();
                    if(filas.Length > 0) { view.DeleteSelectedRows(); }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }

        private bool aguanta_mas(int id_producto)
        {
            try
            {
                int cantidad_en_Origen=0,cantidad_destino=0;
                cantidad_en_Origen = dtOrigen.AsEnumerable().Where(W => Convert.ToInt32(W.ItemArray[1]) == id_producto).Sum(x => x.Field<int>("cantidad"));
                cantidad_destino = dtDestino.AsEnumerable().Where(W => Convert.ToInt32(W.ItemArray[0]) == id_producto).Sum(x => x.Field<int>("cantidad_hasta"));
                return cantidad_en_Origen > cantidad_destino;
            }
            catch(Exception)
            {
                return false;
            }
        }
        private void gview_bodega_desde_DoubleClick(object sender,EventArgs e)
        {
            GridView view = sender as GridView;
            try
            {
                if (Convert.ToInt32(lookUpEditBodega2.EditValue) == 4)
                {
                    repository_lote_hasta.DataSource = Negocio.ClasesCN.CatalogosCN.Lotes_Cargar().Where(x => x.id_lote == 412);
                    repository_ubicacion_hasta.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_Select().Select(K => new { ubicacion = 0 }).Distinct().ToList();
                }
                else
                {
                    repository_lote_hasta.DataSource = Negocio.ClasesCN.CatalogosCN.Lotes_Cargar().Select(L => new { id_lote = L.id_lote, lote = L.lote }).ToList();
                    repository_ubicacion_hasta.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_Select().Select(K => new { ubicacion = K.ubicacion }).Distinct().ToList();
                }


                int bodega =Convert.ToInt32(lookUpEditBodega1.EditValue??0);
                int producto = view.GetFocusedRowCellValue(col_id_producto_desde).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(col_id_producto_desde));
                int id_lote = view.GetFocusedRowCellValue(col_id_lote_desde).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(col_id_lote_desde));
                var ubicacion =view.GetFocusedRowCellValue(col_ubicacion_desde).Equals(DBNull.Value) ? -1 : Convert.ToInt32(view.GetFocusedRowCellValue(col_ubicacion_desde));
                var cantidad_Items =view.GetFocusedRowCellValue(colCantidad_desde).Equals(DBNull.Value) ? -1 : Convert.ToInt32(view.GetFocusedRowCellValue(colCantidad_desde));
                var Productos = Negocio.ClasesCN.InventarioCN.Producto_Select_Fila_Lote(producto, bodega,id_lote).Where(u=>u.ubicacion==ubicacion.ToString() && u.habilitado == true).FirstOrDefault();

                if(aguanta_mas(Productos.id))
                {
                    if(Productos != null)
                    {
                        var Fila= dtDestino.NewRow();
                        Fila[0] = Productos.id;
                        Fila[1] = 412;// 394;
                        Fila[2] = 0.ToString();
                        Fila[3] = Productos.descripcion;
                        Fila[4] = 1;


                        dtDestino.Rows.Add(Fila);
                        grid_bodega_hasta.DataSource = dtDestino;

                    }
               
                }
                else
                {
                    XtraMessageBox.Show($"El codigo {Productos.codigo} ya esta completo en la Distribucion, ya no se pueden hacer mas distribuciones","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {

                Console.WriteLine ("Error :" + ex.Message);
            }
        }
        private void gview_bodega_hasta_KeyDown(object sender,KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Delete)
                {
                    GridView view = sender as GridView;
                    int[] filas = view.GetSelectedRows();
                    if(filas.Length > 0) { view.DeleteSelectedRows(); }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }
        private bool Validar_Distribucion( )
        {
   
            var Listado_productos_En_origen= dtOrigen.Select(string.Format("[id_producto] > '{0}'",0)).ToList<DataRow>();
            var Listado_productos_En_Destinos= dtDestino.Select(string.Format("[id] > '{0}'",0)).ToList<DataRow>();
            List<int> Codigos_origen= new List<int>();
            List<int> Codigos_Destinos= new List<int>();
            Dictionary<int, int> Codigos_Sumas_Origen = new Dictionary<int, int>();
            Dictionary<int, int> Codigos_Sumas_Destinos = new Dictionary<int, int>();


            foreach(var P in Listado_productos_En_origen)
            {
                var ya_agregado=Codigos_origen.Any(O=>O==Convert.ToInt32(P.ItemArray[1]));
                if(!ya_agregado)
                    Codigos_origen.Add(Convert.ToInt32(P.ItemArray[1]));
            }

            foreach(var P in Listado_productos_En_Destinos)
            {
                var ya_agregado=Codigos_Destinos.Any(O=>O==Convert.ToInt32(P.ItemArray[0]));
                if(!ya_agregado)
                    Codigos_Destinos.Add(Convert.ToInt32(P.ItemArray[0]));
            }
            foreach(var C in Codigos_origen)
            {
                Codigos_Sumas_Origen.Add(C,dtOrigen.AsEnumerable().Where(W => Convert.ToInt32(W.ItemArray[1]) == C).Sum(x => x.Field<int>("cantidad")));
            }
            foreach(var CD in Codigos_Destinos)
            {
                Codigos_Sumas_Destinos.Add(CD,dtDestino.AsEnumerable().Where(W => Convert.ToInt32(W.ItemArray[0]) == CD).Sum(x => x.Field<int>("cantidad_hasta")));
            }
            if(Codigos_Sumas_Destinos.Count() > 0 && Codigos_Sumas_Origen.Count > 0)
            {

                foreach(var D in Codigos_Sumas_Origen)
                {
                    if(!(Codigos_Sumas_Destinos.ContainsKey(D.Key) && Codigos_Sumas_Destinos.ContainsValue(D.Value)))
                    {

                        return false;
                    }
                }
                return true;

            }
            else
            {
                return false;
            }
            
 
        }

        private void bbi_traslado_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if(lookUpEditBodega1.EditValue != null && lookUpEditBodega2.EditValue != null)
                {
                    if(Validar_Distribucion())
                    {
                        Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily,16);
                        if(Clases.MyMessageBox.Show($"¿Esta completamente seguro de realizar traslado de {lookUpEditBodega1.Text.ToUpper()} a {lookUpEditBodega2.Text.ToUpper()}?","Inventario",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) return;
                        {
                            var retorno=Negocio.ClasesCN.InventarioCN.TrasladoBodega_Guardar(Convert.ToInt32(lookUpEditBodega1.EditValue ?? -1),Convert.ToInt32(lookUpEditBodega2.EditValue ?? -1),date_fecha.DateTime,"",txtObservacion.Text,Clases.UsuarioLogueado.vID_Empleado,txt_PersonaReferencia.Text,gview_bodega_desde,gview_bodega_hasta);
                            if(retorno.Item1)
                            {
                                Clases.MyMessageBox.Show($"Traslado {retorno.Item3} realizado correctamente","Inventario",MessageBoxButtons.OK,MessageBoxIcon.Question);
                                bbi_limpiar_ItemClick(null,null);
                                BindingSource source = new BindingSource();
                                int vMov = Convert.ToInt32(retorno.Item2);
                                var deBodega = Negocio.ClasesCN.InventarioCN.Traslado_ObtenerBodega(vMov, 0);
                                var haciaBodega = Negocio.ClasesCN.InventarioCN.Traslado_ObtenerBodega(vMov, 1);
                                source.DataSource = Negocio.ClasesCN.InventarioCN.Traslado_Reporte(vMov,haciaBodega.Item1);
                                var report = new Reportes.Inventario.xrpt_traslado_bodega(source);
                                report.Parameters[0].Value = deBodega.Item2;
                                report.ShowPreviewDialog();

                            }
                            else
                            { Clases.MyMessageBox.Show($"No se ha podido realizar el traslado de invetario","Inventario",MessageBoxButtons.YesNo,MessageBoxIcon.Question); }
                 
                        }

                    }
                    else
                    {
                        XtraMessageBox.Show("Por Favor Verifique las Cantidades de Productos, Las cantidades de salida no coinciden con las cantidades de entrada","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Debe de Seleccionar una Bodega de Origen y una bodega destino","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                //bodegaEspecial();
            }
            catch(Exception ex)
            {

                throw;
            }
        }

        ///int cantidad_disponible_para_distribuir=0;
        private void gview_bodega_hasta_ValidateRow(object sender,DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            try
            {

                var ubicacion =view.GetFocusedRowCellValue(col_ubicacion_hasta).Equals(DBNull.Value) ? -1 : Convert.ToInt32(view.GetFocusedRowCellValue(col_ubicacion_hasta));
                if(ubicacion == -1)
                {
                    e.Valid = false; view.SetColumnError(col_ubicacion_hasta,"Campo requerido"); view.FocusedColumn = col_ubicacion_hasta;
                }
                var vCantidad = view.GetFocusedRowCellValue(col_cantidad_hasta).Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue(col_cantidad_hasta));
                if(string.IsNullOrEmpty(vCantidad))
                {
                    e.Valid = false; view.SetColumnError(col_cantidad_hasta,"¡La Cantidad es campo requerido!"); view.FocusedColumn = col_cantidad_hasta;
                }
                else
                {
                    int idproducto = view.GetFocusedRowCellValue(col_id_producto_hasta).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(col_id_producto_hasta));
                    int cantidad_en_Origen=0,cantidad_destino=0;
                    cantidad_en_Origen = dtOrigen.AsEnumerable().Where(W => Convert.ToInt32(W.ItemArray[1]) == idproducto).Sum(x => x.Field<int>("cantidad"));
                    cantidad_destino = dtDestino.AsEnumerable().Where(W => Convert.ToInt32(W.ItemArray[0]) == idproducto).Sum(x => x.Field<int>("cantidad_hasta"));
                    
                    if(cantidad_destino>cantidad_en_Origen)
                    {
                        e.Valid = false;
                        view.SetColumnError(col_cantidad_hasta,"Cantidad disponible para distribuir es de  " + String.Format("{0:n0}",cantidad_en_Origen));
                           view.FocusedColumn = col_cantidad_hasta;

                    }
                    else if(Convert.ToDecimal(vCantidad) <= 0.00M) { e.Valid = false; view.SetColumnError(col_cantidad_hasta,"Cantidad no puede ser menor/igual a 0"); view.FocusedColumn = col_cantidad_hasta; }
                }


            }
            catch(Exception ex)
            {
                e.Valid = false;
                view.SetColumnError(colcodigo_desde,"Ha ocurrido un error al validar la fila");
                view.FocusedColumn = colcodigo_desde;

            }
        }

        private void gview_bodega_hasta_ValidatingEditor(object sender,BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            try
            {

                switch(view.FocusedColumn.Name)
                {
                    case "col_cantidad_hasta":

                        //int idproducto = view.GetFocusedRowCellValue(col_id_producto_hasta).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(col_id_producto_hasta));
                        //int cantidad_en_Origen=0,cantidad_destino=0;
                        //cantidad_en_Origen = dtOrigen.AsEnumerable().Where(W => Convert.ToInt32(W.ItemArray[1]) == idproducto).Sum(x => x.Field<int>("cantidad"));
                        //cantidad_destino = dtDestino.AsEnumerable().Where(W => Convert.ToInt32(W.ItemArray[0]) == idproducto).Sum(x => x.Field<int>("cantidad_hasta"));
                        //cantidad_disponible_para_distribuir = cantidad_en_Origen ;
                        //if(cantidad_destino > cantidad_en_Origen)
                        //{
                        //    e.Valid = false;
                        //}
                        if((Convert.ToInt32(e.Value) <= 0) || (Convert.ToDecimal(e.Value) > 1000000))
                            e.Valid = false;
                        break;
                }
            }
            catch(Exception ex)
            {
                e.Valid = false;
            }

        }

        private void gview_bodega_hasta_InvalidValueException(object sender,InvalidValueExceptionEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;

                switch(view.FocusedColumn.Name)
                {
                    case "col_cantidad_hasta":
                        e.ExceptionMode = ExceptionMode.DisplayError;
                        e.WindowCaption = " Cantidad no puede ser menor/igual a 0 ";
                        e.ErrorText = "Cantidad no puede ser menor/igual a 0";
                        break;
                }
            }
            catch(Exception)
            {

                throw;
            }
        }

        private void gview_bodega_hasta_InvalidRowException(object sender,DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {

            var exp=e.Exception;
            e.ExceptionMode = ExceptionMode.NoAction;
            e.WindowCaption = "Error en el valor ingresado";
            e.ErrorText = "Campo requerido";
        }

        private void bbi_limpiar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lookUpEditBodega1_EditValueChanged(null,null);
            txtObservacion.Text = string.Empty;
            date_fecha.DateTime = DateTime.Now;
            
        }

        private void xfrm_TrasladosBodega_Activated(object sender,EventArgs e)
        {
            repository_ubicacion.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_Select().Select(K => new { ubicacion = K.ubicacion }).Distinct().ToList();
            repository_lote.DataSource = Negocio.ClasesCN.CatalogosCN.Lotes_Cargar().Select(L => new { id_lote = L.id_lote,lote = L.lote }).ToList();
            repository_ubicacion_hasta.DataSource = repository_ubicacion.DataSource;
            repository_lote_hasta.DataSource = repository_lote.DataSource;
          //  binding_producto_hasta.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar();
            repository_producto_hasta.DataSource = binding_producto_hasta;
            grid_bodega_desde.DataSource = dtOrigen;
            grid_bodega_hasta.DataSource = dtDestino;
            txt_PersonaReferencia.Text = Clases.UsuarioLogueado.vNombreCompleto;


        }

        private void lookUpEditBodega1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditBodega2.EditValue = null;
            if (Clases.UsuarioLogueado.saberAdminM())
            {
                lookUpEditBodega2.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar();//.Where(x => x.id != Convert.ToInt32(lookUpEditBodega1.EditValue));
            }
            else
            {
                lookUpEditBodega2.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar().Where(x => /*x.id != Convert.ToInt32(lookUpEditBodega1.EditValue) && */!x.nombre.Contains("BODEGA ESPECIAL"));
            }
            bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == Convert.ToInt32(lookUpEditBodega1.EditValue) && x.stock > 0 && x.habilitado == true).ToList();
            dtDestino.Clear();
            dtOrigen.Clear();
            //bodegaEspecial();
        }

        private void bodegaEspecial()//Terminar las consultas
        {
            Clases.UsuarioLogueado.bodegaEspecial(lookUpEditBodega1);

        }
    }
}