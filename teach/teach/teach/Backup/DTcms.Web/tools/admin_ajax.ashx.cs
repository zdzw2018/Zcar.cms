using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;
using DTcms.Web.UI;
using DTcms.Common;

namespace DTcms.Web.tools
{
    /// <summary>
    /// 管理后台AJAX处理页
    /// </summary>
    public class admin_ajax : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = DTRequest.GetQueryString("action");

            switch (action)
            {
                case "sys_channel_load": //加载频道管理菜单
                    sys_channel_load(context);
                    break;
                case "plugins_nav_load": //加载插件管理菜单
                    plugins_nav_load(context);
                    break;
                case "sys_channel_validate": //验证频道名称是否重复
                    sys_channel_validate(context);
                    break;
                case "sys_model_nav_del": //删除系统模型菜单
                    sys_model_nav_del(context);
                    break;
            }

        }

        #region 加载频道管理菜单================================
        private void sys_channel_load(HttpContext context)
        {
            StringBuilder strTxt = new StringBuilder();
            BLL.sys_channel bll = new BLL.sys_channel();
            DataTable dt = bll.GetList("").Tables[0];
            strTxt.Append("[");
            int i = 1;
            foreach (DataRow dr in dt.Rows)
            {
                Model.manager admin_info = new ManagePage().GetAdminInfo();
                if (!new BLL.manager_role().Exists(admin_info.role_id, Convert.ToInt32(dr["id"]), ManagePage.ActionEnum.View.ToString()))
                {
                    continue;
                }
                BLL.sys_model bll2 = new BLL.sys_model();
                Model.sys_model model2 = bll2.GetModel(Convert.ToInt32(dr["model_id"]));
                strTxt.Append("{");
                strTxt.Append("\"text\":\"" + dr["title"] + "\",");
                strTxt.Append("\"isexpand\":\"false\",");
                strTxt.Append("\"children\":[");
                if (model2.sys_model_navs != null)
                {
                    int j = 1;
                    foreach (Model.sys_model_nav nav in model2.sys_model_navs)
                    {
                        strTxt.Append("{");
                        strTxt.Append("\"text\":\"" + nav.title + "\",");
                        strTxt.Append("\"url\":\"" + nav.nav_url + "?channel_id=" + dr["id"] + "\""); //此处要优化，加上nav.nav_url网站目录标签替换
                        strTxt.Append("}");
                        if (j < model2.sys_model_navs.Count)
                        {
                            strTxt.Append(",");
                        }
                        j++;
                    }
                }
                strTxt.Append("]");
                strTxt.Append("}");
                strTxt.Append(",");
                i++;
            }
            string newTxt = Utils.DelLastChar(strTxt.ToString(), ",") + "]";
            context.Response.Write(newTxt);
            return;
        }
        #endregion

        #region 加载插件管理菜单================================
        private void plugins_nav_load(HttpContext context)
        {
            BLL.plugin bll = new BLL.plugin();
            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath("../plugins/"));
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                Model.plugin aboutInfo = bll.GetInfo(dir.FullName + @"\");
                if (aboutInfo.isload == 1 && File.Exists(dir.FullName + @"\admin\index.aspx"))
                {
                    context.Response.Write("<li><a class=\"l-link\" href=\"javascript:f_addTab('plugin_" + dir.Name
                        + "','" + aboutInfo.name + "','../../plugins/" + dir.Name + "/admin/index.aspx')\">" + aboutInfo.name + "</a></li>\n");
                }
            }
            return;
        }
        #endregion

        #region 验证频道名称是否重复============================
        private void sys_channel_validate(HttpContext context)
        {
            string channelname = DTRequest.GetFormString("channelname");
            string oldname = DTRequest.GetFormString("oldname");
            if (string.IsNullOrEmpty(channelname))
            {
                context.Response.Write("false");
                return;
            }
            //检查是否与站点根目录下的目录同名
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(Utils.GetXmlMapPath("Configpath"));
            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath(siteConfig.webpath));
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                if (channelname.ToLower() == dir.Name)
                {
                    context.Response.Write("false");
                    return;
                }
            }
            //检查是否修改操作
            if (channelname == oldname)
            {
                context.Response.Write("true");
                return;
            }
            //检查Key是否与已存在
            BLL.sys_channel bll = new BLL.sys_channel();
            if (bll.Exists(channelname))
            {
                context.Response.Write("false");
                return;
            }
            context.Response.Write("true");
            return;
        }
        #endregion

        #region 删除系统模型菜单================================
        private void sys_model_nav_del(HttpContext context)
        {
            string _nav_id = context.Request.Form["nav_id"];
            if (string.IsNullOrEmpty(_nav_id))
            {
                context.Response.Write("{msg:0, msgbox:\"对不起，无法获得所要删除的菜单项！\"}");
                return;
            }
            int nav_id;
            if (!int.TryParse(_nav_id, out nav_id))
            {
                context.Response.Write("{msg:0, msgbox:\"对不起，数据在转换过程中发生错误！\"}");
                return;
            }
            BLL.sys_model_nav bll = new BLL.sys_model_nav();
            if (!bll.Exists(nav_id))
            {
                context.Response.Write("{msg:0, msgbox:\"对不起，您所删除的菜单项不存在！\"}");
                return;
            }
            bll.Delete(nav_id);
            context.Response.Write("{msg:1, msgbox:\"删除菜单项成功啦！\"}");
            return;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}