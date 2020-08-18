using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace BasesDatos
{
    public class Archivo
    {
        public StreamWriter escribe;
        public StreamReader lee;
        public string nombre_archivo;
        public SaveFileDialog SaveD;
        public OpenFileDialog openFile;
        public FileStream ArchivoFuente;
        public DirectoryInfo di;
        public BaseDatos BaseD;

        public Archivo()
        {
            SaveD = new SaveFileDialog { InitialDirectory = Directory.GetCurrentDirectory() };
            openFile = new OpenFileDialog { InitialDirectory = Directory.GetCurrentDirectory() };
        }

        public bool IntentaAbrir()
        {
            try
            {
                CierraArchivo();

                openFile.Filter = 
                                  "DICCIONARIO|*.BD";

                if (openFile.ShowDialog() == DialogResult.OK)
                {

                    ArchivoFuente = new FileStream(openFile.FileName, FileMode.Open);
                    nombre_archivo = openFile.FileName;
                    return true;
                }
                else
                {
                    MessageBox.Show("Extension incorrecta");
                    nombre_archivo = "";
                    ArchivoFuente = null;
                    return false;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al abri el archivo");
                return false;
            }


        }
        public void CierraArchivo()
        {
            if (ArchivoFuente != null)
            {
                ArchivoFuente.Close();
                ArchivoFuente = null;
            }
            if (escribe != null)
                escribe.Close();

            if (lee != null)
                lee.Close();
        }
        public void GuardarTabla(Tabla json)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            
            try
            {
                string jsonData = js.Serialize(json);
                File.WriteAllText(di.FullName+"//"+json._NombreTabla.ToString()+".TB",jsonData);

            }
            catch (Exception) { MessageBox.Show("No se pudo guardar el archivo."); }
        }


        public void GuardaBase(BaseDatos json) {
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                string jsonData = js.Serialize(json);
                File.WriteAllText(di.FullName + "//" + json._NombreBD.ToString()+".BD", jsonData);

            }
            catch (Exception) { MessageBox.Show("No se pudo guardar el archivo."); }
        }

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
