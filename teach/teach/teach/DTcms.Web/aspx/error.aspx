<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.error" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<title>提示信息</title>\r\n<style type=\"text/css\">\r\n*{ padding:0; margin:0; font-size:12px; font-family:\"Microsoft YaHei\"}\r\n.showMsg .guery {white-space: pre-wrap; /* css-3 */white-space: -moz-pre-wrap; /* Mozilla, since 1999 */white-space: -pre-wrap; /* Opera 4-6 */white-space: -o-pre-wrap; /* Opera 7 */	word-wrap: break-word; /* Internet Explorer 5.5+ */}\r\na:link,a:visited{text-decoration:none;color:#0068a6}\r\na:hover,a:active{color:#ff6600;text-decoration: underline}\r\n.showMsg{border: 1px solid #1e64c8; zoom:1; width:450px; height:174px;position:absolute;top:50%;left:50%;margin:-87px 0 0 -225px}\r\n.showMsg h5{background-image: url(");
	templateBuilder.Append(config.webpath.ToString());
	templateBuilder.Append("images/msg.png);background-repeat: no-repeat; color:#fff; padding-left:35px; height:25px; line-height:26px;*line-height:28px; overflow:hidden; font-size:14px; text-align:left}\r\n.showMsg .content{ padding:46px 12px 10px 45px; font-size:14px; height:66px;}\r\n.showMsg .bottom{ background:#e4ecf7; margin: 0 1px 1px 1px;line-height:26px; *line-height:30px; height:26px; text-align:center}\r\n.showMsg .ok,.showMsg .guery{background: url(");
	templateBuilder.Append(config.webpath.ToString());
	templateBuilder.Append("images/msg_bg.png) no-repeat 0px -560px;}\r\n.showMsg .guery{background-position: left -460px;}\r\n</style>\r\n</head>\r\n<body>\r\n<div class=\"showMsg\" style=\"text-align:center\">\r\n	<h5>提示信息</h5>\r\n    <div class=\"content guery\" style=\"display:inline-block;display:-moz-inline-stack;zoom:1;*display:inline; max-width:280px\">\r\n        ");
	templateBuilder.Append(msg.ToString());
	templateBuilder.Append("\r\n    </div>\r\n    <div class=\"bottom\">\r\n    	<a href=\"javascript:history.back();\" >[点这里返回上一页]</a>\r\n	</div>\r\n</div>\r\n</body>\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
