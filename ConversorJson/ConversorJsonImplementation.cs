using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace ConversorJson
{
    public class ConversorJsonImplementation : IConversorJson
    {

        public string ConvertJsonInterface(string json)
        {
            if (IsValidJson(json))
            {
                XNode node = JsonConvert.DeserializeXNode(json, "root");
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
