using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.market
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
                if (!new BLL.market_resource().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {

                this.txtrcollect_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
                objectSite.DDLbind(siteConfig.sysgrade,txtGrade,"");
                objectSite.DDLbind(siteConfig.syscollection, txtrcollect_choose, "");
                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                    
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.market_resource bll = new BLL.market_resource();
            Model.market_resource model = bll.GetModel(_id);

            txtraddr.Text = model.raddr;
            txtrcollect_choose.SelectedValue = model.rcollect_choose;
            txtrcollect_date.Text = model.rcollect_date.ToString("yyyy-MM-dd");
            txtremark.Text = model.remark;

            txtGrade.SelectedValue = model.rgrade;
            txtrschool.Text = model.rschool;

            txtrmarket_man.Text = model.rmarket_man;
            txtrparent_name.Text = model.rparent_name;
            txtrschool.Text = model.rschool;
            txtrstudent_name.Text = model.rstudent_name;
            txttel.Text = model.tel;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.market_resource model = new Model.market_resource();
            BLL.market_resource bll = new BLL.market_resource();
            Model.manager modelMange = GetAdminInfo();

            model.add_time = DateTime.Now;
            model.raddr =txtraddr.Text;
            model.rcollect_choose = txtrcollect_choose.SelectedValue;
            model.rcollect_date = Convert.ToDateTime(txtrcollect_date.Text);
            model.remark = txtremark.Text;
            model.rschool = txtrschool.Text.Trim();
            model.rgrade = txtGrade.SelectedValue;
           
            //model.rgrade = txtrgrade.Text;
            model.rmarket_man = txtrmarket_man.Text;
            model.rparent_name = txtrparent_name.Text;
            model.rschool = txtrschool.Text;
            model.rstudent_name = txtrstudent_name.Text;
            model.tel = txttel.Text;
            model.user_id = modelMange.id;
            model.xiaoqu = modelMange.xiaoqu;
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
            BLL.market_resource bll = new BLL.market_resource();
            Model.market_resource model = bll.GetModel(_id);

            model.raddr = txtraddr.Text;
            model.rcollect_choose = txtrcollect_choose.SelectedValue;
            model.rcollect_date = Convert.ToDateTime(txtrcollect_date.Text);
            model.remark = txtremark.Text;
            model.rschool = txtrschool.Text.Trim();
            model.rgrade = txtGrade.SelectedValue;
            //model.rgrade = txtrgrade.Text;
            model.rmarket_man = txtrmarket_man.Text;
            model.rparent_name = txtrparent_name.Text;
            model.rschool = txtrschool.Text;
            model.rstudent_name = txtrstudent_name.Text;
            model.tel = txttel.Text;

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
                JscriptMsg("修改学生信息成功啦！", "list.aspx?channel_id=" + this.channel_id, "Success");
            }
        }
    }
}