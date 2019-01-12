using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
namespace DTcms.Web.admin.budget
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
                if (!new BLL.budget().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                txtbudget_date.Text = DateTime.Now.ToString("yyyy-MM");
                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.budget bll = new BLL.budget();
            Model.budget model = bll.GetModel(_id);

            txtremark.Text = model.remark;
            txtbudget_date.Text = model.budget_date.ToString("yyyy-MM-dd");
            txtbudget_price.Text = model.budget_price.ToString("0.00");
            txtbudget_publicity.Text = model.budget_publicity;
           

        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.budget model = new Model.budget();
            BLL.budget bll = new BLL.budget();

            try
            {
                model.add_time = DateTime.Now;
                model.budget_date = Convert.ToDateTime(txtbudget_date.Text);
                model.budget_price = Convert.ToDecimal(txtbudget_price.Text);
                model.budget_publicity = txtbudget_publicity.Text;
                model.user_id = GetAdminInfo().id;
                model.remark = txtremark.Text.Trim();
                model.xiaoqu = GetAdminInfo().xiaoqu;
            }
            catch (Exception ex)
            {
                return false;
            }

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
            BLL.budget bll = new BLL.budget();
            Model.budget model = bll.GetModel(_id);
            try
            {
                model.remark = txtremark.Text;
                model.budget_date = Convert.ToDateTime(txtbudget_date.Text);
                model.budget_price = Convert.ToDecimal(txtbudget_price.Text);
                model.budget_publicity = txtbudget_publicity.Text;
                model.remark = txtremark.Text.Trim();
            }
            catch (Exception ex)
            {
                return false;
            }

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