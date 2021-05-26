using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using ReportPdf.Clases;
using ReportPdf.Models;
using Path = System.IO.Path;

namespace ReportPdf
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async  void OpenFile(object sender, RoutedEventArgs e)
        {
          
                // Step 1 OpenFile
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Filter = "Json (*.json)|*.json;";
                openFileDialog.Multiselect = false;
                openFileDialog.ShowDialog(); if (!File.Exists(openFileDialog.FileName))
                {
                    MessageBox.Show("File  not exists"); return; }


                //Step 2 Read File 
                var file = openFileDialog.FileNames.FirstOrDefault();
                string inputJson = File.ReadAllText(file);


                //Step3 String to Obj
                var Obj =ConvertJsonToObj.DeserializeJson(inputJson);

                //Step 4 Obj to Html 
               var htmlToBeRendered =  ConvertObjToHtml.GenerateHtml(Obj);

               // Write html output just for debug propourses 
               var FilePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "temp");
               Directory.CreateDirectory(FilePath);
               File.WriteAllText(System.IO.Path.Combine(FilePath , "outputhtml.html"), htmlToBeRendered);

               //Generate Pdf
               var PdfStream = await RenderHtml.RenderPdf(htmlToBeRendered);

               //Save to disk 
               var fileStream = new FileStream(Path.Combine(FilePath,"Out.pdf"), FileMode.Create, FileAccess.Write);
               PdfStream.CopyTo(fileStream);
               fileStream.Dispose();


               System.Diagnostics.Process.Start(Path.Combine(FilePath, "Out.pdf"));



        }
    }
}
