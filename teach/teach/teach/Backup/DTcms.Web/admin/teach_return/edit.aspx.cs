using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.teach_return
{
    public partial class edit : DTcms.Web.UI.ManagePage
    {
        private string action = ActionEnum.Add.ToString(); //操作类型
        private int channel_id;
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("id");
            this.channel_id = DTRequest.GetQueryInt("channel_id");
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

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.student_teach_return bll = new BLL.student_teach_return();
                Model.student_teach_return model = new Model.student_teach_return();
                Model.manager userInfo = GetAdminInfo();
                Model.student_info stu = new BLL.student_info().GetModel(this.id);
                model.return_content = txtaudit_remark.Text;
                model.manager_id = userInfo.id;
                model.manager_name = userInfo.real_name;
                model.return_content = txtaudit_remark.Text;
                model.stu_id = this.id;
                model.stu_name = lblstu_name.Text;
                model.return_time = DateTime.Now;
                model.stu_name = lblstu_name.Text;
               
                if (bll.Add(model) > 0)
                {
                    JscriptMsg("添加反馈记录成功！", "list.aspx?channel_id="+this.channel_id+"&user_id="+this.id, "Success");
                    return;
                }
                else
                {
                    JscriptMsg("保存过程中发生错误！", "", "Erorr");
                    return;
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