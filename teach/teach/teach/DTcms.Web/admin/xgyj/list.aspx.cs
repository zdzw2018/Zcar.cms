using DTcms.BLL;
using DTcms.Common;
using DTcms.Web.UI;
using System;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.xgyj
{
    public partial class list : DTcms.Web.UI.ManagePage
    {
        protected int category_id;
        protected int channel_id;
        protected string keywords = string.Empty;
        protected int monthCount;
        protected int page;
        protected int pageSize;
        protected string property = string.Empty;
        protected int totalCount;
        
        protected int yearCount;

        protected string CombSqlTxt(int _channel_id, string _starttime, string _endtime)
        {
            StringBuilder builder = new StringBuilder();
            if (_channel_id > 0)
            {
                builder.Append(" and channel_id=" + this.channel_id);
            }
            return builder.ToString();
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&year={4}&month={5}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue }));
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&year={4}&month={5}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue }));
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
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");
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
            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
            }
            else
            {
                this.pageSize = this.GetPageSize(15);
                if (!this.Page.IsPostBack)
                {
                    base.ChkAdminLevel(this.channel_id, ManagePage.ActionEnum.View.ToString());
                    DTcms.Model.manager model=GetAdminInfo();
                    for (int i = 2016; i <= DateTime.Now.Year+2; i++)
                    {
                        this.ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }
                    if (model.role_id != 1 && model.role_id != 10 && model.role_id != 16)
                    {
                        this.RptBind(string.Concat(new object[] { " DATENAME(year,add_time)=", this.yearCount, " and DATENAME(month,add_time)=", this.monthCount, " and contract_status=1 and audit_stutas=1 and user_id=", model.id }), "user_id", "datepart(year,add_time) , datepart(month,add_time) ,user_id");
                    }
                   
                    else
                    {
                        this.RptBind(string.Concat(new object[] { " DATENAME(year,add_time)=", this.yearCount, " and DATENAME(month,add_time)=", this.monthCount, " and contract_status=1 and audit_stutas=1 and xiaoqu=" ,model.xiaoqu }), "user_id", "datepart(year,add_time) , datepart(month,add_time),user_id");
                    }
                }
            }
        }

        private void RptBind(string _strWhere, string _orderby, string groupBy)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.rptList.DataSource = new student_contract().GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount, groupBy);
            this.rptList.DataBind();
            this.ddlMonth.SelectedValue = this.monthCount.ToString();
            this.ddlYear.SelectedValue = this.yearCount.ToString();
            this.txtPageNum.Text = this.pageSize.ToString();
            string linkUrl = Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&year={4}&month={5}&page={6}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.yearCount.ToString(), this.monthCount.ToString(), "__id__" });
            this.PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, linkUrl, 8);
        }

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int num;
            if (int.TryParse(this.txtPageNum.Text.Trim(), out num) && (num > 0))
            {
                Utils.WriteCookie("student_page_size", num.ToString(), 43200);
            }
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&year={4}&month={5}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.yearCount.ToString(), this.monthCount.ToString() }));
        }
    }
}