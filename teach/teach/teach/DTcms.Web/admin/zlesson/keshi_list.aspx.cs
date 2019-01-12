using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Text;
using System.Data;
using System.IO;
using OfficeOpenXml;

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
        protected string zeroKeshi = string.Empty;
        protected string tweenKeShi = string.Empty;

        protected int category_id;
        protected string property = string.Empty;
        protected string keywords = string.Empty;
        protected string grade = string.Empty;
        protected string zeroMonthKeShi = string.Empty;
        protected Model.manager model = new Model.manager();
        protected void Page_Load(object sender, EventArgs e)
        {
             model = GetAdminInfo();
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");
            this.grade = DTRequest.GetQueryString("grade");
            this.shaixuan = DTRequest.GetQueryString("shaixuan");
            this.xueguan = DTRequest.GetQueryString("xueguan");
            this.zeroKeshi = DTRequest.GetQueryString("zeroKeshi");
            this.tweenKeShi = DTRequest.GetQueryString("tweenKeShi");
            this.zeroMonthKeShi = DTRequest.GetQueryString("zeroMonthKeShi");
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
              
                DataTable dt = new BLL.manager().GetList("role_id=12 and is_lock=0 and xiaoqu=" + model.xiaoqu).Tables[0];
                this.ddlXueGuan.DataSource = dt;
                this.ddlXueGuan.DataTextField = "real_name";
                this.ddlXueGuan.DataValueField = "id";
                this.ddlXueGuan.DataBind();
                this.ddlXueGuan.Items.Insert(0, new ListItem("=请选择学管师=", ""));
                objectSite.DDLbind(siteConfig.sysgrade, ddlGrade, "=请选择年级=");
                for (int i = 2016; i <= DateTime.Now.Year+2; i++)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                
                ChkAdminLevel(channel_id, ActionEnum.View.ToString()); //检查权限
                if (model.role_id != 1 && model.role_id != 10 && model.role_id != 16)
                {
                    RptBind("id>0 and id in(select stu_id from tb_student_contract where audit_stutas=1) and id in (select stu_id from tb_student_teach where lesson='' and manager_id=" + model.id + " )" + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property,this.grade,this.xueguan), "add_time desc");
                    this.ddlXueGuan.Visible = false;
                }
                
                else
                {
                    RptBind("id>0 and id in(select stu_id from tb_student_contract where audit_stutas=1 and xiaoqu=" + model.xiaoqu + ")" + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property, this.grade, this.xueguan), "add_time desc");
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
            if (!string.IsNullOrEmpty(zeroKeshi))
            {
                strTemp.Append(" and id  in(   select stu_id from(select isnull(m.countlesson,0)-isnull(n.countlesson,0) leftlesson, m.stu_id  from ( select stu_id ,sum(contract_lesson) countlesson from tb_student_contract group by stu_id  ) m full join (select stu_id ,sum(lesson_count) countlesson from tb_lesson group by stu_id)n on m.stu_id=n.stu_id )a where a.leftlesson=0 )");
            }
            if (!string.IsNullOrEmpty(tweenKeShi))
            {
                strTemp.Append(" and id  in(   select stu_id from(select isnull(m.countlesson,0)-isnull(n.countlesson,0) leftlesson, m.stu_id  from ( select stu_id ,sum(contract_lesson) countlesson from tb_student_contract group by stu_id  ) m full join (select stu_id ,sum(lesson_count) countlesson from tb_lesson group by stu_id)n on m.stu_id=n.stu_id )a where 20>a.leftlesson and 0<a.leftlesson )");
            }
            if (!string.IsNullOrEmpty(_grade))
            {
                strTemp.Append(" and  stu_grade='" + _grade + "'");
            }
            if (!string.IsNullOrEmpty(zeroMonthKeShi))
            {
                strTemp.Append(" and  id not in (select stu_id from tb_lesson where year(lesson_date)=" + this.yearCount + " and month(lesson_date)=" + this.monthCount + " and xiaoqu=" + GetAdminInfo().xiaoqu + " )  and id not in(select stu_id from tb_give_lesson where year(lesson_date)=" + this.yearCount + " and month(lesson_date)=" + this.monthCount + " and xiaoqu=" + GetAdminInfo().xiaoqu + " )");
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
            string pageUrl = Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&grade={6}&shaixuan={7}&xueguan={8}&zeroMonthKeShi={9}&zeroKeshi={10}&tweenKeShi={11}&page={12}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.monthCount.ToString(),this.yearCount.ToString(),this.grade,this.ddlShouSou.SelectedValue,this.xueguan,this.zeroMonthKeShi,this.zeroKeshi,this.tweenKeShi, "__id__");
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
            Response.Redirect(Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&grade={6}&shaixuan={7}&xueguan={8}&zeroMonthKeShi={9}&zeroKeshi={10}&tweenKeShi={11}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property,this.monthCount.ToString(),this.yearCount.ToString(),this.grade,this.ddlShouSou.SelectedValue,this.xueguan,this.zeroMonthKeShi,this.zeroKeshi,this.tweenKeShi));
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
            Response.Redirect(Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&grade={6}&shaixuan={7}&xueguan={8}&zeroMonthKeShi={9}&zeroKeshi={10}&tweenKeShi={11}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.monthCount.ToString(),this.yearCount.ToString(),this.grade,this.ddlShouSou.SelectedValue,this.xueguan,this.zeroMonthKeShi,this.zeroKeshi,this.tweenKeShi));
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

        /// <summary>
        /// 获取学生已上赠送课时数
        /// </summary>
        /// <param name="stuid"></param>
        /// <returns></returns>
        protected decimal getGiveKeShi(int stuid)
        {
            DTcms.BLL.give_lesson bll = new BLL.give_lesson();

            return bll.GetLettonCount("stu_id=" + stuid);
        }
        /// <summary>
        /// 获取总课时
        /// </summary>
        /// <param name="stuid"></param>
        /// <returns></returns>
        protected decimal getTotalKeShi(int stuid)
        {
            DTcms.BLL.student_contract bll = new BLL.student_contract();
            return bll.getLessonCount("stu_id=" + stuid + " and audit_stutas=1");
        }
        /// <summary>
        /// 获取总赠送课时
        /// </summary>
        /// <param name="stuid"></param>
        /// <returns></returns>
        protected decimal getTotalGiveKeShi(int stuid)
        {
            DTcms.BLL.student_contract bll = new BLL.student_contract();
            return bll.getGiveLessonCount("stu_id=" + stuid + " and audit_stutas=1");
        }

        /// <summary>
        /// 获取月份新签课时
        /// </summary>
        /// <param name="stuid"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        protected decimal getKeShiMonth(int stuid,int month,int year)
        {
            DTcms.BLL.lesson bll = new BLL.lesson();
            return bll.GetLettonCount("stu_id =" + stuid + " and keshi_status=0 and year(lesson_date)=" + year + "and month(lesson_date)=" + month );
        }

        protected decimal getGiveKeShiMonth(int stuid, int month, int year)
        {
            DTcms.BLL.give_lesson bll = new BLL.give_lesson();
            return bll.GetLettonCount("stu_id =" + stuid + "  and year(lesson_date)=" + year + "and month(lesson_date)=" + month);
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
            Response.Redirect(Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&grade={6}&shaixuan={7}&xueguan={8}&zeroMonthKeShi={9}&zeroKeshi={10}&tweenKeShi={11}",
           this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue,ddlYear.SelectedValue,this.ddlGrade.SelectedValue,this.ddlShouSou.SelectedValue,this.xueguan,this.zeroMonthKeShi,this.zeroKeshi,this.tweenKeShi));
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&grade={6}&shaixuan={7}&xueguan={8}&zeroMonthKeShi={9}&zeroKeshi={10}&tweenKeShi={11}",
           this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue, this.xueguan,this.zeroMonthKeShi,this.zeroKeshi,this.tweenKeShi));
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&grade={6}&shaixuan={7}&xueguan={8}&zeroMonthKeShi={9}&zeroKeshi={10}&tweenKeShi={11}",
          this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue,this.xueguan,this.zeroMonthKeShi,this.zeroKeshi,this.tweenKeShi));

        }

        protected Model.student_teach getXueGuanName(int stu_id)
        {
            DTcms.BLL.student_teach bll = new BLL.student_teach();
            Model.student_teach model = new Model.student_teach();
            DataSet ds = bll.GetList(1, "stu_id=" + stu_id + " and lesson=''", "id");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model= bll.GetModel(int.Parse(ds.Tables[0].Rows[0]["id"].ToString()));
                
            }
            return model;
        }

        protected void ddlXueGuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&grade={6}&shaixuan={7}&xueguan={8}&zeroMonthKeShi={9}&zeroKeshi={10}&tweenKeShi={11}",
         this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue, this.ddlXueGuan.SelectedValue,this.zeroMonthKeShi,this.zeroKeshi,this.tweenKeShi));

        }

        protected void zeroMonthKeshi_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            Response.Redirect(Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&month={1}&year={2}&zeroMonthKeShi={3}",
          this.channel_id.ToString(), this.monthCount.ToString(), this.yearCount.ToString(), linkButton.CommandArgument));

        }

        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {

            //string path = Utils.GetMapPath("/upload/myexcel.xlss");//获取文件的路径信息
            //using (var fileStream = new FileStream(path, FileMode.Create))
            //{
            //    DataSet set = new BLL.student_info().GetList(0, " id>0 and id in(select stu_id from tb_student_contract where audit_stutas=1 and xiaoqu=" + model.xiaoqu+ ")" + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property, this.grade, this.xueguan), "add_time desc");
            //    DataTable list = set.Tables[0];

            //    var pack = new ExcelPackage();
            //    var ws = pack.Workbook.Worksheets.Add("课时安排管理");//新建表格

            //    //var col = 1;
            //    var row = 1;
            //    ws.Cells[1, 1].Value = "学生姓名";
            //    ws.Cells[1, 2].Value = "学管师";
            //    ws.Cells[1, 3].Value = "学校";
            //    ws.Cells[1, 4].Value = "年级";//表格头部
            //    ws.Cells[1, 5].Value = "已上课时";//表格头部
            //    ws.Cells[1, 6].Value = "剩余课时";//表格头部
            //    ws.Cells[1, 7].Value = "剩余赠送课时";//表格头部
            //    ws.Cells[1, 8].Value = "月份课时数";//表格头部
            //    ws.Cells[1, 9].Value = "新签课时收入";//表格头部
            //    ws.Cells[1, 10].Value = "续费课时收入";//表格头部

            //    List<string> clos = new List<string>() { "stu_name", "lesson_date", "lesson_time", "lesson_count", "stu_id", "stu_id", "manager_name", "lesson_name" };

            //    row++;
            //    //循环写入数据到表格
            //    foreach (var coachBatchPayoutExcelModel in list.AsEnumerable())
            //    {
            //        var s = 2;
            //        for (var i = 1; i < 11; i++)
            //        {
            //            var colName = ws.Cells[1, i].Value.ToString();
            //            if (i == 1)
            //            {
            //                ws.Cells[row, i].Value = coachBatchPayoutExcelModel.ItemArray[s] == null ? "" : DateTime.Parse(coachBatchPayoutExcelModel[clos[i]].ToString()).ToString("yyyy-MM-dd");
            //            }
            //            else if (i == 4)
            //            {
            //                string stuname = new DTcms.BLL.student_info().GetModel(int.Parse(coachBatchPayoutExcelModel[clos[i]].ToString())) == null ? "" : new DTcms.BLL.student_info().GetModel(int.Parse(coachBatchPayoutExcelModel[clos[i]].ToString())).stu_name;
            //                ws.Cells[row, i].Value = coachBatchPayoutExcelModel.ItemArray[s] == null ? "" : stuname;
            //            }
            //            else if (i == 5)
            //            {
            //                string stugrade = new DTcms.BLL.student_info().GetModel(int.Parse(coachBatchPayoutExcelModel[clos[i]].ToString())) == null ? "" : new DTcms.BLL.student_info().GetModel(int.Parse(coachBatchPayoutExcelModel[clos[i]].ToString())).stu_grade;
            //                ws.Cells[row, i].Value = coachBatchPayoutExcelModel.ItemArray[s] == null ? "" : stugrade;
            //            }
            //            else
            //            {
            //                ws.Cells[row, i].Value = coachBatchPayoutExcelModel.ItemArray[s] == null ? "" : coachBatchPayoutExcelModel[clos[i]].ToString();
            //            }
            //            s++;
            //        }
            //        row++;
            //    }

            //    var byarrary = pack.GetAsByteArray();
            //    fileStream.Write(byarrary, 0, byarrary.Length);
            //    fileStream.Flush();


            //};
            ////以下为输出文件的代码
            //FileInfo file = new FileInfo(path);//路径
            //Context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //解决中文乱码
            //Context.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode("myexcel.xls")); //解决中文文件名乱码    
            //Context.Response.AddHeader("Content-length", file.Length.ToString());
            //Context.Response.ContentType = "application/vnd.ms-excel";//MIME类型
            //Context.Response.WriteFile(file.FullName);
            //Context.Response.End();

        }

        protected void zeroLeftKeshi_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            Response.Redirect(Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&grade={6}&shaixuan={7}&xueguan={8}&zeroMonthKeShi={9}&zeroKeshi={10}&tweenKeShi={11}",
           this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue, this.ddlXueGuan.SelectedValue, this.zeroMonthKeShi, linkButton.CommandArgument, ""));

        }

        protected void LeftKeshitween_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            Response.Redirect(Utils.CombUrlTxt("keshi_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&grade={6}&shaixuan={7}&xueguan={8}&zeroMonthKeShi={9}&zeroKeshi={10}&tweenKeShi={11}",
           this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue, this.ddlXueGuan.SelectedValue, this.zeroMonthKeShi,"",linkButton.CommandArgument));

        }
        
    }
}