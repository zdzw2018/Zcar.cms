using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.zlesson
{
    public partial class list_view : DTcms.Web.UI.ManagePage
    {
       
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int stuid = 0;

        protected int category_id;
        protected int channel_id;
        protected string property = string.Empty;
        protected string keywords = string.Empty;
        protected string kemu = string.Empty;
        protected string teacher = string.Empty;
        protected int monthCount = 0;//月份统计数
        protected int yearCount;//年份统计

        protected void Page_Load(object sender, EventArgs e)
        {
            
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.property = DTRequest.GetQueryString("property");
            this.kemu = DTRequest.GetQueryString("kemu");
            this.teacher = DTRequest.GetQueryString("teacher");
            stuid = DTRequest.GetQueryInt("stuid");

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
           
            this.pageSize = GetPageSize(15); //每页数量
            if (!Page.IsPostBack)
            {
                for (int i = 2013; i <= DateTime.Now.Year; i++)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                bindTeach();
                if (stuid != 0)
                {
                    RptBind("id>0 and stu_id=" + stuid + CombSqlTxt(this.category_id, this.keywords, this.property,this.teacher,this.kemu,this.yearCount.ToString(),this.monthCount.ToString()), "add_time desc");
                }
                else
                {
                    if (GetAdminInfo().role_id != 1 && GetAdminInfo().role_id != 10 && GetAdminInfo().role_id != 16)
                    {
                        RptBind("id>0 and stu_id in (select id from tb_student_info)  and manager_id=" + GetAdminInfo().id + CombSqlTxt(this.category_id, this.keywords, this.property, this.teacher, this.kemu, this.yearCount.ToString(), this.monthCount.ToString()), "add_time desc");
                    }
                    else
                    {
                        RptBind("id>0 and stu_id in (select id from tb_student_info) " + CombSqlTxt(this.category_id, this.keywords, this.property, this.teacher, this.kemu, this.yearCount.ToString(), this.monthCount.ToString()), "add_time desc");
                    }
                }
            }
        }

        

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            this.ddlTeacher.SelectedValue = teacher;
            this.ddlLesson.SelectedValue = kemu;
            this.ddlMonth.SelectedValue = monthCount.ToString();
            this.ddlYear.SelectedValue = yearCount.ToString();
            BLL.lesson bll = new BLL.lesson();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&stuid={7}&channel_id={8}&page={9}",
                this.category_id.ToString(), this.keywords, this.property, this.teacher, this.kemu, this.yearCount.ToString(), this.monthCount.ToString(), this.stuid.ToString(), this.channel_id.ToString(), "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt( int _category_id, string _keywords, string _property,string _teacher,string _kemu,string _year,string _month)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and stu_id in(select id from tb_student_info where stu_name like '%" + _keywords + "%')");
            }
            if (!string.IsNullOrEmpty(_teacher))
            {
                strTemp.Append(" and manager_id=" + _teacher );
            }
            if (!string.IsNullOrEmpty(_kemu))
            {
                strTemp.Append(" and lesson_name='" + _kemu + "'");
            }
            if (!string.IsNullOrEmpty(_year))
            {
                strTemp.Append(" and year(lesson_date)=" + _year );
            }
            if (!string.IsNullOrEmpty(_month))
            {
                strTemp.Append(" and month(lesson_date)=" + _month);
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
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&stuid={7}&channel_id={8}",
                this.category_id.ToString(), txtKeywords.Text, this.property,this.ddlTeacher.SelectedValue,this.ddlLesson.SelectedValue,this.ddlYear.SelectedValue,this.ddlMonth.SelectedValue,this.stuid.ToString(),this.channel_id.ToString()));
        }


        public void bindTeach()
        {
            DataTable dt = new BLL.manager().GetList("role_id= 11").Tables[0];
            ddlTeacher.DataSource = dt;
            ddlTeacher.DataTextField = "real_name";
            ddlTeacher.DataValueField = "id";
            ddlTeacher.DataBind();
            this.ddlTeacher.Items.Insert(0, new ListItem("=请选择教师=", ""));
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
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&stuid={7}&channel_id={8}",
             this.category_id.ToString(), this.keywords, this.property,this.ddlTeacher.SelectedValue,this.ddlLesson.SelectedValue,this.ddlYear.SelectedValue,this.ddlMonth.SelectedValue,this.stuid.ToString(),this.channel_id.ToString()));
        }

        /// <summary>
        /// 科目选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlLesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&stuid={7}&channel_id={8}",
            this.category_id.ToString(), this.keywords, this.property, this.ddlTeacher.SelectedValue, this.ddlLesson.SelectedValue, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue,this.stuid.ToString(),this.channel_id.ToString()));
        }

        /// <summary>
        /// 教师选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&channel_id={7}",
            this.category_id.ToString(), this.keywords, this.property, this.ddlTeacher.SelectedValue, this.ddlLesson.SelectedValue, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue,this.channel_id.ToString()));
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&stuid={7}&channel_id={8}",
            this.category_id.ToString(), this.keywords, this.property, this.ddlTeacher.SelectedValue, this.ddlLesson.SelectedValue, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue,this.stuid.ToString(),this.channel_id.ToString()));

        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&stuid={7}&channel_id={8}",
            this.category_id.ToString(), this.keywords, this.property, this.ddlTeacher.SelectedValue, this.ddlLesson.SelectedValue, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue,this.stuid.ToString(),this.channel_id.ToString()));

        }


        //批量删除
        protected void shanchu(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            ChkAdminLevel(channel_id, ActionEnum.Delete.ToString()); //检查权限
            BLL.lesson bll = new BLL.lesson();
            string id = linkButton.CommandArgument;
            bll.Delete(int.Parse(id));
            JscriptMsg("删除成功！", Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&stuid={7}&channel_id={8}",
                this.category_id.ToString(), txtKeywords.Text, this.property, this.ddlTeacher.SelectedValue, this.ddlLesson.SelectedValue, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue,this.stuid.ToString(),this.channel_id.ToString())
            , "Success");
        }
        

    }
}