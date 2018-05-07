using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class View_UserDal
    {
        #region 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable RETURN_WAYSelect()
        {
            DataTable dt = new DataTable();
            string CommandText = @" 
                           SELECT * FROM View_User
                              ";
            dt = SQLHelper.GetTable(CommandText);
            return dt;
        }
        #endregion
    }
}
