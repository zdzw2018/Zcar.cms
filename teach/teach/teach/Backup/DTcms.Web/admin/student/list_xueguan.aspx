<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list_xueguan.aspx.cs" Inherits="DTcms.Web.admin.student.list_xueguan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>学管师分配</title>
    <link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
    <link type="text/css" rel="stylesheet" href="../images/style.css" />
    <link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
    <div class="navigation">首页 &gt; 学管师安排 &gt; 学员名称：<asp:Label ID="lbluser_name" runat="server"></asp:Label> 年级：<asp:Label ID="lblgrade" runat="server"></asp:Label></div>
    <div class="tools_box">
	    <div class="tools_bar">
            <div class="search_box">
			    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click" />
		    </div>
            <a href="list_fp.aspx?&channel_id=<%=this.channel_id %>" class="tools_btn"><span><b class="return">学员列表</b></span></a>
            <a href="edit_xueguan.aspx?action=<%=ActionEnum.Add %>&channel_id=<%=this.channel_id %>&user_id=<%=user_id %>" class="tools_btn"><span><b class="add">学管师</b></span></a>
            <a class="tools_btn" href="edit_fp.aspx?action=<%=ActionEnum.Add %>&channel_id=<%=this.channel_id %>&user_id=<%=user_id %>"><span><b class="add">添加老师</b></span></a>
		 
            

        </div>
        <div class="select_box" style=" display:none;">
            合同状态：<asp:DropDownList ID="ddlProperty" runat="server" CssClass="select2" AutoPostBack="True" onselectedindexchanged="ddlProperty_SelectedIndexChanged">
            <asp:ListItem Text="全部" Value=""></asp:ListItem>
            <asp:ListItem Text="未签合同" Value="添加合同"></asp:ListItem>
            <asp:ListItem Text="已签合同" Value="查看合同"></asp:ListItem>
            </asp:DropDownList>
	    </div>
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="6%">选择</th>
        <th align="center">学管师</th>
        <th>操作</th> 
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" />
        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
        </td>
        <td align="center"><%#Eval("manager_name")%></td>
        <td align="center"><a href="edit_xueguan.aspx?channel_id=<%#this.channel_id %>&action=<%#ActionEnum.Edit %>&id=<%#Eval("id")%>&user_id=<%=this.user_id %>">修改</a></td>
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


