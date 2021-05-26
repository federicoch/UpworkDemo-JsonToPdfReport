using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ReportPdf.Models;

namespace ReportPdf.Clases
{
    public static class ConvertObjToHtml
    {
        public static string GenerateHtml(RootJsonInput input)
        {

            string HtmlBase =
                File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Template", "Template1.html"));

            //Get rows for table 1
            HtmlBase = HtmlBase.Replace("{TABLE1_ROWS}", BuildTable1(input));

            //Get Signature for  table 1
            var Signature =
                input.inputData.repeatingData.tables.FirstOrDefault().tableData
                    .Where(p => !string.IsNullOrEmpty(p.Signature)).Select(p => p.Signature).FirstOrDefault();
            HtmlBase = HtmlBase.Replace("{SIGNATURE}", Signature);


            //Get rows for table 1
            HtmlBase = HtmlBase.Replace("{TABLE2_ROWS}", BuildTable2(input));






            return HtmlBase;

        }

        public static string BuildTable1(RootJsonInput input)
        {
            string RowBase = "<tr><th scope='row'>{ROW_NUMBER}</th> <td>{H1}</td> <td>{H2}</td> <td>{H3}</td> <td>{H4}</td> <td>{H5}</td><td>{H6}</td><td>{H7}</td>";
            string TableRows = "";
            var ListTable1Rows = input.inputData.repeatingData.tables[0].tableData;
            int i = 1;
            foreach (var item in ListTable1Rows)
            {
                string aux = RowBase;
                aux = aux.Replace("{ROW_NUMBER}", i.ToString());
                aux = aux.Replace("{H1}", item.data1);
                aux = aux.Replace("{H2}", item.data2);
                aux = aux.Replace("{H3}", item.data3);
                aux = aux.Replace("{H4}", item.data4);
                aux = aux.Replace("{H5}", item.data5);
                aux = aux.Replace("{H6}", item.data6);
                aux = aux.Replace("{H7}", item.data7);
                TableRows += aux;
                i++;
            }

            return TableRows;
        }

        public static string BuildTable2(RootJsonInput input)
        {
            string RowBase = "<tr><th scope='row'>{T1}</th><td>{T2}</td> <td>{T3}</td> </tr>";
            string TableRows = "";
            var ListTable1Rows = input.inputData.repeatingData.tables[1].tableData;
            foreach (var item in ListTable1Rows)
            {
                string aux = RowBase;
                aux = aux.Replace("{T1}", item.Data11);
                aux = aux.Replace("{T2}", item.Data21);
                aux = aux.Replace("{T3}", item.Data31);
           
                TableRows += aux;
            }
            return TableRows;
        }
    }
}
