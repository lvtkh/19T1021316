using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _19T1021316.DomainModels;

namespace _19T1021316.Web.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CategorySearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// ddanh sách các category
        /// </summary>
        public List<Category> Data { get; set; }

    }
}