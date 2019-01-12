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
    public partial class score_list  : DTcms.Web.UI.ManagePage
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
                if (new BLL.student_teach().GetList(1, "stu_id=" + user_id + " and lesson=''", "id").Tables[0].Rows.Count>0)
                {
                    lbXueGuan.Text = new BLL.student_teach().GetList(1, "stu_id=" + user_id + " and lesson=''", "id").Tables[0].Rows[0]["manager_name"].ToString();
                }
                else
                {
                    lbXueGuan.Text = "暂无分配";
                }
                lblgrade.Text = model.stu_grade;
                ChkAdminLevel(channel_id, ActionEnum.View.ToString()); //检查权限
                RptBind("id>0" + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property), "add_time desc");

            }


        }

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _channel_id, int _category_id, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.Append(" and stu_id=" + this.user_id);
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

            BLL.student_teach teachbll = new BLL.student_teach();
            this.rpTeach.DataSource = teachbll.GetList(this.pageSize, this.page, "stu_id=" + user_id+" and lesson<>''", "stu_id", out this.totalCount);
            this.rpTeach.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&page={4}",
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

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property));
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
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property));
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
                    bll.Delete(id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property), "Success");
        }

        //批量审核
        protected void btnDelete1_Click(object sender, EventArgs e)
        {
            if (!ChkAdminLevel1(channel_id, ActionEnum.Delete.ToString())) //检查权限
            {
                JscriptMsg("您没有改项权限，操作失败！", "", "Erorr");
                return;
            }
            BLL.student_contract bll_contract = new BLL.student_contract();

            BLL.student_info bll = new BLL.student_info();

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int contract_id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidcontract_id")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    Model.student_contract student_contract = bll_contract.GetModel(contract_id);
                    bll_contract.UpdateField(contract_id, "status=1");
                    bll.UpdateField(id, "stu_lesson=stu_lesson+" + student_contract.contract_lesson);
                }
            }
            JscriptMsg("批量审核成功啦！", Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property), "Success");
        }
    }
}