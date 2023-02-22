using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19T1021316.DomainModels;
using _19T1021316.BusinessLayers;

namespace _19T1021316.Web
{
    /// <summary>
    /// cung cấp các hàm hỗ trợ để lấy dữ liệu dùng cho DropDownList (Combobox/ Select)
    /// </summary>
    public static class SelectListHelper
    {
        public static List<SelectListItem> Countries()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                //khi tạo ra các giao diện combobox, mỗi phần tử như quốc gia đgl selectlistitem, bản chất như 1 option gồm value là gtri thu2 , text chuỗi hiển thị là gì, selected là tự chọn.

                Value = "",
                Text = "...Chọn quốc gia..."
            });
            foreach (var item in CommonDataService.ListOfCountries())
            {
                list.Add(new SelectListItem()
                {
                    Value = item.CountryName,
                    Text = item.CountryName
                });
            }
            //ASP.net
            return list;
        }
    }
}