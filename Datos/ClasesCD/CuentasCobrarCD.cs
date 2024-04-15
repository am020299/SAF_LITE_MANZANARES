using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Entidades;

namespace Datos.ClasesCD
{
    public class CuentasCobrarCD
    {
        #region PARAMETROS
        public List<CuentasContables> CuentasContablesParametros_Select( )
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.CuentasContables.Where(X => X.estado==1).ToList();
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        public List<ModuloSistema> ModulosSistema_Select( )
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.ModuloSistema.Where(X => X.estado_registro==1).ToList();
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        public int CuentaContable_Update(string numero_cuenta,int id_cuenta,int id_usuario)
        {
            try
            {
                using(Entities db = new Entities())

                {
                    return db.CuentaContable_Update(id_cuenta,numero_cuenta,id_usuario);
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }
        public List<TiposDocumentosCx> TiposDocumentosCxc( )
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.TiposDocumentosCx.Where(X => X.modulo==3).ToList();
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }

        }
        #endregion
        #region DOCUMENTOS CXC
        public List<DocumentosCuentasCobrar> DocumentosCuentasCobrar_Select( )

        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.DocumentosCuentasCobrar.Where(X => X.estado!=0).ToList();
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        public List<CuentasCobrarSelect_Result> CuentasCobrarMaestro_Select( )
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.CuentasCobrarSelect().ToList();
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        public List<CuentasCobrarDetalles_Select_Result> CuentasCobrarDetalles_Todos( )
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.CuentasCobrarDetalles_Select().ToList();
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        public List<CuentasCobrarDetalles_Select_Cliente_Result> CuentasCobrarDetalles_Todos(int id_cliente)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.CuentasCobrarDetalles_Select_Cliente(id_cliente).ToList();
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }

