using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.budget
{
    public partial class report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.budget bll = new BLL.budget();
            this.rptList.DataSource = bll.GetReport("");
            this.rptList.DataBind();
        }
    }
}