using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.zlesson
{
    public partial class add_keshi : DTcms.Web.UI.ManagePage
    {
        protected int stuid = 0;//学生ID
        protected int id = 0;//课时ID

        protected void Page_Load(object sender, EventArgs e)
        {
            this.stuid = DTRequest.GetQueryInt("stuid");
            this.id = DTRequest.GetQueryInt("id");
            if (!IsPostBack)
            {
                if (id != 0)
                {
                    DTcms.Model.lesson_stu_log model = new BLL.lesson_stu_log().GetModel(id);
                    txtLesson.Text = model.stu_lesson.ToString();
                }
            }
        }

        /// <summary>
        /// 添加课时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                DTcms.BLL.lesson_stu_log bll = new BLL.lesson_stu_log();
                DTcms.Model.lesson_stu_log model = new Model.lesson_stu_log();
                model.stu_id = stuid;
                model.lesson_id = 0;
                model.stu_lesson = int.Parse(txtLesson.Text.Trim());//该字段已改为课时数目
                model.add_time = DateTime.Now;
                model.user_id = GetAdminInfo().id;
                model.channel_id = 0;

                if (bll.Add(model) > 0)
                {
                    JscriptMsg("添加成功！", "keshi_list.aspx", "Success");
                }
                else
                {
                    JscriptMsg("添加出差！", "", "error");
                }
            }
            else
            {
                DTcms.Model.lesson_stu_log model = new BLL.lesson_stu_log().GetModel(id);
                
                try
                {
                    new BLL.lesson_stu_log().UpdateField(id, "stu_lesson=" + txtLesson.Text.Trim());
                    JscriptMsg("修改成功！", "keshi_list.aspx", "Success");

                }
                catch
                {
                    JscriptMsg("修改失败！", "", "error");
                }
            }
           
        }
    }
}