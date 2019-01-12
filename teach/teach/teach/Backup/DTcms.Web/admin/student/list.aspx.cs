using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
namespace DTcms.Web.admin.student
{
    public partial class list : DTcms.Web.UI.ManagePage
    {
        protected int channel_id;
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int category_id;
        protected string property = string.Empty;
        protected string grade = string.Empty;
        protected string keywords = string.Empty;
        protected string qianyue = string.Empty;
        protected string shaixuan = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");
            this.grade = DTRequest.GetQueryString("grade");
            this.qianyue = DTRequest.GetQueryString("qianyue");
            this.shaixuan = DTRequest.GetQueryString("shaixuan");

            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
            this.pageSize = GetPageSize(15); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel(channel_id, ActionEnum.View.ToString()); //检查权限
                objectSite.DDLbind(siteConfig.sysgrade, ddlGrade, "=请选择年级=");
                this.ddlProperty.DataSource = new DTcms.BLL.manager().GetList("role_id=9 or role_id=15");
                ddlProperty.DataTextField = "real_name";
                ddlProperty.DataValueField = "id";
                ddlProperty.DataBind();
                this.ddlProperty.Items.Insert(0,new ListItem("=咨询师选择=", ""));

                if (GetAdminInfo().role_id != 1 && GetAdminInfo().role_id != 15 && GetAdminInfo().role_id != 16)
                {
                    this.ddlProperty.Visible = false;
                    RptBind("id>0 and user_id=" + GetAdminInfo().id + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property, this.grade, this.qianyue), "Expr2 desc");
                }
                else
                {
                    RptBind("id>0" + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property, this.grade, this.qianyue), "Expr2 desc");
                }
            }
        }


        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _channel_id, int _category_id, string _keywords, string _property,string _grade,string _qianyue)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.Append(" and contract_status=0 ");
            //if (_channel_id > 0)
            //{
            //    strTemp.Append(" and channel_id=" + channel_id);
            //}
            if (!string.IsNullOrEmpty(_property))
            {
                strTemp.Append(" and user_id=" + _property + "");
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                if (shaixuan == "stu")
                {
                    strTemp.Append(" and  stu_name  like '%" + _keywords + "%'");
                }
                else if (shaixuan == "fang")
                {
                    strTemp.Append(" and  stu_tel  like '%" + _keywords + "%'");
                }
                else
                {
                    strTemp.Append(" and  stu_school  like '%" + _keywords + "%'");
                }
            }
            if (!string.IsNullOrEmpty(_grade))
            {
                strTemp.Append(" and  stu_grade='" + _grade + "'");
            }
            if (!string.IsNullOrEmpty(_qianyue))
            {
                strTemp.Append(" and  stu_parent_name='" + _qianyue + "'");
            }
            return strTemp.ToString();
        }
        #endregion

        //筛选属性
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&grade={4}&qianyue={5}&shaixuan={6}",
               this.channel_id.ToString(), this.category_id.ToString(), this.keywords, ddlProperty.SelectedValue,this.ddlGrade.SelectedValue,this.ddlQianYue.SelectedValue,this.ddlShouSou.SelectedValue));
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            this.ddlProperty.SelectedValue = this.property;
            this.ddlGrade.SelectedValue = this.grade;
            this.ddlShouSou.SelectedValue = this.shaixuan;
            BLL.student_contract bll = new BLL.student_contract();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&grade={4}&qianyue={5}&shaixuan={6}&page={7}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.grade,this.qianyue,this.shaixuan, "__id__");
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
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&grade={4}&qianyue={5}&shaixuan={6}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property,this.grade,this.qianyue,this.ddlShouSou.SelectedValue));
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
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&grade={4}&qianyue={5}&shaixuan={6}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.grade,this.qianyue,this.shaixuan));
        }
        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkAdminLevel1(channel_id, ActionEnum.Delete.ToString())) //检查权限
            {
                JscriptMsg("您没有改项权限，操作失败！", "", "Erorr");
                return;
            }
            BLL.student_info bll = new BLL.student_info();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete( id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&grade={4}&qianyue={5}&shaixuan={6}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.grade,this.qianyue,this.shaixuan), "Success");
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&grade={4}&qianyue={5}&shaixuan={6}",
              this.channel_id.ToString(), this.category_id.ToString(), this.keywords, ddlProperty.SelectedValue, this.ddlGrade.SelectedValue,this.ddlQianYue.SelectedValue,this.ddlShouSou.SelectedValue));
        }

        protected void ddlQianYue_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&grade={4}&qianyue={5}&shaixuan={6}",
             this.channel_id.ToString(), this.category_id.ToString(), this.keywords, ddlProperty.SelectedValue, this.ddlGrade.SelectedValue, this.ddlQianYue.SelectedValue,this.ddlShouSou.SelectedValue));
        }
    }
}