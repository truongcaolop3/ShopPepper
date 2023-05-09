using _20T1080020.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1080020.Web.Models
{
    /// <summary>
    /// Lưu trữ kết quả tìm kiếm, phân trang đối với khách hàng
    /// </summary>
    public class CustomerSearchOutput : PaginationOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Customer> Data { get; set; }
    }
}