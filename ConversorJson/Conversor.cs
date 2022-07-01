using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConversorJson
{
    public class Conversor
    {
        private IConversorJson _conversorJson;
        public Conversor(IConversorJson conversorJson) 
        {
            _conversorJson = conversorJson;
        }
        public string ConvertJson (string jsonConvert) 
        {
           return _conversorJson.ConvertJsonInterface(jsonConvert);
        }



       
    }
}
