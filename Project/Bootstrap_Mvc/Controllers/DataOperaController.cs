using Bootstrap_Mvc.Models;
using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootstrap_Mvc.Controllers
{
    public class DataOperaController : Controller
    {
        // GET: DataOpera
        public ActionResult Index()
        {
            return View();
        }

        #region 数据（分页、搜索）
        /// <summary>
        /// 数据
        /// </summary>
        /// <param name="Condition">查询条件</param>
        /// <param name="order">排序方式</param>
        /// <param name="limit">一页显示多少</param>
        /// <param name="offset">偏移量</param>
        /// <param name="sort">按谁排序</param>
        /// <returns></returns>
        public ActionResult GetList(string Condition, string order = "asc", int limit = 0, int offset = 0, string sort = "UserID")
        {
            try
            {
                TestDataEntities dbContext = new TestDataEntities();
                var tempPersonList = dbContext.User.ToList();
                if (order == "desc" && sort == "UserID")
                {
                    tempPersonList = tempPersonList.OrderByDescending(p => p.UserID).ToList();
                }
                else
                {
                    tempPersonList = tempPersonList.OrderBy(p => p.UserID).ToList();
                }
                if (!string.IsNullOrWhiteSpace(Condition))
                {
                    Condition = Condition.Trim();
                    tempPersonList = tempPersonList.ToList().Where(
                        p => p.UserID.ToString().Contains(Condition) || p.UserName.Contains(Condition)
                    ).ToList();
                }
                var currentPersonList = tempPersonList
                                                 .Skip(offset)
                                                 .Take(limit);

                var total = tempPersonList.Count();
                var rows = currentPersonList;
                return Json(new { total = total, rows = rows, state = true, msg = "加载成功" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { total = 0, rows = 0, state = false, msg = "加载失败" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region 模板下载
        public FileStreamResult ETemplate()
        {
            string fileName = "导入模板.xlsx";//客户端保存的文件名
            string filePath = Server.MapPath("~/Document/导入模板.xlsx");//路径
            return File(new FileStream(filePath, FileMode.Open), "text/plain",
            fileName);
        }
        #endregion

        #region  导入
        /// <summary>
        /// 导入
        /// </summary>
        /// <returns></returns>
        public ActionResult EmployeeExcel()
        {
            try
            {
                HttpPostedFileBase fostFile = Request.Files["EFile"];
                DataTable DepartTable = new DataTable();//获取导入表格
                if (Path.GetExtension(fostFile.FileName) == ".xls")
                {
                    DepartTable = ExeclHelper.XlsExcel(fostFile);
                }
                else if (Path.GetExtension(fostFile.FileName) == ".xlsx")
                {
                    DepartTable = ExeclHelper.XlsxExcel(fostFile);
                }
                else
                {
                    return Json(new { state = false, msg = "文件格式不正确，仅支持.xls和.xlsx结尾的文件！" }, JsonRequestBehavior.AllowGet);
                }
                if (DepartTable.Columns.Count != 6)
                {
                    return Json(new { state = false, msg = "导入格式不正确，请参考导入模板列数！" }, JsonRequestBehavior.AllowGet);
                }
                if (DepartTable.Rows.Count <= 0)
                {
                    return Json(new { state = false, msg = "导入文件中无任何数据！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { state = true, msg = "导入成功" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { state = false, msg = "操作失败", }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}