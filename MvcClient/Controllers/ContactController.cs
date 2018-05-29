using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcClient.Models;
using System.Net.Http;
using PagedList.Mvc;
using PagedList;
namespace MvcClient.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index(string searchBy, string search, int? page, string sortBy)
        {

            IEnumerable<Contact> contList;
            HttpResponseMessage response = ApiHelper.WebApiClient.GetAsync("Contact").Result;
            contList = response.Content.ReadAsAsync<IEnumerable<Contact>>().Result;
            ViewBag.FirstName = String.IsNullOrEmpty(sortBy) ? "FirstName desc" : "";
            ViewBag.PhoneNo = sortBy == "PhoneNo" ? "PhoneNo desc" : "PhoneNo";


            if (searchBy == "PhoneNo")
            {
                contList = contList.Where(x => x.PhoneNo.ToString() == search || search == null || x.PhoneNo.ToString().StartsWith(search)||x.PhoneNo.ToString().Contains(search));
            }
            if (searchBy == "FirstName")
            {
                contList = contList.Where(x => x.FirstName.ToLower().StartsWith(search.ToLower()) || search == null);
            }

            switch (sortBy)
            {
                case "FirstName desc":
                    contList = contList.OrderByDescending(x => x.FirstName);
                    break;
                case "PhoneNo desc":
                    contList = contList.OrderByDescending(x => x.PhoneNo);
                    break;
                case "PhoneNo":
                    contList = contList.OrderBy(x => x.PhoneNo);
                    break;
                default:
                    contList = contList.OrderBy(x => x.FirstName);
                    break;
            }
            return View(contList.ToPagedList(page ?? 1, 4));
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Contact());
            else
            {
                HttpResponseMessage response = ApiHelper.WebApiClient.GetAsync("Contact/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Contact>().Result);
            }
        }










        [HttpPost]
        public ActionResult AddOrEdit(Contact cnt)
        {
            if (ModelState.IsValid)
            {

                if (cnt.Id == 0)
                {
                    HttpResponseMessage response = ApiHelper.WebApiClient.PostAsJsonAsync("Contact", cnt).Result;
                    //TempData["SuccessMessage"] = "Saved Successfully";
                }
                else
                {
                    HttpResponseMessage response = ApiHelper.WebApiClient.PutAsJsonAsync("Contact/" + cnt.Id, cnt).Result;
                    // TempData["SuccessMessage"] = "Updated Successfully";
                }
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }
        }










        public ActionResult Delete(int id)
        {
            Contact contList;
            HttpResponseMessage response = ApiHelper.WebApiClient.GetAsync("Contact/" + id).Result;
            contList = response.Content.ReadAsAsync<Contact>().Result;
            if (response == null)
            {
                return HttpNotFound();
            }
            return View(contList);
        }










        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            HttpResponseMessage response = ApiHelper.WebApiClient.DeleteAsync("Contact/" + id.ToString()).Result;
            //TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
