using _20T1080020.BusinessLayers;
using _20T1080020.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20T1080020.Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private const int PAGE_SIZE = 3;
        private const string SESSION_CONDITION = "EmployeeCondition";
        // GET: Employee
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Quản lý nhân viên";

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
        //// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public ActionResult Search(Models.PaginationSearchInput condition) // int Page , int PageSize , string SearchValue
        {
            int rowCount = 0;
            var data = CommonDataService.ListOfEmployees(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);

            Models.EmployeeSearchOutput result = new Models.EmployeeSearchOutput()
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
            var data = new Employee()
            {
                EmployeeID = 0
            };
            ViewBag.Title = "Bổ sung nhân viên";
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
            var data = CommonDataService.GetEmployee(id);
            if (data == null)
                return RedirectToAction("Index");
            ViewBag.Title = "Cập nhật nhân viên";
            return View(data);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Employee data, string Birthday, HttpPostedFileBase uploadPhoto) //string birthday httppostedFileBase uploadphoto
        {
            DateTime? datimeConvert = Converter.DMYStringToDateTime(Birthday);
            // kiểm soát dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(data.FirstName))
                ModelState.AddModelError(nameof(data.FirstName), "Họ đệm không được trống");
            if (string.IsNullOrWhiteSpace(data.LastName))
                ModelState.AddModelError(nameof(data.LastName), "Tên không được trống");
            if (string.IsNullOrWhiteSpace(data.Email))
                ModelState.AddModelError(nameof(data.Email), "Email không được để trống");
            if (string.IsNullOrWhiteSpace(Birthday) || datimeConvert == null)
                ModelState.AddModelError(nameof(data.BirthDate), "*");
            else
            {
                if (datimeConvert.Value < SqlDateTime.MinValue.Value || datimeConvert.Value > SqlDateTime.MaxValue.Value)
                {
                    //ModelState.AddModelError("Birthdate", "ngày tháng năm sinh không hợp lệ");
                    ModelState.AddModelError(nameof(data.BirthDate), "Ngày tháng năm sinh không hợp lệ");
                }
                else
                    data.BirthDate = datimeConvert.Value;
            }


            data.Photo = data.Photo ?? "";
            data.Notes = data.Notes ?? "";

            if (ModelState.IsValid == false)
            {
                ViewBag.Title = data.EmployeeID == 0 ? "Bổ sung nhân viên" : "Cập nhật nhân viên ";
                return View("Edit", data);
            }
            if (uploadPhoto != null)
            {
                string path = Server.MapPath("~/Images/Employees");
                string fileName = $"{DateTime.Now.Ticks}_{uploadPhoto.FileName}";
                string filePath = System.IO.Path.Combine(path, fileName);
                uploadPhoto.SaveAs(filePath);
                data.Photo = $"/Images/Employees/{fileName}";
            }

            if (data.EmployeeID == 0)
            {
                CommonDataService.AddEmployee(data);
            }
            else
            {
                CommonDataService.UpdateEmployee(data);
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
                CommonDataService.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetEmployee(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Title = "Xóa nhân viên";
            return View(data);
        }
    }
}