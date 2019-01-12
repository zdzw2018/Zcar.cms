using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Text;
using System.Data;

namespace DTcms.Web.admin.zlesson
{
    public partial class keshi_list : DTcms.Web.UI.ManagePage
    {
        protected int channel_id;
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int monthCount=0;//月份统计数
        protected int yearCount;//年份统计
        protected string shaixuan = string.Empty;
        protected string xueguan = string.Empty;

        protected int category_id;
        protected string property = string.Empty;
        protected string keywords = string.Empty;
        protected string grade = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");
            this.grade = DTRequest.GetQueryString("grade");
            this.shaixuan = DTRequest.GetQueryString("shaixuan");
            this.xueguan = DTRequest.GetQueryString("xueguan");

            this.pageSize = GetPageSize(15); //每页数量
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
            if (!Page.IsPostBack)
            {
                DataTable dt = new BLL.manager().GetList("role_id=12").Tables[0];
                this.ddlXueGuan.DataSource = dt;
                this.ddlXueGuan.DataTextField = "real_name";
                this.ddlXueGuan.DataValueField = "id";
                this.ddlXueGuan.DataBind();
                this.ddlXueGuan.Items.Insert(0, new ListItem("=请选择学管师=", ""));
                objectSite.DDLbind(siteConfig.sysgrade, ddlGrade, "=请选择年级=");
                for (int i = 2013; i <= DateTime.Now.Year; i++)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                Model.manager model = GetAdminInfo();
                ChkAdminLevel(channel_id, ActionEnum.View.ToString()); //检查权限
                if (model.role_id != 1 && model.role_id != 10 && model.role_id != 16)
                {
                    RptBind("id>0 and id in(select stu_id from tb_student_contract where audit_stutas=1) and id in (select stu_id from tb_student_teach where lesson='' and manager_id=" + model.id + " )" + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property,this.grade,this.xueguan), "add_time desc");
                    this.ddlXueGuan.Visible = false;
                }
                else
                {
                    RptBind("id>0 and id in(select stu_id from tb_student_contract where audit_stutas=1)" + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property,this.grade,this.xueguan), "add_time desc");
                }
            }
        }
        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _channel_id, int _category_id, string _keywords, string _property,string _grade,string _xueguan)
        {
          
            StringBuilder strTemp = new StringBuilder();
            if (!string.IsNullOrEmpty(_keywords))
            {
                if (shaixuan == "stu")
                {
                    strTemp.Append(" and  stu_name  like '%" + _keywords + "%'");
                }
                else
                {
                    strTemp.Append(" and  stu_school  like '%" + _keywords + "%'");
                }
            }

            if (!string.IsNullOrEmpty(_grade))
            {
                strTemp.Append(" and  stu_grade='" + _grade + "'");
            }

            if (!string.IsNullOrEmpty(_xueguan))
            {
                strTemp.Append(" and  id in (select stu_id from tb_student_teach where manager_id='" + _xueguan + "' and lesson='')");
            }
            return strTemp.ToString();
        }
        #endregion



        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            this.ddlGrade.SelectedValue = this.grade;
            this.ddlXueGuan.SelectedValue = this.xueguan;
            this.ddlMonth.SelectedValue = monthCount.ToString();
            this.ddlShouSou.SelectedValue = shaixuan;
            this.ddlYear.SelectedValue = yearCount.ToString();
            BLL.student_info bll = new BLL.student_info();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&grade={6}&shaixuan={7}&xueguan={8}&page={9}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.monthCount.ToString(),this.yearCount.ToString(),this.grade,this.ddlShouSou.SelectedValue,this.xueguan, "__id__");
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
            Response.Redirect(Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&grade={6}&shaixuan={7}&xueguan={8}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property,this.monthCount.ToString(),this.yearCount.ToString(),this.grade,this.ddlShouSou.SelectedValue,this.xueguan));
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
            Response.Redirect(Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&grade={6}&shaixuan={7}&xueguan={8}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.monthCount.ToString(),this.yearCount.ToString(),this.grade,this.ddlShouSou.SelectedValue,this.xueguan));
        }

        /// <summary>
        ///  获取学生已上课时数
        /// </summary>
        /// <returns></returns>
        protected decimal getKeShi(int stuid)
        {
            DTcms.BLL.lesson bll = new BLL.lesson();
            
            return bll.GetLettonCount("stu_id=" + stuid);
        }

        protected decimal getTotalKeShi(int stuid)
        {
            DTcms.BLL.student_contract bll = new BLL.student_contract();
            return bll.getLessonCount("stu_id=" + stuid + " and audit_stutas=1");
        }

        protected decimal getKeShiMonth(int stuid,int month,int year)
        {
            DTcms.BLL.lesson bll = new BLL.lesson();
            return bll.GetLettonCount("stu_id =" + stuid + " and keshi_status=0 and year(lesson_date)=" + year + "and month(lesson_date)=" + month );
        }

        /// <summary>
        /// 获取新签合同收入
        /// </summary>
        /// <returns></returns>
        protected string getPriceContractStatus0(int stu_id, int year, int month)
        {
            DTcms.BLL.student_contract bll = new BLL.student_contract();
            DataTable dt = bll.GetList(1, "stu_id=" + stu_id + " and contract_status=0", " Expr2 desc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                decimal lessonCount = decimal.Parse(dt.Rows[0]["contract_lesson"].ToString());
                decimal yishangkeshi = getKeShiMonth(stu_id,month,year);
                decimal lessonprice = decimal.Parse(dt.Rows[0]["contract_lesson_price"].ToString());

                return (yishangkeshi * lessonprice).ToString("0.0");
            }
            else
            {
                return "0.0";
            }
        }


        /// <summary>
        /// 获取续费合同收入
        /// </summary>
        /// <returns></returns>
        protected string getPriceContractStatus1(int stu_id,int year,int month)
        {


            DTcms.BLL.student_contract bll = new BLL.student_contract();
            DataTable dt = bll.GetList(1, "stu_id=" + stu_id + " and contract_status=1", " Expr2 desc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                decimal lessonCount = decimal.Parse(dt.Rows[0]["contract_lesson"].ToString());
                decimal yishangkeshi = getKeShiMonthXuFei(stu_id, month, year);
                decimal lessonprice = decimal.Parse(dt.Rows[0]["contract_lesson_price"].ToString());

                return (yishangkeshi * lessonprice).ToString("0.0");
            }
            else
            {
                return "0.0";
            }
        }

        protected decimal getKeShiMonthXuFei(int stuid, int month, int year)
        {
            DTcms.BLL.lesson bll = new BLL.lesson();
           
            return bll.GetLettonCount("stu_id =" + stuid + " and keshi_status=1 and year(lesson_date)=" + year + "and month(lesson_date)=" + month);
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&grade={6}&shaixuan={7}&xueguan={8}",
           this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue,ddlYear.SelectedValue,this.ddlGrade.SelectedValue,this.ddlShouSou.SelectedValue,this.xueguan));
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&grade={6}&shaixuan={7}&xueguan={8}",
           this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue,this.ddlGrade.SelectedValue,this.ddlShouSou.SelectedValue,this.xueguan));
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&grade={6}&shaixuan={7}&xueguan={8}",
          this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue,this.xueguan));

        }

        protected string getXueGuanName(int stu_id)
        {
            DTcms.BLL.student_teach bll = new BLL.student_teach();
            DataSet ds = bll.GetList(1, "stu_id=" + stu_id + " and lesson=''", "id");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["manager_name"].ToString();
            }
            else
            {
                return "未分配";
            }
        }

        protected void ddlXueGuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&grade={6}&shaixuan={7}&xueguan={8}",
         this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue, this.ddlXueGuan.SelectedValue));

        }
    }
}