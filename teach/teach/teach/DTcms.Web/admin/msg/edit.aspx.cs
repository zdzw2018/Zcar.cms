using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.msg
{
    public partial class edit : DTcms.Web.UI.ManagePage
    {
        protected string action = ActionEnum.Add.ToString(); //操作类型
        private int channel_id;
        private int id = 0;
        protected string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.username = DTRequest.GetQueryString("username");
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
                if (!new BLL.message().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {

                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else 
                {
                    txtmsg_income_user.Text = username + ",";
                }

            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.message bll = new BLL.message();
            Model.message model = bll.GetModel(_id);

            txtmsg_income_user.Text = model.msg_income_user;
            txtmsg_title.Text = model.msg_title;
            txtmsg_content.Text = model.msg_content;
            txtmsg_title.ReadOnly = true;
            txtmsg_income_user.ReadOnly = true;
            txtmsg_content.ReadOnly = true;
            //绑定附件
            rptAttach.DataSource = model.download_attachs;
            rptAttach.DataBind();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.message model = new Model.message();
            BLL.message bll = new BLL.message();

            try
            {
                model.add_time = DateTime.Now;
                model.msg_content = txtmsg_content.Text;
                model.msg_from_del = 0;
                model.msg_from_user = GetAdminInfo().user_name;
                model.msg_id = 0;
                model.msg_income_del = 0;
                model.msg_income_user = txtmsg_income_user.Text;
                model.msg_title = txtmsg_title.Text;
                model.remark = 0;
                model.update_time = DateTime.Now;

                //保存附件
                string hidFileList = Request.Params["hidFileName"];
                if (!string.IsNullOrEmpty(hidFileList))
                {
                    string[] fileListArr = hidFileList.Split(',');
                    List<Model.download_attach> ls = new List<Model.download_attach>();
                    for (int i = 0; i < fileListArr.Length; i++)
                    {
                        string[] fileArr = fileListArr[i].Split('|');
                        if (fileArr.Length == 3)
                        {
                            int fileSize = Utils.GetFileSize(fileArr[2]);
                            string fileExt = Utils.GetFileExt(fileArr[2]);
                            ls.Add(new Model.download_attach { id = int.Parse(fileArr[0]), title = fileArr[1], file_path = fileArr[2], file_size = fileSize, file_ext = fileExt });
                        }
                    }
                    model.download_attachs = ls;
                }
                foreach (string item in txtmsg_income_user.Text.Trim().Split(','))
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        model.msg_income_user = item;
                        bll.Add(model);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {

                return false;
            }

           
        }
        #endregion


        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel(channel_id, ActionEnum.Add.ToString()); //检查权限
            BLL.manager mananger = new BLL.manager();
            username = GetAdminInfo().user_name;
            foreach (string item in txtmsg_income_user.Text.Trim().Split(','))
            {

                if (!mananger.Exists(item))
                {
                    JscriptMsg("帐号：" + item + "不存在！", "", "Error");
                    return;
                }
                else if (item.Trim().Equals(username))
                {
                    JscriptMsg("不能发给自己！", "", "Error");
                    return;
                }
            }
            if (!DoAdd())
            {
                JscriptMsg("保存过程中发生错误啦！", "", "Error");
                return;
            }
            JscriptMsg("添加资讯成功啦！", "list.aspx?channel_id=" + this.channel_id, "Success");
        }
    }
}