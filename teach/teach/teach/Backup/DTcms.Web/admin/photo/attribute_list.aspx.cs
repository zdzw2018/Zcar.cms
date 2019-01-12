using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.photo
{
    public partial class attribute_list : DTcms.Web.UI.ManagePage
    {
        protected int channel_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel(channel_id, ActionEnum.View.ToString()); //检查权限
                RptBind("channel_id=" + this.channel_id);
            }
        }

        #region 数据绑定
        private void RptBind(string strWhere)
        {
            BLL.photo_attribute bll = new BLL.photo_attribute();
            DataSet ds = bll.GetList(strWhere);
            this.rptList.DataSource = ds;
            this.rptList.DataBind();
        }
        #endregion

        #region 返回字段类型中文名称
        protected string GetTypeCn(int type_id)
        {
            string type_name = "";
            switch (type_id)
            {
                case (int)AttributeEnum.Text:
                    type_name = "输入框";
                    break;
                case (int)AttributeEnum.Select:
                    type_name = "下拉框";
                    break;
                case (int)AttributeEnum.Radio:
                    type_name = "单选框";
                    break;
                case (int)AttributeEnum.CheckBox:
                    type_name = "复选框";
                    break;
            }
            return type_name;
        }
        #endregion

        //删除扩展属性
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel(channel_id, ActionEnum.Delete.ToString()); //检查权限
            BLL.photo_attribute bll = new BLL.photo_attribute();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("attribute_list.aspx", "channel_id={0}", this.channel_id.ToString()), "Success");
        }

    }
}