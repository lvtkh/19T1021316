﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19T1021316.DomainModels;
using _19T1021316.BusinessLayers;
using _19T1021316.DataLayers;

namespace _19T1021316.Web.Controllers
{
    public class CustomerController : Controller
    {
        private const int PAGE_SIZE = 5;
        private const string CUSTOMER_SEARCH = "CustomerSearchCondition";

        ///// <summary>
        ///// quản lý khách hàng
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult Index(int page = 1, string searchValue = "")
        //{
        //    int rowCount = 0;
        //    var data = CommonDataService.ListOfCustomers(page, PAGE_SIZE, searchValue, out rowCount);
        //    int pageCount = rowCount / PAGE_SIZE;
        //    if (rowCount % PAGE_SIZE > 0)
        //        rowCount += 1;
        //    ViewBag.Page = page;
        //    ViewBag.RowCount = rowCount;
        //    ViewBag.PageCount = pageCount;
        //    ViewBag.SeachValue = searchValue;
        //    return View(data);
        //}

        public ActionResult Index()
        {
            Models.PaginationSearchInput condition = Session[CUSTOMER_SEARCH] as Models.PaginationSearchInput;
            if (condition == null)
            {
                condition = new Models.PaginationSearchInput()
                {
                    Page = 1,
                    PageSize = PAGE_SIZE,
                    SearchValue = ""
                };
            }

            return View(condition);
        }

        public ActionResult Search(Models.PaginationSearchInput condition)
        {
            int rowCount = 0;
            var data = CommonDataService.ListOfCustomers(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);

            var result = new Models.CustomerSearchOutput()
            {
                Page = condition.Page,
                Pagesize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };

            Session[CUSTOMER_SEARCH] = condition;

            return View(result);
        }



        /// <summary>
        /// Thêm Khách hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.Title = "Bổ sung khách hàng";
            Customer data = new Customer()
            {
                CustomerID = 0
            };

            return View("Edit", data);
        }
        /// <summary>
        /// Sửa Khách hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("Index");

            var data = CommonDataService.GetCustomer(id);

            if (data == null)
                return RedirectToAction("Index");

            ViewBag.Title = "Cập nhật khách hàng";
            return View(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer data)
        {
            if (string.IsNullOrWhiteSpace(data.CustomerName))
                ModelState.AddModelError(nameof(data.CustomerName), "Tên khách hàng không được để trống");
            if (string.IsNullOrWhiteSpace(data.ContactName))
                ModelState.AddModelError(nameof(data.ContactName), "Tên liên lạc không dc để trống");
            if (string.IsNullOrWhiteSpace(data.Country))
                ModelState.AddModelError(nameof(data.Email), "Vui lòng nhập email");
            data.Address = data.Address ?? "";

            data.City = data.City ?? "";
            data.PostalCode = data.PostalCode ?? "";
            data.Country = data.Country ?? "";

            if (!ModelState.IsValid)
            {
                ViewBag.Title = data.CustomerID == 0 ? "Bổ sung khách hàng" : "Cập nhật khách hàng";
                return View("Edit", data);
            }

            if (data.CustomerID == 0)
            {
                CommonDataService.AddGetCustomer(data);
            }
            else
            {
                CommonDataService.UpdateCustomer(data);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Xóa Khách hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id = 0 )
        {
            if (id == 0)
                return RedirectToAction("Index");

            if (Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteCustomer(id);
                return RedirectToAction("Index");
            }
            else
            {
                var data = CommonDataService.GetCustomer(id);
                if (data == null)
                    return RedirectToAction("Index");
                return View(data);
            }
        }
    }
}