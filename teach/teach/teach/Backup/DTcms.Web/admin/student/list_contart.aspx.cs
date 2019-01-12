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
    public partial class list_contart : DTcms.Web.UI.ManagePage
    {
        protected int channel_id;
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string xueguan = string.Empty;

        protected int category_id;
        protected string property = string.Empty;
        protected string keywords = string.Empty;
        protected string grade = string.Empty;
        protected string shaixuan = string.Empty;
        protected string tween = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");
            this.grade = DTRequest.GetQueryString("grade");
            this.shaixuan = DTRequest.GetQueryString("shaixuan");
            this.tween = DTRequest.GetQueryString("tween");
            this.xueguan = DTRequest.GetQueryString("xueguan");


            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
            this.pageSize = GetPageSize(15); //每页数量
            if (!Page.IsPostBack)
            {
                DataTable dt = new BLL.manager().GetList("role_id=12").Tables[0];
                this.ddlXueGuan.DataSource = dt;
                this.ddlXueGuan.DataTextField = "real_name";
                this.ddlXueGuan.DataValueField = "id";
                this.ddlXueGuan.DataBind();
                this.ddlXueGuan.Items.Insert(0, new ListItem("=请选择学管师=", ""));
                objectSite.DDLbind(siteConfig.sysgrade, ddlGrade, "=请选择年级=");
                Model.manager model = GetAdminInfo();
                ChkAdminLevel(channel_id, ActionEnum.View.ToString()); //检查权限
                if (model.role_id != 1 && model.role_id != 10 && model.role_id != 16)
                {
                    RptBind(" id>0 and stu_id in(select stu_id from tb_student_contract where audit_stutas=1) and id in (select stu_id from tb_student_teach where lesson='' and manager_id=" + model.id + " )" + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property, this.grade, this.tween, this.xueguan), "Expr2 desc");
                    this.ddlXueGuan.Visible = false;
                }
                else
                {
                    RptBind(" id>0 and stu_id in(select stu_id from tb_student_contract where audit_stutas=1)" + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property, this.grade, this.tween, this.xueguan), "Expr2 desc");
                }
            }
        }


        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _channel_id, int _category_id, string _keywords, string _property,string _grade,string _tween,string _xueguan)
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
            _keywords = _keywords.Replace("'", "");
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
            if (!string.IsNullOrEmpty(_xueguan))
            {
                strTemp.Append(" and  stu_id in (select stu_id from tb_student_teach where manager_id='" + _xueguan + "' and lesson='')");
            }
            if (!string.IsNullOrEmpty(_grade))
            {
                strTemp.Append(" and  stu_grade='" + _grade + "'");
            }

            if (!string.IsNullOrEmpty(_tween))
            {
                strTemp.Append(" and stu_id in (select stu_id from tb_student_contract group by stu_id having sum(contract_lesson)-(select sum(lesson_count) from tb_lesson group by stu_id having stu_id=tb_student_contract.stu_id)<=20 ) ");
            }
            return strTemp.ToString();
        }
        #endregion

        //筛选属性
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_contart.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&grade={4}&shaixuan={5}&tween={6}&xueguan={7}",
               this.channel_id.ToString(), this.category_id.ToString(), this.keywords, ddlProperty.SelectedValue,this.ddlGrade.SelectedValue,this.ddlShouSou.SelectedValue,this.tween,this.xueguan));
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            this.ddlShouSou.SelectedValue = this.shaixuan;
            this.ddlProperty.SelectedValue = this.property;
            this.ddlXueGuan.SelectedValue = this.xueguan;
            this.ddlGrade.SelectedValue = this.grade;
            BLL.student_contract bll = new BLL.student_contract();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("list_contart.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&grade={4}&shaixuan={5}&tween={6}&xueguan={7}&page={8}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.grade,this.shaixuan,this.tween,this.xueguan, "__id__");
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
            Response.Redirect(Utils.CombUrlTxt("list_contart.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&grade={4}&shaixuan={5}&tween={6}&xueguan={7}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property,this.grade,this.ddlShouSou.SelectedValue,this.tween,this.xueguan));
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
            Response.Redirect(Utils.CombUrlTxt("list_contart.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&grade={4}&shaixuan={5}&tween={6}&xueguan={7}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.grade,this.shaixuan,this.tween,this.xueguan));
        }
       

       

        /// <summary>
        ///  获取学生已上课时数
        /// </summary>
        /// <returns></returns>
        protected decimal getKeShi(int stuid)
        {
            DTcms.BLL.lesson bll = new BLL.lesson();
            return bll.GetLettonCount("stu_id=" + stuid );
        }

        protected decimal getTotalKeShi(int stuid)
        {
            DTcms.BLL.student_contract bll = new BLL.student_contract();
            return bll.getLessonCount("stu_id=" + stuid +" and audit_stutas=1 ");
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_contart.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&grade={4}&shaixuan={5}&tween={6}&xueguan={7}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property, this.ddlGrade.SelectedValue,this.ddlShouSou.SelectedValue,this.tween,this.xueguan));
        }

        /// <summary>
        /// 搜索20课时以内的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lb20KeShi_Click(object sender, EventArgs e)
        {
             LinkButton linkButton = (LinkButton)sender;
             Response.Redirect(Utils.CombUrlTxt("list_contart.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&grade={4}&shaixuan={5}&tween={6}&xueguan={7}",
               this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue, linkButton.CommandArgument,this.xueguan));

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
            Response.Redirect(Utils.CombUrlTxt("list_contart.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&grade={4}&shaixuan={5}&tween={6}&xueguan={7}",
               this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue, this.tween, this.ddlXueGuan.SelectedValue));

        }
    }
}