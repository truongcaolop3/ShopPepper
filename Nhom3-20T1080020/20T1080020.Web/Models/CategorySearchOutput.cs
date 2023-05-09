using _20T1080020.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1080020.Web.Models
{
    /// <summary>
    /// Lưu trữ kết quả tìm kiếm, phân trang đối với loại hàng
    /// </summary>
    public class CategorySearchOutput : PaginationOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Category> Data { get; set; }
    }
}