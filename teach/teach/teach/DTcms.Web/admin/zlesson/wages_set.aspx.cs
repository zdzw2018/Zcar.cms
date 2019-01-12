using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.zlesson
{
    public partial class wages_set : DTcms.Web.UI.ManagePage
    {
        private int id = 0;
        private int channel_id;
        private string action = ActionEnum.Add.ToString(); //操作类型
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            if (!string.IsNullOrEmpty(_action) && _action == ActionEnum.Edit.ToString())
            {
                this.action = ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel(channel_id, ActionEnum.Edit.ToString()); //检查权限
                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.tb_wages_set bll = new BLL.tb_wages_set();
            Model.tb_wages_set model = bll.GetModel(_id);
            txtKeShiBegin.Text = model.keshi_begin.ToString();
            txtKeShiEnd.Text = model.keshi_end.ToString();
            txtWages.Text = model.wages.ToString();
            objectSite.SetChkListValue(cblGrade, model.grade);
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {

            if (cblGrade.SelectedValue == "")
            {
                JscriptMsg("请选择年级！", "", "Error");
                return false;
            }
            bool result = true;
            Model.tb_wages_set model = new Model.tb_wages_set();
            BLL.tb_wages_set bll = new BLL.tb_wages_set();
            model.grade = objectSite.GetChkListValue(cblGrade);
            model.add_time = DateTime.Now;
            model.keshi_begin = decimal.Parse(txtKeShiBegin.Text.Trim());
            model.keshi_end = decimal.Parse(txtKeShiEnd.Text.Trim());
            model.wages = decimal.Parse(txtWages.Text.Trim());

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
            if (cblGrade.SelectedValue == "")
            {
                JscriptMsg("请选择年级！", "", "Error");
                return false;
            }
            bool result = true;
            BLL.tb_wages_set bll = new BLL.tb_wages_set();
            Model.tb_wages_set model = bll.GetModel(_id);
            model.grade = objectSite.GetChkListValue(cblGrade);
            model.add_time = DateTime.Now;
            model.keshi_begin = decimal.Parse(txtKeShiBegin.Text.Trim());
            model.keshi_end = decimal.Parse(txtKeShiEnd.Text.Trim());
            model.wages = decimal.Parse(txtWages.Text.Trim());
            if (!bll.Update(model))
            {
                result = false;
            }
            return result;
        }
        #endregion


        //保存
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
                JscriptMsg("修改课时工资成功！", "wages_set_list.aspx?channel_id=" + this.channel_id , "Success");
            }
            else //添加
            {

                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加课时工资成功！", "wages_set_list.aspx?channel_id=" + this.channel_id, "Success");
            }
        }
    }
}