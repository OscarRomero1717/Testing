using ConversorJson;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorJsonTest
{

    public class ConversorTest
    {

        public Mock<IConversorJson> ConversorJsonMock { get; set; }


        [SetUp ]
        public void SetUP() 
        {
            ConversorJsonMock = new Mock<IConversorJson>();

        }

        [Test]
        public void  Given_Recived_a_Json_Valid_When_Conversor_call_then_a_xml_valid() 
        {
            ///arrange
            ///

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

            ConversorJsonMock.Setup(x=> x.ConvertJsonInterface(json)).Returns(responseExpected);


            Conversor jsonConversor = new Conversor(ConversorJsonMock.Object);
          
          
            //act

             string xmlResponse= jsonConversor.ConvertJson(json);

            //assert
            Assert.AreEqual(responseExpected, xmlResponse);


        }


        [Test]
        public void Given_Recived_a_Json_InValid_When_Conversor_call_then_Return_ExceptionJson()
        {
            ///arrange
            
             
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
            ConversorJsonMock.Setup(x => x.ConvertJsonInterface(json)).Throws<JsonReaderException>();
            Conversor jsonConversor = new Conversor(ConversorJsonMock.Object);

            //act



            //assert
            Assert.Throws<JsonReaderException>(()=> jsonConversor.ConvertJson(json));


        }


        [Test]
        public void Given_Recived_a_Json_Null_When_Conversor_call_then_Return_null()
        {
            ///arrange
            ConversorJsonMock.Setup(x => x.ConvertJsonInterface(default)).Returns((string)null);
            Conversor jsonConversor = new Conversor(ConversorJsonMock.Object);
            string json = null;

            //act

            string response= jsonConversor.ConvertJson(json);

            //assert
            Assert.IsNull(response);


        }

    }
}
