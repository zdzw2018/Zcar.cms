<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.index" ValidateRequest="false" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="DTcms.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by DTcms Template Engine at 2013/9/9 19:49:03.
		本页面代码由DTcms模板引擎生成于 2013/9/9 19:49:03. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);

	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<title>");
	templateBuilder.Append(config.webtitle.ToString());
	templateBuilder.Append("</title>\r\n<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/css/style.css\" />\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(config.webpath.ToString());
	templateBuilder.Append("scripts/jquery/jquery-1.3.2.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/js/base.js\"></");
	templateBuilder.Append("script>\r\n</head>\r\n<body>\r\n<div class=\"container_12\">\r\n <!-- .header -->\r\n ");

	templateBuilder.Append(" <div class=\"grid_4\">\r\n   <h1><a href=\"");
	templateBuilder.Append(config.weburl.ToString());
	templateBuilder.Append("\">DTcms v1.0</a></h1>\r\n </div>\r\n <div class=\"search\">\r\n   <input id=\"keywords\" name=\"keywords\" type=\"text\" class=\"search_text\" value=\"输入关健字\" onfocus=\"javascript:if(this.value=='输入关健字')this.value='';\" onblur=\"javascript:if(this.value=='')this.value='输入关健字'\" />\r\n   <input type=\"button\" value=\"搜索\" class=\"search_button\" onclick=\"SiteSearch('");
	templateBuilder.Append(config.webpath.ToString());
	templateBuilder.Append("search.aspx', '#keywords');\" />\r\n </div>\r\n <!-- .nav -->\r\n <div class=\"clear\"></div>\r\n <div class=\"nav\">\r\n  <ul>\r\n   <li><a href=\"");
	templateBuilder.Append(linkurl("index",""));

	templateBuilder.Append("\">首 页</a></li>\r\n   <li><a href=\"");
	templateBuilder.Append(linkurl("article_list",""));

	templateBuilder.Append("\">新闻资讯</a></li>\r\n   <li><a href=\"");
	templateBuilder.Append(linkurl("goods_list",""));

	templateBuilder.Append("\">商品展示</a></li>\r\n   <li><a href=\"");
	templateBuilder.Append(linkurl("photo_list",""));

	templateBuilder.Append("\">图片分享</a></li>\r\n   <li><a href=\"");
	templateBuilder.Append(linkurl("down_list",""));

	templateBuilder.Append("\">资源下载</a></li>\r\n   <li><a href=\"");
	templateBuilder.Append(linkurl("feedback",""));

	templateBuilder.Append("\">在线留言</a></li>\r\n   <li><a href=\"");
	templateBuilder.Append(linkurl("content","about"));

	templateBuilder.Append("\">关于我们</a></li>\r\n   <li><a href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\">联系我们</a></li>\r\n  </ul>\r\n </div>\r\n <!-- /.nav -->");


	templateBuilder.Append("\r\n <!-- /.header -->\r\n <div class=\"clear\"></div>\r\n <div class=\"grid_12\">\r\n  <div class=\"banner\"><img src=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/images/banner.jpg\" width=\"940\" height=\"150\" alt=\"dtcms\" /></div>\r\n </div>\r\n <!-- end banner -->\r\n <div class=\"clear\"></div>\r\n <div class=\"grid_8\">\r\n  <div class=\"grid_4 alpha\">\r\n   <div class=\"list_box\">\r\n    <h2><a href=\"");
	templateBuilder.Append(linkurl("article_list",""));

	templateBuilder.Append("\">最新资讯</a></h2>\r\n    <div class=\"hot_news\">\r\n      ");
	DataTable article_list1 = get_article_list(1, 0, 1, "is_lock=0 and is_top=1");
	

	int adr1__loop__id=0;
	foreach(DataRow adr1 in article_list1.Rows)
	{
		adr1__loop__id++;


	templateBuilder.Append("\r\n      <a href=\"");
	templateBuilder.Append(linkurl("article_show",adr1["id"].ToString().Trim()));

	templateBuilder.Append("\" class=\"hot_news_img\"><img src=\"" + adr1["img_url"].ToString().Trim() + "\" width=\"260\" alt=\"" + adr1["title"].ToString().Trim() + "\" /></a>\r\n      <a href=\"");
	templateBuilder.Append(linkurl("article_show",adr1["id"].ToString().Trim()));

	templateBuilder.Append("\">" + adr1["title"].ToString().Trim() + "</a><span>( ");	templateBuilder.Append(Utils.ObjectToDateTime(adr1["add_time"].ToString().Trim()).ToString("yyyy-MM-dd"));

	templateBuilder.Append(" )</span>\r\n      <p>");
	templateBuilder.Append(Utils.DropHTML(adr1["zhaiyao"].ToString().Trim(),120));

	templateBuilder.Append("</p>\r\n      ");
	}	//end loop


	templateBuilder.Append("\r\n    </div>\r\n    <ul class=\"news_list\">\r\n	 ");
	DataTable article_list5 = get_article_list(1, 0, 5, "is_lock=0");
	

	int adr5__loop__id=0;
	foreach(DataRow adr5 in article_list5.Rows)
	{
		adr5__loop__id++;


	templateBuilder.Append("\r\n     <li><span>( ");	templateBuilder.Append(Utils.ObjectToDateTime(adr5["add_time"].ToString().Trim()).ToString("MM-dd"));

	templateBuilder.Append(" )</span><a href=\"");
	templateBuilder.Append(linkurl("article_show",adr5["id"].ToString().Trim()));

	templateBuilder.Append("\">");
	templateBuilder.Append(Utils.DropHTML(adr5["title"].ToString().Trim(),28));

	templateBuilder.Append("</a></li>\r\n     ");
	}	//end loop


	templateBuilder.Append("\r\n    </ul>\r\n   </div>\r\n   <div class=\"list_box clearfix\">\r\n    <h2><a href=\"");
	templateBuilder.Append(linkurl("photo_list",""));

	templateBuilder.Append("\">图片分享</a></h2>\r\n    <ul class=\"index_img_list\">\r\n     ");
	DataTable photo_list6 = get_photo_list(2, 0, 6, "is_lock=0");
	

	int pdr6__loop__id=0;
	foreach(DataRow pdr6 in photo_list6.Rows)
	{
		pdr6__loop__id++;


	templateBuilder.Append("\r\n     <li><a href=\"");
	templateBuilder.Append(linkurl("photo_show",pdr6["id"].ToString().Trim()));

	templateBuilder.Append("\"><img src=\"" + pdr6["img_url"].ToString().Trim() + "\" width=\"125\" height=\"125\" alt=\"" + pdr6["title"].ToString().Trim() + "\" /><span>" + pdr6["title"].ToString().Trim() + "</span></a></li>\r\n     ");
	}	//end loop


	templateBuilder.Append("\r\n    </ul>\r\n    <div class=\"clear\"></div>\r\n   </div>\r\n  </div>\r\n  <div class=\"grid_4 omega\">\r\n   <div class=\"list_box hot\">\r\n    <h2><a href=\"");
	templateBuilder.Append(linkurl("down_list",""));

	templateBuilder.Append("\">热门资源</a></h2>\r\n    ");
	DataTable down_list1 = get_download_list(3, 0, 1, "is_lock=0 and is_red=1");
	

	int ddr1__loop__id=0;
	foreach(DataRow ddr1 in down_list1.Rows)
	{
		ddr1__loop__id++;


	templateBuilder.Append("\r\n    <div class=\"hot_down clearfix\">\r\n      <a href=\"");
	templateBuilder.Append(linkurl("down_show",ddr1["id"].ToString().Trim()));

	templateBuilder.Append("\" title=\"" + ddr1["title"].ToString().Trim() + "\"><img src=\"" + ddr1["img_url"].ToString().Trim() + "\" width=\"75\" height=\"75\" /></a>\r\n      <b><a href=\"");
	templateBuilder.Append(linkurl("down_show",ddr1["id"].ToString().Trim()));

	templateBuilder.Append("\" title=\"" + ddr1["title"].ToString().Trim() + "\">");
	templateBuilder.Append(Utils.DropHTML(ddr1["title"].ToString().Trim(),18));

	templateBuilder.Append("</a></b>\r\n      <p>");
	templateBuilder.Append(Utils.DropHTML(ddr1["content"].ToString().Trim(),68));

	templateBuilder.Append("</p>\r\n    </div>\r\n     ");
	}	//end loop


	templateBuilder.Append("\r\n    <ul class=\"news_list\">\r\n     ");
	DataTable down_list16 = get_download_list(3, 0, 6, "is_lock=0");
	

	int ddr16__loop__id=0;
	foreach(DataRow ddr16 in down_list16.Rows)
	{
		ddr16__loop__id++;


	templateBuilder.Append("\r\n     <li><span>( ");	templateBuilder.Append(Utils.ObjectToDateTime(ddr16["add_time"].ToString().Trim()).ToString("MM-dd"));

	templateBuilder.Append(" )</span><a href=\"");
	templateBuilder.Append(linkurl("down_show",ddr16["id"].ToString().Trim()));

	templateBuilder.Append("\">");
	templateBuilder.Append(Utils.DropHTML(ddr16["title"].ToString().Trim(),26));

	templateBuilder.Append("</a></li>\r\n     ");
	}	//end loop


	templateBuilder.Append("\r\n    </ul>\r\n   </div>\r\n   <div class=\"list_box\">\r\n    <h2><a href=\"");
	templateBuilder.Append(linkurl("down_list",""));

	templateBuilder.Append("\">图标素材</a></h2>\r\n    <ul class=\"news_list\">\r\n     ");
	DataTable down_list28 = get_download_list(3, 21, 8, "is_lock=0");
	

	int ddr28__loop__id=0;
	foreach(DataRow ddr28 in down_list28.Rows)
	{
		ddr28__loop__id++;


	templateBuilder.Append("\r\n     <li><span>( ");	templateBuilder.Append(Utils.ObjectToDateTime(ddr28["add_time"].ToString().Trim()).ToString("MM-dd"));

	templateBuilder.Append(" )</span><a href=\"");
	templateBuilder.Append(linkurl("down_show",ddr28["id"].ToString().Trim()));

	templateBuilder.Append("\">");
	templateBuilder.Append(Utils.DropHTML(ddr28["title"].ToString().Trim(),26));

	templateBuilder.Append("</a></li>\r\n     ");
	}	//end loop


	templateBuilder.Append("\r\n    </ul>\r\n   </div>\r\n   <div class=\"list_box\">\r\n    <h2><a href=\"");
	templateBuilder.Append(linkurl("down_list",""));

	templateBuilder.Append("\">JQuery应用</a></h2>\r\n    <ul class=\"news_list\">\r\n     ");
	DataTable down_list38 = get_download_list(3, 26, 8, "is_lock=0");
	

	int ddr38__loop__id=0;
	foreach(DataRow ddr38 in down_list38.Rows)
	{
		ddr38__loop__id++;


	templateBuilder.Append("\r\n     <li><span>( ");	templateBuilder.Append(Utils.ObjectToDateTime(ddr38["add_time"].ToString().Trim()).ToString("MM-dd"));

	templateBuilder.Append(" )</span><a href=\"");
	templateBuilder.Append(linkurl("down_show",ddr38["id"].ToString().Trim()));

	templateBuilder.Append("\">");
	templateBuilder.Append(Utils.DropHTML(ddr38["title"].ToString().Trim(),26));

	templateBuilder.Append("</a></li>\r\n     ");
	}	//end loop


	templateBuilder.Append("\r\n    </ul>\r\n   </div>\r\n  </div>\r\n </div>\r\n <!-- end content -->\r\n <div class=\"grid_4 sidebar\">\r\n   <h2><a href=\"");
	templateBuilder.Append(linkurl("goods_list",""));

	templateBuilder.Append("\">商品排行榜</a></h2>\r\n   <div class=\"hot_list\">\r\n     <ul>\r\n       ");
	DataTable photo_list10 = get_photo_list(5, 0, 10, "is_lock=0 and is_red=1");
	

	int pdr10__loop__id=0;
	foreach(DataRow pdr10 in photo_list10.Rows)
	{
		pdr10__loop__id++;


	if (pdr10__loop__id==1)
	{

	templateBuilder.Append("\r\n       <li class=\"first\">\r\n         <b><a href=\"");
	templateBuilder.Append(linkurl("goods_show",pdr10["id"].ToString().Trim()));

	templateBuilder.Append("\">" + pdr10["title"].ToString().Trim() + "</a></b>\r\n         <p>");
	templateBuilder.Append(Utils.DropHTML(pdr10["content"].ToString().Trim(),80));

	templateBuilder.Append("</p>\r\n       </li>\r\n       ");	continue;


	}	//end if


	templateBuilder.Append("\r\n       <li><span>( ");	templateBuilder.Append(Utils.ObjectToDateTime(pdr10["add_time"].ToString().Trim()).ToString("MM-dd"));

	templateBuilder.Append(" )</span><a href=\"");
	templateBuilder.Append(linkurl("goods_show",pdr10["id"].ToString().Trim()));

	templateBuilder.Append("\">");
	templateBuilder.Append(Utils.DropHTML(pdr10["title"].ToString().Trim(),28));

	templateBuilder.Append("</a></li>\r\n       ");
	}	//end loop


	templateBuilder.Append("\r\n     </ul>\r\n   </div>\r\n   <div class=\"sidebar_ad\"><a href=\"http://www.dtcms.net\" target=\"_blank\"><img src=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/images/sidebar_ad.jpg\" width=\"300\" height=\"232\" alt=\"dtcms\" /></a></div>\r\n   <div class=\"sidebar\">\r\n    <h2><a href=\"");
	templateBuilder.Append(linkurl("feedback",""));

	templateBuilder.Append("\">最新留言</a></h2>\r\n    <ul class=\"news_list\">\r\n     ");
	DataTable feedback_list = get_plugin_method("DTcms.Web.Plugin.Feedback", "feedback", "get_feedback_list", 4, "is_lock=0");
	

	int fdr__loop__id=0;
	foreach(DataRow fdr in feedback_list.Rows)
	{
		fdr__loop__id++;


	templateBuilder.Append("\r\n     <li><span>( ");	templateBuilder.Append(Utils.ObjectToDateTime(fdr["add_time"].ToString().Trim()).ToString("MM-dd"));

	templateBuilder.Append(" )</span><a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("feedback",""));

	templateBuilder.Append("\"><b>" + fdr["user_name"].ToString().Trim() + "：</b>");
	templateBuilder.Append(Utils.DropHTML(fdr["title"].ToString().Trim(),26));

	templateBuilder.Append("</a></li>\r\n     ");
	}	//end loop


	templateBuilder.Append("\r\n    </ul>\r\n   </div>\r\n   <div class=\"sidebar\">\r\n    <h2><a href=\"");
	templateBuilder.Append(linkurl("link",""));

	templateBuilder.Append("\">友情链接</a></h2>\r\n    <div class=\"sidebar_link\">\r\n      <ul class=\"txt\">\r\n        ");
	DataTable link_list1 = get_plugin_method("DTcms.Web.Plugin.Link", "link", "get_link_list", 6, "is_lock=0 and is_image=0 and is_red=1");
	

	int ldr1__loop__id=0;
	foreach(DataRow ldr1 in link_list1.Rows)
	{
		ldr1__loop__id++;


	templateBuilder.Append("\r\n        <li><a target=\"_blank\" href=\"" + ldr1["site_url"].ToString().Trim() + "\">" + ldr1["title"].ToString().Trim() + "</a></li>\r\n        ");
	}	//end loop


	templateBuilder.Append("\r\n        <div class=\"clear\"></div>\r\n      </ul>\r\n      <ul class=\"img\">\r\n        ");
	DataTable link_list2 = get_plugin_method("DTcms.Web.Plugin.Link", "link", "get_link_list", 6, "is_lock=0 and is_image=1 and is_red=1");
	

	int ldr2__loop__id=0;
	foreach(DataRow ldr2 in link_list2.Rows)
	{
		ldr2__loop__id++;


	templateBuilder.Append("\r\n        <li><a target=\"_blank\" href=\"" + ldr2["site_url"].ToString().Trim() + "\" title=\"" + ldr2["title"].ToString().Trim() + "\"><img src=\"" + ldr2["img_url"].ToString().Trim() + "\" width=\"88\" height=\"31\" /></a></li>\r\n        ");
	}	//end loop


	templateBuilder.Append("\r\n        <div class=\"clear\"></div>\r\n      </ul>\r\n    </div>\r\n  </div>\r\n </div>\r\n <!-- end sidebar -->\r\n <!-- .footer -->\r\n ");

	templateBuilder.Append(" <div class=\"clear\"></div>\r\n <div class=\"grid_12 footer\"> <a href=\"#\" class=\"back_to_top\">top</a>\r\n   <p>");
	templateBuilder.Append(config.webcopyright.ToString());
	templateBuilder.Append(" &nbsp;");
	templateBuilder.Append(config.webcountcode.ToString());
	templateBuilder.Append("</p>\r\n </div>\r\n <div class=\"clear\"></div>");


	templateBuilder.Append("\r\n <!-- /.footer -->\r\n</div>\r\n</body>\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
