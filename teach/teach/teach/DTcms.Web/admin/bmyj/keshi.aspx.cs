using DTcms.BLL;
using DTcms.Common;
using DTcms.Web.UI;
using System;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.bmyj
{
    public partial class keshi : ManagePage
    {
        protected int category_id;
        protected int channel_id;
        protected int monthCount;
       
        protected decimal total4;
        protected decimal totalhetong;
        protected decimal totalnewmoney;
        protected decimal totalrealmoney;
        protected int yearCount;

        protected string CombSqlTxt(string _starttime, string _endtime)
        {
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(_starttime) && !string.IsNullOrEmpty(_endtime))
            {
                builder.Append(" and add_time between '" + _starttime + "' and '" + _endtime + "'");
            }
            return builder.ToString();
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.Response.Redirect(Utils.CombUrlTxt("keshi.aspx", "channel_id={0}&month={1}&year={2}", new string[] { this.channel_id.ToString(), this.ddlMonth.SelectedValue, this.ddlYear.SelectedValue }));
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.Response.Redirect(Utils.CombUrlTxt("keshi.aspx", "channel_id={0}&month={1}&year={2}", new string[] { this.channel_id.ToString(), this.ddlMonth.SelectedValue, this.ddlYear.SelectedValue }));
        }

        protected decimal getKeShiMonth(int manager_id, int keshi_status)
        {
            lesson lesson = new lesson();
            return lesson.GetLettonCount(string.Concat(new object[] { " stu_id in (select stu_id from tb_student_teach where manager_name=(select real_name from dt_manager where id=", manager_id, ")) and keshi_status=", keshi_status, " and DATENAME(year,lesson_date)=", this.yearCount, " and DATENAME(month,lesson_date)=", this.monthCount, " and stu_id in(select id from tb_student_info ) and xiaoqu=",model.xiaoqu }));
        }

        protected decimal getPriceContractStatus(int managerid, int keshistatus)
        {
            lesson lesson = new lesson();
            DataTable table = null;
            table = lesson.GetList(string.Concat(new object[] { " stu_id in(select stu_id from tb_student_teach where manager_name=(select real_name from dt_manager where id=", managerid, "))  and keshi_status=", keshistatus, " and DATENAME(year,lesson_date)=", this.yearCount, " and DATENAME(month,lesson_date)=", this.monthCount, " and stu_id in(select id from tb_student_info ) and xiaoqu=",model.xiaoqu }), "stu_id", true).Tables[0];
           
            decimal num = 0M;
            foreach (DataRow row in table.Rows)
            {
                student_contract _contract = new student_contract();
                DataTable table2 = _contract.GetList(1, string.Concat(new object[] { "stu_id=", row["stu_id"], " and contract_status=", keshistatus }), " Expr2 desc").Tables[0];
      
                if (table2.Rows.Count > 0)
                {
                    decimal num2 = decimal.Parse(row["lesson"].ToString());
                    decimal num3 = decimal.Parse(table2.Rows[0]["contract_lesson_price"].ToString());
                    decimal num4 = num2 * num3;
                    num += num4;
                }
            }
            return num;
        }
        public Model.manager model = new Model.manager();
        protected void Page_Load(object sender, EventArgs e)
        {
             model = GetAdminInfo();
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.category_id = DTRequest.GetQueryInt("category_id");
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
            if (this.channel_id == 0)
            {
                base.JscriptMsg("频道参数不正确！", "back", "Error");
            }
            else if (!this.Page.IsPostBack)
            {
                base.ChkAdminLevel(this.channel_id, ManagePage.ActionEnum.View.ToString());
                
                for (int i = 2016; i <= DateTime.Now.Year+2; i++)
                {
                    this.ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                if (model.role_id != 1 && model.role_id != 10 && model.role_id != 16)
                {
                    this.RptBind(" lesson='' and manager_id=" + model.id, "manager_id,manager_name");
                }
                else
                {
                    this.RptBind(" lesson='' and manager_id in(select id from dt_manager) and stu_id in(select stu_id from tb_lesson where  DATENAME(year,lesson_date)=" + this.yearCount + " and DATENAME(month,lesson_date)=" + this.monthCount + ") and xiaoqu=" + model.xiaoqu, "manager_id,manager_name");
                }
            }
        }

        private void RptBind(string _strWhere, string _groupBy)
        {
            DataSet list = new student_teach().GetList(_strWhere, _groupBy);
            this.rptList.DataSource = list.Tables[0];
            this.rptList.DataBind();
            for (int i = 0; i < list.Tables[0].Rows.Count; i++)
            {
                this.totalnewmoney += this.getKeShiMonth(int.Parse(list.Tables[0].Rows[i]["manager_id"].ToString()), 0);
                this.totalrealmoney += this.getPriceContractStatus(int.Parse(list.Tables[0].Rows[i]["manager_id"].ToString()), 0);
                this.totalhetong += this.getKeShiMonth(int.Parse(list.Tables[0].Rows[i]["manager_id"].ToString()), 1);
                this.total4 += this.getPriceContractStatus(int.Parse(list.Tables[0].Rows[i]["manager_id"].ToString()), 1);
            }
            this.ddlMonth.SelectedValue = this.monthCount.ToString();
            this.ddlYear.SelectedValue = this.yearCount.ToString();
        }
    }
}