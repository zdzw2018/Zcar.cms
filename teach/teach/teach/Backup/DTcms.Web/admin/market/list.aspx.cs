using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.market
{
    public partial class list : DTcms.Web.UI.ManagePage
    {
        protected int channel_id;
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int category_id;
        protected string property = string.Empty;
        protected string keywords = string.Empty;
        protected string grade = string.Empty;
        protected string school = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");
            this.grade = DTRequest.GetQueryString("grade");
            this.school = DTRequest.GetQueryString("school");
            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
            this.pageSize = GetPageSize(15); //每页数量
            if (!Page.IsPostBack)
            {
                Model.manager model = GetAdminInfo();
                objectSite.DDLbind(siteConfig.syscollection, ddlProperty, "所有途径");
                objectSite.DDLbind(siteConfig.sysgrade, txtGrade, "所有年级");
                ChkAdminLevel(channel_id, ActionEnum.View.ToString()); //检查权限
                if (model.role_id != 1)
                {
                    RptBind("id>0 and user_id=" + model.id + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property, this.school, this.grade), "add_time desc");
                }
                else
                {
                    RptBind("id>0" + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property, this.school, this.grade), "add_time desc");

                }
            }
        }


        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _channel_id, int _category_id, string _keywords, string _property,string _school,string _grade)
        {
            StringBuilder strTemp = new StringBuilder();
            if (!IsAdminLevel("market", ActionEnum.View.ToString()))
            {
                strTemp.Append(" and user_id=" + GetAdminInfo().id);
            }
            if (!string.IsNullOrEmpty(_property)) 
            {
                strTemp.Append(" and rcollect_choose='" + _property + "'");
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (rparent_name like '%" + _keywords + "%' or rstudent_name  like '%" + _keywords + "%')");
            }
            if (!string.IsNullOrEmpty(_school)) {
                strTemp.Append(string.Format(" and rschool ='{0}'",_school));
            }
            if (!string.IsNullOrEmpty(_grade))
            {
                strTemp.Append(string.Format(" and rgrade ='{0}'", _grade));
                txtGrade.SelectedValue = _grade;
            }



            return strTemp.ToString();
        }
        #endregion

        //筛选属性
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&school={4}&grade={5}",
               this.channel_id.ToString(), this.category_id.ToString(), this.keywords, ddlProperty.SelectedValue,school,txtGrade.SelectedValue));
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            this.ddlProperty.SelectedValue = this.property;
            BLL.market_resource bll = new BLL.market_resource();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&page={4}&school={5}&grade={6}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, "__id__",this.school,this.grade);
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

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&school={4}&grade={5}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property,this.school,this.grade));
        }

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
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&school={4}&grade={5}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.school, this.grade));
        }
        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkAdminLevel1(channel_id, ActionEnum.Delete.ToString())) //检查权限
            {
                JscriptMsg("您没有改项权限，操作失败！", "", "Erorr");
                return;
            }
            BLL.market_resource bll = new BLL.market_resource();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete( id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&school={4}&grade={5}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.school, this.grade), "Success");
        }
    }
}