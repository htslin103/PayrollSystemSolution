using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PayrollSystem;

namespace PayrollWeb.Controllers
{
    [TestClass]
    public class CompanyControllerTest
    {
        private IPaySystemService svc;
        private CompanyController controller;


        //This will be called prior to each individual test, so we can put common methods in here
        [TestInitialize]
        public void TestSetup()
        {
            //This method tests GetDetail for Company Controller 

            //This IpaySystemSerivce interface is what the controller interacts with at the business layer. Mock generates this type for us 
            svc = Mock.Of<IPaySystemService>();

            //Mock.Get gets the actual Mock wrapper for us, and we train the object, tell it what it's supposed to do. Here we tell it how to return data to caller
            Mock.Get(svc).Setup(s => s.GetCompanyDetail(1)).Returns(("123", "Acme", "123 Easy"));
            //Return type here is a tuple

            controller = new CompanyController(svc);
        }

        [TestMethod]
        public void TestCompanyControllerGetDetail()
        {  
            //1 is the primary key of company we want to retrieve     
            var result = controller.Detail(1);
            Mock.Get(svc).Verify(s => s.GetCompanyDetail(1));
        }

        [TestMethod]
        public void TestCompanyControllerSaveDetail()
        {
            var result = controller.SaveDetail(1, "123", "Acme", "123 Easy");
            Mock.Get(svc).Verify(s => s.SaveCompanyDetail(1, "123", "Acme", "123 Easy"));
        }
    }
}
