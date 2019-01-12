using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using System.IO;
using OfficeOpenXml;


namespace DTcms.Web.admin.zlesson
{
    public partial class teacher_wages : DTcms.Web.UI.ManagePage
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
                    RptBind(" YEAR(lesson_date)=" + yearCount + " and MONTH(lesson_date)=" + monthCount  + " and manager_id=" + model.id + CombSqlTxt(this.channel_id, this.keywords, this.teacher,this.grade), "  stu_id desc");
                }
                else
                {
                    RptBind(" YEAR(lesson_date)=" + yearCount + " and MONTH(lesson_date)=" + monthCount + " and manager_id in(select id from dt_manager where role_id=11 and is_jianzhi=0 and is_lock=0) and xiaoqu=" + model.xiaoqu + CombSqlTxt(this.channel_id, this.keywords, this.teacher,this.grade), "  stu_id desc");
                }
            }

        }
        public decimal getKeShiMultiple(int stu_id)
        {
           
            BLL.student_contract contact_bll = new BLL.student_contract();
            DataSet ds = contact_bll.GetList(1, " keshi_multiple>0 and audit_stutas=1 and stu_id=" + stu_id, "audit_date");
            if (ds.Tables[0].Rows.Count > 0)
            {
                decimal x = decimal.Parse(ds.Tables[0].Rows[0]["keshi_multiple"].ToString());
                return decimal.Parse(ds.Tables[0].Rows[0]["keshi_multiple"].ToString());
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 获取教师工资区间
        /// </summary>
        /// <param name="total_lesson">总课时</param>
        /// <returns></returns>
        public decimal GetWages(int manager_id,string grade)
        {
            
          
            BLL.lesson lesson_bll = new BLL.lesson();
            decimal total_lesson = lesson_bll.GetLettonCount(" manager_id=" + manager_id + " and year(lesson_date)="+yearCount +" and month(lesson_date)="+monthCount);
            decimal total_give_lesson = new BLL.give_lesson().GetLettonCount(" manager_id=" + manager_id + " and year(lesson_date)=" + yearCount + " and month(lesson_date)=" + monthCount);

            BLL.tb_wages_set bll_wages_set = new BLL.tb_wages_set();
            decimal wages = bll_wages_set.GetWages(total_lesson + total_give_lesson, " grade like '%" + grade + "%'");//获取工资档位

            return wages;

           
        }
        /// <summary>
        /// 获取激励金额
        /// </summary>
        /// <param name="manager_id"></param>
        /// <returns></returns>
        public decimal GetJiLiWages(string stu_id, string manager_id)
        {
            BLL.lesson lesson_bll = new BLL.lesson();
            decimal total_lesson = lesson_bll.GetLettonCount(" manager_id=" + manager_id + " and year(lesson_date)>=2018 and month(lesson_date)<=" + monthCount.ToString() + " and stu_id=" + stu_id);
            decimal total_give_lesson = new BLL.give_lesson().GetLettonCount(" manager_id=" + manager_id + " and year(lesson_date)>=2018 and month(lesson_date)<=" + monthCount.ToString() + " and stu_id=" + stu_id);
         
            BLL.tb_keshi_jili bll_keshi_jili = new BLL.tb_keshi_jili();
            decimal jili = bll_keshi_jili.GetJiLi(total_lesson + total_give_lesson);//获取当月的激励

            decimal total_begin = bll_keshi_jili.GetJiLiStart(total_lesson + total_give_lesson);

            //decimal jili_wages = jili * (total_lesson + total_give_lesson - total_begin);
            decimal jili_wages = jili * (total_lesson + total_give_lesson );
            return jili_wages;
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
                total_wages += GetWages(int.Parse(row["manager_id"].ToString()), new DTcms.BLL.student_info().GetModel(int.Parse(row["stu_id"].ToString())) == null ? "" : new DTcms.BLL.student_info().GetModel(int.Parse(row["stu_id"].ToString())).stu_grade) * decimal.Parse(row["lesson_count"].ToString())*getKeShiMultiple(int.Parse(row["stu_id"].ToString()));
                total_jili += (GetJiLi(row["stu_id"].ToString(), row["manager_id"].ToString()) * decimal.Parse(row["lesson_count"].ToString()));
                total_keshi += decimal.Parse(row["lesson_count"].ToString());
            }
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("teacher_wages.aspx", "channel_id={0}&keywords={1}&teacher={2}&year={3}&month={4}&grade={5}&page={6}",
                this.channel_id.ToString(), this.keywords,this.teacher,this.yearCount.ToString(),this.monthCount.ToString(),this.grade, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _channel_id, string _keywords,string _teacher,string _grade)
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
            Response.Redirect(Utils.CombUrlTxt("teacher_wages.aspx", "channel_id={0}&keywords={1}&teacher={2}&year={3}&month={4}&grade={5}",
                this.channel_id.ToString(), txtKeywords.Text,this.teacher,this.yearCount.ToString(),this.monthCount.ToString(),this.grade));
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
            Response.Redirect(Utils.CombUrlTxt("teacher_wages.aspx", "channel_id={0}&keywords={1}&teacher={2}&year={3}&month={4}&grade={5}",
            this.channel_id.ToString(), this.keywords,this.teacher,this.yearCount.ToString(),this.monthCount.ToString(),this.grade));
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("teacher_wages.aspx", "channel_id={0}&keywords={1}&month={2}&year={3}&teacher={4}&grade={5}",
          this.channel_id.ToString(), this.keywords, ddlMonth.SelectedValue, ddlYear.SelectedValue,this.teacher,this.grade));
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("teacher_wages.aspx", "channel_id={0}&keywords={1}&month={2}&year={3}&teacher={4}&grade={5}",
          this.channel_id.ToString(), this.keywords, ddlMonth.SelectedValue, ddlYear.SelectedValue,this.teacher,this.grade));
        }

        protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("teacher_wages.aspx", "channel_id={0}&keywords={1}&month={2}&year={3}&teacher={4}&grade={5}", new string[] { this.channel_id.ToString(), this.keywords, this.monthCount.ToString(), this.yearCount.ToString(), ddlTeacher.SelectedValue ,this.grade}));
        }
        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("teacher_wages.aspx", "channel_id={0}&keywords={1}&month={2}&year={3}&teacher={4}&grade={5}", new string[] { this.channel_id.ToString(), this.keywords, this.monthCount.ToString(), this.yearCount.ToString(), this.teacher, ddlGrade.SelectedValue }));
        }

        public void bindTeach()
        {
            Model.manager model = GetAdminInfo();
            DataTable dt = new DTcms.BLL.manager().GetList("role_id=11 and is_jianzhi=0 and is_lock=0" + "and xiaoqu=" + model.xiaoqu).Tables[0];
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

        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {

            string path = Utils.GetMapPath("/upload/myexcel.xlss");//获取文件的路径信息
            BLL.lesson bll = new BLL.lesson();
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                DataSet set = bll.GetWagesList(1000, 1, " YEAR(lesson_date)=" + yearCount + " and MONTH(lesson_date)=" + monthCount + " and manager_id in(select id from dt_manager where role_id=11 and is_jianzhi=0 and is_lock=0) and xiaoqu=" + model.xiaoqu + CombSqlTxt(this.channel_id, this.keywords, this.teacher, this.grade), " stu_id desc", out this.totalCount);
                DataTable list = set.Tables[0];

                var pack = new ExcelPackage();
                var ws = pack.Workbook.Worksheets.Add("全职老师工资");//新建表格

                //var col = 1;
                var row = 1;
                ws.Cells[1, 1].Value = "教师";
                ws.Cells[1, 2].Value = "学生";
                ws.Cells[1, 3].Value = "年级";
                ws.Cells[1, 4].Value = "课时";//表格头部
                ws.Cells[1, 5].Value = "年份";//表格头部
                ws.Cells[1, 6].Value = "月份";//表格头部
                ws.Cells[1, 7].Value = "课时单价";//表格头部
                ws.Cells[1, 8].Value = "课时工资";//表格头部
                ws.Cells[1, 9].Value = "课时激励";//表格头部


                List<string> clos = new List<string>() { "manager_name", "stu_id", "lesson_time", "lesson_count", "stu_id", "stu_id", "manager_name", "lesson_name" };

                row++;
                //循环写入数据到表格
                foreach (var coachBatchPayoutExcelModel in list.AsEnumerable())
                {
                    var s = 2;
                    for (var i = 1; i < 11; i++)
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