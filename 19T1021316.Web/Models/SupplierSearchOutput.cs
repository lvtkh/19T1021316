using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _19T1021316.DomainModels;

namespace _19T1021316.Web.Models
{
    /// <summary>
    /// kết quả tìm kiếm, phân trang của nhà cung cấp
    /// </summary>
    public class SupplierSearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// danh sách các supplier
        /// </summary>
        public List<Supplier> Data { get; set; }
    }
}