using _20T1080020.BusinessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _20T1080020.DomainModels;

namespace _20T1080020.Web.Controllers
{
    [Authorize]
    public class ShipperController : Controller
    {
        private const int PAGE_SIZE = 7;
        private const string SESSION_CONDITION = "ShipperCondition";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Quản lý người giao hàng";
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
        public ActionResult Search(Models.PaginationSearchInput condition) // int Page , int PageSize , string SearchValue
        {
            int rowCount = 0;
            var data = CommonDataService.ListOfShippers(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);

            Models.ShipperSearchOutput result = new Models.ShipperSearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };

            Session["SESSION_CONDITION"] = condition;
            return View(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var data = new Shipper()
            {
                ShipperID = 0
            };
            ViewBag.Title = "Bổ sung người giao hàng";
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
            var data = CommonDataService.GetShipper(id);
            if (data == null)
                return RedirectToAction("Index");

            ViewBag.Title = "Cập nhật người giao hàng";
            return View(data);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Shipper data)
        {
            // kiểm soát dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(data.ShipperName))
                ModelState.AddModelError(nameof(data.ShipperName), "Tên không được để trống");
            if (string.IsNullOrWhiteSpace(data.Phone))
                ModelState.AddModelError(nameof(data.Phone), "phone không được để trống");

            if (ModelState.IsValid == false)
            {
                ViewBag.Title = data.ShipperID == 0 ? "Bổ sung người giao hàng " : "Cập nhật người giao hàng ";
                return View("Edit", data);
            }

            if (data.ShipperID == 0)
            {
                CommonDataService.AddShipper(data);
            }
            else
            {
                CommonDataService.UpdateShipper(data);
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
                CommonDataService.DeleteShipper(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetShipper(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Title = "Xóa người giao hàng";
            return View(data);
        }
    }
}