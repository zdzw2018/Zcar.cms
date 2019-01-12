using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.settings
{
    public partial class sysother : DTcms.Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_config", ActionEnum.View.ToString()); //检查权限
                ShowInfo();
            }
        }
        #region 赋值操作=================================
        private void ShowInfo()
        {
            BLL.siteconfig bll = new BLL.siteconfig();
            Model.siteconfig model = bll.loadConfig(Utils.GetXmlMapPath("Configpath"));
            txtsysgrade.Text = model.sysgrade;
            txtsyscollection.Text = model.syscollection;
            txtsysschool.Text = model.sysschool;
                
        }
        #endregion

        /// <summary>
        /// 保存配置信息
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL.siteconfig bll = new BLL.siteconfig();
            Model.siteconfig model = bll.loadConfig(Utils.GetXmlMapPath("Configpath"));
            try
            {
                model.sysgrade = txtsysgrade.Text;
                model.syscollection=txtsyscollection.Text ;
                model.sysschool=txtsysschool.Text ;
                bll.saveConifg(model, Utils.GetXmlMapPath("Configpath"));
                JscriptMsg("修改基础信息成功啦！", "sysother.aspx", "Success");
            }
            catch
            {
                JscriptMsg("文件写入失败，请检查是否有权限！", "", "Error");
            }
        
        }

    }
}