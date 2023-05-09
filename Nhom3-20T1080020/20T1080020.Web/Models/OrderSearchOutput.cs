using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _20T1080020.DomainModels;

namespace _20T1080020.Web.Models
{
    public class OrderSearchOutput :PaginationOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Order> Data { get; set; }
    }
}