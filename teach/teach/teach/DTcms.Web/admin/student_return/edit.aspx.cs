using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.student_return
{
    public partial class edit : DTcms.Web.UI.ManagePage
    {
        private string action = string.Empty; //操作类型
        private int channel_id;
        private int id = 0;
        private int return_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("id");
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.return_id = DTRequest.GetQueryInt("return_id");
            this.action = DTRequest.GetQueryString("action");
           
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
            Model.manager userInfo = GetAdminInfo();
            Model.student_info stu = new BLL.student_info().GetModel(this.id);
            lblstu_name.Text = stu.stu_name;
            lbluser_name.Text = userInfo.user_name;
            if (!IsPostBack)
            {
                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.return_id);
                }
            }
        }

         #region 赋值操作=================================
        private void ShowInfo(int _rid)
        {
            BLL.student_return bll = new BLL.student_return();
            Model.student_return model = bll.GetModel(_rid);

            txtaudit_remark.Text = model.return_content;
            txtadd_date.Text = model.add_time.ToString("yyyy-MM-dd");
            rblAudit_Stutas.SelectedValue = model.return_result;
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            try
            {
                BLL.student_return bll = new BLL.student_return();
                Model.student_return model = new Model.student_return();
                if (action == ActionEnum.Edit.ToString())//修改
                {
                    model = bll.GetModel(return_id);
                }
              
                Model.manager userInfo = GetAdminInfo();
                Model.student_info stu = new BLL.student_info().GetModel(this.id);
                model.add_time = Convert.ToDateTime(txtadd_date.Text);
                model.return_content = txtaudit_remark.Text;
                model.return_result = rblAudit_Stutas.SelectedValue;
                model.return_user_id = userInfo.id;
                model.return_user_name = userInfo.user_name;
                model.stu_id = this.id;
                model.stu_name = stu.stu_name;
                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    ChkAdminLevel(channel_id, ActionEnum.Edit.ToString()); //检查权限
                    if (bll.Update(model))
                    {
                        JscriptMsg("修改回访记录成功！", "list_view.aspx?channel_id=" + this.channel_id + "&user_id=" + this.id, "Success");
                        return;
                    }
                }
                else
                {
                    if (bll.Add(model) > 0)
                    {
                        JscriptMsg("添加回访记录成功！", "list_view.aspx?channel_id=" + this.channel_id + "&user_id=" + this.id, "Success");
                        return;
                    }
                }
                
            }
            catch (Exception ex)
            {

                JscriptMsg("保存过程中发生错误！", "", "Erorr");
                return;
            }
            
        }
    }
}