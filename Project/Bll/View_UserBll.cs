using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Bll
{
    public class View_UserBll
    {
        #region 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable RETURN_WAYSelect()
        {
            DataTable dt = View_UserDal.RETURN_WAYSelect();
            return dt;
        }
        #endregion
    }
}
