using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.contract
{
    public partial class edit : DTcms.Web.UI.ManagePage
    {
        private string action = ActionEnum.Add.ToString(); //操作类型
        protected int channel_id;
        private int id = 0;
        private int stu_id = 0;//学员ID
        private int status = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string queryString = DTRequest.GetQueryString("action");
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.stu_id = DTRequest.GetQueryInt("stu_id");
            if (this.channel_id == 0)
            {
                base.JscriptMsg("频道参数不正确！", "back", "Error");
            }
            else
            {
                if (this.channel_id == 11)
                {
                    this.txtcontract_lesson.ReadOnly = false;
                    this.txtcontract_lesson_price.ReadOnly = false;
                    this.txtcontract_service_price.ReadOnly = false;
                    this.txtcontract_advice_price.ReadOnly = false;
                    this.txtcontract_advice_price_surplus.ReadOnly = false;
                    this.txtcontract_remark.ReadOnly = false;
                }
                if (new BLL.student_contract().Existsbystu_id(this.stu_id, out this.id))
                {
                    queryString = ActionEnum.Edit.ToString();
                }
                if (!string.IsNullOrEmpty(queryString) && (queryString == ActionEnum.Edit.ToString()))
                {
                    this.action = ActionEnum.Edit.ToString();
                    if (this.id == 0)
                    {
                        this.id = DTRequest.GetQueryInt("id");
                    }
                    if (this.id == 0)
                    {
                        base.JscriptMsg("传输参数不正确！", "back", "Error");
                        return;
                    }
                    if (!new BLL.student_contract().Exists(this.id))
                    {
                        base.JscriptMsg("信息不存在或已被删除！", "back", "Error");
                        return;
                    }
                }
                else if (!new BLL.student_info().Exists(this.stu_id))
                {
                    base.JscriptMsg("学生信息不存在或已被删除！", "list.aspx", "Error");
                    return;
                }
                if (!this.Page.IsPostBack)
                {
                    if (this.action == ActionEnum.Edit.ToString())
                    {
                        this.ShowInfo(this.id);
                    }
                    else
                    {
                        this.txtcontract_no.Text = Utils.GetRamCode();
                        Model.student_info model = new BLL.student_info().GetModel(this.stu_id);
                        this.txtstuName.Text = model.stu_name;
                    }
                }
            }

        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.student_contract bll = new BLL.student_contract();
            Model.student_contract model = bll.GetModel(_id);
            Model.student_info model1 = new BLL.student_info().GetModel(model.stu_id);
            this.txtstuName.Text = model1.stu_name;
            this.txtcontract_advice_price.Text = model.contract_advice_price.ToString();
            this.txtcontract_advice_price_surplus.Text = model.contract_advice_price_surplus.ToString();
            this.txtcontract_lesson.Text = model.contract_lesson.ToString();
            this.txtcontract_lesson_price.Text = model.contract_lesson_price.ToString();
            this.txtcontract_no.Text = model.contract_no;
            this.txtaudit_remark.Text = model.audit_remrak;
            this.txtcontract_remark.Text = model.contract_remark;
            this.txtcontract_service_price.Text = model.contract_service_price.ToString();
            this.rblAudit_Stutas.SelectedValue = model.audit_stutas.ToString();
            txtcontract_give_lesson.Text = model.give_lesson.ToString();


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
            model.contract_lesson = Convert.ToInt32(txtcontract_lesson.Text);
            model.contract_lesson_price = Convert.ToDecimal(txtcontract_lesson_price.Text.Trim());
            model.contract_no = txtcontract_no.Text;
            model.contract_remark = txtcontract_remark.Text;
            model.audit_remrak = txtaudit_remark.Text;
            model.contract_service_price = Convert.ToDecimal(txtcontract_service_price.Text.Trim());
            model.user_id = GetAdminInfo().id;
            model.give_lesson = decimal.Parse(txtcontract_give_lesson.Text);
            model.stu_id = this.stu_id;
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

            BLL.student_contract _contract = new BLL.student_contract();
            DTcms.Model.manager adminInfo = GetAdminInfo();
            Model.student_contract model = _contract.GetModel(_id);
            model.contract_advice_price = decimal.Parse(this.txtcontract_lesson.Text) * Convert.ToDecimal(this.txtcontract_lesson_price.Text.Trim());
            model.contract_advice_price_surplus = Convert.ToDecimal(this.txtcontract_advice_price_surplus.Text.Trim());
            model.contract_lesson = decimal.Parse(this.txtcontract_lesson.Text);
            model.contract_lesson_price = Convert.ToDecimal(this.txtcontract_lesson_price.Text.Trim());
            model.contract_no = this.txtcontract_no.Text;
            model.contract_remark = this.txtcontract_remark.Text;
            model.audit_remrak = this.txtaudit_remark.Text;
            model.contract_service_price = Convert.ToDecimal(this.txtcontract_service_price.Text.Trim());
            model.give_lesson = decimal.Parse(txtcontract_give_lesson.Text);
            _contract.Update(model);
            if (this.channel_id != 11)
            {
                _contract.UpdateField(_id, string.Format("audit_user_id={0},audit_date=getdate(),audit_user_name='{1}',audit_remrak='{2}',audit_stutas={3}", new object[] { adminInfo.id, adminInfo.user_name, this.txtaudit_remark.Text, this.rblAudit_Stutas.SelectedValue }));
            }
            Model.student_contract _contract3 = _contract.GetModel(_id);
            if (_contract3.contract_status == "0")
            {
                new BLL.student_info().UpdateField(_contract3.stu_id, "stu_lesson=stu_lesson+" + _contract3.contract_lesson);
            }
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
                JscriptMsg("审核成功啦！", "list_cw.aspx?channel_id=" + this.channel_id, "Success");
            }
            else //添加
            {
                ChkAdminLevel(channel_id, ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加资讯成功啦！", "list_cw.aspx?channel_id=" + this.channel_id, "Success");
            }
        }
    }
}