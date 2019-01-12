using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Text;
using System.Data;

namespace DTcms.Web.admin.yeji
{
    public partial class bmlist : DTcms.Web.UI.ManagePage
    {
        protected int channel_id;
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int category_id;
        protected string property = string.Empty;
        protected string keywords = string.Empty;
        protected string starttime = string.Empty;
        protected string endtime = string.Empty;
        protected double totalnewmoney = 0.0;
        protected double totalrealmoney = 0.0;
        protected int totalhetong = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");
            this.starttime = DTRequest.GetQueryString("starttime");
            
            this.endtime = DTRequest.GetQueryString("endtime");

            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
            this.pageSize = GetPageSize(15); //每页数量

            if (!Page.IsPostBack)
            {
                int[] rolestr = new int[] { 1, 15, 16 };
                ChkAdminLevel(channel_id, ActionEnum.View.ToString()); //检查权限
                ChkRole(rolestr, GetAdminInfo().role_id);//检查权限
                if (GetAdminInfo().role_id != 1)
                {
                    if (string.IsNullOrEmpty(endtime))
                    {
                        RptBind("DATENAME(year,add_time)=" + DateTime.Now.Year + " and DATENAME(month,add_time)=" + DateTime.Now.Month + " and contract_status=0 and audit_stutas=1" + CombSqlTxt(channel_id, starttime, endtime), "user_id", "datepart(year,add_time) , datepart(month,add_time) ,user_id");
                    }
                    else
                    {
                        RptBind("audit_stutas=1  and contract_status=0 " + CombSqlTxt(channel_id, starttime, endtime), "user_id", "datepart(year,add_time) , datepart(month,add_time) ,user_id");

                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(endtime))
                    {
                        RptBind("DATENAME(year,add_time)=" + DateTime.Now.Year + " and DATENAME(month,add_time)=" + DateTime.Now.Month + "  and contract_status=0 and audit_stutas=1" + CombSqlTxt(channel_id, starttime, endtime), "user_id", "datepart(year,add_time) , datepart(month,add_time),user_id");
                    }
                    else
                    {
                        RptBind("audit_stutas=1  and contract_status=0 " + CombSqlTxt(channel_id, starttime, endtime), "user_id", "datepart(year,add_time) , datepart(month,add_time),user_id");

                    }
                }
            }
        }


        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _channel_id, string _starttime, string _endtime)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_channel_id > 0)
            {
                strTemp.Append(" and channel_id=" + channel_id);
            }
            if (!string.IsNullOrEmpty(_starttime) && !string.IsNullOrEmpty(_endtime))
            {
                strTemp.Append(" and add_time between '" + _starttime + "' and '" + _endtime + "'");
            }

            return strTemp.ToString();
        }
        #endregion

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("student_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("bmlist.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property));
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby, string groupBy)
        {
            this.page = DTRequest.GetQueryInt("page", 1);

            BLL.student_contract bll = new BLL.student_contract();
            DataSet ds = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount, groupBy);
            this.rptList.DataSource = ds.Tables[0];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                totalnewmoney += double.Parse(ds.Tables[0].Rows[i]["newmoney"].ToString());
                totalrealmoney += double.Parse(ds.Tables[0].Rows[i]["realmoney"].ToString());
                totalhetong += int.Parse(ds.Tables[0].Rows[i]["hetong"].ToString());
            }
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("bmlist.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&page={4}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion


        #region 返回资讯每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("student_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("bmlist.aspx", "channel_id={0}&starttime={1}&endtime={2}",
                this.channel_id.ToString(), txtStartTime.Text.ToString(), txtEndTime.Text.ToString()));

        }
    }
}