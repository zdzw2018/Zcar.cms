using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

namespace DTcms.Web.admin.manager
{
    public partial class role_edit : DTcms.Web.UI.ManagePage
    {
        private string action = ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = Request.QueryString["action"];
            if (!string.IsNullOrEmpty(_action) && _action == ActionEnum.Edit.ToString())
            {
                this.action = ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.manager_role().Exists(this.id))
                {
                    JscriptMsg("角色不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                rptList1.DataSource = GetNavList();
                rptList1.DataBind();
                rptList3.DataSource = new BLL.sys_channel().GetList("");
                rptList3.DataBind();
                RoleBind();
                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.manager_role bll = new BLL.manager_role();
            Model.manager_role model = bll.GetModel(_id);
            txtRoleName.Text = model.role_name;
            ddlRoleType.SelectedValue = model.role_type.ToString();
            //基本设置
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                string navName = ((HiddenField)rptList1.Items[i].FindControl("hidName")).Value;
                string navValue = ((HtmlInputCheckBox)rptList1.Items[i].FindControl("cblNavName")).Value;
                if (model.manager_role_values != null)
                {
                    Model.manager_role_value modelt = model.manager_role_values.Find(p => p.channel_name == navName && p.action_type == navValue);
                    if (modelt != null)
                    {
                        ((HiddenField)rptList1.Items[i].FindControl("hidId")).Value = modelt.id.ToString();
                        ((HtmlInputCheckBox)rptList1.Items[i].FindControl("cblNavName")).Checked = true;
                    }
                }
            }
            //频道设置
            for (int i = 0; i < rptList3.Items.Count; i++)
            {
                int channelId = Convert.ToInt32(((HiddenField)rptList3.Items[i].FindControl("hidChannelId")).Value);
                if (model.manager_role_values != null)
                {
                    Model.manager_role_value modelt1 = model.manager_role_values.Find(p => p.channel_id == channelId && p.action_type == ActionEnum.View.ToString());
                    if (modelt1 != null)
                    {
                        ((HiddenField)rptList3.Items[i].FindControl("hidViewId")).Value = modelt1.id.ToString();
                        ((HtmlInputCheckBox)rptList3.Items[i].FindControl("cbView")).Checked = true;
                    }
                    Model.manager_role_value modelt2 = model.manager_role_values.Find(p => p.channel_id == channelId && p.action_type == ActionEnum.Add.ToString());
                    if (modelt2 != null)
                    {
                        ((HiddenField)rptList3.Items[i].FindControl("hidAddId")).Value = modelt2.id.ToString();
                        ((HtmlInputCheckBox)rptList3.Items[i].FindControl("cbAdd")).Checked = true;
                    }
                    Model.manager_role_value modelt3 = model.manager_role_values.Find(p => p.channel_id == channelId && p.action_type == ActionEnum.Edit.ToString());
                    if (modelt3 != null)
                    {
                        ((HiddenField)rptList3.Items[i].FindControl("hidEditId")).Value = modelt3.id.ToString();
                        ((HtmlInputCheckBox)rptList3.Items[i].FindControl("cbEdit")).Checked = true;
                    }
                    Model.manager_role_value modelt4 = model.manager_role_values.Find(p => p.channel_id == channelId && p.action_type == ActionEnum.Delete.ToString());
                    if (modelt4 != null)
                    {
                        ((HiddenField)rptList3.Items[i].FindControl("hidDeleteId")).Value = modelt4.id.ToString();
                        ((HtmlInputCheckBox)rptList3.Items[i].FindControl("cbDelete")).Checked = true;
                    }
                }
            }
        }
        #endregion

        #region 角色类型=================================
        private void RoleBind()
        {
            Model.manager model = GetAdminInfo();
            ddlRoleType.Items.Clear();
            ddlRoleType.Items.Add(new ListItem("请选择类型...", ""));
            if (model.role_type < 2)
            {
                ddlRoleType.Items.Add(new ListItem("超级用户", "1"));
            }
            ddlRoleType.Items.Add(new ListItem("系统用户", "2"));
        }
        #endregion

        #region 系统菜单=================================
        /// <summary>
        /// 系统置菜单
        /// </summary>
        private DataTable GetNavList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", Type.GetType("System.String"));
            dt.Columns.Add("value", Type.GetType("System.String"));
            dt.Columns.Add("text", Type.GetType("System.String"));

