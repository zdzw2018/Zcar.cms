using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.zlesson
{
    public partial class jianzhi_teacher_keshi_danjia_edit : DTcms.Web.UI.ManagePage
    {
        private string action = ActionEnum.Add.ToString(); //操作类型
        private int teacher_id = 0;
        private int channel_id;
        protected DTcms.Model.manager manager;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            manager = GetAdminInfo();
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            if (!string.IsNullOrEmpty(_action) && _action == ActionEnum.Edit.ToString())
            {
                this.action = ActionEnum.Edit.ToString();//修改类型
                this.teacher_id = DTRequest.GetQueryInt("teacher_id");
            }

            if (!Page.IsPostBack)
            {
                TreeBind(ddlTeacher,"");
                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo();
                }

            }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
           
            BLL.tb_jianzhi_teacher_keshi_danjia bll = new BLL.tb_jianzhi_teacher_keshi_danjia();
            //Model.tb_jianzhi_teacher_keshi_danjia model = bll.GetModel(_id);
            ddlTeacher.SelectedValue = teacher_id.ToString();
            //txtKeShiDanJia.Text = model.keshi_danjia.ToString();
            DataSet ds = bll.GetList(0, "teacher_id=" + teacher_id, "add_time");
            string grade = string.Empty;
            string keshi_danjia = string.Empty;
            int i = 1;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                grade += row["grade"].ToString();
                keshi_danjia += row["keshi_danjia"].ToString();
                if (i < ds.Tables[0].Rows.Count)
                {
                    grade += ",";
                    keshi_danjia += ",";
                }
                i++;
            }
            objectSite.SetChkListValue(cblGrade, grade);
            txtKeShiDanJia.Text = keshi_danjia;
        }
        #endregion

        #region 绑定模型=================================
        private void TreeBind(DropDownList ddl,string where)
        {
            BLL.manager bll = new BLL.manager();
            DataTable dt = bll.GetList(" role_id=11 and is_jianzhi=1 and is_lock=0 and xiaoqu=" + manager.xiaoqu+where).Tables[0];

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("==请选择教师==", ""));
            foreach (DataRow dr in dt.Rows)
            {

                ddl.Items.Add(new ListItem(dr["real_name"].ToString(), dr["id"].ToString()));

            }
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {

           
            ////////////判定是否是6号
            
            bool result = true;

           
            BLL.tb_jianzhi_teacher_keshi_danjia bll = new BLL.tb_jianzhi_teacher_keshi_danjia();
            int i = 0;
            foreach (ListItem item in cblGrade.Items)
            {
                Model.tb_jianzhi_teacher_keshi_danjia model = new Model.tb_jianzhi_teacher_keshi_danjia();
                if (item.Selected)
                {
                    
                    model.grade = item.Value;
                    try
                    {
                        model.keshi_danjia = decimal.Parse(txtKeShiDanJia.Text.Trim().Split(',')[i]);
                    }
                    catch
                    {
                        JscriptMsg("请确保课时单价个数和年级选择个数相同！", "", "Error");
                        return false;
                    }
                    model.teacher_id = int.Parse(ddlTeacher.SelectedValue);
                    model.teacher_name = ddlTeacher.SelectedItem.Text;
                    model.xiaoqu = manager.xiaoqu;
                    model.add_time = DateTime.Now;
                    if (bll.GetList(1, "teacher_id=" + ddlTeacher.SelectedValue + " and grade='" + item.Value + "'", "id").Tables[0].Rows.Count > 0)
                    {
                        model.id = int.Parse(bll.GetList(1, "teacher_id=" + ddlTeacher.SelectedValue + " and grade='" + item.Value + "'", "id").Tables[0].Rows[0]["id"].ToString());
                        if (!bll.Update(model))
                        {
                            result = false;
                        }
                    }
                    else if (bll.Add(model) < 1)
                    {
                        result = false;
                    }
                    i++;
                }
               
            }
            return result;
        }
        #endregion

        

        #region 修改操作=================================
        //private bool DoEdit(int _id)
        //{

        //    bool result = true;
        //    BLL.tb_jianzhi_teacher_keshi_danjia bll = new BLL.tb_jianzhi_teacher_keshi_danjia();
        //    Model.tb_jianzhi_teacher_keshi_danjia model = bll.GetModel(_id);
        //    model.grade = rblGrade.SelectedValue;
        //    model.keshi_danjia = decimal.Parse(txtKeShiDanJia.Text.Trim());
        //    model.teacher_id = int.Parse(ddlTeacher.SelectedValue);
        //    model.teacher_name = ddlTeacher.SelectedItem.Text;
        //    model.xiaoqu = manager.xiaoqu;
        //    model.add_time = DateTime.Now;

        //    if (!bll.Update(model))
        //    {
        //        result = false;
        //    }
        //    return result;
        //}
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel(channel_id, ActionEnum.Edit.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }

                JscriptMsg("修改课时单价成功！", "jianzhi_teacher_keshi_danjia.aspx?channel_id=" + this.channel_id , "Success");
            }
            else //添加
            {
                ChkAdminLevel(channel_id, ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }

                JscriptMsg("添加课时单价成功！", "jianzhi_teacher_keshi_danjia.aspx?channel_id=" + this.channel_id, "Success");
            }
        }

        protected void txtSx_TextChanged(object sender, EventArgs e)
        {
            string teacher_name = txtSx.Text;
            if (!string.IsNullOrEmpty(teacher_name.Trim()))
            {
                TreeBind(ddlTeacher, " and real_name like '%" + teacher_name + "%'");
            }
            else
            {
                TreeBind(ddlTeacher, "");
            }
           
        }
    }
}