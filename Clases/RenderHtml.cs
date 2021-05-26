using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using jsreport.Binary;
using jsreport.Local;
using jsreport.Types;

namespace ReportPdf.Clases
{
    public static class RenderHtml
    {

        public static async Task<Stream>  RenderPdf(string Html)
        {
            var rs = new LocalReporting()
                .UseBinary(JsReportBinary.GetBinary())
                .KillRunningJsReportProcesses()
                .RunInDirectory(Path.Combine(Directory.GetCurrentDirectory(), "jsreport"))
                .Configure(cfg => cfg.CreateSamples()
                    .FileSystemStore()
                    .BaseUrlAsWorkingDirectory())
                .AsUtility()
                .Create();

       //     rs.StartAsync().Wait();
              var report = await rs.RenderAsync(new RenderRequest()
              {
                  Template = new Template()
                  {
                      Recipe = Recipe.ChromePdf,
                      Engine = Engine.None,
                      Content = Html
                  }
              });

              return report.Content;
        }


    }
}
