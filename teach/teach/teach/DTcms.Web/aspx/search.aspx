<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.search" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<title>站内搜索 - ");
	templateBuilder.Append(config.webname.ToString());
	templateBuilder.Append("</title>\r\n<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/css/style.css\" />\r\n<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append(config.webpath.ToString());
	templateBuilder.Append("css/pagination.css\" />\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(config.webpath.ToString());
	templateBuilder.Append("scripts/jquery/jquery-1.3.2.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/js/base.js\"></");
	templateBuilder.Append("script>\r\n</head>\r\n<body>\r\n<div class=\"container_12\">\r\n  <!-- .header -->\r\n  ");

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


	templateBuilder.Append("\r\n  <!-- /.header -->\r\n  <div class=\"clear\"></div>\r\n  <div class=\"grid_8\" style=\"width:940px;\">\r\n    ");
	DataTable list = get_search_list(15, out totalcount);
	

	templateBuilder.Append(" <!--取得一个DataTable-->\r\n	");
	string pagelist = get_page_link(15, page, totalcount, "search.aspx?keyword="+Server.UrlEncode(keyword)+"&page=__id__");
	

	templateBuilder.Append(" <!--取得分页页码列表-->\r\n    <h2 class=\"page_title_view\"><a>首页</a> &gt; <a>站内搜索</a></h2>\r\n    <h3 class=\"page_news_title\">站内搜索</h3>\r\n    <i class=\"page_news_date\">搜索关健字：");
	templateBuilder.Append(keyword.ToString());
	templateBuilder.Append("，共有");
	templateBuilder.Append(totalcount.ToString());
	templateBuilder.Append("记录 </i>\r\n    <ul class=\"page_news_list\">\r\n      ");
	int dr__loop__id=0;
	foreach(DataRow dr in list.Rows)
	{
		dr__loop__id++;


	templateBuilder.Append("\r\n      <li>\r\n        <a target=\"_blank\" href=\"" + dr["link_url"].ToString().Trim() + "\">" + dr["title"].ToString().Trim() + "</a><span>( ");	templateBuilder.Append(Utils.ObjectToDateTime(dr["add_time"].ToString().Trim()).ToString("yyyy-MM-dd"));

	templateBuilder.Append(" )</span>\r\n        <p>" + dr["remark"].ToString().Trim() + "</p>\r\n      </li>\r\n      ");
	}	//end loop


	templateBuilder.Append("\r\n    </ul>\r\n    <div class=\"line10\"></div>\r\n    <div class=\"flickr\">");
	templateBuilder.Append(pagelist.ToString());
	templateBuilder.Append("</div> <!--放置页码列表-->\r\n    <div class=\"line10\"></div>\r\n  </div>\r\n  <!-- end content -->\r\n\r\n  <!-- .footer -->\r\n  ");

	templateBuilder.Append(" <div class=\"clear\"></div>\r\n <div class=\"grid_12 footer\"> <a href=\"#\" class=\"back_to_top\">top</a>\r\n   <p>");
	templateBuilder.Append(config.webcopyright.ToString());
	templateBuilder.Append(" &nbsp;");
	templateBuilder.Append(config.webcountcode.ToString());
	templateBuilder.Append("</p>\r\n </div>\r\n <div class=\"clear\"></div>");


	templateBuilder.Append("\r\n  <!-- /.footer -->\r\n</div>\r\n</body>\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
