<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list_view.aspx.cs" Inherits="DTcms.Web.admin.student_score.list_view" %>

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
            <a href="list.aspx?&channel_id=<%=this.channel_id %>" class="tools_btn"><span><b class="return">学员列表</b></span></a>
            <a href="edit.aspx?channel_id=<%=this.channel_id %>&action=<%#ActionEnum.Add %>&id=<%=this.user_id%>" class="tools_btn"><span><b class="add">添加成绩</b></span></a>
		   


        </div>
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th>学年度</th>
        <th>学期</th>
        <th>成绩类别</th>
        <th>语文</th>
        <th>数学</th>
        <th>外语</th>
        <th>文综</th>
        <th>理综</th>
        <th>生物</th>
        <th>历史</th>
        <th>地理</th>
        <th>物理</th>
        <th>化学</th>
        
        <th>总分</th>
        <th>操作</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><%#Eval("lesson_year")%></td>
        <td align="center"><%#Eval("lesson_semester")%></td>
        <td align="center"><%#Eval("lesson_type")%></td>
        <td align="center"><%#Eval("lesson_01")%></td>
        <td align="center"><%#Eval("lesson_02")%></td>
        <td align="center"><%#Eval("lesson_03")%></td>
        <td align="center"><%#Eval("lesson_04")%></td>
        <td align="center"><%#Eval("lesson_05")%></td>
        <td align="center"><%#Eval("lesson_06")%></td>
        <td align="center"><%#Eval("lesson_07")%></td>
        <td align="center"><%#Eval("lesson_08")%></td>
        <td align="center"><%#Eval("lesson_09")%></td>
        <td align="center"><%#Eval("lesson_010")%></td>
        <td align="center"><%#Eval("lesson_count")%></td>
        <td align="center"><a href="edit.aspx?channel_id=<%=this.channel_id %>&action=<%#ActionEnum.Edit %>&id=<%=this.user_id%>&score_id=<%#Eval("id") %>">修改</a>&nbsp;<asp:LinkButton ID="shanchu" CommandArgument='<%#Eval("id")%>'   runat="server"  OnClientClick="return confirm('删除记录后不可恢复，您确定吗？');" onclick="shanchu" >删除</asp:LinkButton></td>
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
