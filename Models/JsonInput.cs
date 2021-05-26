using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReportPdf.Models
{


    public class TableData
    {
        public int rownum { get; set; }
        public string data1 { get; set; }
        public string data2 { get; set; }
        public string data3 { get; set; }
        public string data4 { get; set; }
        public string data5 { get; set; }
        public string data6 { get; set; }
        public string data7 { get; set; }
        public string data8 { get; set; }
        public string data9 { get; set; }
        public string data10 { get; set; }
        public string Signature { get; set; }
        public int? rownum1 { get; set; }

        [JsonProperty("data1-1")]
        public string Data11 { get; set; }

        [JsonProperty("data2-1")]
        public string Data21 { get; set; }

        [JsonProperty("data3-1")]
        public string Data31 { get; set; }

        [JsonProperty("data4-1")]
        public string Data41 { get; set; }
    }

    public class Table
    {
        public string name { get; set; }
        public List<TableData> tableData { get; set; }
    }

    public class RepeatingData
    {
        public List<Table> tables { get; set; }
    }

    public class SingleData
    {
        public string data11 { get; set; }
        public string data12 { get; set; }
        public string data13 { get; set; }
        public string data14 { get; set; }
    }

    public class InputData
    {
        public RepeatingData repeatingData { get; set; }
        public SingleData singleData { get; set; }
    }

    public class RootJsonInput
    {
        public InputData inputData { get; set; }
    }

}
