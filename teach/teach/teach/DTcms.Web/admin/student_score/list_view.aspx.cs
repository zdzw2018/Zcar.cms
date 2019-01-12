using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.student_score
{
    public partial class list_view : DTcms.Web.UI.ManagePage
    {
        protected int channel_id;
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int category_id;
        protected string property = string.Empty;
        protected string keywords = string.Empty;
        protected int user_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");
            this.user_id = DTRequest.GetQueryInt("user_id");
            BLL.student_info bll = new BLL.student_info();
            if (!bll.Exists(user_id))
            {
                JscriptMsg("信息不存在或已被删除！", "back", "Error");
                return;
            }
            this.pageSize = GetPageSize(15); //每页数量
            if (!Page.IsPostBack)
            {
                Model.student_info model = bll.GetModel(user_id);
                lbluser_name.Text = model.stu_name;
                lblgrade.Text = model.stu_grade;
                ChkAdminLevel(channel_id, ActionEnum.View.ToString()); //检查权限
                RptBind("id>0" + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property), "add_time desc");
            
            }
            
            
        }

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _channel_id, int _category_id, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.Append(" and stu_id="+this.user_id);
            //if (_channel_id > 0)
            //{
            //    strTemp.Append(" and channel_id=" + channel_id);
            //}
            //if (!string.IsNullOrEmpty(_property)) 
            //{
            //    strTemp.Append(" and contract='" + _property + "'");
            //}
            //_keywords = _keywords.Replace("'", "");
            //if (!string.IsNullOrEmpty(_keywords))
            //{
            //    strTemp.Append(" and (stu_parent_name like '%" + _keywords + "%' or stu_name  like '%" + _keywords + "%')");
            //}
            return strTemp.ToString();
        }
        #endregion



        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            //this.ddlProperty.SelectedValue = this.property;
            BLL.student_score bll = new BLL.student_score();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&user_id={4}&page={5}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.user_id.ToString() ,"__id__");
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
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&user_id={4}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property,this.user_id.ToString()));
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
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&user_id={4}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.user_id.ToString()));
        }
       

        

        //批量删除
        protected void shanchu(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            ChkAdminLevel(channel_id, ActionEnum.Delete.ToString()); //检查权限
            BLL.student_score bll = new BLL.student_score();
            string id = linkButton.CommandArgument;
            bll.Delete(int.Parse(id));
            JscriptMsg("删除成功！", (Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&user_id={4}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.user_id.ToString())), "Success");
        }
    }
}