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
    public class CategoryController : Controller
    {
        private const int PAGE_SIZE = 7;
        private const string SESSION_CONDITION = "CategoryCondition";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Quản lý loại hàng";

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
            var data = CommonDataService.ListOfCategories(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);

            Models.CategorySearchOutput result = new Models.CategorySearchOutput()
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
        public ActionResult Create()
        {
            var data = new Category()
            {
                CategoryID = 0
            };
            ViewBag.Title = "Bổ sung loại hàng";
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
            var data = CommonDataService.GetCategory(id);
            if (data == null)
                return RedirectToAction("Index");


            ViewBag.Title = "Cập nhật loại hàng";
            return View(data);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Category data)
        {
            // kiểm soát dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(data.CategoryName))
                ModelState.AddModelError(nameof(data.CategoryName), "Tên không được để trống");
            if (string.IsNullOrWhiteSpace(data.Description))
                ModelState.AddModelError(nameof(data.Description), "Mô tả không được để trống");
            if(ModelState.IsValid == false)
            {
                ViewBag.Title = data.CategoryID == 0 ? "Bổ sung" : "Cập nhật";
                return View("Edit", data);
            }
            if (data.CategoryID == 0)
            {
                CommonDataService.AddCategory(data);
            }
            else
            {
                CommonDataService.UpdateCategory(data);
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
                CommonDataService.DeleteCategory(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetCategory(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Title = "Xóa loại hàng";
            return View(data);
        }
    }
}