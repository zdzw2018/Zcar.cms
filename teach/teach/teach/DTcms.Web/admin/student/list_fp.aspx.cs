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
        protected string zeroKeshi = string.Empty;
        protected string tweenKeShi = string.Empty;
        protected int tpage;
        protected int monthCount = 0;//月份统计数
        protected int yearCount;//年份统计
        protected decimal total_keshi = 0;
        protected decimal total_left_keshi = 0;
        protected decimal total_left_give_keshi = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.category_id = DTRequest.GetQueryInt("category_id");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");
            this.xueguan = DTRequest.GetQueryString("xueguan");
            this.grade = DTRequest.GetQueryString("grade");
            this.zeorHuiFan = DTRequest.GetQueryString("zeorHuiFan");
            this.zeroKeshi = DTRequest.GetQueryString("zeroKeshi");
            this.tweenKeShi = DTRequest.GetQueryString("tweenKeShi");
            this.twoHuiFan = DTRequest.GetQueryString("twoHuiFan");
            this.shaixuan = DTRequest.GetQueryString("shaixuan");
            this.tpage = DTRequest.GetQueryInt("tpage");
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
                for (int i = 2016; i <= DateTime.Now.Year+2; i++)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                ChkAdminLevel(channel_id, ActionEnum.View.ToString()); //检查权限
                bindTeach();
                bindXueGuan();
                RptBind("id>0 and audit_stutas=1 and xiaoqu="+GetAdminInfo().xiaoqu + CombSqlTxt(this.channel_id, this.category_id, this.keywords, this.property, this.xueguan, this.grade), "Expr2 desc");
            }
        }


        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _channel_id, int _category_id, string _keywords, string _property,string _xueguan,string _grade)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.Append(" and contract_status=0 and stu_id in(select id from tb_student_info) ");
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
            if (!string.IsNullOrEmpty(zeroKeshi))
            {
                strTemp.Append(" and stu_id  in(   select stu_id from(select isnull(m.countlesson,0)-isnull(n.countlesson,0) leftlesson, m.stu_id  from ( select stu_id ,sum(contract_lesson) countlesson from tb_student_contract group by stu_id  ) m full join (select stu_id ,sum(lesson_count) countlesson from tb_lesson group by stu_id)n on m.stu_id=n.stu_id )a where a.leftlesson=0  )");
            }
            if (!string.IsNullOrEmpty(tweenKeShi))
            {
                strTemp.Append(" and stu_id  in(   select stu_id from(select isnull(m.countlesson,0)-isnull(n.countlesson,0) leftlesson, m.stu_id  from ( select stu_id ,sum(contract_lesson) countlesson from tb_student_contract group by stu_id  ) m full join (select stu_id ,sum(lesson_count) countlesson from tb_lesson group by stu_id)n on m.stu_id=n.stu_id )a where 20>a.leftlesson and 0<a.leftlesson  )");
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
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&xueguan={4}&grade={5}&zeorHuiFan={6}&shaixuan={7}&twoHuiFan={8}&month={9}&year={10}&zeroKeshi={11}&&tweenKeShi={12}",
               this.channel_id.ToString(), this.category_id.ToString(), this.keywords, ddlProperty.SelectedValue,this.ddlXueGuan.SelectedValue,this.ddlGrade.SelectedValue,this.zeorHuiFan,this.ddlShouSou.SelectedValue,this.twoHuiFan,this.monthCount.ToString(),this.yearCount.ToString(),this.zeroKeshi,this.tweenKeShi));
        }


        protected decimal getTotalKeShi(int stuid)
        {
            DTcms.BLL.student_contract bll = new BLL.student_contract();
            return bll.getLessonCount("stu_id=" + stuid + " and audit_stutas=1");
        }

        /// <summary>
        /// 获取所有赠送课时
        /// </summary>
        /// <param name="stuid"></param>
        /// <returns></returns>
        protected decimal getTotalGiveKeShi(int stuid)
        {
            DTcms.BLL.student_contract bll = new BLL.student_contract();
            return bll.getGiveLessonCount("stu_id=" + stuid + " and audit_stutas=1");
        }

        public void bindXueGuan()
        {
            DataTable dt = new BLL.manager().GetList("role_id=11 and is_lock=0 and xiaoqu=" + GetAdminInfo().xiaoqu).Tables[0];
            txtteach.DataSource = dt;
            txtteach.DataTextField = "real_name";
            txtteach.DataValueField = "id";
            txtteach.DataBind();

            txtteach.Items.Insert(0, new ListItem("=选择批量分配的学管师=", ""));
        }


        protected void btnFenPei_Click(object sender, EventArgs e)
        {
            ChkAdminLevel(this.channel_id, ActionEnum.Edit.ToString());
            if (string.IsNullOrEmpty(hidIdTeach.Value))
            {
                JscriptMsg("请选择要分配的学管！", "", "Erorr");
                return;
            }
            DTcms.BLL.student_contract _contract = new DTcms.BLL.student_contract();
            for (int i = 0; i < this.rptList.Items.Count; i++)
            {
                int stu_id = Convert.ToInt32(((HiddenField)this.rptList.Items[i].FindControl("hidStuId")).Value);
                CheckBox box = (CheckBox)this.rptList.Items[i].FindControl("chkId");
                if (box.Checked)
                {
                    DTcms.Model.student_info stuModel = new BLL.student_info().GetModel(stu_id);
                    
                    Model.student_teach model = new Model.student_teach();
                    BLL.student_teach bll = new BLL.student_teach();
                    //学员信息
                    model.grade = stuModel.stu_grade;

                    model.manager_id = Convert.ToInt32(hidIdTeach.Value);
                    DTcms.Model.manager manager = new BLL.manager().GetModel(model.manager_id);
                    model.manager_name = manager.real_name;
                    model.stu_id = stu_id;
                    model.stu_name = stuModel.stu_name;
                    model.xiaoqu = GetAdminInfo().xiaoqu;
                    bll.Add(model);
                    
                }
            }

            JscriptMsg("批量分配学管成功！", Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&xueguan={4}&grade={5}&shaixuan={6}&zeorHuiFan={7}&twoHuiFan={8}&month={9}&year={10}&zeroKeshi={11}&tweenKeShi={12}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.xueguan, this.grade, this.shaixuan, this.zeorHuiFan, this.twoHuiFan, this.monthCount.ToString(), this.yearCount.ToString(),this.zeroKeshi,this.tweenKeShi), "Success");


        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (tpage > 0)
            {
                page = tpage;
            }
            this.txtKeywords.Text = this.keywords;
            this.ddlShouSou.SelectedValue = this.shaixuan;
            this.ddlGrade.SelectedValue = this.grade;
            this.ddlProperty.SelectedValue = this.property;
            this.ddlMonth.SelectedValue = monthCount.ToString();
            this.ddlYear.SelectedValue = yearCount.ToString();
            this.ddlXueGuan.SelectedValue = xueguan;
            BLL.student_contract bll = new BLL.student_contract();
            DataSet ds = bll.GetList(0,_strWhere, _orderby);
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                total_keshi += getTotalKeShi(int.Parse(row["id"].ToString()));
                total_left_keshi += (getTotalKeShi(int.Parse(row["id"].ToString())) - getKeShi(int.Parse(row["id"].ToString())));
                total_left_give_keshi += (getTotalGiveKeShi(int.Parse(row["id"].ToString())) - getGiveKeShi(int.Parse(row["id"].ToString())));
            }
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&xueguan={4}&grade={5}&shaixuan={6}&zeorHuiFan={7}&twoHuiFan={8}&month={9}&year={10}&zeroKeshi={11}&tweenKeShi={12}&page={13}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.xueguan,this.grade,this.shaixuan,this.zeorHuiFan,this.twoHuiFan,this.monthCount.ToString(),this.yearCount.ToString(),this.zeroKeshi,this.tweenKeShi,"__id__");
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
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&xueguan={4}&grade={5}&shaixuan={6}&zeorHuiFan={7}&twoHuiFan={8}&month={9}&year={10}&zeroKeshi={11}&tweenKeShi={12}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property, this.xueguan, this.grade, this.ddlShouSou.SelectedValue, this.zeorHuiFan, this.twoHuiFan, this.monthCount.ToString(), this.yearCount.ToString(), this.zeroKeshi, this.tweenKeShi));
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
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&xueguan={4}&grade={5}&shaixuan={6}&zeorHuiFan={7}&twoHuiFan={8}&month={9}&year={10}&zeroKeshi={11}&tweenKeShi={12}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.xueguan,this.grade,this.shaixuan,this.zeorHuiFan,this.twoHuiFan,this.monthCount.ToString(),this.yearCount.ToString(),this.zeroKeshi,this.tweenKeShi));
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
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&xueguan={4}&grade={5}&shaixuan={6}&zeorHuiFan={7}&twoHuiFan={8}&month={9}&year={10}&zeroKeshi={11}&tweenKeShi={12}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property,this.xueguan,this.grade,this.shaixuan,this.zeorHuiFan,this.twoHuiFan,this.monthCount.ToString(),this.yearCount.ToString(),this.zeroKeshi,this.tweenKeShi), "Success");
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
            JscriptMsg("批量审核成功啦！", Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&xueguan={4}&grade={5}&shaixuan={6}&zeorHuiFan={7}&twoHuiFan={8}&month={9}&year={10}&zeroKeshi={11}&tweenKeShi={12}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.xueguan, this.grade, this.shaixuan, this.zeorHuiFan, this.twoHuiFan, this.monthCount.ToString(), this.yearCount.ToString(), this.zeroKeshi, this.tweenKeShi), "Success");
        }

        /// <summary>
        ///  获取学生已上课时数
        /// </summary>
        /// <returns></returns>
        protected decimal getKeShi(int stuid)
        {
            DTcms.BLL.lesson bll = new BLL.lesson();
            return bll.GetLettonCount(" stu_id=" + stuid);
        }

        /// <summary>
        /// 获取已上赠送课时
        /// </summary>
        /// <param name="stuid"></param>
        /// <returns></returns>
        protected decimal getGiveKeShi(int stuid)
        {
            DTcms.BLL.give_lesson bll = new BLL.give_lesson();
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
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&xueguan={6}&grade={7}&shaixuan={8}&zeorHuiFan={9}&twoHuiFan={10}&zeroKeshi={11}&tweenKeShi={12}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue,ddlXueGuan.SelectedValue,this.ddlGrade.SelectedValue,this.shaixuan,this.zeorHuiFan,this.twoHuiFan,this.zeroKeshi,this.tweenKeShi));
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&xueguan={6}&grade={7}&shaixuan={8}&zeorHuiFan={9}&twoHuiFan={10}&zeroKeshi={11}&tweenKeShi={12}",
            this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue,ddlXueGuan.SelectedValue,this.ddlGrade.SelectedValue,this.shaixuan,this.zeorHuiFan,this.twoHuiFan,this.zeroKeshi,this.tweenKeShi));
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
            DTcms.Model.manager model = GetAdminInfo();
           
            DataTable dt = new BLL.manager().GetList("role_id=12 and is_lock=0 and xiaoqu="+model.xiaoqu).Tables[0];

            this.ddlXueGuan.DataSource = dt;
            ddlXueGuan.DataTextField = "real_name";
            ddlXueGuan.DataValueField = "id";
            ddlXueGuan.DataBind();

            ddlXueGuan.Items.Insert(0, new ListItem("=选择学管师=", ""));
        }


        protected void ddlXueGuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&xueguan={6}&grade={7}&shaixuan={8}&zeorHuiFan={9}&twoHuiFan={10}&zeroKeshi={11}&tweenKeShi={12}",
           this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue,ddlXueGuan.SelectedValue,this.ddlGrade.SelectedValue,this.ddlShouSou.SelectedValue,this.zeorHuiFan,this.twoHuiFan,this.zeroKeshi,this.tweenKeShi));
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&xueguan={6}&grade={7}&shaixuan={8}&zeorHuiFan={9}&twoHuiFan={10}&zeroKeshi={11}&tweenKeShi={12}",
           this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlXueGuan.SelectedValue, this.ddlGrade.SelectedValue,this.ddlShouSou.SelectedValue,this.zeorHuiFan,this.twoHuiFan,this.zeroKeshi,this.tweenKeShi));

        }

        /// <summary>
        /// 筛选出0次回访的人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void zeorHuiFan_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&xueguan={6}&grade={7}&shaixuan={8}&zeorHuiFan={9}&twoHuiFan={10}&zeroKeshi={11}&tweenKeShi={12}",
          this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlXueGuan.SelectedValue, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue, linkButton.CommandArgument,this.twoHuiFan,this.zeroKeshi,this.tweenKeShi));

        }
        
        protected void lbTwo_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&xueguan={6}&grade={7}&shaixuan={8}&zeorHuiFan={9}&twoHuiFan={10}&zeroKeshi={11}&tweenKeShi={12}",
          this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlXueGuan.SelectedValue, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue,this.zeorHuiFan, linkButton.CommandArgument,this.zeroKeshi,this.tweenKeShi));

        }

        protected void lbAll_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&xueguan={6}&grade={7}&shaixuan={8}&zeorHuiFan={9}&twoHuiFan={10}&zeroKeshi={11}&tweenKeShi={12}",
         this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlXueGuan.SelectedValue, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue, "", "","",""));

        }

        protected void zeroLeftKeshi_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&xueguan={6}&grade={7}&shaixuan={8}&zeorHuiFan={9}&twoHuiFan={10}&zeroKeshi={11}&tweenKeShi={12}",
          this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlXueGuan.SelectedValue, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue, this.zeorHuiFan, this.twoHuiFan, linkButton.CommandArgument,this.tweenKeShi));

        }

        protected void LeftKeshitween_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            Response.Redirect(Utils.CombUrlTxt("list_fp.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&month={4}&year={5}&xueguan={6}&grade={7}&shaixuan={8}&zeorHuiFan={9}&twoHuiFan={10}&zeroKeshi={11}&tweenKeShi={12}",
          this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlXueGuan.SelectedValue, this.ddlGrade.SelectedValue, this.ddlShouSou.SelectedValue, this.zeorHuiFan, this.twoHuiFan, this.zeroKeshi, linkButton.CommandArgument));

        }
    }
}