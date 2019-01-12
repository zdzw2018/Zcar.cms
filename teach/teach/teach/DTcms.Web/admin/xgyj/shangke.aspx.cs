using DTcms.BLL;
using DTcms.Common;
using DTcms.Web.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.xgyj
{
    public partial class shangke : ManagePage
    {
        protected int channel_id;
        protected int monthCount;
        protected int yearCount;

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.Response.Redirect(Utils.CombUrlTxt("shangke.aspx", "channel_id={0}&month={1}&year={2}", new string[] { this.channel_id.ToString(), this.ddlMonth.SelectedValue, this.ddlYear.SelectedValue }));
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("shangke.aspx", "channel_id={0}&month={1}&year={2}", new string[] { this.channel_id.ToString(), this.ddlMonth.SelectedValue, this.ddlYear.SelectedValue }));
        }

        public int getJieKeStu(int user_id)
        {
            student_teach _teach = new student_teach();
            return _teach.GetZeorRenShu(user_id);
        }

        public int getNoKeStu(int user_id)
        {
            student_teach _teach = new student_teach();
            return int.Parse(_teach.GetListSelect("count(distinct stu_id) as stucount", string.Concat(new object[] { "  stu_id in(select id from tb_student_info) and  stu_id not in(select stu_id from tb_lesson  where datepart(year,lesson_date)=", this.yearCount, " and datepart(month,lesson_date)=", this.monthCount, ") and manager_id=", user_id, " and stu_id in(select a.stu_id from view_student_contract a  left join (select stu_id, sum(lesson_count) as a2 from tb_lesson group by stu_id   )  b  on a.stu_id=b.stu_id group by b.stu_id,a.stu_id,b.a2  having SUM(a.contract_lesson)-IsNull(a2,0)>0)", })).Tables[0].Rows[0][0].ToString());

        }

        public string getShengyu(int user_id)
        {
           // student_teach _teach = new student_teach();
           // return _teach.GetShengYu(user_id);
            DataTable dt = new BLL.student_contract().GetList(0, " audit_stutas=1 and stu_id in(select stu_id from tb_student_teach where manager_name=(select real_name from dt_manager where id=" + user_id + " ) and lesson='') and stu_id in(select id from tb_student_info)", " contract_no desc").Tables[0];
           
            decimal totalLeft = 0;
            List<int> stuList = new List<int>();
            foreach (DataRow dr in dt.Rows)
            {
                decimal KeShiDanJia = decimal.Parse(dr["contract_lesson_price"].ToString());
                if (stuList.Contains(int.Parse(dr["stu_id"].ToString())))
                {
                    continue;
                }
                stuList.Add(int.Parse(dr["stu_id"].ToString()));
                
                if (!string.IsNullOrEmpty(dr["contract_lesson_price"].ToString()))
                {
                    decimal leftKeshi = getTotalKeShi(int.Parse(dr["stu_id"].ToString())) - getKeShi(int.Parse(dr["stu_id"].ToString()));//剩余课时
                  
                   
                    totalLeft += leftKeshi;
                }
            }
            return totalLeft.ToString("0.0");
        }
        /// <summary>
        /// 获取所有剩余课时资产
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public string getShengYuMoney(int user_id)
        {

            DataTable dt = new BLL.student_contract().GetList(0, " audit_stutas=1 and stu_id in(select stu_id from tb_student_teach where manager_name=(select real_name from dt_manager where id=" + user_id + " ) and lesson='') and stu_id in(select id from tb_student_info)", " contract_no desc").Tables[0];
            decimal totalMoney = 0;
            List<int> stuList = new List<int>();
            foreach (DataRow dr in dt.Rows)
            {
                decimal KeShiDanJia = decimal.Parse(dr["contract_lesson_price"].ToString());
                
                if (stuList.Contains(int.Parse(dr["stu_id"].ToString())))
                {
                    continue;
                }
                stuList.Add(int.Parse(dr["stu_id"].ToString()));
                if (!string.IsNullOrEmpty(dr["contract_lesson_price"].ToString()))
                {
                    decimal leftKeshi = getTotalKeShi(int.Parse(dr["stu_id"].ToString())) - getKeShi(int.Parse(dr["stu_id"].ToString()));//剩余课时
                    decimal tempMoney = leftKeshi * KeShiDanJia;//单个学员的费用
                    totalMoney += tempMoney;
                    
                }
            }
            return totalMoney.ToString("0.0");
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

        protected void Page_Load(object sender, EventArgs e)
        {
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
            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
            }
            else if (!this.Page.IsPostBack)
            {
                ChkAdminLevel(this.channel_id, ActionEnum.View.ToString());
                DTcms.Model.manager model = GetAdminInfo();
                for (int i = 2016; i <= DateTime.Now.Year+2; i++)
                {
                    this.ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                if (model.role_id != 1 && model.role_id != 10 && model.role_id != 16)
                {
                    this.RptBind(string.Concat(new object[] { "   manager_id=", model.id, " and stu_id in(select stu_id from tb_lesson where datepart(year,lesson_date)=", this.yearCount, " and datepart(month,lesson_date)=", this.monthCount, ")","and lesson=''" }), " manager_id  ");
                }
                else
                {
                    this.RptBind(string.Concat(new object[] { "  stu_id in(select stu_id from tb_lesson where datepart(year,lesson_date)=", this.yearCount, " and datepart(month,lesson_date)=", this.monthCount, ")", "and lesson=''", "and xiaoqu=" + model.xiaoqu }), " manager_id ");
                }
            }
        }

        private void RptBind(string _strWhere, string _groupBy)
        {
            DataSet listGroupBy = new lesson().GetListGroupBy(_strWhere, _groupBy);
            this.rptList.DataSource = listGroupBy.Tables[0];
            this.rptList.DataBind();
            this.ddlMonth.SelectedValue = this.monthCount.ToString();
            this.ddlYear.SelectedValue = this.yearCount.ToString();
        }
    }
}