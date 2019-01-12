<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="center.aspx.cs" Inherits="DTcms.Web.admin.center" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>管理首页</title>
<link href="images/style.css" rel="stylesheet" type="text/css" />
</head>
<body class="mainbody">
<form id="form1" runat="server">
<div class="navigation nav_icon">你好，<i><%=admin_info.user_name %>(<%=new DTcms.BLL.manager_role().GetTitle(admin_info.role_id) %>)</i>，欢迎进入后台管理中心</div>
<div class="line10"></div>
<div class="nlist1"  style="width:1050px;">
	<ul>
    	<li>本次登录IP：<asp:Literal ID="litIP" runat="server" Text="-" /></li>
        <li>上次登录IP：<asp:Literal ID="litBackIP" runat="server" Text="-" /></li>
        <li>上次登录时间：<asp:Literal ID="litBackTime" runat="server" Text="-" /></li>
    </ul>
    <ul>
        <li>
            乐优论坛链接：<a href="http://bbs.leyouedu.com" target="_blank" >进入论坛</a>
        </li>
        <li>
            乐优官网链接：<a href="http://www.leyouedu.com" target="_blank" >进入官网</a>
        </li>
        <li>
            中学学科网：<a href="http://www.zxxk.com" target="_blank" >进入官网</a>
        </li>
        <li>&nbsp;</li>
    </ul>
</div>

<div>	
 <image  src="images/leyou.jpg" />
</div>
    </form>
</body>
</html>