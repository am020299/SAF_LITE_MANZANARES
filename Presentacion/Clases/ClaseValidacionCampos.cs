using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Clases
{
    public class ClaseValidacionCampos
    {
        public string Evaluar_Expresion_Texbox(string xExpresion)
        {
            //VsaEngine engine = VsaEngine.CreateEngine();
            //try
            //{
            //    object o = Eval.JScriptEvaluate(xExpresion, engine);
            //    return System.Convert.ToDouble(o).ToString();
            //}
            //catch
            //{
            return "No se puede evaluar la expresión";
            //}

        }

        public void Solo_Letras(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsLetter(e.KeyChar)) // SI ES UNA LETRA
                {
                    e.Handled = false; // PERMITE QUE SE ESCRIBAN
                }
                else if (Char.IsControl(e.KeyChar)) // SI USA LA TECLA 'BACKSPACE'
                {
                    e.Handled = false; // PERMITE QUE SE USE
                }
                else if (Char.IsSeparator(e.KeyChar)) // SI USA LA TECLA 'ESPACIO'
                {
                    e.Handled = false; // PERMITE QUE SE USE
                }
                else
                {
                    e.Handled = true; // BLOQUEA CUALQUIER CARACTER MENOS LETRAS, LA TECLA ESPACIO Y BACKSPACE
                }
            }
            catch (Exception)
            {
            }
        }
        public void Escribir_Error(Exception ex)
        {
            string miarchivo = Path.Combine(Path.GetTempPath(), "EXCEPCIONES SISTEMA.log");

            using(StreamWriter writer = new StreamWriter(miarchivo,true))
            {
                writer.WriteLine("***---------------------------------------------------------------------------------***");
                writer.WriteLine("FECHA :" + DateTime.Now.ToString());
                writer.WriteLine();
                while(ex != null)
                {
                    writer.WriteLine(ex.GetType().FullName);
                    writer.WriteLine("Message : " + ex.Message);
                    writer.WriteLine("StackTrace : " + ex.StackTrace);
                    ex = ex.InnerException;
                }
            }
        }
        private static readonly string [] Meses= new string[]{"ENE","FEB","MAR","ABR","MAY","JUN","JUL","AGO","SEP","OCT","NOV","DIC" };
        public static bool Validar_Formato_lote(dynamic lote)
        {
            try
            {
                var Tipo=lote.GetType();
                bool retorno=false;

                if(Tipo.ToString() == "System.String")
                {
                    string  Valor=((lote) as String);
                    if(Valor.Length == 8)
                    {
                        bool mes_valido=false;
                        bool anio_valido=false;
                        string Mes=Valor.Substring(0,3);
                        mes_valido = Meses.Contains(Mes.ToUpper());
                        string anio=Valor.Substring(4,4);
                        anio_valido = (Convert.ToInt16(anio) > 1900 && Convert.ToInt16(anio) <= 2199);
                        retorno = mes_valido && anio_valido;
                    }

                }
                return retorno;
            }
            catch(Exception ex)
            {
                new Clases.ClaseValidacionCampos().Escribir_Error(ex);
                return false;
            }
        }
        public void Numeros_Y_Letras(KeyPressEventArgs e)
        {
            try
            {
                string cadena = "qwertyuiopasdfghjklñzxcvbnm1234567890QWERTYUIOPASDFGHJKLÑZXCVBNM" + (Char)8;

                if (!cadena.Contains(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
            }
        }

    }
}
