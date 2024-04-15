using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Entidades;

namespace Datos.ClasesCD
{
    public class ContabilidadCD
    {
        #region CUENTAS
        public List<VerCuentas> Cuentas_Select( )
        {
            try
            {
                using(Entities Entidades = new Entities())
                {
                    return Entidades.VerCuentas.ToList();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        public List<ParametrosCuentasContables> ParametrosCuentasContables_Select( )
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.ParametrosCuentasContables.Where(C => C.estado==1).ToList();
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        public bool Tienen_Movimientos(int id_cuenta)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    var cuenta=db.VerCuentas.Where(X=>X.id==id_cuenta).FirstOrDefault().numero_cuenta;
                    return db.ComprobanteDiarioDetalle.Where(Z => Z.estado==1).Any(C => C.numero_cuenta==cuenta);
                }
            }
            catch(Exception)
            {

                return false;
            }
        }
        public int Cuenta_Insert(string numero_cuenta,string nombre_cuenta,string naturaleza,string clasificacion,bool agrupacion,bool deslizamiento,int nivel,int id_usuario)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.Cuenta_Insert(numero_cuenta,nombre_cuenta,naturaleza,clasificacion,agrupacion,deslizamiento,nivel,id_usuario);
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }
        public int Cuenta_Modificar(int id_cuenta,string numero_cuenta,string nombre_cuenta,bool agrupacion,bool deslizamiento,int nivel,int id_usuario)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.Cuenta_Modificar(id_cuenta,numero_cuenta,nombre_cuenta,agrupacion,deslizamiento,nivel,id_usuario);
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }
        public int Cuenta_Eliminar(int id_cuenta,string numero_cuenta,string nombre_cuenta,bool agrupacion,bool deslizamiento,int nivel,int id_usuario)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.Cuenta_Eliminar(id_cuenta,numero_cuenta,nombre_cuenta,agrupacion,deslizamiento,nivel,id_usuario);
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }
        public Tuple<List<int>,List<int>> CuentasModificarAgrupacion_Deslizamiento(List<int> Lista_cuentas_modificar,bool agrupacion, bool deslizamiento,int id_usuario)
        {
            try
            {
                List<int>Correctos= new List<int>();
                List<int>InCorrectos= new List<int>();
                using(Entities entities = new Entities())
                {

                    foreach(var i in Lista_cuentas_modificar)
                    {
                        if(Tienen_Movimientos(i))
                        {
                            InCorrectos.Add(i);
                        }
                        else if(entities.Cuentas_Modificar_Agrupacion(i,agrupacion,deslizamiento,id_usuario)>0)
                        {
                            Correctos.Add(i);
                        }
                    }
                }
                return Tuple.Create(Correctos,InCorrectos);

            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return Tuple.Create<List<int>,List<int>>(null,null);
            }
        }
        public bool Cuenta_Validar(string numero_cuenta)
        {
            try
            {
                using(Entities entities= new Entities())
                {
                    return entities.VerCuentas.Any(W => W.numero_cuenta==numero_cuenta);
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
               // return Tuple.Create<List<int>,List<int>>(null,null);
            }
        }
        public VerCuentas Cuenta(string numero_cuenta)
        {
            try
            {
                using(Entities entities = new Entities())
                {
                    return entities.VerCuentas.Where(X=>X.numero_cuenta==numero_cuenta).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion
        #region COMPROBANTES
        public List<TipoComprobante> Tipo_Comprobante_Select( )
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.TipoComprobante.Where(X => X.estado==1).ToList();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        public int ComprobanteDiario_Insert(string concepto,int tipo,int id_usuario,DateTime fecha,GridView Grilla)
        {
            bool controlador=false;
            int id_comprobante_insertado = 0;
            using(Entities entities = new Entities())
            {
                using(var db = entities.Database.BeginTransaction())
                {
                    try
                    {
                        var ok=entities.ComprobanteDiario_Insertar(concepto,tipo,id_usuario,fecha);
                        if(ok!=null)
                        {
                            int id=ok.FirstOrDefault().Value;
                            id_comprobante_insertado=id;
                            if(id>0)
                            {
                                int correctos=0;
                                for(int i = 0;i < Grilla.RowCount;i++)
                                {

                                    string vCuenta = Grilla.GetRowCellValue(i, "num_cuenta").ToString();
                                    decimal vDebe = Convert.ToDecimal(Grilla.GetRowCellValue(i, "debe"));
                                    decimal vHaber = Convert.ToDecimal(Grilla.GetRowCellValue(i, "haber"));
                                    int detalle=entities.ComprobanteDiarioDetalle_Insertar(vCuenta,id,vDebe,vHaber);
                                    if(detalle>0)
                                        correctos++;
                                    else
                                        break;
                                }
                                if(correctos==Grilla.RowCount)
                                    controlador=true;
                            }
                        }
                        if(controlador)
                        {
                            entities.SaveChanges();
                            db.Commit();
                        }
                        else
                        {
                            db.Rollback();
                        }
                    }
                    catch(Exception ex)
                    {
                        db.Rollback();
                        XtraMessageBox.Show($"Error: {ex.Message}","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        controlador=false;
                        id_comprobante_insertado=0;
                    }

                }

            }
            return id_comprobante_insertado;
        }
        public DateTime Fecha_Primer_Asiento( )
        {
            try
            {
                using(Entities db = new Entities())
                {
                    var Z=db.ComprobanteDiario.Min(X => X.fecha_asiento);
                    return Z.HasValue ? Z.Value.Date : DateTime.Now.Date;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return DateTime.Now.Date;
            }


        }
        public DateTime Fecha_Ultimo_Asiento( )
        {
            try
            {
                using(Entities db = new Entities())
                {
                    var Z=db.ComprobanteDiario.Max(X => X.fecha_asiento);
                    return Z.HasValue ? Z.Value.Date : DateTime.Now.Date;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return DateTime.Now.Date;
            }
        }
        public List<Comprobante_diarios_Select_Result> Comprobante_Diarios_Select(DateTime Desde,DateTime Hasta,int Tipo_Documento)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.Comprobante_diarios_Select(Desde.Date,Hasta.Date,Tipo_Documento).ToList();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        public List<ComprobanteDiaarioDetalle_Select_Result> ComprobanteDiarioDetalles_Select(DateTime Desde,DateTime Hasta)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.ComprobanteDiaarioDetalle_Select(Desde.Date,Hasta.Date).ToList();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        public ComprobanteDiario Comprobante_Diarios_Select(int id_comprobante)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.ComprobanteDiario.Where(X => X.id==id_comprobante).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }

        }
        public DataTable ComprobanteDiarioDetalles_Select(int id_comprobante)
        {
            DataTable detalle_comprobantes;
            try
            {

                detalle_comprobantes= new DataTable();
                detalle_comprobantes.Columns.Add("id",typeof(int));
                detalle_comprobantes.Columns.Add("id_comprobante",typeof(int));
                detalle_comprobantes.Columns.Add("num_cuenta",typeof(string));
                detalle_comprobantes.Columns.Add("nom_cuenta",typeof(string));
                detalle_comprobantes.Columns.Add("debe",typeof(decimal));
                detalle_comprobantes.Columns.Add("haber",typeof(decimal));
                detalle_comprobantes.Clear();
                using(Entities Entidades = new Entities())
                {
                    foreach(var d in Entidades.ComprobanteDiarioDetalle.Where(X => X.id_comprobante==id_comprobante && X.estado==1).ToList())
                    {
                        DataRow Fila=detalle_comprobantes.NewRow();
                        Fila[0]=d.id;
                        Fila[1]=d.id_comprobante;
                        Fila[2]=d.numero_cuenta;
                        Fila[3]=d.descripcion;
                        Fila[4]=d.debe;
                        Fila[5]=d.haber;
                        detalle_comprobantes.Rows.Add(Fila);
                    }
                    return detalle_comprobantes;
                }

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return new DataTable();
            }
        }
        public int ComprobanteDiarioDetalle_Actualizar(int id_detalle_actualizar)
        {
            try
            {
                using(Entities entities = new Entities())
                {
                    var DETALLE= entities.ComprobanteDiarioDetalle.Where(X=>X.id==id_detalle_actualizar).FirstOrDefault();
                    DETALLE.estado=0;
                    return entities.SaveChanges();
                }

            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }
        public int comprobanteDiarioDetalle_Insertar(string numero_cuenta,int id_comprobante,decimal debe,decimal haber)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.ComprobanteDiarioDetalle_Insertar(numero_cuenta,id_comprobante,debe,haber);
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }
        public int ComprobanteDiario_Actualizar(int id_comprobante,int id_usuario,string concepto)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.ComprobanteDiario_Actualizar(id_comprobante,id_usuario,concepto);
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }
        public int ComprobanteDiario_Eliminar(int id_comprobante,int id_usuario,string Razon)
        {
            try
            {
                using(Entities entities = new Entities())
                {
                    return entities.ComprobanteDiario_Eliminar(id_comprobante,id_usuario,Razon);
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }

        #endregion
        #region REPORTES
        public List<ComprobanteDiario_Select_Reporte_Result> ComprobanteDiario_Reporte(int id_comprobante)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.ComprobanteDiario_Select_Reporte(id_comprobante).ToList();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion
    }
}
