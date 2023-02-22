using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021316.DomainModels
{
    /// <summary>
    /// nhà cung cấp
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// ID nhà cung cấp
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// Tên nhà cung cấp
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Tên giao dịch
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Mã bưu chính
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Thành phố ncc
        /// </summary>
        public string City { get; set; }


        /// <summary>
        /// Số điện thoại ncc
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Country { get; set; }
    }
}
