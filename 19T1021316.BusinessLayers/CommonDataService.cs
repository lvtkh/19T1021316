using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021316.DomainModels;
using _19T1021316.DataLayers;
using System.Configuration;
using _19T1021316.DataLayers.SQL_Server;

namespace _19T1021316.BusinessLayers
{
    /// <summary>
    /// cung cấp các chức năng nghiệp vụ liên quan đến
    /// Quốc gia, Nhà cung cấp, Khách hàng,Loại hàng, Nhân viên, Người giao hàng.
    /// </summary>

    public static class CommonDataService
    {
        private static ICountryDAL countryDB;
        private static ICommonDAL<Supplier> supplierDB;
        private static ICommonDAL<Customer> customerDB;
        private static ICommonDAL<Category> categoryDB;
        private static ICommonDAL<Employee> employeeDB;
        private static ICommonDAL<Shipper> shipperDB;

        /// <summary>
        /// Ctor
        /// </summary>
        static CommonDataService()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            //   countryDB = new DataLayers.FakeDB.CountryDAL();
            countryDB = new DataLayers.SQL_Server.CountryDAL(connectionString);
            supplierDB = new DataLayers.SQL_Server.SupplierDAL(connectionString);
            customerDB = new DataLayers.SQL_Server.CustomerDAL(connectionString);
            categoryDB = new DataLayers.SQL_Server.CategoryDAL(connectionString);
            employeeDB = new DataLayers.SQL_Server.EmployeeDAL(connectionString);
            shipperDB = new DataLayers.SQL_Server.ShipperDAL(connectionString);

        }
        #region chức năng tác nghiệp liên quan đến quốc gia
        /// <summary>
        /// Danh sách các quốc gia
        /// </summary>
        /// <returns></returns>
        public static List<Country> ListOfCountries()
        {
            return countryDB.List().ToList();
        }


        #endregion

