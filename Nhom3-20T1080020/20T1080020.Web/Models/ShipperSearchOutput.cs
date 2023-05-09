using _20T1080020.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1080020.Web.Models
{
    /// <summary>
    /// Lưu trữ kết quả tìm kiếm, phân trang đối với nhà nhân viên giao hàng
    /// </summary>
    public class ShipperSearchOutput : PaginationOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Shipper> Data { get; set; }
    }
}