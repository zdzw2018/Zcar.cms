<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="keshi_detial.aspx.cs" Inherits="DTcms.Web.admin.zlesson.keshi_detial" %>

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
    <div class="navigation"> <a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 学员课时记录 &gt; 课时列表</div>
    

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th align="center" width="7%">学生姓名</th>
        <th width="7%" align="center">上课课时</th>
        <th width="7%" align="center">上课时间</th>
        <th width="5%" align="center">添加人</th>
        <th width="8%">操作</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><%#new DTcms.BLL.student_info().GetModel(int.Parse(Eval("stu_id").ToString())).stu_name%></td>
        <td align="center"><%#Eval("stu_lesson") %></td>
        <td align="center"><%#Convert.ToDateTime(Eval("add_time")).ToString("yyyy-MM-dd")%></td>
        <td align="center"><%#new DTcms.BLL.manager().GetModel(int.Parse(Eval("user_id").ToString())).real_name%></td>
        <td align="center"><a href="add_keshi.aspx?id=<%#Eval("id")%>">修改</a></td>
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

