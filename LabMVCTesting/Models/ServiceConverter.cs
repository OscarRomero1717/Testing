using ConversorJson;

namespace LabMVCTesting.Models
{
    public class ServiceConverter
    {

        private IConversorJson _conversorJson;
        public ServiceConverter(IConversorJson conversorJson) 
        {
            _conversorJson = conversorJson;
        }

        public string Convert (string json) 
        {
            try
            {
                return _conversorJson.ConvertJsonInterface(json);
            }
            catch (Exception ex)
            {

                //log  ex

                return null;
            }
           
        
        }

    }
}
