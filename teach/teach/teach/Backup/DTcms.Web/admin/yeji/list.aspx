<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="DTcms.Web.admin.yeji.list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>个人业绩管理</title>
    <link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
    <link type="text/css" rel="stylesheet" href="../images/style.css" />
    <link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
     <script type="text/javascript" src="../../scripts/calendar.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="navigation">首页 &gt; 个人业绩管理 &gt; 管理列表</div>
    <div class="tools_box">
	    <div class="tools_bar">
        <div class="search_box">
        开始时间：<asp:TextBox ID="txtStartTime" runat="server"  CssClass="txtInput required" onclick="return Calendar('txtStartTime');" maxlength="100"></asp:TextBox>
        结束时间：<asp:TextBox ID="txtEndTime" runat="server"  CssClass="txtInput required" onclick="return Calendar('txtEndTime');" maxlength="100"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click" />
        </div>
        </div>
        <div class="select_box">
            请选择：
	    </div>
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
      <th width="15%" align="center">姓名</th>
       <th align="center" width="15%">年份</th>
       <th align="center" width="15%">月份</th>
        <th align="center" width="15%">新签金额</th>
        <th align="center">实收金额</th>
        <th align="center" width="10%">新签人数</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
         <td align="center"><%#new DTcms.BLL.manager().GetModel(int.Parse(Eval("user_id").ToString())).real_name %></td>
         <td align="center"><%#Eval("year") %></td>
         <td align="center"><%#Eval("month") %></td>
        <td align="center"><%#Eval("newmoney")%></td>
        <td align="center"><%#Eval("realmoney")%></td>
        <td align="center"><%#Eval("hetong")%></td>
              </tr>
    </ItemTemplate>
    <FooterTemplate>
      <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
      </table>
    </FooterTemplate>
    </asp:Repeater>
    <!--列表展示.结束-->

   
    <div class="line15"></div>
    <div class="page_box">
      <div id="PageContent" runat="server" class="flickr right"></div>
      <div class="left">
         显示<asp:TextBox ID="txtPageNum" runat="server" CssClass="txtInput2 small2" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" 
             ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
      </div>
    </div>
    <div class="line10"></div>
</form>
</body>
</html>
