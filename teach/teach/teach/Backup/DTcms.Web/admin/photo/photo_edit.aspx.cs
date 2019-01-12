using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.photo
{
    public partial class photo_edit : DTcms.Web.UI.ManagePage
    {
        private string action = ActionEnum.Add.ToString(); //操作类型
        private int channel_id;
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            this.channel_id = DTRequest.GetQueryInt("channel_id");

            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
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
                if (!new DTcms.BLL.photo().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                TreeBind(this.channel_id); //绑定类别
                if (action == ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else
                {
                    LitAttributeList.Text = GetAttributeHtml(null, this.channel_id, this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.photo bll = new BLL.photo();
            Model.photo model = bll.GetModel(_id);

            ddlCategoryId.SelectedValue = model.category_id.ToString();
            txtTitle.Text = model.title;
            txtPhotoNo.Text = model.photo_no;
            txtLinkUrl.Text = model.link_url;
            if (model.is_msg == 1)
            {
                cblItem.Items[0].Selected = true;
            }
            if (model.is_top == 1)
            {
                cblItem.Items[1].Selected = true;
            }
            if (model.is_red == 1)
            {
                cblItem.Items[2].Selected = true;
            }
            if (model.is_hot == 1)
            {
                cblItem.Items[3].Selected = true;
            }
            if (model.is_slide == 1)
            {
                cblItem.Items[4].Selected = true;
            }
            if (model.is_lock == 1)
            {
                cblItem.Items[5].Selected = true;
            }
            txtMarketPrice.Text = model.market_price.ToString();
            txtSellPrice.Text = model.sell_price.ToString();
            txtSortId.Text = model.sort_id.ToString();
            txtClick.Text = model.click.ToString();
            txtDiggGood.Text = model.digg_good.ToString();
            txtDiggAct.Text = model.digg_act.ToString();
            txtContent.Value = model.content;
            txtSeoTitle.Text = model.seo_title;
            txtSeoKeywords.Text = model.seo_keywords;
            txtSeoDescription.Text = model.seo_description;
            //赋值上传的相册
            focus_photo.Value = model.img_url; //封面图片
            LitAlbumList.Text = GetAlbumHtml(model.photo_albums, model.img_url);
            //赋值属性列表
            LitAttributeList.Text = GetAttributeHtml(model.photo_attribute_values, this.channel_id, _id);
        }
        #endregion

        #region 绑定类别=================================
        private void TreeBind(int _channel_id)
        {
            BLL.category bll = new BLL.category();
            DataTable dt = bll.GetList(0, _channel_id);

            this.ddlCategoryId.Items.Clear();
            this.ddlCategoryId.Items.Add(new ListItem("请选择类别...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 返回相册列表HMTL=========================
        private string GetAlbumHtml(List<Model.photo_album> models, string focus_photo)
        {
            StringBuilder strTxt = new StringBuilder();
            if (models != null)
            {
                foreach (Model.photo_album modelt in models)
                {
                    strTxt.Append("<li>\n");
                    strTxt.Append("<input type=\"hidden\" name=\"hide_photo_name\" value=\"" + modelt.id + "|" + modelt.big_img + "|" + modelt.small_img + "\" />\n");
                    strTxt.Append("<img onclick=\"focus_img(this);\" bigsrc=\"" + modelt.big_img + "\" src=\"" + modelt.small_img + "\"\n");
                    if (focus_photo == modelt.small_img)
                    {
                        strTxt.Append(" class=\"current\"\n");
                    }
                    strTxt.Append(" />\n");
                    strTxt.Append("<br><a onclick=\"show_link(this);\" href=\"javascript:;\">链接</a><a onclick=\"del_img(this);\" href=\"javascript:;\">删除</a>\n");
                    strTxt.Append("</li>\n");
                }
            }
            return strTxt.ToString();
        }
        #endregion

        #region 返回属性列表HMTL=========================
        private string GetAttributeHtml(List<Model.photo_attribute_value> models, int _channel_id, int _photo_id)
        {
            StringBuilder strTxt = new StringBuilder();
            BLL.photo_attribute bll = new BLL.photo_attribute();
            DataSet ds = bll.GetList("channel_id=" + _channel_id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                strTxt.Append("<tr><th>扩展属性：</th><td>\n");
                strTxt.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"border_table\">\n");
                strTxt.Append(" <tbody><col width=\"80px\"><col>\n");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int _value_id = 0;
                    string _value_content = "";
                    if (models != null)
                    {
                        foreach (Model.photo_attribute_value modelt in models)
                        {
                            if (modelt.attribute_id == Convert.ToInt32(dr["id"]) && modelt.photo_id == _photo_id)
                            {
                                _value_id = modelt.id;
                                _value_content = modelt.content;
                            }
                        }
                    }
                    strTxt.Append("<tr><th>" + dr["title"] + "</th><td>\n");
                    strTxt.Append(GetAttributeType(Convert.ToInt32(dr["id"]), dr["title"].ToString(), dr["default_value"].ToString(), Convert.ToInt32(dr["type"]),
                        _value_id, _value_content));
                    strTxt.Append("</td></tr>\n");
                }
                strTxt.Append("</tbody>\n");
                strTxt.Append("</table>\n");
                strTxt.Append("</td></tr>\n");
            }
            return strTxt.ToString();
        }
        #endregion

        #region 返回属性类型=============================
        /// <summary>
        /// 返回属性类型HTML
        /// </summary>
        /// <param name="_id">属性ID</param>
        /// <param name="_title">属性标题</param>
        /// <param name="_default_value">属性默认值</param>
        /// <param name="_type">属性类型</param>
        /// <param name="_value_id">属性值ID</param>
        /// <param name="_value">属性值内容</param>
        /// <returns>HTML代码</returns>
        private string GetAttributeType(int _id, string _title, string _default_value, int _type, int _value_id, string _value)
        {
            //分解默认值
            string[] valueArr = _default_value.Split(',');
            StringBuilder str = new StringBuilder();
            str.Append("<input type=\"hidden\" name=\"value_" + _id + "\" value=\"" + _value_id + "\"/>\n");
            switch (_type)
            {
                case (int)AttributeEnum.Text:
                    if (_value_id > 0)
                        _default_value = _value;
                    str.Append("<input type=\"text\" name=\"content_" + _id + "\" value=\"" + _default_value + "\" class=\"txtInput middle\" />\n");
                    break;
                case (int)AttributeEnum.Select:
                    str.Append("<select name=\"content_" + _id + "\" class=\"select2\">\n");
                    for (int i = 0; i < valueArr.Length; i++)
                    {
                        str.Append("<option value=\"" + valueArr[i] + "\"");
                        if (_value_id > 0 && _value == valueArr[i])
                            str.Append(" selected");
                        str.Append(">" + valueArr[i] + "</option>\n");
                    }
                    str.Append("</select>\n");
                    break;
                case (int)AttributeEnum.Radio:
                    for (int i = 0; i < valueArr.Length; i++)
                    {
                        str.Append("<label class=\"attr\"><input type=\"radio\" name=\"content_" + _id + "\" value=\"" + valueArr[i] + "\"");
                        if (_value_id > 0 && _value == valueArr[i])
                            str.Append(" checked");
                        str.Append("  />" + valueArr[i] + "</label>\n");
                    }
                    break;
                case (int)AttributeEnum.CheckBox:
                    for (int i = 0; i < valueArr.Length; i++)
                    {
                        str.Append("<label class=\"attr\"><input type=\"checkbox\" name=\"content_" + _id + "\" value=\"" + valueArr[i] + "\"");
                        if (_value_id > 0 && !string.IsNullOrEmpty(_value))
                        {
                            string[] _valueArr = _value.Split(',');
                            for (int j = 0; j < _valueArr.Length; j++)
                            {
                                if (valueArr[i] == _valueArr[j])
                                    str.Append(" checked");
                            }
                        }
                        str.Append(" />" + valueArr[i] + "</label>\n");
                    }
                    break;
            }
            return str.ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            DTcms.Model.photo model = new Model.photo();
            DTcms.BLL.photo bll = new BLL.photo();

            model.channel_id = this.channel_id;
            model.title = txtTitle.Text.Trim();
            model.category_id = int.Parse(ddlCategoryId.SelectedValue);
            model.photo_no = txtPhotoNo.Text.Trim();
            model.market_price = decimal.Parse(txtMarketPrice.Text.Trim());
            model.sell_price = decimal.Parse(txtSellPrice.Text.Trim());
            model.link_url = txtLinkUrl.Text.Trim();
            model.img_url = focus_photo.Value;
            model.content = txtContent.Value;
            model.seo_title = txtSeoTitle.Text.Trim();
            model.seo_keywords = txtSeoKeywords.Text.Trim();
            model.seo_description = txtSeoDescription.Text.Trim();
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            model.click = int.Parse(txtClick.Text.Trim());
            model.is_msg = 0;
            model.is_top = 0;
            model.is_red = 0;
            model.is_hot = 0;
            model.is_slide = 0;
            model.is_lock = 0;
            if (cblItem.Items[0].Selected == true)
            {
                model.is_msg = 1;
            }
            if (cblItem.Items[1].Selected == true)
            {
                model.is_top = 1;
            }
            if (cblItem.Items[2].Selected == true)
            {
                model.is_red = 1;
            }
            if (cblItem.Items[3].Selected == true)
            {
                model.is_hot = 1;
            }
            if (cblItem.Items[4].Selected == true)
            {
                model.is_slide = 1;
            }
            if (cblItem.Items[5].Selected == true)
            {
                model.is_lock = 1;
            }
            //保存相册
            string[] albumArr = Request.Form.GetValues("hide_photo_name");
            if (albumArr != null && albumArr.Length > 0)
            {
                List<Model.photo_album> ls = new List<Model.photo_album>();
                for (int i = 0; i < albumArr.Length; i++)
                {
                    string[] imgArr = albumArr[i].Split('|');
                    if (imgArr.Length == 3)
                    {
                        ls.Add(new Model.photo_album { big_img = imgArr[1], small_img = imgArr[2] });
                    }
                }
                model.photo_albums = ls;
            }

            //扩展属性
            BLL.photo_attribute bll2 = new BLL.photo_attribute();
            DataSet ds2 = bll2.GetList("channel_id=" + this.channel_id);

            List<Model.photo_attribute_value> attrls = new List<Model.photo_attribute_value>();
            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                int attr_id = int.Parse(dr["id"].ToString());
                string attr_title = dr["title"].ToString();
                string attr_value = Request.Form["content_" + attr_id];
                if (!string.IsNullOrEmpty(attr_value))
                {
                    attrls.Add(new Model.photo_attribute_value { attribute_id = attr_id, title = attr_title, content = attr_value });
                }
            }
            model.photo_attribute_values = attrls;

            if (bll.Add(model) < 1)
            {
                result = false;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = true;
            DTcms.BLL.photo bll = new BLL.photo();
            DTcms.Model.photo model = bll.GetModel(_id);

            model.channel_id = this.channel_id;
            model.title = txtTitle.Text.Trim();
            model.category_id = int.Parse(ddlCategoryId.SelectedValue);
            model.photo_no = txtPhotoNo.Text.Trim();
            model.market_price = decimal.Parse(txtMarketPrice.Text.Trim());
            model.sell_price = decimal.Parse(txtSellPrice.Text.Trim());
            model.link_url = txtLinkUrl.Text.Trim();
            model.img_url = focus_photo.Value;
            model.content = txtContent.Value;
            model.seo_title = txtSeoTitle.Text.Trim();
            model.seo_keywords = txtSeoKeywords.Text.Trim();
            model.seo_description = txtSeoDescription.Text.Trim();
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            model.click = int.Parse(txtClick.Text.Trim());
            model.is_msg = 0;
            model.is_top = 0;
            model.is_red = 0;
            model.is_hot = 0;
            model.is_slide = 0;
            model.is_lock = 0;
            if (cblItem.Items[0].Selected == true)
            {
                model.is_msg = 1;
            }
            if (cblItem.Items[1].Selected == true)
            {
                model.is_top = 1;
            }
            if (cblItem.Items[2].Selected == true)
            {
                model.is_red = 1;
            }
            if (cblItem.Items[3].Selected == true)
            {
                model.is_hot = 1;
            }
            if (cblItem.Items[4].Selected == true)
            {
                model.is_slide = 1;
            }
            if (cblItem.Items[5].Selected == true)
            {
                model.is_lock = 1;
            }
            //保存相册
            if (model.photo_albums != null)
                model.photo_albums.Clear();
            string[] albumArr = Request.Form.GetValues("hide_photo_name");
            if (albumArr != null)
            {
                List<Model.photo_album> ls = new List<Model.photo_album>();
                for (int i = 0; i < albumArr.Length; i++)
                {
                    string[] imgArr = albumArr[i].Split('|');
                    int img_id = int.Parse(imgArr[0]);
                    if (imgArr.Length == 3)
                    {
                        ls.Add(new Model.photo_album { id = img_id, photo_id = _id, big_img = imgArr[1], small_img = imgArr[2] });
                    }
                }
                model.photo_albums = ls;
            }

            //扩展属性
            BLL.photo_attribute bll2 = new BLL.photo_attribute();
            DataSet ds2 = bll2.GetList("channel_id=" + this.channel_id);

            List<Model.photo_attribute_value> attrls = new List<Model.photo_attribute_value>();
            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                int attr_id = int.Parse(dr["id"].ToString());
                string attr_title = dr["title"].ToString();
                string attr_value_id = Request.Form["value_" + attr_id];
                string attr_value_content = Request.Form["content_" + attr_id];
                if (!string.IsNullOrEmpty(attr_value_id) && !string.IsNullOrEmpty(attr_value_content))
                {
                    attrls.Add(new Model.photo_attribute_value { id =  Convert.ToInt32(attr_value_id), photo_id = _id, attribute_id = attr_id, title = attr_title, content = attr_value_content });
                }
            }
            model.photo_attribute_values = attrls;

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
                JscriptMsg("修改图文成功啦！", "photo_list.aspx?channel_id=" + this.channel_id, "Success");
            }
            else //添加
            {
                ChkAdminLevel(channel_id, ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加图文成功啦！", "photo_list.aspx?channel_id=" + this.channel_id, "Success");
            }
        }
    }
}