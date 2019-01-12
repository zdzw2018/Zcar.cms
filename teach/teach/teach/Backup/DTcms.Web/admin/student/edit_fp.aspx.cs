using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
namespace DTcms.Web.admin.student
{
    public partial class edit_fp : DTcms.Web.UI.ManagePage
    {
        protected string action = ActionEnum.Add.ToString(); //操作类型
        protected int channel_id;
        protected int id = 0;
        protected int user_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            this.user_id = DTRequest.GetQueryInt("user_id");
            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
            if (!new BLL.student_info().Exists(this.user_id))
            {
                JscriptMsg("信息不存在或已被删除！", "back", "Error");
                return;
            }
            if (!string.IsNullOrEmpty(_action) && _action == ActionEnum.Edit.ToString())
            {
                this.action = ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.student_teach().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                Model.student_info model = new BLL.student_info() .GetModel(user_id);
                txtstu_name.Text = model.stu_name;
                txtgrade.Text = model.stu_grade;
                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.student_teach bll = new BLL.student_teach();
            Model.student_teach model = bll.GetModel(_id);
            txtlesson.SelectedValue = model.lesson;
            bindTeach();
            txtteach.SelectedValue = model.manager_id.ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.student_teach model = new Model.student_teach();
            BLL.student_teach bll = new BLL.student_teach();
            //学员信息
            model.grade = txtgrade.Text;
            model.lesson = txtlesson.SelectedValue;
            model.manager_id = Convert.ToInt32(txtteach.SelectedValue);
            model.manager_name = txtteach.SelectedItem.Text;
            model.stu_id = this.user_id;
            model.stu_name = txtstu_name.Text;
            if (bll.Add(model) > 0)
            {
                return result;
            }
            else 
            {
                return false;
            }
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = true;
            //学员信息
            BLL.student_teach bll = new BLL.student_teach();
            Model.student_teach model = bll.GetModel(id);
            model.grade = txtgrade.Text;
            model.lesson = txtlesson.SelectedValue;
            model.manager_id = Convert.ToInt32(txtteach.SelectedValue);
            model.manager_name = txtteach.SelectedItem.Text;
            model.stu_id = this.user_id;
            model.stu_name = txtstu_name.Text;
            if (!bll.Update(model))
            {
                result = false;
            }
            return result;
        }
        #endregion

        public void bindTeach() 
        {
            DataTable dt = new BLL.manager().GetList(string.Format("lesson like '%{0}%'",txtlesson.SelectedValue)).Tables[0];
            txtteach.DataSource = dt;
            txtteach.DataTextField = "real_name";
            txtteach.DataValueField = "id";
            txtteach.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    ChkAdminLevel(channel_id, ActionEnum.Edit.ToString()); //检查权限
                    if (!DoEdit(this.id))
                    {
                        JscriptMsg("保存过程中发生错误啦！", "", "Error");
                        return;
                    }
                    JscriptMsg("修改学生信息成功啦！", "list_teach_lesson.aspx?channel_id=" + this.channel_id+"&user_id="+this.user_id, "Success");
                }
                else //添加
                {
                    ChkAdminLevel(channel_id, ActionEnum.Add.ToString()); //检查权限
                    if (!DoAdd())
                    {
                        JscriptMsg("保存过程中发生错误啦！", "", "Error");
                        return;
                    }
                    JscriptMsg("添加学生信息成功啦！", "list_teach_lesson.aspx?channel_id=" + this.channel_id+"&user_id="+this.user_id, "Success");
                }
            }
            catch (Exception)
            {

                JscriptMsg("保存过程中发生错误啦！", "", "Error");
                return;
            }
           
        }

        protected void txtlesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtlesson.SelectedValue != "")
            {
                bindTeach();
            }
            else
            {
                txtteach.Items.Clear();
                txtteach.Items.Add(new ListItem("请选择", ""));
            }
        }
    }
}