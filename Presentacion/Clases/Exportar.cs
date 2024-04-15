using DevExpress.XtraEditors;
using ExcelDataReader;
using Presentacion.Formularios.Principal;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Presentacion.Clases
{
    public class Exportar
    {
        public void Exportar_Grid_A_Excel(DevExpress.XtraGrid.GridControl grilla)
        {

            try
            {
                string ruta = "";
                SaveFileDialog openfile1 = new SaveFileDialog();
                openfile1.Filter = "Archivos Excel (.xls, .xlsx) |*.xlsx;*.xls";
                openfile1.Title = "Guardar el archivo";
                if (openfile1.ShowDialog() == DialogResult.OK)
                {
                    if (openfile1.FileName.Equals("") == false)
                    {
                        ruta = openfile1.FileName;
                    }
                    else
                    {
                        return;
                    }
                }
                if (!string.IsNullOrWhiteSpace(ruta))
                    grilla.ExportToXlsx(ruta);
                else
                    return;
            }catch(Exception ex)
            {
                XtraMessageBox.Show(string.Format("Error al exportar el archivo a excel.\nComuniquese con el administrador de sistema.\nError:{0}",ex.Message.ToString()), "Error de exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Exportar_Pivote_A_Excel(DevExpress.XtraPivotGrid.PivotGridControl grilla)
        {
           
            try
            {
                string ruta = "";
                SaveFileDialog openfile1 = new SaveFileDialog();
                openfile1.Filter = "Archivos Excel (.xls, .xlsx) |*.xlsx;*.xls";
                openfile1.Title = "Guardar el archivo";
                if (openfile1.ShowDialog() == DialogResult.OK)
                {
                    if (openfile1.FileName.Equals("") == false)
                    {
                        ruta = openfile1.FileName;
                    }
                    else
                    {
                        return;
                    }
                }
                if (!string.IsNullOrWhiteSpace(ruta))
                {
                    WaitForm1 fr = new WaitForm1();
                    fr.progressPanel1.Description = "Generando Archivo";
                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Presentacion.Formularios.Principal.WaitForm1));
                    grilla.ExportToXlsx(ruta);
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
                    XtraMessageBox.Show("Documento exportado correctamente","Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    
                else
                    return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Error al exportar el archivo a excel.\nComuniquese con el administrador de sistema.\nError:{0}", ex.Message.ToString()), "Error de exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ImportarExcel_A_Grid(DevExpress.XtraGrid.GridControl dtGrid)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog(); 
                openFileDialog1.Filter = "Archivos Excel (.xls, .xlsx) |*.xls; *.xlsx";
                openFileDialog1.FilterIndex = 3;

                openFileDialog1.Multiselect = false;
                openFileDialog1.Title = "ABRIR ARCHIVO";   
                openFileDialog1.InitialDirectory = @"Desktop"; 

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    using(var stream = File.Open(openFileDialog1.FileName,FileMode.Open,FileAccess.Read))
                    {
                        using(IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });
                            var tables = result.Tables[0];
                            dtGrid.DataSource = tables;
 
                        }
                    }
                    //    string pathName = openFileDialog1.FileName;
                    //    string fileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    //    DataTable tbContainer = new DataTable();
                    //    string strConn = string.Empty;
                    //    //string sheetName = fileName;

                    //    FileInfo file = new FileInfo(pathName);
                    //    if (!file.Exists) { throw new Exception("Error, el archivo no existe!"); }
                    //    string extension = file.Extension;
                    //    switch (extension)
                    //    {
                    //        case ".xls":
                    //            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    //            break;
                    //        case ".xlsx":
                    //            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                    //            break;
                    //        default:
                    //            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    //            break;
                    //    }
                    //    OleDbConnection cnnxls = new OleDbConnection(strConn);
                    //    OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}$]", ObtenerNombrePrimeraHoja(pathName)), cnnxls);
                    //    oda.Fill(tbContainer);
                      
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error al importar el archivo de excel.\nComuniquese con el administrador de sistema", "Error de importación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new Clases.ClaseValidacionCampos().Escribir_Error(ex);
            }
        }
        //private string ObtenerNombrePrimeraHoja(string rutaLibro)
        //{
        //    Excel.Application app = null;
        //    try
        //    {
        //        app = new Excel.Application();
        //        Excel.Workbook wb = app.Workbooks.Open(rutaLibro);
        //        Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets.Item[1];//Primera hoja del libro
        //        string name = ws.Name;
        //        ws = null;
        //        wb.Close();
        //        wb = null;
        //        return name;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (((app != null)))
        //            app.Quit();
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        //        app = null;
        //    }
        //}
    }
}
