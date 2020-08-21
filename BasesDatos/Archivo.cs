using System;
using System.IO;
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

        public void AbrirBase()
        {
            try
            {
                CierraArchivo();

                openFile.Filter =
                                  "DICCIONARIO|*.BD";

                if (openFile.ShowDialog() == DialogResult.OK)
                {

                    JavaScriptSerializer js = new JavaScriptSerializer();

                    string ruta = File.ReadAllText(openFile.FileName);

                    BaseDatos bas = js.Deserialize<BaseDatos>(ruta);

                    BaseD = bas;
                }
                else
                {
                    MessageBox.Show("Extension incorrecta");

                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);

            }


        }
        public void CierraArchivo()
        {

            if (BaseD != null)
            {
                BaseD = null;
            }
        }
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
        public void EliminaTabla(string nombreTabla)
        {
            File.Delete(SaveD.InitialDirectory + "//" + BaseD._NombreBD + "//" + nombreTabla + ".TB");
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
