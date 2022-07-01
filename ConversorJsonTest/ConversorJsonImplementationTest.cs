using ConversorJson;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorJsonTest
{
    public class ConversorJsonImplementationTest
    {
        [Test]
        public void Given_Recived_a_Json_Valid_When_Conversor_call_then_a_xml_valid()
        {
            ///arrange
            ConversorJsonImplementation jsonConversor = new ConversorJsonImplementation();
            string json = @"{
   ""ClientId"":3,
   ""Payment"":1,
   ""Items"":[
       {
           ""ProductId"":3,
           ""Quantity"":5,
           ""UnitPrice"": 10
       },
       {
           ""ProductId"":3,
           ""Quantity"":1,
           ""UnitPrice"": 180
       }
   ]
}";
            string responseExpected = @"<root>
  <ClientId>3</ClientId>
  <Payment>1</Payment>
  <Items>
    <ProductId>3</ProductId>
    <Quantity>5</Quantity>
    <UnitPrice>10</UnitPrice>
  </Items>
  <Items>
    <ProductId>3</ProductId>
    <Quantity>1</Quantity>
    <UnitPrice>180</UnitPrice>
  </Items>
</root>";
            //act

            string xmlResponse = jsonConversor.ConvertJsonInterface(json);

            //assert
            Assert.AreEqual(responseExpected, xmlResponse);


        }


        [Test]
        public void Given_Recived_a_Json_InValid_When_Conversor_call_then_Retunr_ExceptionJson()
        {
            ///arrange
            ConversorJsonImplementation jsonConversor = new ConversorJsonImplementation();
            string json = @"{
   ""ClientId"":3,
   ""Payment"":1,
   ""Items"":[
       {
           ""ProductId"":3,
           ""Quantity"":5,
           ""UnitPrice"": 10
       ,
       {
           ""ProductId"":3,
           ""Quantity"":1,
           ""UnitPrice"": 180
       }
   ]
}";

            //act



            //assert
            Assert.Throws<JsonReaderException>(() => jsonConversor.ConvertJsonInterface(json));


        }


        [Test]
        public void Given_Recived_a_Json_Null_When_Conversor_call_then_Return_null()
        {
            ///arrange
            ConversorJsonImplementation jsonConversor = new ConversorJsonImplementation();
            string json = null;

            //act

            string response = jsonConversor.ConvertJsonInterface(json);

            //assert
            Assert.IsNull(response);


        }
    }
}
