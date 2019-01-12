using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
namespace DTcms.Web.admin.student
{
    public partial class view : DTcms.Web.UI.ManagePage
    {
        private string action = ActionEnum.Add.ToString(); //操作类型
        private int channel_id;
        private int id = 0;
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected Model.student_info model = new Model.student_info();
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
            this.pageSize = GetPageSize(15); //每页数量
            if (!string.IsNullOrEmpty(_action) && _action == ActionEnum.Edit.ToString())
            {
                this.action = ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.student_info().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
                model=new BLL.student_info().GetModel(id);
            }
            if (!IsPostBack)
            {
                this.txt_stu_addr.Text = this.model.stu_addr;
                this.txt_stu_grade.Text = this.model.stu_grade;
                this.txt_stu_lesson.Text = this.model.stu_lesson.ToString();
                this.txt_stu_name.Text = this.model.stu_name;
                this.txt_stu_parent_name.Text = this.model.stu_parent_name;
                this.txt_stu_remark.Text = this.model.stu_remark;
                this.txt_stu_school.Text = this.model.stu_school;
                this.txt_stu_tel.Text = this.model.stu_tel;
                this.RptBind("id>0 and stu_id=" + this.id, "Expr2 desc");

            }
           
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
            Response.Redirect(Utils.CombUrlTxt("view.aspx", "channel_id={0}",
            this.channel_id.ToString()));
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
           
         
            BLL.student_contract bll = new BLL.student_contract();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("view.aspx", "channel_id={0}&page={1}",
                this.channel_id.ToString(), "__id__");
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.model.stu_addr = this.txt_stu_addr.Text;
            this.model.stu_grade = this.txt_stu_grade.Text;
            this.model.stu_lesson = decimal.Parse(this.txt_stu_lesson.Text);
            this.model.stu_name = this.txt_stu_name.Text;
            this.model.stu_parent_name = this.txt_stu_parent_name.Text;
            this.model.stu_remark = this.txt_stu_remark.Text;
            this.model.stu_school = this.txt_stu_school.Text;
            this.model.stu_tel = this.txt_stu_tel.Text;
            try
            {
                new DTcms.BLL.student_info().Update(this.model);
                base.JscriptMsg("修改合同信息成功！", string.Concat(new object[] { "view.aspx?channel_id=", this.channel_id.ToString(), "&id=", this.id, "&action=", this.action }), "Success");
            }
            catch
            {
                base.JscriptMsg("修改合同信息失败！", string.Concat(new object[] { "view.aspx?channel_id=", this.channel_id.ToString(), "&id=", this.id, "&action=", this.action }), "Error");
            }
        }

    }
}