using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021316.Web.Models
{
    /// <summary>
    /// lớp cơ sở cho các lớp dùng để chứa kết quả tìm kiếm dưới dạng phân trang
    /// </summary>
    public abstract class PaginationSearchOutput
    {
        /// <summary>
        /// trang đang đc hiển thị
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// số dòng trên mỗi trang
        /// </summary>
        public int Pagesize { get; set; }
        /// <summary>
        /// Giá trị dạng tìm kiếm
        /// </summary>
        public string SearchValue { get; set; }
        /// <summary>
        /// số dòng dữ liệu tìm được
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        /// tổng số trang
        /// </summary>
        public int PageCount
        {
            get
            {
                if (Pagesize == 0)
                    return 1;
                int p = RowCount / Pagesize;
                if (RowCount % Pagesize > 0)
                    p += 1;
                return p;
            }
        }
    }
}