        #region chức năng tác nghiệp liên quan đến nhà cung cấp
        /// <summary>
        /// Tìm kiếm và lấy danh sách nhà cung cấp dưới dạng phân trang
        /// </summary>
        /// <param name="page"> trang cần xem</param>
        /// <param name="pageSize"> Số dòng hiển thị trên mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <param name="rowCount">tham số đầu ra: số dòng dữ liệu truy vấn được</param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(int page,
                int pageSize,
                string searchValue,
                out int rowCount)
        {
            rowCount = supplierDB.Count(searchValue);
            return supplierDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Tìm kiếm và lấy danh sách nhà cung cấp (không phân trang)
        /// </summary>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không phân trang)</param>
        /// <returns></returns>

        public static List<Supplier> ListOfSuppliers(string searchValue = "")
        {
            return supplierDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin nhà cung cấp dựa vào mã
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static Supplier GetSupplier(int supplierID)
        {
            return supplierDB.Get(supplierID);
        }
        /// <summary>
        /// Thêm mới nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddGetSupplier(Supplier data)
        {
            return supplierDB.Add(data);
        }
        /// <summary>
        /// Cập nhật nhà cung cấp
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static bool UpdateSupplier(Supplier data)
        {
            return supplierDB.Update(data);
        }
        /// <summary>
        /// Xoá nhà cung cấp dựa vào ID
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static bool DeleteSupplier(int supplierID)
        {
            return supplierDB.Delete(supplierID);
        }
        /// <summary>
        /// Kiểm tra xem nhà cung cấp có dữ liệu liên quan hay không?
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static bool InUserSupplier(int supplierID)
        {
            return supplierDB.InUsed(supplierID);
        }

        #endregion
        #region chức năng tác nghiệp liên quan đến khách hàng
        /// <summary>
        /// Tìm kiếm và lấy danh sách khách hàng dưới dạng phân trang
        /// </summary>
        /// <param name="page"> trang cần xem</param>
        /// <param name="pageSize"> Số dòng hiển thị trên mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Giá trị tìm kiếm(chuỗi rỗng nếu lấy toàn bộ dữ liệu)</param>
        /// <param name="rowCount">tham số đầu ra: số dòng dữ liệu truy vấn được</param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers(int page,
            int pageSize,
            string searchValue,
            out int rowCount)
        {
            rowCount = customerDB.Count(searchValue);
            return customerDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Tìm kiếm và lấy danh sách khách hàng (không phân trang)
        /// </summary>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không phân trang)</param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers(string searchValue = "")
        {
            return customerDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin khách hàng dựa vào mã
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static Customer GetCustomer(int customerID)
        {
            return customerDB.Get(customerID);
        }
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddGetCustomer(Customer data)
        {
            return customerDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCustomer(Customer data)
        {
            return customerDB.Update(data);
        }
        /// <summary>
        /// Xoá khách hàng dựa vào ID
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool DeleteCustomer(int customerID)
        {
            return customerDB.Delete(customerID);
        }
        /// <summary>
        /// Kiểm tra xem khách hàng có dữ liệu liên quan hay không?
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool InUserCustomer(int customerID)
        {
            return customerDB.InUsed(customerID);
        }

        #endregion

        #region chức năng tác nghiệp liên quan đến loaị hàng
        /// <summary>
        /// Tìm kiếm và lấy danh sách loại hàng dưới dạng phân trang
        /// </summary>
        /// <param name="page"> trang cần xem</param>
        /// <param name="pageSize"> Số dòng hiển thị trên mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Giá trị tìm kiếm(chuỗi rỗng nếu lấy toàn bộ dữ liệu)</param>
        /// <param name="rowCount">tham số đầu ra: số dòng dữ liệu truy vấn được</param>
        /// <returns></returns>
        public static List<Category> ListOfCategories(int page,
            int pageSize,
            string searchValue,
            out int rowCount)
        {
            rowCount = categoryDB.Count(searchValue);
            return categoryDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Tìm kiếm và lấy danh sách loại hàng (không phân trang)
        /// </summary>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không phân trang)</param>
        /// <returns></returns>
        public static List<Category> ListOfCategories(string searchValue = "")
        {
            return categoryDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin loại hàng dựa vào mã
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static Category GetCategory(int categoryID)
        {
            return categoryDB.Get(categoryID);
        }
        /// <summary>
        /// Thêm mới loại hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddGetCategory(Category data)
        {
            return categoryDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin loại hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCategory(Category data)
        {
            return categoryDB.Update(data);
        }
        /// <summary>
        /// Xoá loại hàng dựa vào ID
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>

        public static bool DeleteCategory(int categoryID)
        {
            return categoryDB.Delete(categoryID);
        }
        /// <summary>
        /// Kiểm tra xem loại hàng có dữ liệu liên quan hay không?
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static bool InUserCategory(int categoryID)
        {
            return categoryDB.InUsed(categoryID);
        }

        #endregion
        #region chức năng tác nghiệp liên quan đến nhân viên
        /// <summary>
        /// Tìm kiếm và lấy danh sách nhân viên dưới dạng phân trang
        /// </summary>
        /// <param name="page"> trang cần xem</param>
        /// <param name="pageSize"> Số dòng hiển thị trên mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Giá trị tìm kiếm(chuỗi rỗng nếu lấy toàn bộ dữ liệu)</param>
        /// <param name="rowCount">tham số đầu ra: số dòng dữ liệu truy vấn được</param>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees(int page,
            int pageSize,
            string searchValue,
            out int rowCount)
        {
            rowCount = employeeDB.Count(searchValue);
            return employeeDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Tìm kiếm và lấy danh sách nhân viên (không phân trang)
        /// </summary>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không phân trang)</param>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees(string searchValue = "")
        {
            return employeeDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin nhân viên dựa vào mã
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static Employee GetEmployee(int employeeID)
        {
            return employeeDB.Get(employeeID);
        }
        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddGetEmployee(Employee data)
        {
            return employeeDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateEmployee(Employee data)
        {
            return employeeDB.Update(data);
        }
        /// <summary>
        /// Xoá nhân viên dựa vào ID
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>

        public static bool DeleteEmployee(int employeeID)
        {
            return employeeDB.Delete(employeeID);
        }
        /// <summary>
        /// Kiểm tra xem nhân viên có dữ liệu liên quan hay không?
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static bool InUserEmloyee(int employeeID)
        {
            return employeeDB.InUsed(employeeID);
        }

        #endregion

        #region chức năng tác nghiệp liên quan đến người giao hàng
        /// <summary>
        /// Tìm kiếm và lấy danh sách người giao hàng dưới dạng phân trang
        /// </summary>
        /// <param name="page"> trang cần xem</param>
        /// <param name="pageSize"> Số dòng hiển thị trên mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Giá trị tìm kiếm(chuỗi rỗng nếu lấy toàn bộ dữ liệu)</param>
        /// <param name="rowCount">tham số đầu ra: số dòng dữ liệu truy vấn được</param>
        /// <returns></returns>
        public static List<Shipper> ListOfShippers(int page,
            int pageSize,
            string searchValue,
            out int rowCount)
        {
            rowCount = shipperDB.Count(searchValue);
            return shipperDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Tìm kiếm và lấy danh sách người giao hàng(không phân trang)
        /// </summary>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không phân trang)</param>
        /// <returns></returns>
        public static List<Shipper> ListOfShippers(string searchValue = "")
        {
            return shipperDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin người giao hàng dựa vào mã
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static Shipper GetShipper(int shipperID)
        {
            return shipperDB.Get(shipperID);
        }
        /// <summary>
        /// Thêm mới người giao hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddGetShipper(Shipper data)
        {
            return shipperDB.Add(data);
        }
        /// <summary>
        ///  Cập nhật thông tin người giao hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateShipper(Shipper data)
        {
            return shipperDB.Update(data);
        }
        /// <summary>
        /// Xoá người giao hàng dựa vào ID
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static bool DeleteShipper(int shipperID)
        {
            return shipperDB.Delete(shipperID);
        }
        /// <summary>
        /// Kiểm tra xem người giao hàng có dữ liệu liên quan hay không?
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static bool InUserShipper(int shipperID)
        {
            return shipperDB.InUsed(shipperID);
        }

        #endregion
    }
}


