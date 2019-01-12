using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.contract
{
    public partial class list_cw : DTcms.Web.UI.ManagePage
    {
        protected int channel_id;
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int category_id;
        protected string property = string.Empty;
        protected string keywords = string.Empty;
        protected string shenqing = string.Empty;
        protected string qianyue = string.Empty;
        protected string shaixuan = string.Empty;

        protected int monthCount = 0;//月份统计数
        protected int yearCount;//年份统计
        protected double totalnewmoney = 0.0;
        protected double totalrealmoney = 0.0;
        protected double price = 0.0;

         protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel(this.channel_id, ActionEnum.Delete.ToString());
            DTcms.BLL.student_contract _contract = new DTcms.BLL.student_contract();
            for (int i = 0; i < this.rptList.Items.Count; i++)
            {
                int num2 = Convert.ToInt32(((HiddenField) this.rptList.Items[i].FindControl("hidId")).Value);
                CheckBox box = (CheckBox) this.rptList.Items[i].FindControl("chkId");
                if (box.Checked)
                {
                    _contract.Delete(num2);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixuan={8}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.shenqing, this.yearCount.ToString(), this.monthCount.ToString(), this.qianyue, this.shaixuan }), "Success");
        }

         protected void btnShenHeChengGong_Click(object sender, EventArgs e)
         {
             ChkAdminLevel(this.channel_id, ActionEnum.Delete.ToString());
             DTcms.BLL.student_contract _contract = new DTcms.BLL.student_contract();
             for (int i = 0; i < this.rptList.Items.Count; i++)
             {
                 int _id = Convert.ToInt32(((HiddenField)this.rptList.Items[i].FindControl("hidId")).Value);
                 CheckBox box = (CheckBox)this.rptList.Items[i].FindControl("chkId");
                 if (box.Checked)
                 {
                     bool result = true;

                     if (this.channel_id != 11)
                     {
                         _contract.UpdateField(_id, string.Format("audit_user_id={0},audit_date=getdate(),audit_user_name='{1}',audit_remrak='{2}',audit_stutas={3}", new object[] { GetAdminInfo().id, GetAdminInfo().user_name, "", 1 }));
                     }
                     Model.student_contract _contract3 = _contract.GetModel(_id);
                     if (_contract3.contract_status == "0")
                     {
                         new BLL.student_info().UpdateField(_contract3.stu_id, "stu_lesson=stu_lesson+" + _contract3.contract_lesson);
                     }
                     
                 }
             }
             JscriptMsg("批量审核通过成功啦！", Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixuan={8}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.shenqing, this.yearCount.ToString(), this.monthCount.ToString(), this.qianyue, this.shaixuan }), "Success");

         }

        

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&qianyue={5}&shaixuan={6}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.txtKeywords.Text, this.property, this.shenqing, this.qianyue, this.ddlShouSou.SelectedValue }));
        }

        protected string CombSqlTxt(int _channel_id, int _category_id, string _keywords, string _property, string _shenqing, string _year, string _month, string _qianyue)
        {
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(_property))
            {
                builder.Append(" and audit_stutas='" + (Convert.ToInt32(_property) - 1) + "'");
            }
            _keywords = _keywords.Replace("'", "");
            if (this.shaixuan == "stu")
            {
                builder.Append(" and  stu_name  like '%" + _keywords + "%'");
            }
            else
            {
                builder.Append(" and  stu_tel  like '%" + _keywords + "%'");
            }
            if (!string.IsNullOrEmpty(_shenqing))
            {
                builder.Append(" and user_id=" + _shenqing);
            }
            if (!string.IsNullOrEmpty(_year) && (_year != "0"))
            {
                builder.Append(" and year(Expr2)=" + _year);
            }
            if (!string.IsNullOrEmpty(_month) && (_month != "0"))
            {
                builder.Append(" and month(Expr2)=" + _month);
            }
            if (!string.IsNullOrEmpty(_qianyue))
            {
                builder.Append(" and  stu_parent_name='" + _qianyue + "'");
            }
            return builder.ToString();
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixuan={8}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.ddlProperty.SelectedValue, this.ddlZiXunShi.SelectedValue, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue, this.ddlQianYue.SelectedValue, this.shaixuan }));
        }

        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixun={8}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.ddlProperty.SelectedValue, this.ddlZiXunShi.SelectedValue, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue, this.ddlQianYue.SelectedValue, this.ddlShouSou.SelectedValue }));
        }

        protected void ddlQianYue_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixuan={8}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.ddlProperty.SelectedValue, this.ddlZiXunShi.SelectedValue, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue, this.ddlQianYue.SelectedValue, this.shaixuan }));
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixuan={8}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.ddlProperty.SelectedValue, this.ddlZiXunShi.SelectedValue, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue, this.ddlQianYue.SelectedValue, this.shaixuan }));
        }

        protected void ddlZiXunShi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixuan={8}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.ddlProperty.SelectedValue, this.ddlZiXunShi.SelectedValue, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue, this.ddlQianYue.SelectedValue, this.shaixuan }));
        }

        private int GetPageSize(int _default_size)
        {
            int num;
            if (int.TryParse(Utils.GetCookie("student_page_size"), out num) && (num > 0))
            {
                return num;
            }
            return _default_size;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");
            this.shenqing = DTRequest.GetQueryString("shenqing");
            this.qianyue = DTRequest.GetQueryString("qianyue");
            this.shaixuan = DTRequest.GetQueryString("shaixuan");
            if (DTRequest.GetQueryInt("month") != 0)
            {
                this.monthCount = DTRequest.GetQueryInt("month");
            }
            if (DTRequest.GetQueryInt("year") != 0)
            {
                this.yearCount = DTRequest.GetQueryInt("year");
            }
            if (this.channel_id == 0)
            {
                base.JscriptMsg("频道参数不正确！", "back", "Error");
            }
            else
            {
                this.pageSize = this.GetPageSize(15);
                if (!this.Page.IsPostBack)
                {
                    for (int i = 2016; i <= DateTime.Now.Year+2; i++)
                    {
                        this.ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }
                    this.ddlYear.Items.Insert(0, new ListItem("==请选择年份==", "0"));
                    this.ddlZiXunShi.DataSource = new DTcms.BLL.manager().GetList("(role_id=12 or role_id=9 or role_id=15) and is_lock=0 and xiaoqu="+GetAdminInfo().xiaoqu);
                    this.ddlZiXunShi.DataTextField = "real_name";
                    this.ddlZiXunShi.DataValueField = "id";
                    this.ddlZiXunShi.DataBind();
                    this.ddlZiXunShi.Items.Insert(0, new ListItem("=请选择申请人=", ""));
                    base.ChkAdminLevel(this.channel_id, ActionEnum.View.ToString());
                    this.RptBind("id>0 and xiaoqu="+GetAdminInfo().xiaoqu + this.CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property, this.shenqing, this.yearCount.ToString(), this.monthCount.ToString(), this.qianyue), "Expr2 desc");
                }
            }
        }

        private void RptBind(string _strWhere, string _orderby)
        {
            DTcms.Model.manager model = GetAdminInfo();
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            this.ddlQianYue.SelectedValue = this.qianyue;
            this.ddlShouSou.SelectedValue = this.shaixuan;
            this.ddlProperty.SelectedValue = this.property;
            this.ddlZiXunShi.SelectedValue = this.shenqing;
            this.ddlMonth.SelectedValue = this.monthCount.ToString();
            this.ddlYear.SelectedValue = this.yearCount.ToString();
            DTcms.BLL.student_contract _contract = new DTcms.BLL.student_contract();
            DataSet set = _contract.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataSource = set.Tables[0];
            DataSet list = _contract.GetList("id>0 and xiaoqu=" +model.xiaoqu+ this.CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property, this.shenqing, this.yearCount.ToString(), this.monthCount.ToString(), this.qianyue));
            for (int i = 0; i < list.Tables[0].Rows.Count; i++)
            {
                this.totalnewmoney += double.Parse(list.Tables[0].Rows[i]["contract_service_price"].ToString());
                this.totalrealmoney += double.Parse(list.Tables[0].Rows[i]["contract_advice_price"].ToString());
                this.price += double.Parse(list.Tables[0].Rows[i]["contract_advice_price_surplus"].ToString());
            }
            this.rptList.DataBind();
            this.txtPageNum.Text = this.pageSize.ToString();
            string linkUrl = Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixuan={8}&page={9}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.shenqing, this.yearCount.ToString(), this.monthCount.ToString(), this.qianyue, this.shaixuan, "__id__" });
            this.PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, linkUrl, 8);
        }

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int num;
            if (int.TryParse(this.txtPageNum.Text.Trim(), out num) && (num > 0))
            {
                Utils.WriteCookie("student_page_size", num.ToString(), 0xa8c0);
            }
            Response.Redirect(Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixuan={8}", new string[] { this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.shenqing, this.yearCount.ToString(), this.monthCount.ToString(), this.qianyue, this.shaixuan }));
        }
    }
}