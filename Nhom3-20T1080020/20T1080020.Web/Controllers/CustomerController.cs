using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _20T1080020.DomainModels;
using _20T1080020.BusinessLayers;
namespace _20T1080020.Web.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private const int PAGE_SIZE = 7;
        private const string SESSION_CONDITION = "CustomerCondition";
        // GET: Customer
        public ActionResult Index()
        {
            ViewBag.Title = "Quản lý khách hàng";
            Models.PaginationSearchInput condition
                = Session[SESSION_CONDITION] as Models.PaginationSearchInput;

            if (condition == null)
            {
                condition = new Models.PaginationSearchInput()
                {
                    Page = 1,
                    PageSize = PAGE_SIZE,
                    SearchValue = ""
                };
            }

            return View(condition); // truyền dữ liệu bằng model
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public ActionResult Search(Models.PaginationSearchInput condition)
        {
            int rowCount = 0;
            var data = CommonDataService.ListOfCustomer(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);
            Models.CustomerSearchOutput result = new Models.CustomerSearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };
            Session[SESSION_CONDITION] = condition;

            return View(result);
        }
            public ActionResult Create()
        {
            var data = new Customer()
            {
                CustomerID = 0
            };
            ViewBag.Title = "Bổ sung khách hàng";
            return View("Edit", data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
                return RedirectToAction("Index");
            var data = CommonDataService.GetCustomer(id);
            if (data == null)
                return RedirectToAction("Index");


            ViewBag.Title = "Cập nhật khách hàng";
            return View(data);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Customer data)
        {
            // kiểm soát dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(data.CustomerName))
                ModelState.AddModelError(nameof(data.CustomerName), "Tên không được để trống");
            if (string.IsNullOrWhiteSpace(data.ContactName))
                ModelState.AddModelError(nameof(data.ContactName), "liên hệ không được trống");
            if (string.IsNullOrWhiteSpace(data.Country))
                ModelState.AddModelError(nameof(data.Country), "vui lòng chọn quốc gia");

            data.Address = data.Address ?? "";
            data.Email = data.Email ?? "";
            data.City = data.City ?? "";
            data.PostalCode = data.PostalCode ?? "";

            if (ModelState.IsValid == false)
            {
                ViewBag.Title = data.CustomerID == 0 ? "Bổ sung khách hàng " : "Cập nhật khách hàng ";
                return View("Edit", data);
            }

            if (data.CustomerID == 0)
            {
                CommonDataService.AddCustomer(data);
            }
            else
            {
                CommonDataService.UpdateCustomer(data);
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id = 0)
        {
            if (id <= 0)
                return RedirectToAction("Index");
            if (Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteCustomer(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetCustomer(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Title = "Xóa khách hàng";
            return View(data);
        }
    }
}