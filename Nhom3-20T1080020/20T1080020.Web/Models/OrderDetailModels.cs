using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _20T1080020.DomainModels;

namespace _20T1080020.Web.Models
{
    public class OrderDetailModels
    {
        
        /// <summary>
        /// Lấy ra thông tin của đơn đặt hàng
        /// </summary>
        public Order Order { get; set; }
        /// <summary>
        /// Lấy ra thông tin chi tiết của đơn đặt hàng
        /// </summary>
        public List<OrderDetail> OrderDetails { get; set; }
    }
}