            dt.Rows.Add("sys_config", ActionEnum.View.ToString(), "查看系统配置");
            dt.Rows.Add("sys_config", ActionEnum.Edit.ToString(), "修改系统配置");
            dt.Rows.Add("sys_model", ActionEnum.View.ToString(), "查看模型配置");
            dt.Rows.Add("sys_model", ActionEnum.Add.ToString(), "添加模型配置");
            dt.Rows.Add("sys_model", ActionEnum.Edit.ToString(), "修改模型配置");
            dt.Rows.Add("sys_model", ActionEnum.Delete.ToString(), "删除模型配置");
            dt.Rows.Add("sys_channel", ActionEnum.View.ToString(), "查看频道配置");
            dt.Rows.Add("sys_channel", ActionEnum.Add.ToString(), "添加频道配置");
            dt.Rows.Add("sys_channel", ActionEnum.Edit.ToString(), "修改频道配置");
            dt.Rows.Add("sys_channel", ActionEnum.Delete.ToString(), "删除频道配置");
            dt.Rows.Add("sys_plugin", ActionEnum.View.ToString(), "查看系统插件");
            dt.Rows.Add("sys_plugin", ActionEnum.Add.ToString(), "安装系统插件");
            dt.Rows.Add("sys_plugin", ActionEnum.Edit.ToString(), "生成插件模板");
            dt.Rows.Add("sys_plugin", ActionEnum.Delete.ToString(), "卸载系统插件");
            dt.Rows.Add("sys_templet",ActionEnum.View.ToString(), "查看系统模板");
            dt.Rows.Add("sys_templet", ActionEnum.Add.ToString(), "启用系统模板");
            dt.Rows.Add("sys_templet", ActionEnum.Edit.ToString(), "生成系统模板");
            dt.Rows.Add("sys_templet", ActionEnum.Delete.ToString(), "删除模板文件");
            dt.Rows.Add("sys_log", ActionEnum.View.ToString(), "查看系统日志");
            dt.Rows.Add("sys_log", ActionEnum.Delete.ToString(), "删除系统日志");
            dt.Rows.Add("sys_manager", ActionEnum.View.ToString(), "查看管理员");
            dt.Rows.Add("sys_manager", ActionEnum.Add.ToString(), "添加管理员");
            dt.Rows.Add("sys_manager", ActionEnum.Edit.ToString(), "修改管理员");
            dt.Rows.Add("sys_manager", ActionEnum.Delete.ToString(), "删除管理员");
            dt.Rows.Add("sys_role", ActionEnum.View.ToString(), "查看管理角色");
            dt.Rows.Add("sys_role", ActionEnum.Add.ToString(), "添加管理角色");
            dt.Rows.Add("sys_role", ActionEnum.Edit.ToString(), "修改管理角色");
            dt.Rows.Add("sys_role", ActionEnum.Delete.ToString(), "删除管理角色");
            dt.Rows.Add("market", ActionEnum.View.ToString(), "市场主任");
            dt.Rows.Add("msg", ActionEnum.Edit.ToString(), "咨询主任");
            return dt;
        }
        #endregion



        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.manager_role model = new Model.manager_role();
            BLL.manager_role bll = new BLL.manager_role();

            model.role_name = txtRoleName.Text.Trim();
            model.role_type = int.Parse(ddlRoleType.SelectedValue);

