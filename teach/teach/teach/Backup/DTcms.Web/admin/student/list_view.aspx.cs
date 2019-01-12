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
    public partial class list_view : DTcms.Web.UI.ManagePage
    {
        protected int channel_id;
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int category_id;
        protected string property = string.Empty;
        protected string keywords = string.Empty;

        protected int monthCount = 0;//月份统计数
        protected int yearCount;//年份统计

        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");

            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
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
                for (int i = 2013; i <= DateTime.Now.Year; i++)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                ChkAdminLevel(channel_id, ActionEnum.View.ToString()); //检查权限
                RptBind("id>0" + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property), "Expr2 desc");
            }
        }


        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _channel_id, int _category_id, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            if (GetAdminInfo().role_id != 1 && GetAdminInfo().role_id != 10 && GetAdminInfo().role_id != 16)
            {
                strTemp.Append(" and contract_status=0 and stu_id in(select stu_id from tb_student_contract where audit_stutas=1) and stu_id in (select tb_student_teach.stu_id from tb_student_teach where tb_student_teach.manager_id=" + GetAdminInfo().id + " )");
            }
            else
            {
                strTemp.Append(" and contract_status=0 and stu_id in(select stu_id from tb_student_contract where audit_stutas=1)");
            }
            //if (_channel_id > 0)
            //{
            //    strTemp.Append(" and channel_id=" + channel_id);
            //}
            //if (!string.IsNullOrEmpty(_property)) 
            //{
            //    strTemp.Append(" and contract='" + _property + "'");
            //}
            //_keywords = _keywords.Replace("'", "");
            //if (!string.IsNullOrEmpty(_keywords))
            //{
            //    strTemp.Append(" and (stu_parent_name like '%" + _keywords + "%' or stu_name  like '%" + _keywords + "%')");
            //}
            return strTemp.ToString();
        }
        #endregion

        //筛选属性
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}",
               this.channel_id.ToString(), this.category_id.ToString(), this.keywords, ddlProperty.SelectedValue));
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            this.ddlProperty.SelectedValue = this.property;
            this.ddlMonth.SelectedValue = monthCount.ToString();
            this.ddlYear.SelectedValue = yearCount.ToString();
            BLL.student_contract bll = new BLL.student_contract();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&page={4}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, "__id__");
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
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property));
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
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property));
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
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property), "Success");
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
            JscriptMsg("批量审核成功啦！", Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property), "Success");
        }

        /// <summary>
        ///  获取学生剩余课时数
        /// </summary>
        /// <returns></returns>
        protected decimal getKeShi(int stuid)
        {
            DTcms.BLL.lesson bll = new BLL.lesson();
            return bll.GetLettonCount("stu_id=" + stuid + " and manager_id=" + GetAdminInfo().id);
        }

        protected decimal getTotalKeShi(int stuid)
        {
            DTcms.BLL.student_contract bll = new BLL.student_contract();
            return bll.getLessonCount("stu_id=" + stuid + " and audit_stutas=1");
        }
        /// <summary>
        ///  获取学生剩余课时数
        /// </summary>
        /// <returns></returns>
        protected decimal getKeShi1(int stuid)
        {
            DTcms.BLL.lesson bll = new BLL.lesson();
            return bll.GetLettonCount("stu_id=" + stuid);
        }

        protected decimal getKeShiMonth(int stuid, int month, int year)
        {
            DTcms.BLL.lesson bll = new BLL.lesson();
            return bll.GetLettonCount("stu_id=" + stuid + " and manager_id="+GetAdminInfo().id+" and year(lesson_date)=" + year + "and month(lesson_date)=" + month);
        }
        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}",
          this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue));
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_view.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}",
          this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue));
        }
    }
}