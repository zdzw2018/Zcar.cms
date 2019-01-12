<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list_view.aspx.cs" Inherits="DTcms.Web.admin.student_return.list_view" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>学生信息管理</title>
    <link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
    <link type="text/css" rel="stylesheet" href="../images/style.css" />
    <link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
    <div class="navigation">首页 &gt; 学员回访记录 &gt; 学员名称：<asp:Label ID="lbluser_name" runat="server"></asp:Label> 年级：<asp:Label ID="lblgrade" runat="server"></asp:Label></div>
    <div class="tools_box">
	    <div class="tools_bar">
            <div class="search_box">
			    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click" />
		    </div>
           
            <a id="xueyuan"  href="list.aspx?channel_id=<%=this.channel_id %>" class="tools_btn"><span><b class="return">学员列表</b></span></a>
            <a id="tianjia"  href="edit.aspx?channel_id=<%=this.channel_id %>&action=<%#ActionEnum.Add %>&id=<%=this.user_id%>" class="tools_btn"><span><b class="add">添加信息</b></span></a>
         
        </div>
    </div>
    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th align="center" width="10%">回访时间</th>
        <th align="center" width="60%">回访内容</th>
        <th width="10%" align="center">回访人</th>
        <th align="center" width="10%">回访类型</th>
        <th align="center">操作</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><%#string.Format("{0:d}", Eval("add_time"))%></td>
        <td align="center"><%#Eval("return_content")%></td>
        <td align="center"><%#Eval("return_user_name")%></td>
        <td align="center"><%#Eval("return_result")%></td>
        <td align="center"><a href="edit.aspx?channel_id=<%=this.channel_id %>&action=<%#ActionEnum.Edit %>&id=<%=this.user_id%>&return_id=<%#Eval("id")%>">修改</a>&nbsp;&nbsp;<asp:LinkButton ID="shanchu" CommandArgument='<%#Eval("id")%>'   runat="server"  OnClientClick="return confirm('删除记录后不可恢复，您确定吗？');" onclick="shanchu" >删除</asp:LinkButton></td>
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
