using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20T1080020.DataLayers;
using _20T1080020.DomainModels;
using System.Configuration;

namespace _20T1080020.BusinessLayers
{
    /// <summary>
    /// Cung caapscacs chức năng nghiệp vụ xử lý dữ liệu chung liên quan đến:
    /// Quốc gia, Nhà cung cấp, khách hàng, Người giao hàng , Nhân viên , Loại hàng.
    /// </summary>
    public static class CommonDataService
    {
        private static readonly ICountryDAL countryDB;
        private static readonly ICommonDAL<Supplier> supplierDB;
        private static readonly ICommonDAL<Category> categoryDB;
        private static readonly ICommonDAL<Customer> customerDB;
        private static readonly ICommonDAL<Employee> employeeDB;
        private static readonly ICommonDAL<Shipper> shipperDB;

        /// <summary>
        /// Actor
        /// </summary>
        static CommonDataService()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            countryDB = new DataLayers.SQLServer.CountryDAL(connectionString);
            supplierDB = new DataLayers.SQLServer.SupplierDAL(connectionString);
            categoryDB = new DataLayers.SQLServer.CategoryDAL(connectionString);
            customerDB = new DataLayers.SQLServer.CustomerDAL(connectionString);
            employeeDB = new DataLayers.SQLServer.EmployeeDAL(connectionString);
            shipperDB = new DataLayers.SQLServer.ShipperDAL(connectionString);
        }

        #region Country
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Country> ListOfCountries()
        {
            return countryDB.List().ToList();
        }


        #endregion

        #region Supplier
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"> trang cần hiển thị</param>
        /// <param name="pageSize">số dòng tren mỗi trang (0 nếu không phân trang</param>
        /// <param name="searchValue"> Giá trị tìm kiếm ( chuỗi rỗng nếu không tìm kiếm</param>
        /// <param name="rowCount"> Tham số đầu raparam>
        /// <returns></returns>
        /// 
        public static List<Supplier> ListOfSuppliers(int page , int pageSize, string searchValue, out int rowCount)
        {
            rowCount  = supplierDB.Count(searchValue);

            return supplierDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(String searchValue = "")
        {
            return supplierDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="suppplierID"></param>
        /// <returns></returns>
        public static Supplier GetSupplier(int suppplierID)
        {
            return supplierDB.Get(suppplierID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddSupplier(Supplier data)
        {
            return supplierDB.Add(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateSupplier(Supplier data)
        {
            return supplierDB.Update(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool DeleteSupplier(int suppplierID)
        {
            return supplierDB.Delete(suppplierID);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public static bool InUsedSupplier(int supplierId)
        {
            return supplierDB.InUsed(supplierId);
        }
        #endregion 

        #region Customer
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"> trang cần hiển thị</param>
        /// <param name="pageSize">số dòng tren mỗi trang (0 nếu không phân trang</param>
        /// <param name="searchValue"> Giá trị tìm kiếm ( chuỗi rỗng nếu không tìm kiếm</param>
        /// <param name="rowCount"> Tham số đầu raparam>
        /// <returns></returns>
        public static List<Customer> ListOfCustomer(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = customerDB.Count(searchValue);

            return customerDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomer(String searchValue = "")
        {
            return customerDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static Customer GetCustomer(int customerID)
        {
            return customerDB.Get(customerID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCustomer(Customer data)
        {
            return customerDB.Add(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCustomer(Customer data)
        {
            return customerDB.Update(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool DeleteCustomer(int customerID)
        {
            return customerDB.Delete(customerID);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool InUsedCustomer(int customerID)
        {
            return customerDB.InUsed(customerID);
        }
        #endregion

        #region Category
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"> trang cần hiển thị</param>
        /// <param name="pageSize">số dòng tren mỗi trang (0 nếu không phân trang</param>
        /// <param name="searchValue"> Giá trị tìm kiếm ( chuỗi rỗng nếu không tìm kiếm</param>
        /// <param name="rowCount"> Tham số đầu raparam>
        /// <returns></returns>
        public static List<Category> ListOfCategories(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = categoryDB.Count(searchValue);

            return categoryDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Category> ListOfCategories(String searchValue = "")
        {
            return categoryDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static Category GetCategory(int categoryID)
        {
            return categoryDB.Get(categoryID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCategory(Category data)
        {
            return categoryDB.Add(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCategory(Category data)
        {
            return categoryDB.Update(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool DeleteCategory(int categoryID)
        {
            return categoryDB.Delete(categoryID);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static bool InUsedCategory(int categoryID)
        {
            return categoryDB.InUsed(categoryID);
        }
        #endregion

        #region  Shipper
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"> trang cần hiển thị</param>
        /// <param name="pageSize">số dòng tren mỗi trang (0 nếu không phân trang</param>
        /// <param name="searchValue"> Giá trị tìm kiếm ( chuỗi rỗng nếu không tìm kiếm</param>
        /// <param name="rowCount"> Tham số đầu raparam>
        /// <returns></returns>
        public static List<Shipper> ListOfShippers(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = shipperDB.Count(searchValue);

            return shipperDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Shipper> ListOfShippers(String searchValue = "")
        {
            return shipperDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipplerID"></param>
        /// <returns></returns>
        public static Shipper GetShipper(int shipplerID)
        {
            return shipperDB.Get(shipplerID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddShipper(Shipper data)
        {
            return shipperDB.Add(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateShipper(Shipper data)
        {
            return shipperDB.Update(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool DeleteShipper(int shipplerID)
        {
            return shipperDB.Delete(shipplerID);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static bool InUsedShipper(int shipperID)
        {
            return shipperDB.InUsed(shipperID);
        }
        #endregion  

        #region  Employee
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"> trang cần hiển thị</param>
        /// <param name="pageSize">số dòng tren mỗi trang (0 nếu không phân trang</param>
        /// <param name="searchValue"> Giá trị tìm kiếm ( chuỗi rỗng nếu không tìm kiếm</param>
        /// <param name="rowCount"> Tham số đầu raparam>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = employeeDB.Count(searchValue);

            return employeeDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees(String searchValue = "")
        {
            return employeeDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static Employee GetEmployee(int employeeID)
        {
            return employeeDB.Get(employeeID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddEmployee(Employee data)
        {
            return employeeDB.Add(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateEmployee(Employee data)
        {
            return employeeDB.Update(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool DeleteEmployee(int employeeID)
        {
            return employeeDB.Delete(employeeID);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static bool InUsedEmployee(int employeeID)
        {
            return employeeDB.InUsed(employeeID);
        }
        #endregion  
    }
}
