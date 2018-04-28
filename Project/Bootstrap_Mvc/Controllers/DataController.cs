using Bootstrap_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootstrap_Mvc.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        #region 内置参数
        /// <summary>
        /// 数据
        /// </summary>
        /// <param name="Condition">查询条件</param>
        /// <param name="order">排序方式</param>
        /// <param name="limit">一页显示多少</param>
        /// <param name="offset">偏移量</param>
        /// <param name="sort">按谁排序</param>
        /// <returns></returns>
        public ActionResult Built_inTableGetList(string search, string order = "asc", int limit = 0, int offset = 0, string sort = "表名")
        {
            try
            {
                TestDataEntities dbContext = new TestDataEntities();
                var tempPersonList = dbContext.View_User.ToList();
                if (order == "desc" && sort == "表名")
                {
                    tempPersonList = tempPersonList.OrderByDescending(p => p.表名).ToList();
                }
                else
                {
                    tempPersonList = tempPersonList.OrderBy(p => p.表名).ToList();
                }
                if (!string.IsNullOrWhiteSpace(search))
                {
                    tempPersonList = tempPersonList.ToList().Where(
                        p => p.表名.Contains(search) || p.字段名.Contains(search)
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

        #region 自定义参数
        /// <summary>
        /// 数据
        /// </summary>
        /// <param name="Condition">查询条件</param>
        /// <param name="order">排序方式</param>
        /// <param name="limit">一页显示多少</param>
        /// <param name="offset">偏移量</param>
        /// <param name="sort">按谁排序</param>
        /// <returns></returns>
        public ActionResult CustomizeTableList(string search, int a, int b, string order = "asc", int limit = 0, int offset = 0, string sort = "表名")
        {
            try
            {
                TestDataEntities dbContext = new TestDataEntities();
                var tempPersonList = dbContext.View_User.ToList();
                if (order == "desc" && sort == "表名")
                {
                    tempPersonList = tempPersonList.OrderByDescending(p => p.表名).ToList();
                }
                else
                {
                    tempPersonList = tempPersonList.OrderBy(p => p.表名).ToList();
                }
                if (!string.IsNullOrWhiteSpace(search))
                {
                    tempPersonList = tempPersonList.ToList().Where(
                        p => p.表名.Contains(search) || p.字段名.Contains(search)
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

    }
}