using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
namespace DTcms.Web.admin.student
{
    public partial class list_fp : DTcms.Web.UI.ManagePage
    {
        protected int channel_id;
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string grade = string.Empty;

        protected int category_id;
        protected string property = string.Empty;
        protected string keywords = string.Empty;
        protected string xueguan = string.Empty;
        protected string shaixuan = string.Empty;
        protected string zeorHuiFan = string.Empty;
        protected string twoHuiFan = string.Empty;

        protected int monthCount = 0;//月份统计数
        protected int yearCount;//年份统计
        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");
            this.xueguan = DTRequest.GetQueryString("xueguan");
            this.grade = DTRequest.GetQueryString("grade");
            this.zeorHuiFan = DTRequest.GetQueryString("zeorHuiFan");
            this.twoHuiFan = DTRequest.GetQueryString("twoHuiFan");
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
               
                objectSite.DDLbind(siteConfig.sysgrade, ddlGrade, "=请选择年级=");
                for (int i = 2013; i <= DateTime.Now.Year; i++)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                ChkAdminLevel(channel_id, ActionEnum.View.ToString()); //检查权限
                bindTeach();
                RptBind("id>0 and audit_stutas=1" + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property, this.xueguan, this.grade), "Expr2 desc");
            }
        }


        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _channel_id, int _category_id, string _keywords, string _property,string _xueguan,string _grade)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.Append(" and contract_status=0 ");
            //if (_channel_id > 0)
            //{
            //    strTemp.Append(" and channel_id=" + channel_id);
            //}
            //if (!string.IsNullOrEmpty(_property)) 
            //{
            //    strTemp.Append(" and contract='" + _property + "'");
            //}
            //_keywords = _keywords.Replace("'", "");
            if (shaixuan == "stu" && !string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and  stu_name  like '%" + _keywords + "%'");
            }
            else if (shaixuan == "xuexiao" && !string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and  stu_school  like '%" + _keywords + "%'");
            }
            if (!string.IsNullOrEmpty(zeorHuiFan))
            {
                strTemp.Append(" and stu_id not in(select stu_id from tb_student_return where return_user_id in(select id from dt_manager where role_id=10))");
            }
            if (!string.IsNullOrEmpty(twoHuiFan))
            {
                strTemp.Append(" and  stu_id in(select stu_id from tb_student_return where datediff(dd,add_time ,getdate())<2 and  return_user_id in(select id from dt_manager where role_id=10))");
            }
            if (!string.IsNullOrEmpty(_xueguan))
            {
                strTemp.Append(" and  id in(select stu_id from tb_student_teach where manager_id= " + _xueguan + ")");
            }
            if (!string.IsNullOrEmpty(_grade))
            {
                strTemp.Append(" and  stu_grade='" + _grade + "'");
            }
            return strTemp.ToString();
        }
        #endregion

        //筛选属性
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&xueguan={4}&grade={5}&zeorHuiFan={6}&shaixuan={7}&twoHuiFan={8}&month={9}&year={10}",
               this.channel_id.ToString(), this.category_id.ToString(), this.keywords, ddlProperty.SelectedValue,this.ddlXueGuan.SelectedValue,this.ddlGrade.SelectedValue,this.zeorHuiFan,this.ddlShouSou.SelectedValue,this.twoHuiFan,this.monthCount.ToString(),this.yearCount.ToString()));
        }


        protected decimal getTotalKeShi(int stuid)
        {
            DTcms.BLL.student_contract bll = new BLL.student_contract();
            return bll.getLessonCount("stu_id=" + stuid + " and audit_stutas=1");
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            this.ddlShouSou.SelectedValue = this.shaixuan;
            this.ddlGrade.SelectedValue = this.grade;
            this.ddlProperty.SelectedValue = this.property;
            this.ddlMonth.SelectedValue = monthCount.ToString();
            this.ddlYear.SelectedValue = yearCount.ToString();
            this.ddlXueGuan.SelectedValue = xueguan;
            BLL.student_contract bll = new BLL.student_contract();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&xueguan={4}&grade={5}&shaixuan={6}&zeorHuiFan={7}&twoHuiFan={8}&month={9}&year={10}&page={11}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.xueguan,this.grade,this.shaixuan,this.zeorHuiFan,this.twoHuiFan,this.monthCount.ToString(),this.yearCount.ToString(),"__id__");
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
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&xueguan={4}&grade={5}&shaixuan={6}&zeorHuiFan={7}&twoHuiFan={8}&month={9}&year={10}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property,this.xueguan,this.grade,this.ddlShouSou.SelectedValue,this.zeorHuiFan,this.twoHuiFan,this.monthCount.ToString(),this.yearCount.ToString()));
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
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&xueguan={4}&grade={5}&shaixuan={6}&zeorHuiFan={7}&twoHuiFan={8}&month={9}&year={10}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.xueguan,this.grade,this.shaixuan,this.zeorHuiFan,this.twoHuiFan,this.monthCount.ToString(),this.yearCount.ToString()));
        }
        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkAdminLevel1(channel_id, ActionEnum.Delete.ToString())) //检查权限
            {
                JscriptMsg("您没有改项权限，操作失败！", "", "Erorr");
                return;
            }
            BLL.student_info bll = new BLL.student_info();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete( id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&xueguan={4}&grade={5}&shaixuan={6}&zeorHuiFan={7}&twoHuiFan={8}&month={9}&year={10}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.xueguan,this.grade,this.shaixuan,this.zeorHuiFan,this.twoHuiFan,this.monthCount.ToString(),this.yearCount.ToString()), "Success");
        }

        //批量审核
        protected void btnDelete1_Click(object sender, EventArgs e)
        {
            if (!ChkAdminLevel1(channel_id, ActionEnum.Delete.ToString())) //检查权限
            {
                JscriptMsg("您没有改项权限，操作失败！", "", "Erorr");
                return;
            }
            BLL.student_contract bll_contract = new BLL.student_contract();
            
            BLL.student_info bll = new BLL.student_info();

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int contract_id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidcontract_id")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    Model.student_contract student_contract = bll_contract.GetModel(contract_id);
                    bll_contract.UpdateField(contract_id,"status=1");
                    bll.UpdateField(id, "stu_lesson=stu_lesson+" + student_contract.contract_lesson);
                }
            }
            JscriptMsg("批量审核成功啦！", Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&xueguan={4}&grade={5}&shaixuan={6}&zeorHuiFan={7}&twoHuiFan={8}&month={9}&year={10}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.xueguan,this.grade,this.shaixuan,this.zeorHuiFan,this.twoHuiFan,this.monthCount.ToString(),this.yearCount.ToString()), "Success");
        }

        /// <summary>
        ///  获取学生剩余课时数
        /// </summary>
        /// <returns></returns>
        protected decimal getKeShi(int stuid)
        {
            DTcms.BLL.lesson bll = new BLL.lesson();
            return bll.GetLettonCount("stu_id=" + stuid);
        }

        protected int getReturnMonth(int stuid, int month, int year)
        {
            DTcms.BLL.student_return bll = new BLL.student_return();
            return bll.getReturnCountByMonth(" stu_id=" + stuid + " and return_user_id in(select id from dt_manager where role_id=10)  and year(add_time)=" + year + "and month(add_time)=" + month);
        }

        protected int getReturnCount(int stuid)
        {
            DTcms.BLL.student_return bll = new BLL.student_return();
            return bll.getReturnCountByMonth(" stu_id=" + stuid + " and return_user_id in(select id from dt_manager where role_id=10)");
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&xueguan={6}&grade={7}&shaixuan={8}&zeorHuiFan={9}&twoHuiFan={10}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue,ddlXueGuan.SelectedValue,this.ddlGrade.SelectedValue,this.shaixuan,this.zeorHuiFan,this.twoHuiFan));
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&xueguan={6}&grade={7}&shaixuan={8}&zeorHuiFan={9}&twoHuiFan={10}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue,ddlXueGuan.SelectedValue,this.ddlGrade.SelectedValue,this.shaixuan,this.zeorHuiFan,this.twoHuiFan));
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

        public void bindTeach()
        {
            DataTable dt = new BLL.manager().GetList("role_id=12").Tables[0];
            this.ddlXueGuan.DataSource = dt;
            ddlXueGuan.DataTextField = "real_name";
            ddlXueGuan.DataValueField = "id";
            ddlXueGuan.DataBind();

            ddlXueGuan.Items.Insert(0, new ListItem("=选择学管师=", ""));
        }


        protected void ddlXueGuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&xueguan={6}&grade={7}&shaixuan={8}&zeorHuiFan={9}&twoHuiFan={10}",
           this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue,ddlXueGuan.SelectedValue,this.ddlGrade.SelectedValue,this.ddlShouSou.SelectedValue,this.zeorHuiFan,this.twoHuiFan));
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&xueguan={6}&grade={7}&shaixuan={8}&zeorHuiFan={9}&twoHuiFan={10}",
           this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlXueGuan.SelectedValue, this.ddlGrade.SelectedValue,this.ddlShouSou.SelectedValue,this.zeorHuiFan,this.twoHuiFan));

        }

        /// <summary>
        /// 筛选出0次回访的人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void zeorHuiFan_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&xueguan={6}&grade={7}&shaixuan={8}&zeorHuiFan={9}&twoHuiFan={10}",
          this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlXueGuan.SelectedValue, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue, linkButton.CommandArgument,this.twoHuiFan));

        }

        protected void lbTwo_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&xueguan={6}&grade={7}&shaixuan={8}&zeorHuiFan={9}&twoHuiFan={10}",
          this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlXueGuan.SelectedValue, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue,this.zeorHuiFan, linkButton.CommandArgument));

        }

        protected void lbAll_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&xueguan={6}&grade={7}&shaixuan={8}&zeorHuiFan={9}&twoHuiFan={10}",
         this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlXueGuan.SelectedValue, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue, "", ""));

        }
    }
}