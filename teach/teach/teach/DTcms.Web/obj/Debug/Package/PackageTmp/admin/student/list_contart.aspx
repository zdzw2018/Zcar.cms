﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list_contart.aspx.cs" Inherits="DTcms.Web.admin.student.list_contart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <div class="navigation">首页 &gt; 学员合同续费 &gt; 学员管理 </div>
    <div class="tools_box">
	    <div class="tools_bar">
            <div class="search_box">

             <asp:LinkButton ID="lb20KeShi" CommandArgument="<20" runat="server" onclick="lb20KeShi_Click">20课时以内</asp:LinkButton>
            <asp:DropDownList ID="ddlShouSou" runat="server" CssClass="select2" >
                <asp:ListItem Value="stu">学生姓名</asp:ListItem>
                <asp:ListItem Value="xuexiao">学校名</asp:ListItem>
              
                </asp:DropDownList>
			    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click" />
		    </div>
           
		  
            
          

        </div>
          <asp:DropDownList ID="ddlGrade" runat="server" CssClass="select2" 
                AutoPostBack="True" onselectedindexchanged="ddlGrade_SelectedIndexChanged">
            </asp:DropDownList>
        <div class="select_box" style="display:none">
            合同状态：<asp:DropDownList ID="ddlProperty" runat="server" CssClass="select2" AutoPostBack="True" onselectedindexchanged="ddlProperty_SelectedIndexChanged">
            <asp:ListItem Text="全部" Value=""></asp:ListItem>
            <asp:ListItem Text="未签合同" Value="添加合同"></asp:ListItem>
            <asp:ListItem Text="已签合同" Value="查看合同"></asp:ListItem>
            </asp:DropDownList>
	    </div>

          <asp:DropDownList ID="ddlXueGuan" runat="server" CssClass="select2" 
                AutoPostBack="true" onselectedindexchanged="ddlXueGuan_SelectedIndexChanged">
        </asp:DropDownList>
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
      
        <th align="center" width="7%">学生姓名</th>
          <th align="center" width="5%">学管师</th>
        <th width="7%" align="center">学校</th>
        <th width="7%" align="center">年级</th>
        <th width="5%" align="center">课时</th>
         <th width="5%" align="center">剩余课时</th>
        <th width="8%">操作</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
       
        <td align="center">  <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
        <asp:HiddenField ID="hidcontract_id" Value='<%#Eval("contract_id")%>' runat="server" /><%#Eval("stu_name")%></td>
          <td align="center"><%#getXueGuanName(int.Parse(Eval("id").ToString()))%></td>
        <td align="center"><%#Eval("stu_school")%></td>
        <td align="center"><%#Eval("stu_grade")%></td>
        <td align="center"><%#getTotalKeShi(int.Parse(Eval("id").ToString()))%></td>
        <td align="center"><%#getTotalKeShi(int.Parse(Eval("id").ToString())) - getKeShi(int.Parse(Eval("id").ToString()))%></td>
        <td align="center"><a href="view.aspx?channel_id=<%#this.channel_id %>&action=<%#ActionEnum.Edit %>&id=<%#Eval("id")%>">查看</a> <a href="edit_contart.aspx?channel_id=<%#this.channel_id %>&action=<%#ActionEnum.Add %>&id=<%#Eval("id")%>">续费</a></td>
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

