using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.student_score
{
    public partial class edit : DTcms.Web.UI.ManagePage
    {
        private string action = string.Empty; //操作类型
        private int channel_id;
        private int id = 0;
        private int score_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("id");
            this.score_id = DTRequest.GetQueryInt("score_id");
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            action = DTRequest.GetQueryString("action");
            if (this.id == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            if (!new BLL.student_info().Exists(this.id))
            {
                JscriptMsg("信息不存在或已被删除！", "back", "Error");
                return;
            }
            if (!IsPostBack) 
            {
               
                ddllesson_year.Items.Add(new ListItem("请选择学年度..",""));
                for (int i = DateTime.Now.Year; i < DateTime.Now.Year+1; i++)
                {
                    ddllesson_year.Items.Add(new ListItem(i+"-"+(i+1),i+"-"+(i+1)));
                }
                ddllesson_semester.Items.Add(new ListItem("请选择学期..", ""));
                ddllesson_semester.Items.Add(new ListItem("第一学期", "第一学期"));
                ddllesson_semester.Items.Add(new ListItem("第二学期", "第二学期"));
                ddllesson_type.Items.Add(new ListItem("报名成绩", "报名成绩"));
                ddllesson_type.Items.Add(new ListItem("期中考试", "期中考试"));
                ddllesson_type.Items.Add(new ListItem("期末考试", "期末考试"));
                ddllesson_type.Items.Add(new ListItem("中考成绩", "中考成绩"));
                ddllesson_type.Items.Add(new ListItem("高考成绩", "高考成绩"));
                ddllesson_type.Items.Add(new ListItem("市质检", "市质检"));
                ddllesson_type.Items.Add(new ListItem("省质检", "省质检"));

                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.score_id);
                }
            }
            Model.manager userInfo = GetAdminInfo();
            Model.student_info stu = new BLL.student_info().GetModel(this.id);
            lblstu_name.Text = stu.stu_name;

           
        }

        #region 赋值操作=================================
        private void ShowInfo(int _rid)
        {
            BLL.student_score bll = new BLL.student_score();
            Model.student_score model = bll.GetModel(_rid);
            ddllesson_year.SelectedValue = model.lesson_year;
            ddllesson_semester.SelectedValue = model.lesson_semester;
            ddllesson_type.SelectedValue = model.lesson_type;
            TextBox1.Text = model.lesson_01.ToString();
            TextBox2.Text = model.lesson_02.ToString();
            TextBox3.Text = model.lesson_03.ToString();
            TextBox4.Text = model.lesson_04.ToString();
            TextBox5.Text = model.lesson_05.ToString();
            TextBox6.Text = model.lesson_06.ToString();
            TextBox7.Text = model.lesson_07.ToString();
            TextBox8.Text = model.lesson_08.ToString();
            TextBox9.Text = model.lesson_09.ToString();
            TextBox10.Text = model.lesson_010.ToString();
            TextBox14.Text = model.lesson_count.ToString();
           
        }
        #endregion
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.student_score bll = new BLL.student_score();
                Model.student_score model = new Model.student_score();
                if (action == ActionEnum.Edit.ToString())//修改
                {
                    model = bll.GetModel(score_id);
                }
             

                Model.manager userInfo = GetAdminInfo();
                Model.student_info stu = new BLL.student_info().GetModel(this.id);
                model.add_time = DateTime.Now;
                model.lesson_01 = Convert.ToDecimal(TextBox1.Text);
                model.lesson_02 = Convert.ToDecimal(TextBox2.Text);
                model.lesson_03 = Convert.ToDecimal(TextBox3.Text);
                model.lesson_04 = Convert.ToDecimal(TextBox4.Text);
                model.lesson_05 = Convert.ToDecimal(TextBox5.Text);
                model.lesson_06 = Convert.ToDecimal(TextBox6.Text);
                model.lesson_07 = Convert.ToDecimal(TextBox7.Text);
                model.lesson_08 = Convert.ToDecimal(TextBox8.Text);
                model.lesson_09 = Convert.ToDecimal(TextBox9.Text);
                model.lesson_010 = Convert.ToDecimal(TextBox10.Text);
              
                model.lesson_count = Convert.ToDecimal(TextBox14.Text);
                model.lesson_semester = ddllesson_semester.SelectedValue;
                model.lesson_type = ddllesson_type.SelectedValue;
                model.lesson_year = ddllesson_year.SelectedValue;
                model.stu_id = this.id;
                model.stu_name = stu.stu_name;
                model.user_id = userInfo.id;
                model.user_name = userInfo.user_name;
                model.stu_id = this.id;
                model.stu_name = stu.stu_name;
                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    if (bll.Update(model))
                    {
                        JscriptMsg("修改成绩成功！", "list_view.aspx?channel_id=" + this.channel_id + "&user_id=" + this.id, "Success");
                        return;
                    }
                }
                else if (bll.Add(model) > 0)
                {
                    JscriptMsg("添加学员记录成功！", "list_view.aspx?channel_id="+this.channel_id+"&user_id="+this.id, "Success");
                    return;
                }
                else
                {
                    JscriptMsg("保存过程中发生错误！", "", "Erorr");
                    return;
                }
            }
            catch (Exception ex)
            {

                JscriptMsg("保存过程中发生错误！", "", "Erorr");
                return;
            }

        }
    }
}