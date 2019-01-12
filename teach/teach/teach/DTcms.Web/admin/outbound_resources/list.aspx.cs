using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
namespace DTcms.Web.admin.outbound_resources
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
        protected string zixun = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");
            this.zixun = DTRequest.GetQueryString("zixun");

            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
            this.pageSize = GetPageSize(15); //每页数量
            if (!Page.IsPostBack)
            {

                ChkAdminLevel(channel_id, ActionEnum.View.ToString()); //检查权限
                this.txtZiXunShi.DataSource = new DTcms.BLL.manager().GetList("role_id=14");
                txtZiXunShi.DataTextField = "real_name";
                txtZiXunShi.DataValueField = "id";
                txtZiXunShi.DataBind();
                this.txtZiXunShi.Items.Insert(0,new ListItem("=录入员选择=", ""));
                objectSite.DDLbind(siteConfig.sysgrade, txtGrade, "请选择年级");
                Model.manager model = GetAdminInfo();
                if (model.role_id != 1)
                {
                    this.txtZiXunShi.Visible = false;
                    RptBind("id>0 and user_id=" + model.id + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property, this.zixun), "add_time desc");
                }
                else
                {
                    RptBind("id>0 and xiaoqu="+model.xiaoqu + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property,this.zixun), "add_time desc");
                }
            }
        }


        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _channel_id, int _category_id, string _keywords, string _property,string _zixun)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_channel_id > 0)
            {
                strTemp.Append(" and channel_id=" + channel_id);
            }
            if (!string.IsNullOrEmpty(_property))
            {
                strTemp.Append(" and grade='" + _property + "'");
            }
            if (!string.IsNullOrEmpty(_zixun))
            {
                strTemp.Append(" and user_id=" + _zixun);
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and  stu_name  like '%" + _keywords + "%'");
            }
            return strTemp.ToString();
        }
        #endregion


        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            this.txtGrade.SelectedValue = this.property;
            this.txtZiXunShi.SelectedValue = this.zixun;
            BLL.outbound_resources bll = new BLL.outbound_resources();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&zixun={4}&page={5}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.zixun, "__id__");
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
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}}&zixun={4}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property,this.zixun));
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
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&zixun={4}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.zixun));
        }
        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkAdminLevel1(channel_id, ActionEnum.Delete.ToString())) //检查权限
            {
                JscriptMsg("您没有改项权限，操作失败！", "", "Erorr");
                return;
            }
            BLL.outbound_resources bll = new BLL.outbound_resources();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&zixun={4}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.zixun), "Success");
        }

        //筛选属性
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&zixun={4}",
               this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.txtGrade.SelectedValue,this.txtZiXunShi.SelectedValue));
        }

        /// <summary>
        /// 咨询师筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtZiXunShi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&zixun={4}",
               this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.txtGrade.SelectedValue, this.txtZiXunShi.SelectedValue));

        }
    }
}