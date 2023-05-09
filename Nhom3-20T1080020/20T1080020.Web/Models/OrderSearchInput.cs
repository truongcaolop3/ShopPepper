using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1080020.Web.Models
{
    public class OrderSearchInput : PaginationSearchInput
    {
        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; }
    }
}