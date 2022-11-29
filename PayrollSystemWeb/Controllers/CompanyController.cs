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

            return View(model); 
        }

        public IActionResult SaveDetail(CompanyDetailViewModel model)
        {   
            //only need to specify name of View if in same folder
            if (ModelState.IsValid)
            {
                svc.SaveCompanyDetail(model.Id, model.TaxId, model.Name, model.StreetAddress);
                //validate inbound params
                //Interact with business layer
                return View("Index");
            }
            ////If model state is not valid, stay on the same view with the same model, which will contain error indications
            else
            {
                return View("Detail", model);
            }
        }

        public IActionResult _cdetailpartial(int id)
        {
            var comp = svc.GetCompanyDetail(id);
            var model = new CompanyDetailViewModel()
            {
                Id = id,
                TaxId = "00-1234567",
                Name = $"{id} - Acme",
                StreetAddress = comp.address
            };
            return PartialView(model);
        }
    }
}
