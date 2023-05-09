using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1080020.Web.Models
{
    /// <summary>
    /// Lớp cơ sở dùng để biểu diex kết quả tìm kiếm dưới dạng phân trang
    /// </summary>
    public abstract class PaginationOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Số dòng mỗi trang
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Giá trị tim kiếm
        /// </summary>
        public string SearchValue { get; set; }
        /// <summary>
        /// Số dòng dữ liệu tìm được 
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PageCount
        {
            get
            {
                if (PageSize == 0)
                    return 1;

                int p = RowCount / PageSize;
                if (RowCount % PageSize > 0)
                    p += 1;
                return p;
            }
        }

    }
}