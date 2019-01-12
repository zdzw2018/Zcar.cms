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

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            this.stu_id = DTRequest.GetQueryInt("stuid");
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            
            if (!string.IsNullOrEmpty(_action) && _action == ActionEnum.Edit.ToString())
            {
                this.action = ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
               
                
            }
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
            bool result = true;
            Model.lesson model = new Model.lesson();
            BLL.lesson bll = new BLL.lesson();
            model.lesson_count = Convert.ToDecimal(txtlesson_count.Text.Trim());
            model.lesson_date = Convert.ToDateTime(txtlesson_date.Text);
            model.lesson_grade ="";
            model.stu_id = stu_id;
            model.lesson_name = txtlesson.SelectedValue;
            model.manager_id =Convert.ToInt32(txtteach.SelectedValue);
            model.manager_name = txtteach.SelectedItem.Text;
            model.user_id = GetAdminInfo().id;
            model.lesson_time = txtLessonTimeStart.SelectedValue + "~" + txtLessonTimeEnd.SelectedValue;//txtlesson_time.SelectedValue ;
            if ( string.IsNullOrEmpty(getKeShi(stu_id).ToString()) || getKeShi(stu_id) == getContractKeShi(stu_id) )
            {
                model.keshi_status = 1;
            }
            else
            {
                if ((getContractKeShi(stu_id)-getKeShi(stu_id)) - decimal.Parse(txtlesson_count.Text) < 0)
                {
                    model.lesson_count = getContractKeShi(stu_id) - getKeShi(stu_id);
                    decimal tempx = getContractKeShi(stu_id) - getKeShi(stu_id);
                    model.keshi_status = 0;
                    if (bll.Add(model) < 1)
                    {
                        return false;
                    }
                    model.lesson_count = Convert.ToDecimal(txtlesson_count.Text.Trim()) - tempx;
                    model.keshi_status = 1;
                }
                DTcms.BLL.student_contract bllcontract = new BLL.student_contract();
                DataTable dt = bllcontract.GetList(1, "stu_id=" + stu_id + " and contract_status=1", "  Expr2 desc").Tables[0];
               
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
        ///  获取学生已上课时数
        /// </summary>
        /// <returns></returns>
        protected decimal getKeShi(int stuid)
        {
            DTcms.BLL.lesson bll = new BLL.lesson();
            return bll.GetLettonCount("stu_id=" + stuid + " and keshi_status=0");
        }

        protected decimal getContractKeShi(int stu_id)
        {
            DTcms.BLL.student_contract bll = new BLL.student_contract();
            return bll.getLessonCount("stu_id=" + stu_id + " and contract_status=0");
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
            model.user_id = GetAdminInfo().id;
            model.id = _id;
            if (!bll.Update(model))
            {
                result = false;
            }
            return result;
        }
        #endregion

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
                JscriptMsg("修改课时成功！", "list_view.aspx?channel_id=" + this.channel_id + "&stuid=" + stu_id, "Success");
            }
            else //添加
            {
               
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加课时成功！", "list_view.aspx?channel_id=" + this.channel_id + "&stuid="+stu_id, "Success");
            }
        }
        //绑定教师
        public void bindTeach( string kemu)
        {
            DataTable dt = new BLL.manager().GetList(string.Format("lesson like '%{0}%' and id in(select manager_id from tb_student_teach where stu_id={1} and lesson<>'')", kemu=="" ? txtlesson.SelectedValue: kemu, stu_id)).Tables[0];
            txtteach.DataSource = dt;
            txtteach.DataTextField = "real_name";
            txtteach.DataValueField = "id";
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