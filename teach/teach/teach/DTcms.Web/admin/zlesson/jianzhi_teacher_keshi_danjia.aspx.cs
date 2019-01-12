using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.zlesson
{
    public partial class jianzhi_teacher_keshi_danjia : DTcms.Web.UI.ManagePage
    {
       
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int channel_id;
        protected Model.manager model = new Model.manager();

        protected string keywords = string.Empty;
        protected int teacher_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            model = GetAdminInfo();
            this.teacher_id = DTRequest.GetQueryInt("teacher_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.pageSize = GetPageSize(15); //每页数量
            if (!Page.IsPostBack)
            {
                BindJianZhiTeacher();
                if (model.role_id != 1 && model.role_id != 10 && model.role_id != 16)
                {
                    RptBind("id>0  and teacher_id=" + model.id, "add_time desc");
                }

                else
                {
                    RptBind("id>0 and xiaoqu=" + model.xiaoqu  + CombSqlTxt(this.teacher_id, this.keywords), "add_time desc");
                }
            }
        }


        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            this.ddlTeacher.SelectedValue = teacher_id.ToString();
            BLL.tb_jianzhi_teacher_keshi_danjia bll = new BLL.tb_jianzhi_teacher_keshi_danjia();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("jianzhi_teacher_keshi_danjia.aspx", "channel_id={0}&teacher_id={1}&keywords={2}&page={3}",
                this.channel_id.ToString(), this.teacher_id.ToString(),this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
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
                    Utils.WriteCookie("jianzhi_terahcer_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("jianzhi_teacher_keshi_danjia.aspx", "channel_id={0}&teacher_id={1}&keywords={2}",
             this.channel_id.ToString(), this.teacher_id.ToString(), this.keywords));
        }


        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel(channel_id, ActionEnum.Delete.ToString()); //检查权限
            BLL.tb_jianzhi_teacher_keshi_danjia bll = new BLL.tb_jianzhi_teacher_keshi_danjia();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            JscriptMsg("批量删除成功啦！", "jianzhi_teacher_keshi_danjia.aspx?channel_id="+channel_id, "Success");
        }

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("jianzhi_teacher_keshi_danjia.aspx", "channel_id={0}&teacher_id={1}&keywords={2}",
          this.channel_id.ToString(), this.teacher_id.ToString(), txtKeywords.Text.Trim()));
        }

        #region 教师选择
        protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("jianzhi_teacher_keshi_danjia.aspx", "channel_id={0}&teacher_id={1}&keywords={2}",
          this.channel_id.ToString(), this.ddlTeacher.SelectedValue.ToString(), this.keywords));

        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt( int _teacher_id, string _keywords)
        {

            StringBuilder strTemp = new StringBuilder();
            if (!string.IsNullOrEmpty(_keywords))
            {
               
                strTemp.Append(" and  teacher_name  like '%" + _keywords + "%'");
                
            }
            if (_teacher_id > 0)
            {
                strTemp.Append(" and teacher_id=" + teacher_id);
            }
           
            return strTemp.ToString();
        }
        #endregion

        #region 绑定兼职老师
        protected void BindJianZhiTeacher()
        {
            DataTable dt = new BLL.manager().GetList("role_id=11 and is_lock=0 and is_jianzhi=1 and xiaoqu=" + model.xiaoqu).Tables[0];
            this.ddlTeacher.DataSource = dt;
            this.ddlTeacher.DataTextField = "real_name";
            this.ddlTeacher.DataValueField = "id";
            this.ddlTeacher.DataBind();
            this.ddlTeacher.Items.Insert(0, new ListItem("=请选择学教师=", ""));
        }
        #endregion

        #region 返回资讯每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("jianzhi_terahcer_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion
    }
}