        public int AnularRecibo(int id_documento)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.AnularReciboCXC(id_documento);
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public List<DocumentosCuentasCobrar_Clientes_Select_Result> DocumentosCuentasCobrar_Por_cliente(int id_cliente)
        {

            try
            {
                using(Entities db = new Entities())
                {
                    return db.DocumentosCuentasCobrar_Clientes_Select(id_cliente).ToList();
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }

        public List<CargarClienteCobrar_Result> CargarCliente_Select()
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.CargarClienteCobrar().ToList();
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public Documento_Cliente_Select_Result Documento_Cliente_Select_Fila(int id_cliente,int id_documento)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.Documento_Cliente_Select(id_cliente,id_documento).ToList().FirstOrDefault();
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        public int Verfica_maximo_documento(int tipo_documento)
        {
            try
            {
                using(Entities db= new Entities())
                {

                    return Convert.ToInt32( db.DocumentosCuentasCobrar.Where(C => C.tipo_documento==tipo_documento && C.estado!=0).Max(F => F.numero_doc));
                }
            }
            catch(Exception)
            {

                return 0;
            }
        }
        //public int Ultimo_id_Documento_Insertado(int tipo_documento)
        //{
        //    try
        //    {
        //        using(Entities db = new Entities())
        //        {

        //            return Convert.ToInt32(db.DocumentosCuentasCobrar.Where(C => C.tipo_documento==tipo_documento && C.estado!=0).Max(F => F.id_documento));
        //        }
        //    }
        //    catch(Exception)
        //    {

        //        return -1;
        //    }
        //}
        public int DocumentosCuentasCobrar_Insert(int tipo_documento,int id_cliente,int numero_documento,DateTime fecha_doc,decimal monto_total_doc,decimal sub_total_doc,decimal descuento,decimal impuesto,int id_usuario,string concepto_documento,int id_cobrador,decimal retenciones,bool hay_contabilidad,int id_terminos,int numero_modulo,int id_factura)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    var R= db.DocumentosCuentasCobrar_Insert(tipo_documento,id_cliente,numero_documento,fecha_doc,monto_total_doc,sub_total_doc,descuento,impuesto,id_usuario,concepto_documento,id_cobrador,retenciones,hay_contabilidad,id_terminos,numero_modulo,id_factura);
                    if(R!=null)
                    {
                        if(R.FirstOrDefault().HasValue)
                        {
                            return Convert.ToInt32(db.DocumentosCuentasCobrar.Where(C => C.tipo_documento==tipo_documento && C.estado!=0).Max(F => F.id_documento));// R.FirstOrDefault().Value;

                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }
        public int DocumentosCuentasCobrar_Update(int tipo_documento,int id_cliente,int numero_documento,DateTime fecha_doc,decimal monto_total_doc,decimal sub_total_doc,decimal descuento,decimal impuesto,int id_usuario,string concepto_documento,int id_cobrador,decimal retenciones,bool hay_contabilidad,int id_terminos,int numero_modulo,int id_documento)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    var R= db.DocumentosCuentasCobrar_Update(tipo_documento,id_cliente,numero_documento,fecha_doc,monto_total_doc,sub_total_doc,descuento,impuesto,id_usuario,concepto_documento,id_cobrador,retenciones,hay_contabilidad,id_terminos,numero_modulo,id_documento);
                    if(R!=null)
                    {
                        return R.FirstOrDefault().Value;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }
        public int DocumentosCuentasCobrar_Anular(int id_documento,int id_usuario,int modulo)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.DocumentosCuentasCobrar_Anular(id_documento,id_usuario,modulo);
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }
        public DocumentosCuentasCobrar DocumentosCuentasCobrar_Select(int id_documento)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.DocumentosCuentasCobrar.Where(C => C.id_documento==id_documento).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        public bool Documento_ya_Aplicado(int id_documento)
        {
            try
            {

                using(Entities entities = new Entities())
                {
                    return entities.AplicacionDocumentos.Any(F => (F.id_documento_aplicado==id_documento || F.id_documento_a_aplicar==id_documento) && F.estado==1);
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }
        public bool Existe_numero_documento(int numero,int tipo_documento)
        {
            try
            {

                using(Entities entities = new Entities())
                {
                    return entities.DocumentosCuentasCobrar.Any(X => X.numero_doc==numero && X.tipo_documento==tipo_documento);
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }
        public int Aplica_documento_Cuentas_cobrar(int id_tipo_documento, int id_cliente,decimal sub_total_doc, string concepto_documento, int id_usuario,int id_cobrador, GridView Grilla,bool permit_seleccionar)//
        {
         
           bool controlador=false;
           int catidad_insertado = 0;
            int id_documento_aplicado = 0;
            int id_abono;
            using (Entities db = new Entities())
            {
                using(var db_trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        int numero_documento = Convert.ToInt32(db.DocumentosCuentasCobrar.Where(C => C.tipo_documento == id_tipo_documento && C.estado != 0).Max(F => F.numero_doc)) + 1;
                      
                        DocumentosCuentasCobrar dc = new DocumentosCuentasCobrar();
                        dc.tipo_documento = id_tipo_documento;
                        dc.id_cliente = id_cliente;
                        dc.numero_doc = numero_documento;
                        dc.fecha_doc = DateTime.Now;
                        dc.monto_doc = sub_total_doc;
                        dc.subtotal_doc = sub_total_doc;
                        dc.monto_descuento_doc = 0;
                        dc.monto_impuesto_doc = 0;
                        dc.fecha_regisro = DateTime.Now;
                        dc.estado = 1;
                        dc.id_usuario = id_usuario;
                        dc.id_comprobante = 0;
                        dc.concepto = "";
                        dc.id_cobrador = id_cobrador;
                        dc.retenciones = 0;
                        dc.id_termino = 0;
                        dc.modulo = 3;
                        dc.id_factura = 0;
                        db.DocumentosCuentasCobrar.Add(dc);
                        db.SaveChanges();
                        id_documento_aplicado = dc.id_documento;

                        //Abonos_Caja ac = new Abonos_Caja();
                        //ac.id_documento = id_documento_aplicado;
                        //ac.id_cliente = id_cliente;
                        //ac.monto = sub_total_doc;
                        //ac.fecha = DateTime.Now;
                        //ac.observacion = "";
                        //ac.estado = 1;
                        //ac.activo = true;
                        //ac.id_usuario = id_usuario;
                        //ac.fecha_registro = DateTime.Now;
                        //db.Abonos_Caja.Add(ac);
                        //db.SaveChanges();
                        //id_abono = ac.id;

                       string tipo_documento= db.TiposDocumentosCx.Where(o => o.id_tipo_documento == id_tipo_documento).FirstOrDefault().nombre_documento;
                        concepto_documento = concepto_documento + " "+tipo_documento+ " N° FACTURA";
                        if (!permit_seleccionar)
                        {
                            int con_monto=0;
                            for(int i = 0;i < Grilla.DataRowCount;i++)
                            {
                                int  documento_aplicar=Convert.ToInt32(Grilla.GetRowCellValue(i, "id_documento"));
                                DateTime fecha=db.Database.SqlQuery<DateTime>("SELECT GETDATE()").SingleOrDefault();
                                decimal monto_pago= Convert.ToDecimal(Grilla.GetRowCellValue(i, "monto_pago"));
                                if(monto_pago>0)
                                {
                                    int aplicadook=db.AplicacionDocumento_Insert(id_documento_aplicado,documento_aplicar,fecha ,id_usuario,monto_pago);
                                    if(aplicadook>0)
                                    {
                                        catidad_insertado++;
                                        concepto_documento = concepto_documento+" "+ Convert.ToInt32(Grilla.GetRowCellValue(i, "numero_doc"))+ ",";
                                    }
                                    else
                                        break;
                                    con_monto++;
                                }
                                if(con_monto==catidad_insertado)
                                {
                                    controlador=true;
                                }
                            }
                            if(controlador)
                            {
                                DocumentosCuentasCobrar dc2 = db.DocumentosCuentasCobrar.Find(id_documento_aplicado);
                                dc2.concepto = concepto_documento;
                                db.SaveChanges();

                                Abonos_Caja ac = new Abonos_Caja();
                                ac.id_documento = id_documento_aplicado;
                                ac.id_cliente = id_cliente;
                                ac.monto = sub_total_doc;
                                ac.fecha = DateTime.Now;
                                ac.observacion =concepto_documento;
                                ac.estado = 1;
                                ac.activo = true;
                                ac.id_usuario = id_usuario;
                                ac.fecha_registro = DateTime.Now;
                                db.Abonos_Caja.Add(ac);
                                db.SaveChanges();
                                db_trans.Commit();
                            }
                            else
                            {
                                db_trans.Rollback();
                            }
                        }
                        else
                        {
                            int con_monto=0;
                            int[] Seleccionadas= Grilla.GetSelectedRows();
                            foreach(int i in Seleccionadas.Where(X => Convert.ToDecimal(X.ToString())>=0))
                            {
                                int  documento_aplicar=Convert.ToInt32(Grilla.GetRowCellValue(i, "id_documento"));
                                DateTime fecha=db.Database.SqlQuery<DateTime>("SELECT GETDATE()").SingleOrDefault();
                                //decimal monto_pago= Convert.ToInt32(Grilla.GetRowCellValue(i, "monto_pago"));
                                decimal monto_pago = Convert.ToDecimal(Grilla.GetRowCellValue(i, "monto_pago"));
                                if (monto_pago>0)
                                {
                                    int aplicadook=db.AplicacionDocumento_Insert(id_documento_aplicado,documento_aplicar,fecha ,id_usuario,monto_pago);
                                    if(aplicadook>0)
                                    {
                                        catidad_insertado++;
                                        concepto_documento = concepto_documento + " " + Convert.ToInt32(Grilla.GetRowCellValue(i, "numero_doc")) + ",";
                                    }
                                    else
                                        break;
                                    con_monto++;
                                }
                                if(con_monto==catidad_insertado)
                                {
                                    controlador=true;
                                }
                            }
                            if(controlador)
                            {
                                DocumentosCuentasCobrar dc2 = db.DocumentosCuentasCobrar.Find(id_documento_aplicado);
                                dc2.concepto = concepto_documento;
                                db.SaveChanges();

                                Abonos_Caja ac = new Abonos_Caja();
                                ac.id_documento = id_documento_aplicado;
                                ac.id_cliente = id_cliente;
                                ac.monto = sub_total_doc;
                                ac.fecha = DateTime.Now;
                                ac.observacion = concepto_documento;
                                ac.estado = 1;
                                ac.activo = true;
                                ac.id_usuario = id_usuario;
                                ac.fecha_registro = DateTime.Now;
                                db.Abonos_Caja.Add(ac);
                                db.SaveChanges();
                                db_trans.Commit();
                            }
                            else
                            {
                                db_trans.Rollback();
                            }
                        }
                       

                    }
                    catch(Exception ex)
                    {
                        db_trans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message,"Mensaje del sistema");
                        id_documento_aplicado = 0;
                        controlador = false;
                    }
                }
            }
            return id_documento_aplicado;
        }
        public List<Documento_AplicadosCargar_Result> Documentos_AplicadosCargar()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Documento_AplicadosCargar().ToList();

                }
            }
            catch (Exception ex)
            {

                return null;
            }

        }
        public List<Report_Documento_Select_FilaCxc_Result> Reporte_Documento_Select_Fila(int id_documento)//Obtener Documento
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.Report_Documento_Select_FilaCxc(id_documento).ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message, "Mensaje del sistema");
                return null;
            }
        }

        #endregion
        #region REPORTES
        public List<Movimientos_Por_Rango_Fechas_Result> Documentos_CuentasCobrar_Select_Rango(DateTime Desde,DateTime hasta)//Todos los documentos de cxc
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.Movimientos_Por_Rango_Fechas(Desde.Date,hasta.Date).ToList();

                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message,"Mensaje del sistema");
                return null;
            }
        }
        public List<Documento_Select_Fila_Result> Documento_Select_Fila( int id_documento )//Obtener Documento
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.Documento_Select_Fila(id_documento).ToList();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message,"Mensaje del sistema");
                return null;
            }
        }

        public List<Antiguedad_de_saldos_Result> Antiguedad_de_saldos_cuentas_por_cobrar()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Antiguedad_de_saldos().ToList();

                }
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public List<Estado_Cuenta_CXC_Result> Estado_cuenta(int id_cliente, DateTime Desde, DateTime Hasta)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.Estado_Cuenta_CXC(id_cliente, Desde.Date, Hasta.Date).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        public List<ver_deuda_clientes_Result> cxc_clientes(int estado)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.ver_deuda_clientes(estado).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion
    }
}
