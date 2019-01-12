<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="market_resource_list.aspx.cs" Inherits="DTcms.Web.admin.market.list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>资讯管理</title>
<link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
<link type="text/css" rel="stylesheet" href="../images/style.css" />
<link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../js/function.js"></script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
    <div class="navigation">首页 &gt; 资源管理 &gt; 管理列表</div>
    <div class="tools_box">
	    <div class="tools_bar">
            <div class="search_box">
			    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click" />
		    </div>
            <a href="edit.aspx?action=<%=ActionEnum.Add %>" class="tools_btn"><span><b class="add">添加资源</b></span></a>
            <asp:LinkButton ID="btnSave" runat="server" CssClass="tools_btn" onclick="btnSave_Click"><span><b class="send">保存排序</b></span></asp:LinkButton>
		    <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>
            <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn"  
                OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><span><b class="delete">批量删除</b></span></asp:LinkButton>
        </div>
        <div class="select_box">
            请选择：&nbsp;
            <asp:DropDownList ID="ddlProperty" runat="server" CssClass="select2" AutoPostBack="True" >
                <asp:ListItem Value="" Selected="True">收集途径</asp:ListItem> 
                <asp:ListItem Value="ques">问卷</asp:ListItem>
                <asp:ListItem Value="outfield">外场</asp:ListItem>
                <asp:ListItem Value="purchase">资源购买</asp:ListItem>
                <asp:ListItem Value="other">其他</asp:ListItem> 
            </asp:DropDownList>
	    </div>
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server" onitemcommand="rptList_ItemCommand">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="6%"  width="10%" >选择</th>
        <th align="left" width="10%" >家长姓名</th>
        <th width="10%" align="left">学生姓名</th>
        <th width="10%" align="left">收集日期</th>
        <th width="10%" align="left">联系电话</th>

        <th width="10%" align="left">学校</th>
        <th width="10%" align="left">年级</th>
        <th width="10%" align="left">家庭住址</th>

        
        <th width="10%" align="left">市场人员</th>
        <th width="10%" align="left">收集途径</th>
        <th width="10%" align="left">备注</th>

      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /></td>
        <td><a href="edit.aspx"><%#Eval("rparent_name")%></a></td>
        <td><a href="edit.aspx"><%#Eval("rstudent_name")%></a></td> 
        <td><%#string.Format("{0:g}", Eval("add_time"))%></td>
        <td align="left"><%#Eval("tel")%></td>
       
         <td align="left"><%#Eval("rschool")%></td>
         <td align="left"><%#Eval("rgrade")%></td>
         <td align="left"><%#Eval("raddr")%></td>

         <td align="left"><%#Eval("rmarket_man")%></td>
         <td align="left"><%#Eval("rcollect_choose")%></td>
         <td align="left"><%#Eval("remark")%></td> 

        <td align="left"><a href="edit.aspx?action=<%#ActionEnum.Edit %>&id=<%#Eval("id")%>">修改</a></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
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
