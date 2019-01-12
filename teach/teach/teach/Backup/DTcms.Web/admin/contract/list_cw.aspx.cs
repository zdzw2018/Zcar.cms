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
                monthCount = DTRequest.GetQueryInt("month");
            }
            else
            {
                monthCount = DateTime.Now.Month;
            }
            if (DTRequest.GetQueryInt("year") != 0)
            {
                yearCount = DTRequest.GetQueryInt("year");
            }
            else
            {
                yearCount = DateTime.Now.Year;
            }
            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
            this.pageSize = GetPageSize(15); //每页数量
            if (!Page.IsPostBack)
            {
                for (int i = 2013; i <= DateTime.Now.Year; i++)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                this.ddlZiXunShi.DataSource = new DTcms.BLL.manager().GetList("role_id=12 or role_id=9 or role_id=15");
                this.ddlZiXunShi.DataTextField = "real_name";
                this.ddlZiXunShi.DataValueField = "id";
                this.ddlZiXunShi.DataBind();
                this.ddlZiXunShi.Items.Insert(0, new ListItem("=请选择申请人=", ""));
                ChkAdminLevel(channel_id, ActionEnum.View.ToString()); //检查权限
                RptBind("id>0" + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property, this.shenqing, yearCount.ToString(), monthCount.ToString(), this.qianyue), "Expr2 desc");
            }
        }


        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _channel_id, int _category_id, string _keywords, string _property,string _shenqing,string _year,string _month,string _qianyue)
        {
            StringBuilder strTemp = new StringBuilder();
            if (!string.IsNullOrEmpty(_property))
            {
                strTemp.Append(" and audit_stutas='" + (Convert.ToInt32( _property)-1) + "'");
            }
            _keywords = _keywords.Replace("'", "");
            if (shaixuan == "stu")
            {
                strTemp.Append(" and  stu_name  like '%" + _keywords + "%'");
            }
            else 
            {
                strTemp.Append(" and  stu_tel  like '%" + _keywords + "%'");
            }
            
            if (!string.IsNullOrEmpty(_shenqing))
            {
                strTemp.Append(" and user_id=" + _shenqing);
            }
            if (!string.IsNullOrEmpty(_year))
            {
                strTemp.Append(" and year(Expr2)=" + _year);
            }
            if (!string.IsNullOrEmpty(_month))
            {
                strTemp.Append(" and month(Expr2)=" + _month);
            }
            if (!string.IsNullOrEmpty(_qianyue))
            {
                strTemp.Append(" and  stu_parent_name='" + _qianyue + "'");
            }
           
            return strTemp.ToString();
        }
        #endregion

        //筛选属性
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixun={8}",
               this.channel_id.ToString(), this.category_id.ToString(), this.keywords, ddlProperty.SelectedValue,this.ddlZiXunShi.SelectedValue,this.ddlYear.SelectedValue,this.ddlMonth.SelectedValue,this.ddlQianYue.SelectedValue,this.ddlShouSou.SelectedValue));
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            this.ddlQianYue.SelectedValue = this.qianyue;
            this.ddlShouSou.SelectedValue = shaixuan;
            this.ddlProperty.SelectedValue = this.property;
            this.ddlZiXunShi.SelectedValue = this.shenqing;
            this.ddlMonth.SelectedValue = monthCount.ToString();
            this.ddlYear.SelectedValue = yearCount.ToString();
            BLL.student_contract bll = new BLL.student_contract();
           

            DataSet ds = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataSource = ds.Tables[0];
            DataSet ds1 = bll.GetList(_strWhere);
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                totalnewmoney += double.Parse(ds1.Tables[0].Rows[i]["contract_service_price"].ToString());
                totalrealmoney += double.Parse(ds1.Tables[0].Rows[i]["contract_advice_price"].ToString());
                price += double.Parse(ds1.Tables[0].Rows[i]["contract_advice_price_surplus"].ToString());
            }
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixuan={8}&page={9}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.shenqing,this.yearCount.ToString(),this.monthCount.ToString(),this.qianyue,this.shaixuan ,"__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回资讯每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("student_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixuan={8}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property,this.shenqing,this.yearCount.ToString(),this.monthCount.ToString(),this.qianyue,this.ddlShouSou.SelectedValue));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("student_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixuan={8}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.shenqing, this.yearCount.ToString(), this.monthCount.ToString(),this.qianyue,this.shaixuan));
        }
        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel(channel_id, ActionEnum.Delete.ToString()); //检查权限
            BLL.student_contract bll = new BLL.student_contract();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixuan={8}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.shenqing, this.yearCount.ToString(), this.monthCount.ToString(),this.qianyue,this.shaixuan), "Success");
        }

        /// <summary>
        /// 申请人改变的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlZiXunShi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixuan={8}",
              this.channel_id.ToString(), this.category_id.ToString(), this.keywords, ddlProperty.SelectedValue, this.ddlZiXunShi.SelectedValue,this.ddlYear.SelectedValue,this.ddlMonth.SelectedValue,this.ddlQianYue.SelectedValue,this.shaixuan));
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixuan={8}",
             this.channel_id.ToString(), this.category_id.ToString(), this.keywords, ddlProperty.SelectedValue, this.ddlZiXunShi.SelectedValue, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue,this.ddlQianYue.SelectedValue,this.shaixuan));

        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixuan={8}",
             this.channel_id.ToString(), this.category_id.ToString(), this.keywords, ddlProperty.SelectedValue, this.ddlZiXunShi.SelectedValue, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue,this.ddlQianYue.SelectedValue,this.shaixuan));

        }

        protected void ddlQianYue_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_cw.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shenqing={4}&year={5}&month={6}&qianyue={7}&shaixuan={8}",
             this.channel_id.ToString(), this.category_id.ToString(), this.keywords, ddlProperty.SelectedValue, this.ddlZiXunShi.SelectedValue, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue, this.ddlQianYue.SelectedValue,this.shaixuan));

        }
    }
}