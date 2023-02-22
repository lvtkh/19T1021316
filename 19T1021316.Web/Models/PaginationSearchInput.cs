using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021316.Web.Models
{
    /// <summary>
    /// lưu trữ thông tin đầu vào dùng cho tìm kiếm phân trang đơn giản
    /// </summary>
    public class PaginationSearchInput
    {/// <summary>
     /// trang cần hiển thị
     /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// số dòng hiển thị trên mỗi trang
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// giá trị cần tìm
        /// </summary>
        public string SearchValue { get; set; }
    }
}