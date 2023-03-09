using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _19T1021316.Web.Models;
using _19T1021316.DomainModels;

namespace _19T1021316.Web.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductSearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Product> Data { get; set; }
        /// <summary>
        ///     Category Id
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        ///     Supplier Id
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        ///     From
        /// </summary>
        public int From => (Page - 1) * Pagesize + 1;

        /// <summary>
        ///     To
        /// </summary>
        public int To => (Page - 1) * Pagesize + Data.Count;
    }


}