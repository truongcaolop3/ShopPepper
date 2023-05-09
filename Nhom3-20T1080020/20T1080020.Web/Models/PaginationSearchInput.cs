using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1080020.Web.Models
{
    /// <summary>
    /// Lưu trữ thông tin đầu vào dùng để tìm kiếm phân trang
    /// </summary>
    public class PaginationSearchInput
    {
        /// <summary>
        /// trang cần hiển thị
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Số dòng mỗi trang
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Gá trị tìm kiếm
        /// </summary>
        public string SearchValue { get; set; }
        
    }
}