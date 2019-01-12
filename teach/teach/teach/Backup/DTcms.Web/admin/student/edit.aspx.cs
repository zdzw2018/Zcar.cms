using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
namespace DTcms.Web.admin.student
{
    public partial class edit : DTcms.Web.UI.ManagePage
    {
        private string action = ActionEnum.Add.ToString(); //操作类型
        protected int channel_id;
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
                if (!new BLL.student_info().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                
                objectSite.DDLbind(siteConfig.sysgrade, txtgrade, "请选择...");
                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        /// <summary>
        ///  获取学生剩余课时数
        /// </summary>
        /// <returns></returns>
        protected decimal getKeShi(int stuid)
        {
            DTcms.BLL.lesson bll = new BLL.lesson();
            return bll.GetLettonCount("stu_id=" + stuid);
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.student_info bll = new BLL.student_info();
            Model.student_info model = bll.GetModel(_id);
            
            txtstu_addr.Text = model.stu_addr;
            txtgrade.SelectedValue = model.stu_grade;
           
            txtstu_name.Text = model.stu_name;
            ddlQianYue.SelectedValue = model.stu_parent_name;
            
            txtstu_remark.Text = model.stu_remark;
            txtstu_school.Text = model.stu_school;
            txtstu_tel.Text = model.stu_tel;
            Model.student_contract model_contract = new BLL.student_contract().GetModelByStu(model.id);
            if (model_contract != null) 
            {
                txtcontract_advice_price.Text = model_contract.contract_advice_price.ToString();
                txtcontract_advice_price_surplus.Text = model_contract.contract_advice_price_surplus.ToString();
                txtcontract_lesson.Text = model_contract.contract_lesson.ToString();
                txtcontract_lesson_price.Text = model_contract.contract_lesson_price.ToString();
                txtcontract_no.Text = model_contract.contract_no;
                txtcontract_remark.Text = model_contract.contract_remark;
                txtcontract_service_price.Text = model_contract.contract_service_price.ToString();
               
                switch (model_contract.audit_stutas) 
                {
                    case 0:
                        lblstutas.Text = "未审核";
                        txtstu_lesson.Text = "0";
                        break;
                    case 1:
                        lblstutas.Text = "审核通过";
                        txtstu_lesson.Text = (model_contract.contract_lesson - getKeShi(model.id)).ToString();
                        break;
                    default:
                        lblstutas.Text = "审核未通过";
                        txtstu_lesson.Text = "0";
                        break;
                }
               
            }
            
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.student_info model = new Model.student_info();
            BLL.student_info bll = new BLL.student_info();
            //学员信息
            model.channel_id = this.channel_id;
            model.stu_addr = txtstu_addr.Text;
            model.stu_grade = txtgrade.SelectedValue;
            model.stu_name = txtstu_name.Text;
            model.stu_parent_name = ddlQianYue.SelectedValue;
            model.stu_remark = txtstu_remark.Text;
            model.stu_school = txtstu_school.Text;
            model.stu_tel = txtstu_tel.Text;
            model.user_id = GetAdminInfo().id;
            model.stu_lesson = Convert.ToInt32(txtcontract_lesson.Text); 

            Model.student_contract model_contract = new Model.student_contract();
            BLL.student_contract bll_contract = new BLL.student_contract();
            model_contract.contract_status = "0";
            model_contract.channel_id = this.channel_id;
            model_contract.add_time = DateTime.Now;
            model_contract.contract_advice_price = Convert.ToInt32(txtcontract_lesson.Text) * Convert.ToDecimal(txtcontract_lesson_price.Text.Trim());
            model_contract.contract_advice_price_surplus = Convert.ToDecimal(txtcontract_advice_price_surplus.Text.Trim());
            model_contract.contract_lesson = Convert.ToInt32(txtcontract_lesson.Text);
            model_contract.contract_lesson_price = Convert.ToDecimal(txtcontract_lesson_price.Text.Trim());
            model_contract.contract_no = Utils.GetRamCode();
            model_contract.contract_remark = txtcontract_remark.Text;
            model_contract.contract_service_price = Convert.ToDecimal(txtcontract_service_price.Text.Trim());
            model_contract.user_id = GetAdminInfo().id;
           



            model.id = bll.Add(model);
            if (model.id > 0)
            {
                model_contract.stu_id = model.id;
                bll_contract.Add(model_contract);
                return result;
            }
            else 
            {
                return false;
            }


            
           
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = true;
            //学员信息
            BLL.student_info bll = new BLL.student_info();
            Model.student_info model = bll.GetModel(_id);
            model.channel_id = channel_id;
            model.stu_addr = txtstu_addr.Text;
            model.stu_grade = txtgrade.SelectedValue;
            model.stu_name = txtstu_name.Text;
            model.stu_parent_name = ddlQianYue.SelectedValue;
            model.stu_remark = txtstu_remark.Text;
            model.stu_school = txtstu_school.Text;
            model.stu_tel = txtstu_tel.Text;
           

            //合同信息
            BLL.student_contract bll_contract = new BLL.student_contract();
            Model.student_contract model_contract = new BLL.student_contract().GetModelByStu(model.id);
            model_contract.channel_id = this.channel_id;
            
          
            model_contract.contract_advice_price = Convert.ToInt32(txtcontract_lesson.Text) * Convert.ToDecimal(txtcontract_lesson_price.Text.Trim());
            model_contract.contract_advice_price_surplus = Convert.ToDecimal(txtcontract_advice_price_surplus.Text.Trim());
            model_contract.contract_lesson = Convert.ToInt32(txtcontract_lesson.Text);
            model.stu_lesson = Convert.ToInt32(txtcontract_lesson.Text); 
            model_contract.contract_lesson_price = Convert.ToDecimal(txtcontract_lesson_price.Text.Trim());
            model_contract.contract_no = txtcontract_no.Text;
            model_contract.contract_remark = txtcontract_remark.Text;
            model_contract.contract_service_price = Convert.ToDecimal(txtcontract_service_price.Text.Trim());
            //model_contract.user_id = GetAdminInfo().id;
            if (model_contract.audit_stutas == 2)//假如审核失败后重新提交那么审核状态会变为未审核
            {
                model_contract.audit_stutas = 0;
            }

            if (!bll.Update(model) || !bll_contract.Update(model_contract))
            {
                result = false;
            }
            return result;
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    ChkAdminLevel(channel_id, ActionEnum.Edit.ToString()); //检查权限
                    if (!DoEdit(this.id))
                    {
                        JscriptMsg("保存过程中发生错误啦！", "", "Error");
                        return;
                    }
                    JscriptMsg("修改学生信息成功啦！", "list.aspx?channel_id=" + this.channel_id, "Success");
                }
                else //添加
                {
                    ChkAdminLevel(channel_id, ActionEnum.Add.ToString()); //检查权限
                    if (!DoAdd())
                    {
                        JscriptMsg("保存过程中发生错误啦！", "", "Error");
                        return;
                    }
                    JscriptMsg("添加学生信息成功啦！", "list.aspx?channel_id=" + this.channel_id, "Success");
                }
            }
            catch (Exception)
            {

                JscriptMsg("保存过程中发生错误啦！", "", "Error");
                return;
            }
           
        }
    }
}