using Microsoft.AspNetCore.Mvc;
using PayrollSystem;
using PayrollWeb.Models;

namespace PayrollWeb.Controllers
{
    public class CompanyController : Controller
    {
        private IPaySystemService svc;
        //This contructor has an IPaySystemService interface from the Test project
        public CompanyController(IPaySystemService svc)
        {
            this.svc = svc;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {

            //Choose the view
            var comp = svc.GetCompanyDetail(id); //Id may have negative num if doesn't exist
            var model = new CompanyDetailViewModel()
            {
                Id = id,
                TaxId = comp.taxid,
                StreetAddress = comp.address,
                Name = comp.name
            };
            //ViewBag.Name = comp.name;
            //ViewBag.TaxId = comp.taxid;
            //ViewBag.Address = comp.address;
            //ViewBag.Id = id;
            return View(model); 
        }

        public IActionResult SaveDetail(int id, string taxid, string name, string streetAddress) 
        {
            //only need to specify name of View if in same folder
            svc.SaveCompanyDetail(id, taxid, name, streetAddress);
            //validate inbound params
            //Interact with business layer
            return View("Index");
        }
    }
}
