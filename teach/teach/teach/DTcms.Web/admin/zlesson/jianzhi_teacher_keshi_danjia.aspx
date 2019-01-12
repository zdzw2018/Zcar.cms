<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jianzhi_teacher_keshi_danjia.aspx.cs" Inherits="DTcms.Web.admin.zlesson.jianzhi_teacher_keshi_danjia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>兼职教师课时单价管理</title>
    <link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
    <link type="text/css" rel="stylesheet" href="../images/style.css" />
    <link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
    
</head>
<body class="mainbody">
<form id="form1" runat="server">
 
    <div class="navigation"> 首页 &gt; 兼职教师管理 &gt; 兼职教师课时单价</div>
    <div class="tools_box">
	    <div class="tools_bar">
            <%if (model.role_id == 1 || model.role_id == 10 || model.role_id == 16){%>
             <a href="jianzhi_teacher_keshi_danjia_edit.aspx?action=<%=ActionEnum.Add %>&channel_id=<%=channel_id %>" class="tools_btn"><span><b class="add">添加课时单价</b></span></a> 
               <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn"  
                OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><span><b class="delete">批量删除</b></span></asp:LinkButton>
              <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>
            <%} %>
            <div class="search_box">
                 
			    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click" />
		    </div>
        </div>

        <div class="select_box">
            教师筛选：&nbsp;
            
               <asp:DropDownList ID="ddlTeacher" runat="server" CssClass="select2" 
                AutoPostBack="True" 
                onselectedindexchanged="ddlTeacher_SelectedIndexChanged"  >

                </asp:DropDownList>
	    </div>
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
       <th width="6%" align="center">选择</th>
        <th align="center" width="15%">教师姓名</th>
         <th align="center" width="15%">年级</th>
        <th width="15%" align="center">课时单价</th>
         <%if (model.role_id == 1 || model.role_id == 10 || model.role_id == 16){%>
        <th width="10%" align="center">操作</th>
          <%} %>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
           <td align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /></td>
        <td align="center"><%#Eval("teacher_name")%></td>
         <td align="center"><%#Eval("grade")%></td>
        <td align="center"><%#Eval("keshi_danjia")%></td>
       
       
         <%if (model.role_id == 1 || model.role_id == 10 || model.role_id == 16){%>
        <td align="center"><a href="jianzhi_teacher_keshi_danjia_edit.aspx?teacher_id=<%#Eval("teacher_id") %>&action=<%=ActionEnum.Edit %>&channel_id=<%=channel_id %>">修改</a>&nbsp;
          <%} %>
        </td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"4\">暂无记录</td></tr>" : ""%>
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
