using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021316.DomainModels
{
    /// <summary>
    /// Loại hàng
    /// </summary>
    public class Category
    {
        /// <summary>
        /// 
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        public string ParentCategoryld { get; set; }
        public object ParentCategoryId { get; set; }
    }
}
