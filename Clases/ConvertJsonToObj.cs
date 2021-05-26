using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ReportPdf.Models;

namespace ReportPdf.Clases
{
    public static class ConvertJsonToObj
    {


        public static RootJsonInput DeserializeJson(string input)
        {
           return  JsonConvert.DeserializeObject<RootJsonInput>(input, GetNewtonSettings());
        }

        private static JsonSerializerSettings GetNewtonSettings()
        {
            JsonSerializerSettings jsonSetting = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                Culture = CultureInfo.InvariantCulture,
                Error = HandleDeserializationError
            };

            return jsonSetting;
        }

        private static void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }
    }
}