using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.comment
{
    public partial class edit : DTcms.Web.UI.ManagePage
    {
        private int id = 0;
        protected Model.comment model = new Model.comment();

        protected void Page_Load(object sender, EventArgs e)
        {
            id = DTRequest.GetQueryInt("id");
            if (id == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            if (!new BLL.comment().Exists(this.id))
            {
                JscriptMsg("信息不存在或已被删除！", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                ShowInfo(this.id);
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.comment bll = new BLL.comment();
            model = bll.GetModel(_id);
            txtReContent.Text = Utils.ToTxt(model.reply_content);
            rblIsLock.SelectedValue = model.is_lock.ToString();
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL.comment bll = new BLL.comment();
            model = bll.GetModel(this.id);
            model.is_reply = 1;
            model.reply_content = Utils.ToHtml(txtReContent.Text);
            model.is_lock = int.Parse(rblIsLock.SelectedValue);
            model.reply_time = DateTime.Now;
            bll.Update(model);
            JscriptMsg("评论回复成功啦！", "list.aspx?channel_id=" + model.channel_id, "Success");
        }
    }
}