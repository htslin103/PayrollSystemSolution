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
            var comp = svc.GetAllCompanies(); //Id may have negative num if doesn't exist
            GenericListModel model = new GenericListModel(comp);

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
            var model = new CompanyDetailViewModel(id, comp);
            return PartialView(model);
        }
        /* This section has to do with the Employees */

        public IActionResult Employees()
        {
            var model = new EmployeeDetailModel();
            return View(model);
        }

        public IActionResult SaveEmployeeDetails(EmployeeDetailModel model)
        {
            return RedirectToAction("Employees");
        }

        public IActionResult ManageResources()
        {
            var model = new ManageResourceModel();
            return View(model);
        }

        public IActionResult Hire(ManageResourceModel model)
        {
            return RedirectToAction("ManageResources");
        }

        public IActionResult Terminate(ManageResourceModel model)
        {
            return RedirectToAction("ManageResources");
        }

        public IActionResult _EmployeeDetailPartial(int id)
        {
            var model = new EmployeeDetailModel();
            return PartialView(model);
        }
    }
}