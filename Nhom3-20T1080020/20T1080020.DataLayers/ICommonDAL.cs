using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20T1080020.DomainModels;

namespace _20T1080020.DataLayers
{
    /// <summary>
    /// Định nghĩa phép xử lts dữ liệu chung 
    /// </summary>
    public interface ICommonDAL <T> where T : class
    {
        /// <summary>
        /// Tìm kiếm và lấy danh sách dữ liệu dưới dạng phân trang (pagination) 
        /// </summary>
        /// <param name="page"> Trang cần hiển thị </param>
        /// <param name="pageSize">số dòng hiển thị trên mỗi trang(bằng 0 nếu không phân trang) </param>
        /// <param name="searchValue">Giá trị cần tìm (chuỗi rỗng nếu không tìm, tức là truy vẫn toàn bộ dữ liệu ></param>
        /// <returns></returns>
        IList<T> List(int page = 1, int pageSize = 0 , string searchValue = "");
        /// <summary>
        /// đếm số dòng dữ liệu tìm được 
        /// </summary>
        /// <param name="searchValue">Giá trị cần tìm (chuỗi rỗng nếu không tìm, tức là truy vẫn toàn bộ dữ liệu ></param>
        /// <returns></returns>
        int Count(string searchValue = "");
        /// <summary>
        /// lấy 1 dòng dựa vào id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);
        /// <summary>
        /// Bổ sung dữ liệu vào CSDL
        /// </summary>
        /// <param name="data"></param>
        /// <returns> ID của dữ liệu vừa được bổ sung</returns>
        int Add(T data);
        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(T data);
        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// Kiểm tra xem hiện có dữ lieuj khác liên quan đến dữ liệu có mã là id hay không? 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool InUsed(int id);
    }
}
