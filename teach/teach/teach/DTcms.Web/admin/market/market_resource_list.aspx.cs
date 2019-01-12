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
        protected int id;
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int user_id;

        protected string property = string.Empty;
        protected string keywords = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("id");
            this.user_id = DTRequest.GetQueryInt("user_id");

            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");
            this.pageSize = GetPageSize(15); //每页数量
            if (!Page.IsPostBack)
            {

                RptBind("id>0" + CombSqlTxt(this.id, this.user_id, this.keywords, this.property), "add_time desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.ddlProperty.SelectedValue = this.property;
            this.txtKeywords.Text = this.keywords;
            BLL.market_resource bll = new BLL.market_resource();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("market_resource_list.aspx", "id={0}&user_id={1}&keywords={2}&property={3}&page={4}",
                 this.keywords, this.property, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int id,int user_id, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (rparent_name like '%" + _keywords + "%' or rstudent_name like '%" + _keywords + "%' or rschool like '%" + _keywords + "%')");
            }
            if (!string.IsNullOrEmpty(_property))
            {
                switch (_property)
                {
                    case "ques":
                        strTemp.Append(" and ques='问卷'");
                        break;
                    case "outfield":
                        strTemp.Append(" and outfield='外场'");
                        break;
                    case "purchase":
                        strTemp.Append(" and purchase='资源购买'");
                        break;
                    case "other":
                        strTemp.Append(" and other='其他'");
                        break;
                }
            }
            return strTemp.ToString();
        }
        #endregion


        #region 返回图文每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("market_resource_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //设置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           // ChkAdminLevel(channel_id, ActionEnum.Edit.ToString()); //检查权限
            int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("hidId")).Value);
            BLL.market_resource bll = new BLL.market_resource();
            Model.market_resource model = bll.GetModel(id);
            //switch (e.CommandName.ToLower())
            //{
            //    case "ibtnmsg":
            //        if (model.is_msg == 1)
            //            bll.UpdateField(id, "is_msg=0");
            //        else
            //            bll.UpdateField(id, "is_msg=1");
            //        break;
            //    case "ibtntop":
            //        if (model.is_top == 1)
            //            bll.UpdateField(id, "is_top=0");
            //        else
            //            bll.UpdateField(id, "is_top=1");
            //        break;
            //    case "ibtnred":
            //        if (model.is_red == 1)
            //            bll.UpdateField(id, "is_red=0");
            //        else
            //            bll.UpdateField(id, "is_red=1");
            //        break;
            //    case "ibtnhot":
            //        if (model.is_hot == 1)
            //            bll.UpdateField(id, "is_hot=0");
            //        else
            //            bll.UpdateField(id, "is_hot=1");
            //        break;
            //    case "ibtnslide":
            //        if (model.is_slide == 1)
            //            bll.UpdateField(id, "is_slide=0");
            //        else
            //            bll.UpdateField(id, "is_slide=1");
            //        break;
            //}
            this.RptBind("id>0" + CombSqlTxt(this.id,this.user_id, this.keywords, this.property), "add_time desc");
        }


        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("market_resource_list.aspx", "id={0}&user_id={1}&keywords={2}&property={3}",
               this.id.ToString(), this.user_id.ToString(), txtKeywords.Text, this.property));
        }


        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("market_resource_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("market_resource_list.aspx", "id={0}&user_id={1}&keywords={2}&property={3}",
                this.id.ToString(), this.user_id.ToString(), this.keywords, this.property));
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            BLL.market_resource bll = new BLL.market_resource();
            Repeater rptList = new Repeater();
           
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "sort_id=" + sortId.ToString());
            }
            JscriptMsg("保存排序成功啦！", Utils.CombUrlTxt("market_resource_list.aspx", "id={0}&user_id={1}&keywords={2}&property={3}",
                this.id.ToString(), this.user_id.ToString(), this.keywords, this.property), "Success");
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
           // ChkAdminLevel(channel_id, ActionEnum.Delete.ToString()); //检查权限
            BLL.market_resource bll = new BLL.market_resource();
            Repeater rptList = new Repeater();
           
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("market_resource_list.aspx", "id={0}&user_id={1}&keywords={2}&property={3}",
                this.id.ToString(), this.user_id.ToString(), this.keywords, this.property), "Success");
        }
    }
}