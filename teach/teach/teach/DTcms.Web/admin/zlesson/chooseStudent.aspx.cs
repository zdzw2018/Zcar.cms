using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using System.Text;
using System.Web.UI.HtmlControls;

namespace DTcms.Web.admin.zlesson
{
    public partial class chooseStudent : DTcms.Web.UI.ManagePage
    {
        private string grade = "";
        private int lesson_id = 0;
        private int channel_id;
        protected void Page_Load(object sender, EventArgs e)
        {
             this.lesson_id = DTRequest.GetQueryInt("lesson_id");
             this.channel_id = DTRequest.GetQueryInt("channel_id");
            if (!Page.IsPostBack)
            {
                TreeBind(); //绑定年级
                if (GetAdminInfo().user_name != "admin")
                {
                   RptBind("id>0 and stu_lesson>0 and id in(select stu_id from tb_student_contract where audit_stutas=1) and id in (select stu_id from tb_student_teach where lesson='' and manager_id=" + GetAdminInfo().id + " )" + CombSqlTxt(this.grade), " add_time desc");
                }
                else
                {
                    RptBind("id>0 and stu_lesson>0 and id in(select stu_id from tb_student_contract where audit_stutas=1)" + CombSqlTxt(this.grade), " add_time desc");

                }
                ShowInfo();
            }
        }

        private void TreeBind()
        {
            BLL.student_info bll = new BLL.student_info();
            DataTable dt = bll.GetList(" distinct stu_grade ","").Tables[0];
            ddlgrade.Items.Clear();
            ddlgrade.Items.Add(new ListItem("全部", ""));
            foreach (DataRow item in dt.Rows)
            {
                ddlgrade.Items.Add(new ListItem( item[0].ToString(),item[0].ToString()));
            }
        }

        private void ShowInfo()
        {
            BLL.lesson_stu_log bll = new BLL.lesson_stu_log();
            //基本设置
            for (int i = 0; i < rptlist.Items.Count; i++)
            {
                string NavName = ((HtmlInputCheckBox)rptlist.Items[i].FindControl("cblNavName")).Value;
                Model.lesson_stu_log modelt = bll.GetModel(Convert.ToInt32(NavName), this.lesson_id);
                if (modelt != null) 
                {
                    ((HiddenField)rptlist.Items[i].FindControl("hidId")).Value = modelt.id.ToString();
                    ((HtmlInputCheckBox)rptlist.Items[i].FindControl("cblNavName")).Checked = true;
                }
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {



            BLL.student_info bll = new BLL.student_info();
            this.rptlist.DataSource = bll.GetList("id,stu_name", _strWhere);
            this.rptlist.DataBind();
           
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _grade)
        {
            StringBuilder strTemp = new StringBuilder();
            if (!string.IsNullOrEmpty(grade))
            {
                strTemp.Append(" and stu_grade='" + grade + "'");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            try
            {
                BLL.lesson_stu_log bll = new BLL.lesson_stu_log();
                int userid = GetAdminInfo().id;
                List<Model.lesson_stu_log> ls = new List<Model.lesson_stu_log>();
                //基本设置
                for (int i = 0; i < rptlist.Items.Count; i++)
                {
                    HiddenField hidId = rptlist.Items[i].FindControl("hidId") as HiddenField;
                    HtmlInputCheckBox hcbNavValue = rptlist.Items[i].FindControl("cblNavName") as HtmlInputCheckBox;
                    if (hcbNavValue.Checked == true)
                    {
                        ls.Add(new Model.lesson_stu_log { id = Convert.ToInt32(hidId.Value), channel_id = this.channel_id, stu_id = Convert.ToInt32(hcbNavValue.Value), lesson_id = this.lesson_id, user_id = userid, stu_lesson = 0, add_time = DateTime.Now });
                    }
                    
                }
                bll.Delete(ls, this.lesson_id);
                bll.Add(ls);
            }
            catch (Exception ex)
            {

                return false;
            }
            return result;
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (!DoAdd())
            {
                JscriptMsg("保存过程中发生错误啦！", "", "Error");
                return;
            }
            JscriptMsg("添加资讯成功啦！", "list.aspx?channel_id=" + this.channel_id, "Success");
        }
    }
}