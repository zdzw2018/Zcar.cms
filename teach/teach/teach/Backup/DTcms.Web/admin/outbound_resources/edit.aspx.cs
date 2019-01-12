using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
namespace DTcms.Web.admin.outbound_resources
{
    public partial class edit : DTcms.Web.UI.ManagePage
    {
        private string action = ActionEnum.Add.ToString(); //操作类型
        private int channel_id;
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
            if (!string.IsNullOrEmpty(_action) && _action == ActionEnum.Edit.ToString())
            {
                this.action = ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.outbound_resources().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                objectSite.DDLbind(siteConfig.sysgrade, txtGrade, "");
                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.outbound_resources bll = new BLL.outbound_resources();
            Model.outbound_resources model = bll.GetModel(_id);

            txtaddress.Text = model.address;
            txtGrade.SelectedValue = model.grade;
            txtpartent_name.Text = model.partent_name;
            txtschool.Text = model.school;
            txtstu_name.Text = model.stu_name;
            txttel.Text = model.tel;
            txtdate_visit.Text = model.date_visit.ToString();
            txtvisit_content.Text = model.remark;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.outbound_resources model = new Model.outbound_resources();
            BLL.outbound_resources bll = new BLL.outbound_resources();

            try
            {
                model.channel_id = this.channel_id;
                model.address = txtaddress.Text;
                model.grade = txtGrade.SelectedValue;
                model.partent_name = txtpartent_name.Text;
                model.remark = txtvisit_content.Text;
                model.school = txtschool.Text;
                model.user_id = GetAdminInfo().id;
                model.stu_name = txtstu_name.Text;
                model.tel = txttel.Text;
                
                model.date_visit = Convert.ToDateTime(txtdate_visit.Text);
                bll.Add(model);
            }
            catch (Exception)
            {
                return false;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = true;
            BLL.outbound_resources bll = new BLL.outbound_resources();
            Model.outbound_resources model = bll.GetModel(_id);

            model.channel_id = this.channel_id;
            model.address = txtaddress.Text;
            model.grade = txtGrade.SelectedValue;
            model.partent_name = txtpartent_name.Text;
            model.school = txtschool.Text;
            model.user_id = GetAdminInfo().id;
            model.stu_name = txtstu_name.Text;
            model.tel = txttel.Text;
            model.date_visit = Convert.ToDateTime(txtdate_visit.Text);
            model.remark = txtvisit_content.Text;

            if (!bll.Update(model))
            {
                result = false;
            }
            return result;
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel(channel_id, ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改资讯成功啦！", "list.aspx?channel_id=" + this.channel_id, "Success");
            }
            else //添加
            {
                ChkAdminLevel(channel_id, ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加资讯成功啦！", "list.aspx?channel_id=" + this.channel_id, "Success");
            }
        }
    }
}