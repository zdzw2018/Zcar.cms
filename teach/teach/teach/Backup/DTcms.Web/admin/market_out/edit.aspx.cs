using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.market_out
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
                if (!new BLL.market_outfield().Exists(this.id))
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
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.market_outfield bll = new BLL.market_outfield();
            Model.market_outfield model = bll.GetModel(_id);

            txtactivity_content.Text = model.activity_content;
            txtactivity_location.Text = model.activity_location;
            txtactivity_time.Text = model.activity_time.ToString("yyyy-MM-dd");
            txtcollect_msg.Text = model.collect_msg.ToString() ;
            txtoprice_push.Text = model.oprice_push.ToString();
            txtpart_time_fees.Text = model.part_time_fees.ToString();
            txtques_feed.Text = model.ques_feed;
            txtwatchers.Text = model.watchers.ToString();


        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.market_outfield model = new Model.market_outfield();
            BLL.market_outfield bll = new BLL.market_outfield();
            try
            {

                model.add_time = DateTime.Now;
                model.activity_content = txtactivity_content.Text;
                model.activity_location = txtactivity_location.Text;
                model.activity_time = Convert.ToDateTime(txtactivity_time.Text);
                model.add_time = DateTime.Now;
                model.channel_id = this.channel_id;
                model.collect_msg = Convert.ToInt32(txtcollect_msg.Text);
                model.oprice_push = Convert.ToDecimal(txtoprice_push.Text);
                model.part_time_fees = Convert.ToDecimal(txtpart_time_fees.Text);
                model.ques_feed = txtques_feed.Text;
                model.user_id = GetAdminInfo().id;
                model.watchers = Convert.ToInt32(txtwatchers.Text);
            }
            catch (Exception ex)
            {
               result = false;
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
            BLL.market_outfield bll = new BLL.market_outfield();
            Model.market_outfield model = bll.GetModel(_id);

            try
            {
                model.activity_content = txtactivity_content.Text;
                model.activity_location = txtactivity_location.Text;
                model.activity_time = Convert.ToDateTime(txtactivity_time.Text);
                model.add_time = DateTime.Now;
                model.channel_id = this.channel_id;
                model.collect_msg = Convert.ToInt32(txtcollect_msg.Text);
                model.oprice_push = Convert.ToDecimal(txtoprice_push.Text);
                model.part_time_fees = Convert.ToDecimal(txtpart_time_fees.Text);
                model.ques_feed = txtques_feed.Text;
                model.watchers = Convert.ToInt32(txtwatchers.Text);
            }
            catch (Exception)
            {
                
                 result = false;
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