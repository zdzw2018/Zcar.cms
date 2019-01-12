using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System.IO;
using OfficeOpenXml.Table;
using System.Linq;


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
        protected string xueguan = string.Empty;
        protected int monthCount = 0;//月份统计数
        protected int yearCount;//年份统计
        protected decimal leftkeshi;
        protected string grade = string.Empty;
        protected decimal totalKeshi;
        protected int user_id = 0;
        protected string start_time = string.Empty;
        protected string end_time = string.Empty;

        public void bindTeach()
        {
            Model.manager model = GetAdminInfo();
            DataTable dt = new DTcms.BLL.manager().GetList("role_id= 11" + "and xiaoqu=" + model.xiaoqu).Tables[0];
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


        public void bindXueGuan()
        {
            DTcms.Model.manager model = GetAdminInfo();

            DataTable dt = new BLL.manager().GetList("role_id=12 and is_lock=0 and xiaoqu=" + model.xiaoqu).Tables[0];

            this.ddlXueGuan.DataSource = dt;
            ddlXueGuan.DataTextField = "real_name";
            ddlXueGuan.DataValueField = "id";
            ddlXueGuan.DataBind();

            ddlXueGuan.Items.Insert(0, new ListItem("=选择学管师=", ""));
        }


        protected void ddlXueGuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&start_time={7}&end_time={8}&stuid={9}&channel_id={10}&grade={11}&leftkeshi={12}&xueguan={13}&user_id={14}", new string[] { this.category_id.ToString(), this.keywords, this.property, this.ddlTeacher.SelectedValue, this.ddlLesson.SelectedValue, this.yearCount.ToString(), this.monthCount.ToString(), this.txtStartTime.Text, this.txtEndTime.Text, this.stuid.ToString(), this.channel_id.ToString(), this.grade, this.leftkeshi.ToString(),this.ddlXueGuan.SelectedValue,this.user_id.ToString() }));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&start_time={7}&end_time={8}&stuid={9}&channel_id={10}&grade={11}&leftkeshi={12}&xueguan={13}&user_id={14}", new string[] { this.category_id.ToString(), txtKeywords.Text.Trim(), this.property, this.ddlTeacher.SelectedValue, this.ddlLesson.SelectedValue, this.yearCount.ToString(), this.monthCount.ToString(), this.txtStartTime.Text, this.txtEndTime.Text, this.stuid.ToString(), this.channel_id.ToString(), this.grade, this.leftkeshi.ToString(), this.xueguan,this.user_id.ToString() }));
        }

        protected string CombSqlTxt(int _category_id, string _keywords, string _property, string _teacher,string _xueguan, string _kemu, string _year,string _month,string _start_time, string _end_time, string _grade)
        {
            StringBuilder builder = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                builder.Append(" and stu_id in(select id from tb_student_info where stu_name like '%" + _keywords + "%')");
            }
            if (!string.IsNullOrEmpty(_teacher))
            {
                builder.Append(" and manager_id=" + _teacher);
            }
            if (!string.IsNullOrEmpty(_xueguan))
            {
                builder.Append(" and stu_id in(select stu_id from tb_student_teach where manager_id='" + _xueguan + "')");
            }
            if (!string.IsNullOrEmpty(_kemu))
            {
                builder.Append(" and lesson_name='" + _kemu + "'");
            }
            if (channel_id == 11)
            {
                if (!string.IsNullOrEmpty(_year))
                {
                    builder.Append(" and year(lesson_date)=" + _year);
                }
                if (!string.IsNullOrEmpty(_month))
                {
                    builder.Append(" and month(lesson_date)=" + _month);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(_start_time) && !string.IsNullOrEmpty(_end_time))
                {
                    builder.Append(" and lesson_date between '" + _start_time + " 00:00:00' and '" + _end_time + " 23:59:59'");
                }
                else
                {
                    builder.Append(" and year(lesson_date)=" + DateTime.Now.Year + " and  month(lesson_date)=" + DateTime.Now.Month);
                }
            }
            if (!string.IsNullOrEmpty(_grade))
            {
                builder.Append(" and  stu_id in(select id from tb_student_info where stu_grade='" + _grade + "')");
            }
            return builder.ToString();
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&start_time={7}&end_time={8}&stuid={9}&channel_id={10}&grade={11}&leftkeshi={12}&xueguan={13}&user_id={14}", new string[] { this.category_id.ToString(), this.keywords, this.property, this.ddlTeacher.SelectedValue, this.ddlLesson.SelectedValue, this.yearCount.ToString(),this.monthCount.ToString(),this.txtStartTime.Text, this.txtEndTime.Text, this.stuid.ToString(), this.channel_id.ToString(), this.ddlGrade.SelectedValue, this.leftkeshi.ToString(),this.xueguan,this.user_id.ToString() }));
        }

        protected void ddlLesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&start_time={7}&end_time={8}&stuid={9}&channel_id={10}&grade={11}&leftkeshi={12}&xueguan={13}&user_id={14}", new string[] { this.category_id.ToString(), this.keywords, this.property, this.ddlTeacher.SelectedValue, this.ddlLesson.SelectedValue, this.yearCount.ToString(), this.monthCount.ToString(), this.txtStartTime.Text, this.txtEndTime.Text, this.stuid.ToString(), this.channel_id.ToString(), this.grade, this.leftkeshi.ToString(), this.xueguan,this.user_id.ToString() }));
        }

        protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&start_time={7}&end_time={8}&stuid={9}&channel_id={10}&grade={11}&leftkeshi={12}&xueguan={13}&user_id={14}", new string[] { this.category_id.ToString(), this.keywords, this.property, this.ddlTeacher.SelectedValue, this.ddlLesson.SelectedValue, this.yearCount.ToString(), this.monthCount.ToString(), this.txtStartTime.Text, this.txtEndTime.Text, this.stuid.ToString(), this.channel_id.ToString(), this.grade, this.leftkeshi.ToString(), this.xueguan,this.user_id.ToString() }));
        }

        private int GetPageSize(int _default_size)
        {
            int num;
            if (int.TryParse(Utils.GetCookie("lesson_page_size"), out num) && (num > 0))
            {
                return num;
            }
            return _default_size;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((DTRequest.GetQueryString("leftkeshi") != null) && (DTRequest.GetQueryString("leftkeshi") != ""))
            {
                this.leftkeshi = decimal.Parse(DTRequest.GetQueryString("leftkeshi"));
            }
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");

            this.property = DTRequest.GetQueryString("property");
            this.kemu = DTRequest.GetQueryString("kemu");
            this.grade = DTRequest.GetQueryString("grade");
            this.teacher = DTRequest.GetQueryString("teacher");
            this.xueguan = DTRequest.GetQueryString("xueguan");
            this.stuid = DTRequest.GetQueryInt("stuid");
            this.user_id = DTRequest.GetQueryInt("user_id");
            this.start_time = DTRequest.GetQueryString("start_time");
            this.end_time = DTRequest.GetQueryString("end_time");
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            if (DTRequest.GetQueryInt("month") != 0)
            {
                this.monthCount = DTRequest.GetQueryInt("month");
            }
            else
            {
                this.monthCount = DateTime.Now.Month;
            }
            if (DTRequest.GetQueryInt("year") != 0)
            {
                this.yearCount = DTRequest.GetQueryInt("year");
            }
            else
            {
                this.yearCount = DateTime.Now.Year;
            }
            
            this.pageSize = this.GetPageSize(15);
            if (!this.Page.IsPostBack)
            {
                objectSite.DDLbind(base.siteConfig.sysgrade, this.ddlGrade, "=请选择年级=");
                DTcms.Model.manager model = GetAdminInfo();
                for (int i = 2016; i <= DateTime.Now.Year+2; i++)
                {
                    this.ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                this.bindTeach();
                this.bindXueGuan();
                if (this.stuid != 0)
                {
                    this.RptBind("id>0 and stu_id=" + this.stuid + this.CombSqlTxt(this.category_id, this.keywords, this.property, this.teacher,this.xueguan, this.kemu,this.yearCount.ToString(),this.monthCount.ToString(), this.start_time, this.end_time.ToString(), this.grade), "add_time desc");
                }
                else if (model.role_id != 1 && model.role_id != 10 && model.role_id != 16)
                {
                    this.RptBind("id>0 and stu_id in (select id from tb_student_info)  and manager_id=" + model.id + this.CombSqlTxt(this.category_id, this.keywords, this.property, this.teacher,this.xueguan, this.kemu, this.yearCount.ToString(), this.monthCount.ToString(), this.start_time.ToString(), this.end_time.ToString(), this.grade), "add_time desc");
                   
                }
                
                else
                {
                    this.RptBind("id>0 and stu_id in (select id from tb_student_info where xiaoqu=" + model.xiaoqu + ") " + this.CombSqlTxt(this.category_id, this.keywords, this.property, this.teacher, this.xueguan,this.kemu, this.yearCount.ToString(), this.monthCount.ToString(), this.start_time.ToString(), this.end_time.ToString(), this.grade), "add_time desc");
                }
            }
        }

        private void RptBind(string _strWhere, string _orderby)
        {
            
            
            
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            this.ddlTeacher.SelectedValue = this.teacher;
            this.ddlLesson.SelectedValue = this.kemu;
            this.ddlXueGuan.SelectedValue = this.xueguan;
            this.ddlMonth.SelectedValue = this.monthCount.ToString();
            this.ddlYear.SelectedValue = this.yearCount.ToString();
            this.txtStartTime.Text = this.start_time.ToString();
            this.txtEndTime.Text = this.end_time.ToString();
            this.ddlGrade.SelectedValue = this.grade;
            DTcms.BLL.lesson lesson = new DTcms.BLL.lesson();
            DataSet list = lesson.GetList(_strWhere);
            DataSet set2 = lesson.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataSource = set2.Tables[0];
            this.rptList.DataBind();
            for (int i = 0; i < list.Tables[0].Rows.Count; i++)
            {
                this.totalKeshi += decimal.Parse(list.Tables[0].Rows[i]["lesson_count"].ToString());
            }
            this.txtPageNum.Text = this.pageSize.ToString();
            string linkUrl = Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&start_time={7}&end_time={8}&stuid={9}&channel_id={10}&grade={11}&page={12}&leftkeshi={13}&xueguan={14}&user_id={15}", new string[] { this.category_id.ToString(), this.keywords, this.property, this.teacher, this.kemu, this.yearCount.ToString(), this.monthCount.ToString(), this.start_time.ToString(), this.end_time.ToString(), this.stuid.ToString(), this.channel_id.ToString(), this.ddlGrade.SelectedValue, "__id__", this.leftkeshi.ToString(),this.xueguan,this.user_id.ToString() });
            this.PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, linkUrl, 8);
        }

        protected void shanchu(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            base.ChkAdminLevel(this.channel_id, ActionEnum.Delete.ToString());
            DTcms.BLL.lesson lesson = new DTcms.BLL.lesson();
            string commandArgument = button.CommandArgument;
            lesson.Delete(int.Parse(commandArgument));
            JscriptMsg("删除成功！", Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&start_time={7}&end_time={8}&stuid={9}&channel_id={10}&grade={11}&leftkeshi={12}&xueguan={13}&user_id={14}", new string[] { this.category_id.ToString(), this.txtKeywords.Text, this.property, this.ddlTeacher.SelectedValue, this.ddlLesson.SelectedValue, this.yearCount.ToString(), this.monthCount.ToString(), this.txtStartTime.Text, this.txtEndTime.Text, this.stuid.ToString(), this.channel_id.ToString(), this.grade, this.leftkeshi.ToString(),this.xueguan,this.user_id.ToString() }), "Success");
        }

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int num;
            if (int.TryParse(this.txtPageNum.Text.Trim(), out num) && (num > 0))
            {
                Utils.WriteCookie("lesson_page_size", num.ToString(), 43200);
            }
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&start_time={7}&end_time={8}&stuid={9}&channel_id={10}&grade={11}&leftkeshi={12}&xueguan={13}&user_id={14}", new string[] { this.category_id.ToString(), this.keywords, this.property, this.ddlTeacher.SelectedValue, this.ddlLesson.SelectedValue, this.yearCount.ToString(), this.monthCount.ToString(), this.txtStartTime.Text, this.txtEndTime.Text, this.stuid.ToString(), this.channel_id.ToString(), this.grade, this.leftkeshi.ToString(),this.xueguan,this.user_id.ToString() }));
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&start_time={7}&end_time={8}&stuid={9}&channel_id={10}&grade={11}&leftkeshi={12}&xueguan={13}&user_id={14}", new string[] { this.category_id.ToString(), this.keywords, this.property, this.ddlTeacher.SelectedValue, this.ddlLesson.SelectedValue, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue, this.txtStartTime.Text, this.txtEndTime.Text, this.stuid.ToString(), this.channel_id.ToString(), this.grade, this.leftkeshi.ToString(),this.xueguan,this.user_id.ToString() }));
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "category_id={0}&keywords={1}&property={2}&teacher={3}&kemu={4}&year={5}&month={6}&start_time={7}&end_time={8}&stuid={9}&channel_id={10}&grade={11}&leftkeshi={12}&xueguan={13}&user_id={14}", new string[] { this.category_id.ToString(), this.keywords, this.property, this.ddlTeacher.SelectedValue, this.ddlLesson.SelectedValue, this.ddlYear.SelectedValue, this.ddlMonth.SelectedValue, this.txtStartTime.Text, this.txtEndTime.Text, this.stuid.ToString(), this.channel_id.ToString(), this.grade, this.leftkeshi.ToString(),this.xueguan,this.user_id.ToString() }));

        }

        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {

            string path = Utils.GetMapPath("/upload/myexcel.xls");//获取文件的路径信息
            using (var fileStream = new FileStream(path , FileMode.Create))
            {
                DataSet set = new BLL.lesson().GetList(0, " id>0 and stu_id in (select id from tb_student_info where xiaoqu=" + GetAdminInfo().xiaoqu + ") " + this.CombSqlTxt(this.category_id, this.keywords, this.property, this.teacher,this.xueguan, this.kemu, this.yearCount.ToString(), this.monthCount.ToString(), this.start_time.ToString(), this.end_time.ToString(), this.grade), "add_time desc");
                DataTable list = set.Tables[0];

                var pack = new ExcelPackage();
                var ws = pack.Workbook.Worksheets.Add("课时安排管理");//新建表格

                //var col = 1;
                var row = 1;
                ws.Cells[1, 1].Value = "上课日期";
                ws.Cells[1, 2].Value = "上课时间";
                ws.Cells[1, 3].Value = "课时";
                ws.Cells[1, 4].Value = "学生姓名";//表格头部
                ws.Cells[1, 5].Value = "年级";//表格头部
                ws.Cells[1, 6].Value = "上课老师";//表格头部
                ws.Cells[1, 7].Value = "科目";//表格头部

                List<string> clos = new List<string>() { "", "lesson_date", "lesson_time", "lesson_count", "stu_id", "stu_id", "manager_name", "lesson_name" };

                row++;
                //循环写入数据到表格
                foreach (var coachBatchPayoutExcelModel in list.AsEnumerable())
                {
                    var s = 2;
                    for (var i = 1; i < 8; i++)
                    {
                        var colName = ws.Cells[1, i].Value.ToString();
                        if (i == 1)
                        {
                            ws.Cells[row, i].Value = coachBatchPayoutExcelModel.ItemArray[s] == null ? "" : DateTime.Parse(coachBatchPayoutExcelModel[clos[i]].ToString()).ToString("yyyy-MM-dd");
                        }
                        else if (i == 4)
                        {
                            string stuname = new DTcms.BLL.student_info().GetModel(int.Parse(coachBatchPayoutExcelModel[clos[i]].ToString())) == null ? "" : new DTcms.BLL.student_info().GetModel(int.Parse(coachBatchPayoutExcelModel[clos[i]].ToString())).stu_name;
                            ws.Cells[row, i].Value = coachBatchPayoutExcelModel.ItemArray[s] == null ? "" : stuname;
                        }
                        else if (i == 5)
                        {
                            string stugrade = new DTcms.BLL.student_info().GetModel(int.Parse(coachBatchPayoutExcelModel[clos[i]].ToString())) == null ? "" : new DTcms.BLL.student_info().GetModel(int.Parse(coachBatchPayoutExcelModel[clos[i]].ToString())).stu_grade;
                            ws.Cells[row, i].Value = coachBatchPayoutExcelModel.ItemArray[s] == null ? "" : stugrade;
                        }
                        else
                        {
                            ws.Cells[row, i].Value = coachBatchPayoutExcelModel.ItemArray[s] == null ? "" : coachBatchPayoutExcelModel[clos[i]].ToString();
                        }
                        s++;
                    }
                    row++;
                }

                var byarrary = pack.GetAsByteArray();
                fileStream.Write(byarrary, 0, byarrary.Length);
                fileStream.Flush();


            };
            //以下为输出文件的代码
            FileInfo file = new FileInfo(path);//路径
            Context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //解决中文乱码
            Context.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode("myexcel.xls")); //解决中文文件名乱码    
            Context.Response.AddHeader("Content-length", file.Length.ToString());
            Context.Response.ContentType = "application/vnd.ms-excel";//MIME类型
            Context.Response.WriteFile(file.FullName);
            Context.Response.End();
           
        }
    }
}