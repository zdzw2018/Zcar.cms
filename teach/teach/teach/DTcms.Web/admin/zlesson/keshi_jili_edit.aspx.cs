using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.zlesson
{
    public partial class keshi_jili_edit : DTcms.Web.UI.ManagePage
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
            BLL.tb_keshi_jili bll = new BLL.tb_keshi_jili();
            Model.tb_keshi_jili model = bll.GetModel(_id);
            txtTotalBegin.Text = model.total_begin.ToString();
            txtTotalEnd.Text = model.total_end.ToString();
            txtAddWages.Text = model.add_wages.ToString();
            txtDangWei.Text = model.dangwei.ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.tb_keshi_jili model = new Model.tb_keshi_jili();
            BLL.tb_keshi_jili bll = new BLL.tb_keshi_jili();
            model.add_time = DateTime.Now;
            model.total_begin = decimal.Parse(txtTotalBegin.Text.Trim());
            model.total_end = decimal.Parse(txtTotalEnd.Text.Trim());
            model.add_wages = decimal.Parse(txtAddWages.Text.Trim());
            model.dangwei = int.Parse(txtDangWei.Text.Trim());

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
            BLL.tb_keshi_jili bll = new BLL.tb_keshi_jili();
            Model.tb_keshi_jili model = bll.GetModel(_id);
            model.add_time = DateTime.Now;
            model.total_begin = decimal.Parse(txtTotalBegin.Text.Trim());
            model.total_end = decimal.Parse(txtTotalEnd.Text.Trim());
            model.add_wages = decimal.Parse(txtAddWages.Text.Trim());
            model.dangwei = int.Parse(txtDangWei.Text.Trim());
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
                JscriptMsg("修改课时工资成功！", "keshi_jili_list.aspx?channel_id=" + this.channel_id, "Success");
            }
            else //添加
            {

                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加课时工资成功！", "keshi_jili_list.aspx?channel_id=" + this.channel_id, "Success");
            }
        }
    }
}