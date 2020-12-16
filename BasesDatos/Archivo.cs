using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace BasesDatos
{
    /// <summary>
    /// Clase para poder guardar BD
    /// </summary>
    public class Archivo
    {
        /// <summary>
        /// / Elemeno para poder escribir en el archivo
        /// </summary>
        public StreamWriter escribe;
        /// <summary>
        /// Elemento para poder leer en el archivo
        /// </summary>
        public StreamReader lee;
        /// <summary>
        /// Nombre del Archivo
        /// </summary>
        public string nombre_archivo;
        /// <summary>
        /// Elemento que nos permite visualizar y guardar un archivo
        /// </summary>
        public SaveFileDialog SaveD;
        /// <summary>
        /// Elemento que nos permite visualizar y abrir un archivo
        /// </summary>
        public OpenFileDialog openFile;
        /// <summary>
        /// Elemento que nos permite manejar el archivo
        /// </summary>
        public FileStream ArchivoFuente;
        /// <summary>
        /// Elemento que nos permite manejar la carpeta donde se guardara la BD
        /// </summary>
        public DirectoryInfo di;
        /// <summary>
        /// Base de datos que se va a manejar
        /// </summary>
        public BaseDatos BaseD;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Archivo()
        {
            SaveD = new SaveFileDialog { InitialDirectory = Directory.GetCurrentDirectory() };
            openFile = new OpenFileDialog { InitialDirectory = Directory.GetCurrentDirectory() };
        }
        /// <summary>
        /// funcion que indica si la BD se puede o no abrir 
        /// </summary>
        /// <returns>Verdadero o falso si se puede abrir la BD</returns>
        public bool AbrirBase()
        {
            try
            {
                CierraArchivo();

                openFile.Filter =
                                  "BaseDeDatos|*.BD";

                if (openFile.ShowDialog() == DialogResult.OK)
                {

                    JavaScriptSerializer js = new JavaScriptSerializer();

                    string ruta = File.ReadAllText(openFile.FileName);

                    BaseDatos bas = js.Deserialize<BaseDatos>(ruta);

                    BaseD = bas;
                    return true;
                }
                else
                {
                    MessageBox.Show("No se seleccionó un archivo compatible.");
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        /// <summary>
        /// funcion que cierra la base de datos y el archivo
        /// </summary>
        public void CierraArchivo()
        {

            if (BaseD != null)
            {
                BaseD = null;
            }
        }
       /// <summary>
       /// Funcion que guarda una tabla en un archivo especifico
       /// </summary>
       /// <param name="json">Tabla que se quiere guardar</param>
        public void GuardarTabla(Tabla json)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                //SaveD.InitialDirectory

                string jsonData = js.Serialize(json);
                if (di == null)
                {
                    File.WriteAllText(SaveD.InitialDirectory + "//" + BaseD._NombreBD + "//" + json._NombreTabla.ToString() + ".TB", jsonData);

                }
                else
                {
                    File.WriteAllText(di.FullName + "//" + json._NombreTabla.ToString() + ".TB", jsonData);

                }

            }
            catch (Exception) { MessageBox.Show("No se pudo guardar el archivo."); }
        }
        /// <summary>
        /// Funcion que elimina la base de datos 
        /// </summary>
        /// <param name="base">Base de datos a eliminar</param>
        public void EliminarBase(BaseDatos @base)
        {
            Directory.Delete(SaveD.InitialDirectory + "//" + @base._NombreBD, true);
        }
       /// <summary>
       /// Funcion que Guarda una base de datos completa
       /// </summary>
       /// <param name="json">Base de datos a guardar</param>
        public void GuardaBase(BaseDatos json)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                string jsonData = js.Serialize(json);
                if (di == null)
                {
                    File.WriteAllText(SaveD.InitialDirectory + "//" + BaseD._NombreBD + "//" + json._NombreBD.ToString() + ".BD", jsonData);

                }
                else
                {
                    File.WriteAllText(di.FullName + "//" + json._NombreBD.ToString() + ".BD", jsonData);

                }


            }
            catch (Exception) { MessageBox.Show("No se pudo guardar el archivo."); }
        }
       /// <summary>
       /// Funcion que elimina una tabla de la BD
       /// </summary>
       /// <param name="nombreTabla"></param>
        public void EliminaTabla(string nombreTabla)
        {
            File.Delete(SaveD.InitialDirectory + "//" + BaseD._NombreBD + "//" + nombreTabla + ".TB");
        }
       /// <summary>
       /// Funcion que Crea el archivo BD y su carpeta
       /// </summary>
       /// <param name="obj">NOmbre de la BD</param>
       /// <param name="op">Crear con carpeta</param>
        public void CreaArchivo(string obj, int op)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            switch (op)
            {
                case 0:
                    di = Directory.CreateDirectory(obj.ToString());
                    BaseD = new BaseDatos(di.Name);
                    GuardaBase(BaseD);
                    break;

            }


        }
    }
}
