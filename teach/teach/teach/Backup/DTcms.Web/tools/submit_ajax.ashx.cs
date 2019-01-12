using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Web.SessionState;
using DTcms.Web.UI;
using DTcms.Common;

namespace DTcms.Web.tools
{
    /// <summary>
    /// AJAX提交处理
    /// </summary>
    public class submit_ajax : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = DTRequest.GetQueryString("action");

            switch (action)
            {
                case "digg_add": //顶踩
                    digg_add(context);
                    break;
                case "comment_add": //提交评论
                    comment_add(context);
                    break;
                case "comment_list": //评论列表
                    comment_list(context);
                    break;
                case "getKuaiDi":
                    getKuaiDi(context);
                    break;
                case "getKuaiDiLog":
                    getKuaiDiLog(context);
                    break;
            }
        }

        private void getKuaiDi(HttpContext context)
        {
            string code = DTRequest.GetQueryString("code");
            string url = "http://www.kuaidi100.com/autonumber/auto?num=";
            System.Net.WebClient client = new System.Net.WebClient();
            client.Encoding = System.Text.Encoding.Default;
            context.Response.Write(client.DownloadString(url + code));
        }
        private void getKuaiDiLog(HttpContext context)
        {
            string code = DTRequest.GetQueryString("code");
            string type = DTRequest.GetQueryString("type");
            switch (type) 
            {
                case "zhaijisong":
                    type = "zjs";
                    break;
                case "huitongkuaidi":
                    type="huitong";
                    break;
                case "quanfengkuaidi":
                    type = "quanfeng";
                    break;
                case "debangwuliu":
                    type = "debang";
                    break;
                case "quanyikuaidi":
                    type = "quanyi";
                    break;
            }
            string url = string.Format("http://www.aikuaidi.cn/rest/?key=1b3c421c678b4aa8a9082443829160c9&order={0}&id={1}", code, type);
            System.Net.WebClient client = new System.Net.WebClient();
            client.Encoding = System.Text.Encoding.Default;
            context.Response.Write(client.DownloadString(url));
        }

        #region 顶和踩的处理方法==============================
        private void digg_add(HttpContext context)
        {
            string channel_type = DTRequest.GetFormString("channel_type");
            int id = DTRequest.GetFormInt("id");
            if (!string.IsNullOrEmpty(channel_type) && id > 0)
            {
                string cookie = Utils.GetCookie(DTKeys.COOKIE_DIGG_KEY, channel_type + id.ToString());
                if (cookie == id.ToString())
                {
                    context.Response.Write("{msg:0, msgbox:\"您刚刚提交过，体息一会吧！\"}");
                    return;
                }
            }
            switch (channel_type)
            {
                case "article":
                    digg_article_add(context);
                    break;
                case "photo":
                    digg_photo_add(context);
                    break;
                case "download":
                    digg_download_add(context);
                    break;
                case "content":
                    digg_content_add(context);
                    break;
            }
        }
        #region 模块处理方法
        //资讯模块
        private void digg_article_add(HttpContext context)
        {
            string channel_type = DTRequest.GetFormString("channel_type");
            string digg_type = DTRequest.GetFormString("digg_type");
            int id = DTRequest.GetFormInt("id");
            BLL.article bll = new BLL.article();
            if (!bll.Exists(id))
            {
                context.Response.Write("{msg:0, msgbox:\"信息不存在或已删除！\"}");
                return;
            }
            if (digg_type == "good")
            {
                bll.UpdateField(id, "digg_good=digg_good+1");
            }
            else
            {
                bll.UpdateField(id, "digg_act=digg_act+1");
            }
            Model.article model = bll.GetModel(id);
            context.Response.Write("{msg:1, digggood:" + model.digg_good + ", diggact:" + model.digg_act + ", msgbox:\"成功顶或踩了一下！\"}");
            Utils.WriteCookie(DTKeys.COOKIE_DIGG_KEY, channel_type + id.ToString(), id.ToString(), 8640);
            return;
        }
        //图文模块
        private void digg_photo_add(HttpContext context)
        {
            string channel_type = DTRequest.GetFormString("channel_type");
            string digg_type = DTRequest.GetFormString("digg_type");
            int id = DTRequest.GetFormInt("id");
            BLL.photo bll = new BLL.photo();
            if (!bll.Exists(id))
            {
                context.Response.Write("{msg:0, msgbox:\"信息不存在或已删除！\"}");
                return;
            }
            if (digg_type == "good")
            {
                bll.UpdateField(id, "digg_good=digg_good+1");
            }
            else
            {
                bll.UpdateField(id, "digg_act=digg_act+1");
            }
            Model.photo model = bll.GetModel(id);
            context.Response.Write("{msg:1, digggood:" + model.digg_good + ", diggact:" + model.digg_act + ", msgbox:\"成功顶或踩了一下！\"}");
            Utils.WriteCookie(DTKeys.COOKIE_DIGG_KEY, channel_type + id.ToString(), id.ToString(), 8640);
            return;
        }
        //下载模块
        private void digg_download_add(HttpContext context)
        {
            string channel_type = DTRequest.GetFormString("channel_type");
            string digg_type = DTRequest.GetFormString("digg_type");
            int id = DTRequest.GetFormInt("id");
            BLL.download bll = new BLL.download();
            if (!bll.Exists(id))
            {
                context.Response.Write("{msg:0, msgbox:\"信息不存在或已删除！\"}");
                return;
            }
            if (digg_type == "good")
            {
                bll.UpdateField(id, "digg_good=digg_good+1");
            }
            else
            {
                bll.UpdateField(id, "digg_act=digg_act+1");
            }
            Model.download model = bll.GetModel(id);
            context.Response.Write("{msg:1, digggood:" + model.digg_good + ", diggact:" + model.digg_act + ", msgbox:\"成功顶或踩了一下！\"}");
            Utils.WriteCookie(DTKeys.COOKIE_DIGG_KEY, channel_type + id.ToString(), id.ToString(), 8640);
            return;
        }
        //内容模块
        private void digg_content_add(HttpContext context)
        {
            string channel_type = DTRequest.GetFormString("channel_type");
            string digg_type = DTRequest.GetFormString("digg_type");
            int id = DTRequest.GetFormInt("id");
            BLL.contents bll = new BLL.contents();
            if (!bll.Exists(id))
            {
                context.Response.Write("{msg:0, msgbox:\"信息不存在或已删除！\"}");
                return;
            }
            if (digg_type == "good")
            {
                bll.UpdateField(id, "digg_good=digg_good+1");
            }
            else
            {
                bll.UpdateField(id, "digg_act=digg_act+1");
            }
            Model.contents model = bll.GetModel(id);
            context.Response.Write("{msg:1, digggood:" + model.digg_good + ", diggact:" + model.digg_act + ", msgbox:\"成功顶或踩了一下！\"}");
            Utils.WriteCookie(DTKeys.COOKIE_DIGG_KEY, channel_type + id.ToString(), id.ToString(), 8640);
            return;
        }
        #endregion
        #endregion

        #region 提交评论的处理方法============================
        private void comment_add(HttpContext context)
        {
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(Utils.GetXmlMapPath(DTKeys.FILE_SITE_XML_CONFING));
            StringBuilder strTxt = new StringBuilder();
            BLL.comment bll = new BLL.comment();
            Model.comment model = new Model.comment();

            string _code = DTRequest.GetFormString("txtCode");
            int _channel_id = DTRequest.GetQueryInt("channel_id");
            int _content_id = DTRequest.GetQueryInt("content_id");
            string _title = DTRequest.GetFormString("txtTitle");
            string _content = DTRequest.GetFormString("txtContent");

            //校检验证码
            if (string.IsNullOrEmpty(_code))
            {
                context.Response.Write("{msg:0, msgbox:\"对不起，请输入验证码！\"}");
                return;
            }
            if (context.Session[DTKeys.SESSION_CODE] == null)
            {
                context.Response.Write("{msg:0, msgbox:\"对不起，系统找不到生成的验证码！\"}");
                return;
            }
            if (_code.ToLower() != (context.Session[DTKeys.SESSION_CODE].ToString()).ToLower())
            {
                context.Response.Write("{msg:0, msgbox:\"您输入的验证码与系统的不一致！\"}");
                return;
            }
            if (_channel_id == 0 || _content_id == 0)
            {
                context.Response.Write("{msg: 0, msgbox: \"对不起，参数传输有误！\"}");
                return;
            }
            if (string.IsNullOrEmpty(_content))
            {
                context.Response.Write("{msg: 0, msgbox: \"对不起，请输入评论的内容！\"}");
                return;
            }

            model.channel_id = _channel_id;
            model.content_id = _content_id;
            model.title = _title;
            model.content = Utils.ToHtml(_content);
            model.user_name = "游客";
            model.user_ip = DTRequest.GetIP();
            model.is_lock = siteConfig.commentstatus; //审核开关
            model.add_time = DateTime.Now;
            model.is_reply = 0;
            if (bll.Add(model) > 0)
            {
                context.Response.Write("{msg: 1, msgbox: \"恭喜您，留言提交成功啦！\"}");
                return;
            }
            context.Response.Write("{msg: 0, msgbox: \"对不起，保存过程中发生错误！\"}");
            return;
        }
        #endregion

        #region 取得评论列表方法==============================
        private void comment_list(HttpContext context)
        {
            int _channel_id = DTRequest.GetQueryInt("channel_id");
            int _content_id = DTRequest.GetQueryInt("content_id");
            int _page_index = DTRequest.GetQueryInt("page_index");
            int _page_size = DTRequest.GetQueryInt("page_size");
            int totalcount;
            StringBuilder strTxt = new StringBuilder();

            if (_channel_id == 0 || _content_id == 0 || _page_size == 0)
            {
                context.Response.Write("获取失败，传输参数有误！");
                return;
            }

            BLL.comment bll = new BLL.comment();
            DataSet ds = bll.GetList(_page_size, _page_index, string.Format("is_lock=0 and channel_id={0} and content_id={1}", _channel_id.ToString(), _content_id.ToString()), "add_time desc", out totalcount);
            //如果记录存在
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    strTxt.Append("<li>\n");
                    strTxt.Append("<div class=\"title\"><span>" + dr["add_time"] + "</span>" + dr["user_name"] + "</div>");
                    strTxt.Append("<div class=\"box\">" + dr["content"] + "</div>");
                    if (Convert.ToInt32(dr["is_reply"]) == 1)
                    {
                        strTxt.Append("<div class=\"reply\">");
                        strTxt.Append("<strong>管理员回复：</strong>" + dr["reply_content"].ToString());
                        strTxt.Append("<span class=\"time\">" + dr["reply_time"].ToString() + "</span>");
                        strTxt.Append("</div>");
                    }
                    strTxt.Append("</li>\n");
                }
            }
            else
            {
                strTxt.Append("<p>暂无评论，快来抢沙发吧！</p>");
            }
            context.Response.Write(strTxt.ToString());
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}