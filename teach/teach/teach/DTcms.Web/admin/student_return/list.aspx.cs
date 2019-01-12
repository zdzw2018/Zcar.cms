using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.student_return
{
    public partial class list : DTcms.Web.UI.ManagePage
    {
        protected int channel_id;
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string grade = string.Empty;
        protected string xueguan = string.Empty;

        protected int category_id;
        protected string property = string.Empty;
        protected string keywords = string.Empty;
        protected int monthCount = 0;//月份统计数
        protected int yearCount;//年份统计
        protected string shaixuan = string.Empty;
        protected string sevenHuiFan = string.Empty;
        protected string twoHuiFan = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");
            this.shaixuan = DTRequest.GetQueryString("shaixuan");
            this.grade = DTRequest.GetQueryString("grade");
            this.sevenHuiFan = DTRequest.GetQueryString("sevenHuiFan");
            this.xueguan = DTRequest.GetQueryString("xueguan");
            this.twoHuiFan = DTRequest.GetQueryString("twoHuiFan");

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
                Model.manager model = GetAdminInfo();
                DataTable dt = new BLL.manager().GetList("role_id=12 and is_lock=0 and xiaoqu=" + model.xiaoqu).Tables[0];
                this.ddlXueGuan.DataSource = dt;
                this.ddlXueGuan.DataTextField = "real_name";
                this.ddlXueGuan.DataValueField = "id";
                this.ddlXueGuan.DataBind();
                this.ddlXueGuan.Items.Insert(0, new ListItem("=请选择学管师=", ""));
                objectSite.DDLbind(siteConfig.sysgrade, ddlGrade, "=请选择年级=");
                
                ChkAdminLevel(channel_id, ActionEnum.View.ToString()); //检查权限
                for (int i = 2016; i <= DateTime.Now.Year+2; i++)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                if (model.role_id != 1 & model.role_id != 10 && model.role_id != 16)
                {
                    RptBind("id>0 and id in(select stu_id from tb_student_contract where audit_stutas=1) and id in (select stu_id from tb_student_teach where lesson='' and manager_id=" + model.id + " )" + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property, this.grade, this.xueguan), "add_time desc");
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
            //if (_channel_id > 0)
            //{
            //    strTemp.Append(" and channel_id=" + channel_id);
            //}
            //if (!string.IsNullOrEmpty(_property)) 
            //{
            //    strTemp.Append(" and contract='" + _property + "'");
            //}
            if (!string.IsNullOrEmpty(_grade))
            {
                strTemp.Append(" and  stu_grade='" + _grade + "'");
            }
            if (!string.IsNullOrEmpty(_xueguan))
            {
                strTemp.Append(" and  id in (select stu_id from tb_student_teach where manager_id='" + _xueguan + "' and lesson='')");
            }
            if (!string.IsNullOrEmpty(sevenHuiFan))
            {
                strTemp.Append(" and  (id in(select  stu_id  from tb_student_return group by stu_id having datediff(dd,max(add_time) ,getdate())>7 ) or id not in(select stu_id from tb_student_return ))");
            }
            if (!string.IsNullOrEmpty(twoHuiFan))
            {
                strTemp.Append(" and  id in(select stu_id  from tb_student_return group by stu_id having datediff(dd,max(add_time) ,getdate())<2 )");
            }
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
            //this.ddlProperty.SelectedValue = this.property;
            this.ddlShouSou.SelectedValue = this.shaixuan;
            this.ddlMonth.SelectedValue = monthCount.ToString();
            this.ddlYear.SelectedValue = yearCount.ToString();
            BLL.student_info bll = new BLL.student_info();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shaixuan={4}&grade={5}&sevenHuiFan={6}&twoHuiFan={7}}&xueguan={8}&page={9}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.shaixuan ,this.grade,this.sevenHuiFan,this.twoHuiFan,this.xueguan,"__id__");
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
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shaixuan={4}&grade={5}&sevenHuiFan={6}&twoHuiFan={7}&xueguan={8}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property,this.ddlShouSou.SelectedValue,this.ddlGrade.SelectedValue,this.sevenHuiFan,this.twoHuiFan,this.ddlXueGuan.SelectedValue));
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
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&shaixuan={4}&grade={5}&sevenHuiFan={6}&twoHuiFan={7}&xueguan={8}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.shaixuan,this.grade,this.sevenHuiFan,this.twoHuiFan,this.xueguan));
        }
       

        protected int getReturnMonth(int stuid, int month, int year)
        {
            DTcms.BLL.student_return bll = new BLL.student_return();
            return bll.getReturnCountByMonth(" stu_id=" + stuid + " and year(add_time)=" + year + "and month(add_time)=" + month);
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&shaixuan={6}&grade={7}&sevenHuiFan={8}&twoHuiFan={9}&xueguan={10}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue,this.ddlShouSou.SelectedValue,this.ddlGrade.SelectedValue,this.sevenHuiFan,this.twoHuiFan,this.ddlXueGuan.SelectedValue));
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&shaixuan={6}&grade={7}&sevenHuiFan={8}&twoHuiFan={9}&xueguan={10}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue,this.ddlShouSou.SelectedValue,this.ddlGrade.SelectedValue,this.sevenHuiFan,this.twoHuiFan,this.ddlXueGuan.SelectedValue));
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&shaixuan={6}&grade={7}&sevenHuiFan={8}&twoHuiFan={9}&xueguan={10}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, this.ddlShouSou.SelectedValue, this.ddlGrade.SelectedValue,this.sevenHuiFan,this.twoHuiFan,this.ddlXueGuan.SelectedValue));

        }

        /// <summary>
        /// 7天未回访
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbSeven_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&shaixuan={6}&grade={7}&sevenHuiFan={8}&twoHuiFan={9}&xueguan={10}",
          this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, this.ddlShouSou.SelectedValue, this.ddlGrade.SelectedValue, linkButton.CommandArgument,this.twoHuiFan,this.ddlXueGuan.SelectedValue));

        }

        
        //2天内有回访
        protected void lbTwo_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&shaixuan={6}&grade={7}&sevenHuiFan={8}&twoHuiFan={9}&xueguan={10}",
          this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, this.ddlShouSou.SelectedValue, this.ddlGrade.SelectedValue,this.sevenHuiFan, linkButton.CommandArgument,this.ddlXueGuan.SelectedValue));

        }

        protected void lbAll_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&shaixuan={6}&grade={7}&sevenHuiFan={8}&twoHuiFan={9}&xueguan={10}",
         this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, this.ddlShouSou.SelectedValue, this.ddlGrade.SelectedValue, "", "",this.ddlXueGuan.SelectedValue));

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
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&shaixuan={6}&grade={7}&sevenHuiFan={8}&twoHuiFan={9}&xueguan={10}",
       this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, this.ddlShouSou.SelectedValue, this.ddlGrade.SelectedValue, "", "", this.ddlXueGuan.SelectedValue));

        }
      
    }
}