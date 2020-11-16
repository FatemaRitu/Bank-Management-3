using MVCBank.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVCBank.ViewModels;

namespace MVCBank.Controllers
{
    [HandleError]
    public class CustomerController : Controller
    {
        BankContext db = new BankContext();

        public ActionResult List(string SearchString, string CurrentFilter, string SortOrder, int? page)
        {
            List<CustomerViewModel> userList = db.Customers.Select(u => new CustomerViewModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                DOB = u.DOB,
                Email = u.Email,
                ImageName = u.ImageName,
                ImageUrl = u.ImageUrl
            }).ToList();
            ViewBag.SortNameParam = string.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }
            ViewBag.CurrentFilter = SearchString;

            var list = userList;
            if (!string.IsNullOrEmpty(SearchString))
            {
                list = list.Where(u => u.CustomerName.ToUpper().
                Contains(SearchString.ToUpper())).ToList();
            }
            switch (SortOrder)
            {
                case "name_desc":
                    list = list.OrderByDescending(u => u.CustomerName).ToList();
                    break;
                default:
                    list = list.OrderBy(u => u.CustomerName).ToList();
                    break;
            }
            int PageSize = 3;
            int PageNumber = (page ?? 1);

            return View(list.ToPagedList(PageNumber, PageSize));
        }
        public ActionResult Index(string SearchString, string CurrentFilter, string SortOrder, int? page)
        {
            
            ViewBag.SortNameParam = string.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }
            ViewBag.CurrentFilter = SearchString;
            List<CustomerViewModel> userList = db.Customers.Select(u => new CustomerViewModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                DOB = u.DOB,
                Email = u.Email,
                ImageName = u.ImageName,
                ImageUrl = u.ImageUrl
            }).ToList();
            var list = userList;
            if (!string.IsNullOrEmpty(SearchString))
            {
                list = list.Where(u => u.CustomerName.ToUpper().
                Contains(SearchString.ToUpper())).ToList();
            }
            switch (SortOrder)
            {
                case "name_desc":
                    list = list.OrderByDescending(u => u.CustomerName).ToList();
                    break;
                default:
                    list = list.OrderBy(u => u.CustomerName).ToList();
                    break;
            }
            int PageSize = 3;
            int PageNumber = (page ?? 1);

            return View(list.ToPagedList(PageNumber, PageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer vobj)
        {
            var result = false;
            try
            {
                Customer obj;
                if (vobj.Id == 0)
                {
                    obj = new Customer();
                    obj.FirstName = vobj.FirstName;
                    obj.LastName = vobj.LastName;
                    obj.DOB = vobj.DOB;
                    obj.Email = vobj.Email;
                    string fileName = Path.GetFileNameWithoutExtension(vobj.ImageFile.FileName);
                    string extension = Path.GetExtension(vobj.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    vobj.ImageUrl = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/" + fileName));
                    vobj.ImageFile.SaveAs(fileName);
                    obj.ImageName = vobj.ImageName;
                    obj.ImageUrl = vobj.ImageUrl;
                    db.Customers.Add(obj);
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    obj = db.Customers.SingleOrDefault(u => u.Id == vobj.Id);
                    obj.FirstName = vobj.FirstName;
                    obj.LastName = vobj.LastName;
                    obj.DOB = vobj.DOB;
                    obj.Email = vobj.Email;
                    string fileName = Path.GetFileNameWithoutExtension(vobj.ImageFile.FileName);
                    string extension = Path.GetExtension(vobj.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    vobj.ImageUrl = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/" + fileName));
                    vobj.ImageFile.SaveAs(fileName);
                    obj.ImageName = vobj.ImageName;
                    obj.ImageUrl = vobj.ImageUrl;
                    db.SaveChanges();
                    result = true;

                }
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception )
            {
                throw;
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customer obj = db.Customers.SingleOrDefault(u => u.Id == id);
            CustomerViewModel vobj = new CustomerViewModel();
            vobj.Id = obj.Id;
            vobj.FirstName = obj.FirstName;
            vobj.LastName = obj.LastName;
            vobj.Email = obj.Email;
            vobj.DOB = obj.DOB;
            vobj.ImageName = obj.ImageName;
            vobj.ImageUrl = obj.ImageUrl;
            
            return View(vobj);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Customer obj = db.Customers.SingleOrDefault(u => u.Id == id);
            CustomerViewModel vobj = new CustomerViewModel();
            vobj.FirstName = obj.FirstName;
            vobj.LastName = obj.LastName;
            vobj.Email = obj.Email;
            vobj.DOB = obj.DOB;
            vobj.ImageName = obj.ImageName;
            vobj.ImageUrl = obj.ImageUrl;
            vobj.Id = obj.Id;
            return View(vobj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Customer obj = db.Customers.SingleOrDefault(u => u.Id == id);
            if (obj != null)
            {
                db.Customers.Remove(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }

        }
        public PartialViewResult Details(int id)
        {
            Customer obj = db.Customers.SingleOrDefault(u => u.Id == id);
            CustomerViewModel vobj = new CustomerViewModel();
            vobj.FirstName = obj.FirstName;
            vobj.LastName = obj.LastName;
            vobj.Email = obj.Email;
            vobj.DOB = obj.DOB;
            vobj.ImageName = obj.ImageName;
            vobj.ImageUrl = obj.ImageUrl;
            vobj.Id = obj.Id;
            ViewBag.Details = "Show";
            return PartialView("_CustomerDetails", vobj);
        }
    }
}