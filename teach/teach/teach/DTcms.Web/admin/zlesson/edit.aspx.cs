using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.zlesson
{
    public partial class edit : DTcms.Web.UI.ManagePage
    {
        private string action = ActionEnum.Add.ToString(); //操作类型
      
        private int id = 0;
        private int stu_id = 0;
        private int channel_id;
        protected DTcms.Model.manager manager;
        protected int user_id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            this.stu_id = DTRequest.GetQueryInt("stuid");
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.user_id = DTRequest.GetQueryInt("user_id");
            manager = GetAdminInfo();
            if (!string.IsNullOrEmpty(_action) && _action == ActionEnum.Edit.ToString())
            {
                this.action = ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
               
                
            }
            /*if (user_id == 0)
            {
                JscriptMsg("学管不存在！", "", "Error");
                return ;
            }*/
            if (!Page.IsPostBack)
            {
                
                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }

            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.lesson bll = new BLL.lesson();
            Model.lesson model = bll.GetModel(_id);
            txtlesson_count.Text = model.lesson_count.ToString();
            txtlesson_date.Text = model.lesson_date.ToString("yyyy-MM-dd");
            //txtlesson_grade.Text = model.lesson_grade;
            txtlesson.SelectedValue = model.lesson_name;
            //txtlesson_teach.Text = model.lesson_teach;
            txtLessonTimeStart.SelectedValue = model.lesson_time.Split('~')[0];
            txtLessonTimeEnd.SelectedValue = model.lesson_time.Split('~')[1];
            bindTeach(model.lesson_name);
            txtteach.SelectedValue = model.manager_id.ToString();
        }
        #endregion

       

        #region 增加操作=================================
        private bool DoAdd()
        {

            ////////////判定是否是6号
            if (manager.role_type != 1)
            {
                if (DateTime.Now.Day >= 6)
                {
                    DateTime dateTemp = Convert.ToDateTime(txtlesson_date.Text);//日期
                    if (dateTemp.Month < DateTime.Now.Month)
                    {
                        JscriptMsg("6号之后不能添加" + DateTime.Now.Month + "月之前的课时", "", "Warn");
                        return false;
                    }
                }
            }
            bool result = true;
            
            Model.lesson model = new Model.lesson();
            BLL.lesson bll = new BLL.lesson();
            model.lesson_count = Convert.ToDecimal(txtlesson_count.Text.Trim());
            model.lesson_date = Convert.ToDateTime(txtlesson_date.Text);
            if (model.lesson_date > DateTime.Now)
            {
                JscriptMsg("上课日期不能超过今天！", "", "Error");
                return false;
            }
            else if (toResult(model.lesson_date, DateTime.Now).Days >= 5)
            {
                JscriptMsg("上课日期不能在5日前！", "", "Error");
                return false;
            }
            
            model.lesson_grade ="";
            model.stu_id = stu_id;
            model.lesson_name = txtlesson.SelectedValue;
            model.manager_id = Convert.ToInt32(txtteach.SelectedValue);
            model.manager_name = txtteach.SelectedItem.Text;
            model.user_id = user_id;
            model.xiaoqu = manager.xiaoqu;
            model.lesson_time = txtLessonTimeStart.SelectedValue + "~" + txtLessonTimeEnd.SelectedValue;//txtlesson_time.SelectedValue ;
            decimal leftKeShi = getContractKeShi(stu_id) - getKeShi(stu_id);//剩余新签课时
            decimal leftXufeiKeShi = getXuFeiContractKeShi(stu_id) - getXuFeiKeShi(stu_id);
            if ( string.IsNullOrEmpty(getKeShi(stu_id).ToString()) || getKeShi(stu_id) == getContractKeShi(stu_id) )
            {
                model.keshi_status = 1;
                if (getXuFeiContractKeShi(stu_id) < decimal.Parse(txtlesson_count.Text))
                {
                    JscriptMsg("该学员续费课时不足！", "", "Error");
                    return false;
                }
            }
            else
            {
                if (leftKeShi - decimal.Parse(txtlesson_count.Text) < 0)
                {
                    model.lesson_count = leftKeShi;
                    decimal tempx = leftKeShi;
                    model.keshi_status = 0;
                    if ((getXuFeiContractKeShi(stu_id) - getXuFeiKeShi(stu_id)) < (Convert.ToDecimal(txtlesson_count.Text.Trim()) - tempx))
                    {
                        JscriptMsg("该学员的剩余课时为：" + leftKeShi + ",该学员续费课时不足！", "", "Error");
                        return false;
                    }
                    if (bll.Add(model) < 1)
                    {
                        return false;
                    }
                    
                    model.lesson_count = Convert.ToDecimal(txtlesson_count.Text.Trim()) - tempx;
                    model.keshi_status = 1;
                }
                
               // DTcms.BLL.student_contract bllcontract = new BLL.student_contract();
               // DataTable dt = bllcontract.GetList(1, "stu_id=" + stu_id + " and contract_status=1", "  Expr2 desc").Tables[0];
               
            }
            if (leftKeShi < decimal.Parse(txtlesson_count.Text) && leftXufeiKeShi < decimal.Parse(txtlesson_count.Text))//剩余新签课时
            {
                JscriptMsg("该学员的剩余课时为：" + leftKeShi + ",该学员课时不足！请核对", "", "Error");
                return false;
            }
            //model.add_time = DateTime.Now.ToString();
            //model.lesson_teach = txtlesson_teach.Text;
            //model.lesson_time = txtlesson_time.SelectedValue;
            //model.user_id = GetAdminInfo().id.ToString() ;
            //
            
            if (bll.Add(model) < 1)
            {
                result = false;
            }
            return result;
        }
        #endregion


        /// <summary>
        ///  获取学生新签已上课时数
        /// </summary>
        /// <returns></returns>
        protected decimal getKeShi(int stuid)
        {
            DTcms.BLL.lesson bll = new BLL.lesson();
            return bll.GetLettonCount("stu_id=" + stuid + " and keshi_status=0");
        }
        /// <summary>
        /// 计算日期间隔
        /// </summary>
        /// <param name="d1">要参与计算的其中一个日期</param>
        /// <param name="d2">要参与计算的另一个日期</param>
        /// <returns>一个表示日期间隔的TimeSpan类型</returns>
        public static TimeSpan toResult(DateTime d1, DateTime d2)
        {
            TimeSpan ts;
            if (d1 > d2)
            {
                ts = d1 - d2;
            }
            else
            {
                ts = d2 - d1;
            }
            return ts;
        }
        /// <summary>
        /// 获取已上学费课时
        /// </summary>
        /// <param name="stuid"></param>
        /// <returns></returns>
        protected decimal getXuFeiKeShi(int stuid)
        {
            DTcms.BLL.lesson bll = new BLL.lesson();
            return bll.GetLettonCount("stu_id=" + stuid + " and keshi_status=1");
        }

        /// <summary>
        /// 新签的课时总和
        /// </summary>
        /// <param name="stu_id"></param>
        /// <returns></returns>
        protected decimal getContractKeShi(int stu_id)
        {
            DTcms.BLL.student_contract bll = new BLL.student_contract();
            return bll.getLessonCount("stu_id=" + stu_id + " and contract_status=0 and audit_stutas=1");
        }
        /// <summary>
        /// 续费课时总和
        /// </summary>
        /// <param name="stu_id"></param>
        /// <returns></returns>
        protected decimal getXuFeiContractKeShi(int stu_id)
        {
            DTcms.BLL.student_contract bll = new BLL.student_contract();
            return bll.getLessonCount("stu_id=" + stu_id + " and contract_status=1 and audit_stutas=1");
        }

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
          
            bool result = true;
            BLL.lesson bll = new BLL.lesson();
            Model.lesson model = bll.GetModel(_id);
            model.lesson_time = txtLessonTimeStart.SelectedValue + "~" + txtLessonTimeEnd.SelectedValue;//txtlesson_time.SelectedValue;
            model.lesson_count = Convert.ToDecimal(txtlesson_count.Text.Trim());
            model.lesson_date = Convert.ToDateTime(txtlesson_date.Text);
            model.lesson_grade ="";

            model.lesson_name = txtlesson.SelectedValue;
            model.manager_id = Convert.ToInt32(txtteach.SelectedValue);
            model.manager_name = txtteach.SelectedItem.Text;
            
            model.id = _id;
            if (!bll.Update(model))
            {
                result = false;
            }
            return result;
        }
        #endregion
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
        ///  获取学生已上课时数
        /// </summary>
        /// <returns></returns>
        protected decimal getTotalRealKeShi(int stuid)
        {
            DTcms.BLL.lesson bll = new BLL.lesson();

            return bll.GetLettonCount("stu_id=" + stuid);
        }
        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel(channel_id, ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                if (getContractKeShi(stu_id) - getKeShi(stu_id) <= 20 && getXuFeiContractKeShi(stu_id) - getXuFeiKeShi(stu_id) <= 20)
                {
                    Response.Write("<script>alert('学员课时已低于20课时，请及时关注!')</script>");
                }
                JscriptMsg("修改课时成功！", "list_view.aspx?channel_id=" + this.channel_id + "&stuid=" + stu_id + "&leftkeshi=" + (getTotalKeShi(stu_id) - getTotalRealKeShi(stu_id))+"&user_id="+user_id, "Success");
            }
            else //添加
            {
                ChkAdminLevel(channel_id, ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                if (getContractKeShi(stu_id) - getKeShi(stu_id) <= 20 && getXuFeiContractKeShi(stu_id) - getXuFeiKeShi(stu_id) <= 20)
                {
                    Response.Write("<script>alert('学员课时已低于20课时，请及时关注!')</script>");
                }
                JscriptMsg("添加课时成功！", "list_view.aspx?channel_id=" + this.channel_id + "&stuid=" + stu_id + "&leftkeshi=" + (getTotalKeShi(stu_id) - getTotalRealKeShi(stu_id)) + "&user_id=" + user_id, "Success");
            }
        }
        //绑定教师
        public void bindTeach( string kemu)
        {
            //DataTable dt = new BLL.manager().GetList(string.Format("lesson like '%{0}%' and id in(select manager_id from tb_student_teach where stu_id={1} and lesson<>'')", kemu=="" ? txtlesson.SelectedValue: kemu, stu_id)).Tables[0];
            DataTable dt = new BLL.student_teach().GetList("stu_id=" + stu_id + " and lesson<>'' and lesson='" + (kemu == "" ? txtlesson.SelectedValue : kemu) + "' and xiaoqu="+manager.xiaoqu).Tables[0];
            txtteach.DataSource = dt;
            txtteach.DataTextField = "manager_name";
            txtteach.DataValueField = "manager_id";
            txtteach.DataBind();
        }
        protected void txtlesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtlesson.SelectedValue != "")
            {
                bindTeach(this.txtlesson.SelectedValue);
            }
            else
            {
                txtteach.Items.Clear();
                txtteach.Items.Add(new ListItem("=请选择=", ""));
            }
        }

        /// <summary>
        /// 时间改变的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtLessonTimeEnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime ts1 = DateTime.Parse(txtLessonTimeEnd.SelectedValue);
            DateTime ts2 = DateTime.Parse(txtLessonTimeStart.SelectedValue);
            TimeSpan ts = ts1.Subtract(ts2).Duration();

            txtlesson_count.Text = (Convert.ToDecimal((ts.Hours*3600 +ts.Minutes*60)) / 3600).ToString("0.0");
        }
    }
}