            List<Model.manager_role_value> ls = new List<Model.manager_role_value>();
            //基本设置
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                HiddenField hidNavName = rptList1.Items[i].FindControl("hidName") as HiddenField;
                HtmlInputCheckBox hcbNavValue = rptList1.Items[i].FindControl("cblNavName") as HtmlInputCheckBox;
                if (hidNavName != null && hcbNavValue!=null)
                {
                    if (hcbNavValue.Checked == true)
                    {
                        ls.Add(new Model.manager_role_value { channel_id = 0, channel_name = hidNavName.Value, action_type = hcbNavValue.Value });
                    }
                }
            }
            //频道设置
            for (int i = 0; i < rptList3.Items.Count; i++)
            {
                int channelId = Convert.ToInt32(((HiddenField)rptList3.Items[i].FindControl("hidChannelId")).Value);
                HtmlInputCheckBox hcbView = rptList3.Items[i].FindControl("cbView") as HtmlInputCheckBox;
                HtmlInputCheckBox hcbAdd = rptList3.Items[i].FindControl("cbAdd") as HtmlInputCheckBox;
                HtmlInputCheckBox hcbEdit = rptList3.Items[i].FindControl("cbEdit") as HtmlInputCheckBox;
                HtmlInputCheckBox hcbDelete = rptList3.Items[i].FindControl("cbDelete") as HtmlInputCheckBox;
                if (hcbView != null && hcbView.Checked == true)
                {
                    ls.Add(new Model.manager_role_value { channel_id = channelId, channel_name = "channel", action_type = ActionEnum.View.ToString() });
                }
                if (hcbAdd != null && hcbAdd.Checked == true)
                {
                    ls.Add(new Model.manager_role_value { channel_id = channelId, channel_name = "channel", action_type = ActionEnum.Add.ToString() });
                }
                if (hcbEdit != null && hcbEdit.Checked == true)
                {
                    ls.Add(new Model.manager_role_value { channel_id = channelId, channel_name = "channel", action_type = ActionEnum.Edit.ToString() });
                }
                if (hcbDelete != null && hcbDelete.Checked == true)
                {
                    ls.Add(new Model.manager_role_value { channel_id = channelId, channel_name = "channel", action_type = ActionEnum.Delete.ToString() });
                }
            }

            model.manager_role_values = ls;
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
            BLL.manager_role bll = new BLL.manager_role();
            Model.manager_role model = bll.GetModel(_id);

            model.role_name = txtRoleName.Text.Trim();
            model.role_type = int.Parse(ddlRoleType.SelectedValue);

            List<Model.manager_role_value> ls = new List<Model.manager_role_value>();
            //基本设置
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                int hidId = Convert.ToInt32(((HiddenField)rptList1.Items[i].FindControl("hidId")).Value);
                HiddenField hidNavName = rptList1.Items[i].FindControl("hidName") as HiddenField;
                HtmlInputCheckBox hcbNavValue = rptList1.Items[i].FindControl("cblNavName") as HtmlInputCheckBox;
                if (hidNavName != null && hcbNavValue != null)
                {
                    if (hcbNavValue.Checked == true)
                    {
                        ls.Add(new Model.manager_role_value { id = hidId, role_id = _id, channel_id = 0, channel_name = hidNavName.Value, action_type = hcbNavValue.Value });
                    }
                }
            }
            //频道设置
            for (int i = 0; i < rptList3.Items.Count; i++)
            {
                int channelId = Convert.ToInt32(((HiddenField)rptList3.Items[i].FindControl("hidChannelId")).Value);
                HtmlInputCheckBox hcbView = rptList3.Items[i].FindControl("cbView") as HtmlInputCheckBox;
                HtmlInputCheckBox hcbAdd = rptList3.Items[i].FindControl("cbAdd") as HtmlInputCheckBox;
                HtmlInputCheckBox hcbEdit = rptList3.Items[i].FindControl("cbEdit") as HtmlInputCheckBox;
                HtmlInputCheckBox hcbDelete = rptList3.Items[i].FindControl("cbDelete") as HtmlInputCheckBox;
                int hidViewId = Convert.ToInt32(((HiddenField)rptList3.Items[i].FindControl("hidViewId")).Value);
                int hidAddId = Convert.ToInt32(((HiddenField)rptList3.Items[i].FindControl("hidAddId")).Value);
                int hidEditId = Convert.ToInt32(((HiddenField)rptList3.Items[i].FindControl("hidEditId")).Value);
                int hidDeleteId = Convert.ToInt32(((HiddenField)rptList3.Items[i].FindControl("hidDeleteId")).Value);

                if (hcbView != null && hcbView.Checked == true)
                {
                    ls.Add(new Model.manager_role_value { id = hidViewId, role_id = _id, channel_id = channelId, channel_name = "channel", action_type = ActionEnum.View.ToString() });
                }
                if (hcbAdd != null && hcbAdd.Checked == true)
                {
                    ls.Add(new Model.manager_role_value { id = hidAddId, role_id = _id, channel_id = channelId, channel_name = "channel", action_type = ActionEnum.Add.ToString() });
                }
                if (hcbEdit != null && hcbEdit.Checked == true)
                {
                    ls.Add(new Model.manager_role_value { id = hidEditId, role_id = _id, channel_id = channelId, channel_name = "channel", action_type = ActionEnum.Edit.ToString() });
                }
                if (hcbDelete != null && hcbDelete.Checked == true)
                {
                    ls.Add(new Model.manager_role_value { id = hidDeleteId, role_id = _id, channel_id = channelId, channel_name = "channel", action_type = ActionEnum.Delete.ToString() });
                }
            }

            model.manager_role_values = ls;
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
                ChkAdminLevel("sys_role", ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改角色成功啦！", "role_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("sys_role", ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加角色成功啦！", "role_list.aspx", "Success");
            }
        }
    }
}