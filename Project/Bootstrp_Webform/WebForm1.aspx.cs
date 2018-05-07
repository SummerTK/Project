using Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bootstrp_Webform
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable data = View_UserBll.RETURN_WAYSelect();
            GridView1.DataSource = data;
            GridView1.DataBind();
        }
    }
}