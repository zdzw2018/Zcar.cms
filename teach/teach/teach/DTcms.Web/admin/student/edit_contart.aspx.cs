using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
namespace DTcms.Web.admin.student
{
    public partial class edit_contart : DTcms.Web.UI.ManagePage
    {
        private string action = ActionEnum.Add.ToString(); //操作类型
        private int channel_id;
        private int id = 0;
        private int stu_id = 0;//学员ID
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.stu_id = DTRequest.GetQueryInt("id");
            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
            if (!string.IsNullOrEmpty(_action) && _action == ActionEnum.Edit.ToString())
            {
                this.action = ActionEnum.Edit.ToString();//修改类型
                if (id == 0) { this.id = DTRequest.GetQueryInt("id"); }

                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.student_contract().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            else
            {
                if (!new BLL.student_info().Exists(stu_id))
                {
                    JscriptMsg("学生信息不存在或已被删除！", "list.aspx", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ShowInfo(this.id);
                txtcontract_no.Text = Utils.GetRamCode();
                Model.student_info model = new BLL.student_info().GetModel(this.stu_id);
                txtstuName.Text = model.stu_name;

            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            
            
            //获取合同信息

        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.student_contract model = new Model.student_contract();
            BLL.student_contract bll = new BLL.student_contract();

            model.channel_id = this.channel_id;
            model.add_time = DateTime.Now;
            model.contract_advice_price = decimal.Parse(this.txtcontract_lesson.Text) * Convert.ToDecimal(this.txtcontract_lesson_price.Text.Trim());
            model.contract_advice_price_surplus = Convert.ToDecimal(txtcontract_advice_price_surplus.Text.Trim());
            model.contract_lesson = Convert.ToDecimal(txtcontract_lesson.Text);
            model.contract_lesson_price = Convert.ToDecimal(txtcontract_lesson_price.Text.Trim());
            model.contract_no = txtcontract_no.Text;
            model.contract_status = "1";
            model.contract_remark = txtcontract_remark.Text;
            model.contract_service_price = Convert.ToDecimal(txtcontract_service_price.Text.Trim());
            model.user_id = GetAdminInfo().id;
            model.stu_id = this.stu_id;
            model.xiaoqu = GetAdminInfo().xiaoqu;
            model.give_lesson = decimal.Parse(txtcontract_give_lesson.Text);
            if (bll.Add(model) < 1)
            {
                result = false;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = true;
          
            return true;
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
                JscriptMsg("添加合同成功啦！", "list_contart.aspx?channel_id=" + this.channel_id, "Success");
            }
            else //添加
            {
                ChkAdminLevel(channel_id, ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加合同成功啦！", "list_contart.aspx?channel_id=" + this.channel_id, "Success");
            }
        }
    }
}