using Castle.Core.Logging;
using ConversorJson;
using LabMVCTesting.Controllers;
using LabMVCTesting.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabMVCTestingTest
{
    public class HomeControllerTest
    {
        public Mock<ILogger<HomeController>> logger { get; set; }
        public Mock<IConversorJson> conversorJson { get; set; }



       





        [SetUp]
        public void SetUP()
        {
            logger = new Mock<ILogger<HomeController>>();
            conversorJson = new Mock<IConversorJson>();

        }

        [Test]
        public void Given_Json_Valid_When_Call_Controller_Returns_Xml_Valid() 
        {

            //arrange

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
            var httpContext = new DefaultHttpContext();

            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            conversorJson.Setup(x => x.ConvertJsonInterface(json)).Returns(responseExpected);


            HomeController controller = new HomeController(logger.Object, conversorJson.Object)
            {
                TempData = tempData
            };

            //act

            var result = controller.Index(json) as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual(responseExpected, result.TempData["OK"]);

            //assert



        }
    }
}
