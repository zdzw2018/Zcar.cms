using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.zlesson
{
    public partial class jianzhi_teacher_wages : DTcms.Web.UI.ManagePage
    {
        protected int monthCount = 0;//月份统计数
        protected int yearCount;//年份统计

        protected int channel_id;
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;
        protected string teacher = string.Empty;
        protected DTcms.Model.manager model = new Model.manager();
        protected decimal total_wages = 0;
        protected decimal total_jili = 0;
        protected decimal total_keshi = 0;
        protected string grade = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            model = GetAdminInfo();
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
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.teacher = DTRequest.GetQueryString("teacher");
            this.grade = DTRequest.GetQueryString("grade");
            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
            this.pageSize = GetPageSize(15); //每页数量

            if (!Page.IsPostBack)
            {
                objectSite.DDLbind(base.siteConfig.sysgrade, this.ddlGrade, "=请选择年级=");
                this.bindTeach();
                for (int i = 2018; i <= DateTime.Now.Year + 2; i++)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                ChkAdminLevel(channel_id, ActionEnum.View.ToString()); //检查权限
                if (model.role_id != 1 && model.role_id != 10 && model.role_id != 16)
                {
                    RptBind(" YEAR(lesson_date)=" + yearCount + " and MONTH(lesson_date)=" + monthCount + " and manager_id=" + model.id + CombSqlTxt(this.channel_id, this.keywords, this.teacher, this.grade), "  stu_id desc");
                }
                else
                {
                    RptBind(" YEAR(lesson_date)=" + yearCount + " and MONTH(lesson_date)=" + monthCount + " and manager_id in(select id from dt_manager where role_id=11 and is_jianzhi=1 and is_lock=0) and xiaoqu=" + model.xiaoqu + CombSqlTxt(this.channel_id, this.keywords, this.teacher, this.grade), "  stu_id desc");
                }
            }

        }
        public decimal getKeShiMultiple(int stu_id)
        {

            BLL.student_contract contact_bll = new BLL.student_contract();
            DataSet ds = contact_bll.GetList(1, " keshi_multiple>0 and audit_stutas=1 and stu_id=" + stu_id, "audit_date");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return decimal.Parse(ds.Tables[0].Rows[0]["keshi_multiple"].ToString());
            }
            else
            {
                return 1;
            }
        }

        
        

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            this.ddlTeacher.SelectedValue = this.teacher;
            this.ddlMonth.SelectedValue = monthCount.ToString();
            this.ddlYear.SelectedValue = yearCount.ToString();
            this.ddlGrade.SelectedValue = this.grade;
            BLL.lesson bll = new BLL.lesson();
            DataSet ds = bll.GetListAll(0, _strWhere, "stu_id");
            this.rptList.DataSource = bll.GetWagesList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                
                total_wages += decimal.Parse(getKeShiDanJia(int.Parse(row["manager_id"].ToString()), int.Parse(row["stu_id"].ToString()))) * decimal.Parse(row["lesson_count"].ToString()) * getKeShiMultiple(int.Parse(row["stu_id"].ToString()));

                total_keshi += decimal.Parse(row["lesson_count"].ToString());
                total_jili += (GetJiLi(row["stu_id"].ToString(), row["manager_id"].ToString()) * decimal.Parse(row["lesson_count"].ToString()));
            }
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("jianzhi_teacher_wages.aspx", "channel_id={0}&keywords={1}&teacher={2}&year={3}&month={4}&grade={5}&page={6}",
                this.channel_id.ToString(), this.keywords, this.teacher, this.yearCount.ToString(), this.monthCount.ToString(), this.grade, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _channel_id, string _keywords, string _teacher, string _grade)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and manager_name like '%" + _keywords + "%'");
            }
            if (!string.IsNullOrEmpty(_teacher))
            {
                strTemp.Append(" and manager_id=" + _teacher);
            }
            if (!string.IsNullOrEmpty(_grade))
            {
                strTemp.Append(" and  stu_id in(select id from tb_student_info where stu_grade='" + _grade + "')");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回资讯每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("lesson_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("jianzhi_teacher_wages.aspx", "channel_id={0}&keywords={1}&teacher={2}&year={3}&month={4}&grade={5}",
                this.channel_id.ToString(), txtKeywords.Text, this.teacher, this.yearCount.ToString(), this.monthCount.ToString(), this.grade));
        }

        protected string getKeShiDanJia(int teacher_id,int stu_id)
        {
            BLL.student_info bll_stu = new BLL.student_info();
            Model.student_info stu = bll_stu.GetModel(stu_id);

            BLL.tb_jianzhi_teacher_keshi_danjia bll_jianzhi_keshi = new BLL.tb_jianzhi_teacher_keshi_danjia();
            string grade = string.Empty;
            if (stu.stu_grade.Contains("小"))
            {
                grade = "小";
            }
            else
            {
                grade = stu.stu_grade;
            }
            DataSet ds = bll_jianzhi_keshi.GetList(1, "teacher_id=" + teacher_id + " and grade like '%" + grade + "%'", "id");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["keshi_danjia"].ToString();
            }
            else
            {
                return "0";
            }

        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("lesson_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("jianzhi_teacher_wages.aspx", "channel_id={0}&keywords={1}&teacher={2}&year={3}&month={4}&grade={5}",
            this.channel_id.ToString(), this.keywords, this.teacher, this.yearCount.ToString(), this.monthCount.ToString(), this.grade));
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("jianzhi_teacher_wages.aspx", "channel_id={0}&keywords={1}&month={2}&year={3}&teacher={4}&grade={5}",
          this.channel_id.ToString(), this.keywords, ddlMonth.SelectedValue, ddlYear.SelectedValue, this.teacher, this.grade));
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("jianzhi_teacher_wages.aspx", "channel_id={0}&keywords={1}&month={2}&year={3}&teacher={4}&grade={5}",
          this.channel_id.ToString(), this.keywords, ddlMonth.SelectedValue, ddlYear.SelectedValue, this.teacher, this.grade));
        }

        protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("jianzhi_teacher_wages.aspx", "channel_id={0}&keywords={1}&month={2}&year={3}&teacher={4}&grade={5}", new string[] { this.channel_id.ToString(), this.keywords, this.monthCount.ToString(), this.yearCount.ToString(), ddlTeacher.SelectedValue, this.grade }));
        }
        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("teacher_wages.aspx", "channel_id={0}&keywords={1}&month={2}&year={3}&teacher={4}&grade={5}", new string[] { this.channel_id.ToString(), this.keywords, this.monthCount.ToString(), this.yearCount.ToString(), this.teacher, ddlGrade.SelectedValue }));
        }

        public void bindTeach()
        {
            Model.manager model = GetAdminInfo();
            DataTable dt = new DTcms.BLL.manager().GetList("role_id=11 and is_jianzhi=1 and is_lock=0" + "and xiaoqu=" + model.xiaoqu).Tables[0];
            //if (model.role_id == 10 || model.role_id == 16)
            //{
            //    dt = new BLL.manager().GetList("role_id=11 and xiaoqu=" + model.xiaoqu).Tables[0];
            //}
            this.ddlTeacher.DataSource = dt;
            this.ddlTeacher.DataTextField = "real_name";
            this.ddlTeacher.DataValueField = "id";
            this.ddlTeacher.DataBind();
            this.ddlTeacher.Items.Insert(0, new ListItem("=请选择教师=", ""));
        }

        public decimal GetJiLi(string stu_id, string manager_id)
        {
            BLL.lesson lesson_bll = new BLL.lesson();
            decimal total_lesson = lesson_bll.GetLettonCount(" manager_id=" + manager_id + " and year(lesson_date)>=2018 and month(lesson_date)<=" + monthCount.ToString() + " and stu_id=" + stu_id);
            decimal total_give_lesson = new BLL.give_lesson().GetLettonCount(" manager_id=" + manager_id + " and year(lesson_date)>=2018 and month(lesson_date)<=" + monthCount.ToString() + " and stu_id=" + stu_id);

            BLL.tb_keshi_jili bll_keshi_jili = new BLL.tb_keshi_jili();
            decimal jili = bll_keshi_jili.GetJiLi(total_lesson + total_give_lesson);//获取当月的激励


            return jili;
        }
    }
}