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

        public string ConvertJson (string jsonToConvert) 
        {
            if (IsValidJson(jsonToConvert))
            {
                XNode node = JsonConvert.DeserializeXNode(jsonToConvert, "root");
                return node.ToString();
            }
            return null;
            
        }



        private static bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false; }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    throw;
                }
                catch (Exception ex) //some other exception
                {
                    throw;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
