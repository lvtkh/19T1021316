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
    public class EmployeeController : Controller
    {
        private const int PAGE_SIZE = 5;
        private const string EMPLOYEE_SEARCH = "EmployeeSearchCondition";


        ///// <summary>
        ///// quản lý nhân viên
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult Index(int page = 1, string searchValue = "")
        //{
        //    int rowCount = 0;
        //    var data = CommonDataService.ListOfEmployees(page, PAGE_SIZE, searchValue, out rowCount);
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
            Models.PaginationSearchInput condition = Session[EMPLOYEE_SEARCH] as Models.PaginationSearchInput;
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
            var data = CommonDataService.ListOfEmployees(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);

            var result = new Models.EmployeeSearchOutput()
            {
                Page = condition.Page,
                Pagesize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };

            Session[EMPLOYEE_SEARCH] = condition;

            return View(result);
        }


        /// <summary>
        /// Thêm Nhân viên
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.Title = "Bổ sung nhân viên";
            Employee data = new Employee()
            {
                EmployeeID = 0
            };

            return View("Edit", data);
        }
        /// <summary>
        /// Sửa Nhân viên
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("Index");

            var data = CommonDataService.GetEmployee(id);

            if (data == null)
                return RedirectToAction("Index");

            ViewBag.Title = "Cập nhật nhân viên";
            return View(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Employee data)
        {
            if (string.IsNullOrWhiteSpace(data.FirstName))
                ModelState.AddModelError(nameof(data.FirstName), "Họ đệm không được để trống");
            if (string.IsNullOrWhiteSpace(data.LastName))
                ModelState.AddModelError(nameof(data.LastName), "Tên không được để trống");
            if (string.IsNullOrWhiteSpace(data.BirthDate))
                ModelState.AddModelError(nameof(data.BirthDate), "Ngày sinh không được để trống");
            if (string.IsNullOrWhiteSpace(data.Email))
                ModelState.AddModelError(nameof(data.Email), "Vui lòng nhập email");
            if (string.IsNullOrWhiteSpace(data.Password))
                ModelState.AddModelError(nameof(data.Password), "Vui lòng nhập mật khẩu");

            data.Notes = data.Notes ?? "";
            data.Photo = data.Photo ?? "";

            if (!ModelState.IsValid)
            {
                ViewBag.Title = data.EmployeeID == 0 ? "Bổ sung nhân viên" : "Cập nhật nhân viên";
                return View("Edit", data);
            }

            if (data.EmployeeID == 0)
            {
                CommonDataService.AddGetEmployee(data);
            }
            else
            {
                CommonDataService.UpdateEmployee(data);
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Xóa Nhân viên
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("Index");

            if (Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            else
            {
                var data = CommonDataService.GetEmployee(id);
                if (data == null)
                    return RedirectToAction("Index");
                return View(data);
            }
        }
    }
}