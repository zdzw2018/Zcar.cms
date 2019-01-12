using DTcms.BLL;
using DTcms.Common;
using DTcms.Web.UI;
using System;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.bmyj
{
    public partial class list : ManagePage
    {
        protected int category_id;
        protected int channel_id;
        protected string keywords = string.Empty;
        protected int monthCount;
        protected int page;
        protected int pageSize;
        protected string property = string.Empty;
        protected int totalCount;
        protected int totalhetong;
        protected double totalnewmoney;
        protected double totalrealmoney;
        protected int yearCount;

        protected string CombSqlTxt(int monthCount, int yearCount)
        {
            StringBuilder builder = new StringBuilder();
            if (monthCount > 0)
            {
                builder.Append(" and datepart(month,add_time)=" + monthCount);
            }
            if (yearCount > 0)
            {
                builder.Append(" and datepart(year,add_time)=" + yearCount);
            }
            return builder.ToString();
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.ddlMonth.SelectedValue, this.ddlYear.SelectedValue }));
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.ddlMonth.SelectedValue, this.ddlYear.SelectedValue }));
        }

        private int GetPageSize(int _default_size)
        {
            int num;
            if (int.TryParse(Utils.GetCookie("student_page_size"), out num) && (num > 0))
            {
                return num;
            }
            return _default_size;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (DTRequest.GetQueryInt("month") != 0)
            {
                this.monthCount = DTRequest.GetQueryInt("month");
            }
            else
            {
                this.monthCount = DateTime.Now.Month;
            }
            if (DTRequest.GetQueryInt("year") != 0)
            {
                this.yearCount = DTRequest.GetQueryInt("year");
            }
            else
            {
                this.yearCount = DateTime.Now.Year;
            }
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");
            if (this.channel_id == 0)
            {
                base.JscriptMsg("频道参数不正确！", "back", "Error");
            }
            else
            {
                this.pageSize = this.GetPageSize(15);
                DTcms.Model.manager model = GetAdminInfo();
                if (!base.IsPostBack)
                {
                    int[] rolestr = new int[] { 1, 10, 16 };
                    base.ChkAdminLevel(this.channel_id, ManagePage.ActionEnum.View.ToString());
                    base.ChkRole(rolestr, base.GetAdminInfo().role_id);
                    for (int i = 2016; i <= DateTime.Now.Year+2; i++)
                    {
                        this.ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }
                    if (model.role_id != 1 && model.role_id != 10 && model.role_id != 16)
                    {
                        this.RptBind("audit_stutas=1 and user_id in(select id from dt_manager where role_id=12 or role_id=10) and contract_status=1 and user_id=" + model.id + this.CombSqlTxt(this.monthCount, this.yearCount), "user_id", "datepart(year,add_time) , datepart(month,add_time) ,user_id");
                    }
                    else
                    {
                        this.RptBind("audit_stutas=1 and user_id in(select id from dt_manager where role_id=12 or role_id=10) and contract_status=1 and xiaoqu=" + model.xiaoqu + "" + this.CombSqlTxt(this.monthCount, this.yearCount), "user_id", "datepart(year,add_time) , datepart(month,add_time) ,user_id");
                    }
                }
            }
        }

        private void RptBind(string _strWhere, string _orderby, string groupBy)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            DataSet set = new student_contract().GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount, groupBy);
            this.rptList.DataSource = set.Tables[0];
            this.ddlYear.SelectedValue = this.yearCount.ToString();
            this.ddlMonth.SelectedValue = this.monthCount.ToString();
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                this.totalnewmoney += double.Parse(set.Tables[0].Rows[i]["newmoney"].ToString());
                this.totalrealmoney += double.Parse(set.Tables[0].Rows[i]["realmoney"].ToString());
                this.totalhetong += int.Parse(set.Tables[0].Rows[i]["hetong"].ToString());
            }
            this.rptList.DataBind();
            this.txtPageNum.Text = this.pageSize.ToString();
            string linkUrl = Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&page={6}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.monthCount.ToString(), this.yearCount.ToString(), "__id__" });
            this.PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, linkUrl, 8);
        }

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int num;
            if (int.TryParse(this.txtPageNum.Text.Trim(), out num) && (num > 0))
            {
                Utils.WriteCookie("student_page_size", num.ToString(), 43200);
            }
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.monthCount.ToString(), this.yearCount.ToString() }));
        }
    }
}