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
    public class ShipperSearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// ddanh sách người giao hàng
        /// </summary>
        public List<Shipper> Data { get; set; }

    }
}