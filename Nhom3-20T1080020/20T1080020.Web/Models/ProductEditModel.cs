using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _20T1080020.DomainModels;

namespace _20T1080020.Web.Models
{
    public class ProductEditModel
    {
        /// <summary>
        /// lấy ra danh sách mặt hàng
        /// </summary>
        public Product product { get; set; }
        /// <summary>
        /// lấy ra danh sách các thuộc tính của mặt hàng 
        /// </summary>
        public List<ProductAttribute> productAttributes { get; set; }
        /// <summary>
        /// lấy ra danh sách ảnh của mặt hàng
        /// </summary>
        public List<ProductPhoto> productPhotos { get; set; }
    }
}