<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="keshi_list.aspx.cs" Inherits="DTcms.Web.admin.zlesson.keshi_list" %>

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
 
    <div class="navigation"> 首页 &gt; 学员课时记录 &gt; 课时列表</div>
    <div class="tools_box">
	    <div class="tools_bar">
            <div class="search_box">
            <asp:DropDownList ID="ddlShouSou" runat="server" CssClass="select2" >
                <asp:ListItem Value="stu">学生姓名</asp:ListItem>

                <asp:ListItem Value="xuexiao">学校名</asp:ListItem>
                
                </asp:DropDownList>
			    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click" />
		    </div>
        </div>

        <div class="select_box">
            选择筛选：&nbsp;
            年份：
               <asp:DropDownList ID="ddlYear" runat="server" CssClass="select2" 
                AutoPostBack="True" 
                onselectedindexchanged="ddlYear_SelectedIndexChanged"  >

                </asp:DropDownList>
          月份：  <asp:DropDownList ID="ddlMonth" runat="server" CssClass="select2" 
                AutoPostBack="True" onselectedindexchanged="ddlMonth_SelectedIndexChanged" >
                 <asp:ListItem Value="" Selected="True">请选择</asp:ListItem>
                <asp:ListItem Value="1">一月份</asp:ListItem>
                <asp:ListItem Value="2">二月份</asp:ListItem>
                <asp:ListItem Value="3">三月份</asp:ListItem>
                <asp:ListItem Value="4">四月份</asp:ListItem>
                <asp:ListItem Value="5">五月份</asp:ListItem>
                <asp:ListItem Value="6">六月份</asp:ListItem>
                <asp:ListItem Value="7">七月份</asp:ListItem>
                <asp:ListItem Value="8">八月份</asp:ListItem>
                <asp:ListItem Value="9">九月份</asp:ListItem>
                <asp:ListItem Value="10">十月份</asp:ListItem>
                <asp:ListItem Value="11">十一月</asp:ListItem>
                <asp:ListItem Value="12">十二月</asp:ListItem>
            </asp:DropDownList>

               <asp:DropDownList ID="ddlGrade" runat="server" CssClass="select2" 
                AutoPostBack="True" onselectedindexchanged="ddlGrade_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:DropDownList ID="ddlXueGuan" runat="server" CssClass="select2" 
                AutoPostBack="true" onselectedindexchanged="ddlXueGuan_SelectedIndexChanged">
        </asp:DropDownList>
          
	    </div>
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
       
        <th align="center" width="7%">学生姓名</th>
         <th align="center" width="5%">学管师</th>
        <th width="5%" align="center">学校</th>
        <th width="5%" align="center">年级</th>
        <th width="5%" align="center">已上课时数</th>
        <th width="5%" align="center">剩余课时数</th>
        <th width="9%" align="center">月份课时数</th>
        <th width="7%" align="center">新签课时收入</th>
         <th width="7%" align="center">续费课时收入</th>
        <th width="8%">操作</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><%#Eval("stu_name")%></td>
         <td align="center"><%#getXueGuanName(int.Parse(Eval("id").ToString()))%></td>
        <td align="center"><%#Eval("stu_school")%></td>
        <td align="center"><%#Eval("stu_grade")%></td>
        <td align="center"><%#getKeShi(int.Parse(Eval("id").ToString()))%></td>
        <td align="center"><%#getTotalKeShi(int.Parse(Eval("id").ToString())) - getKeShi(int.Parse(Eval("id").ToString()))%></td>
        <td align="center"><%=monthCount%>月份：新签课时：<%#getKeShiMonth(int.Parse(Eval("id").ToString()), monthCount,yearCount)%>课时 &nbsp;续费课时：<%#getKeShiMonthXuFei(int.Parse(Eval("id").ToString()), monthCount, yearCount)%>课时</td>
        <td align="center"><%#getPriceContractStatus0(int.Parse(Eval("id").ToString()), yearCount,monthCount)%></td>
         <td align="center"><%#getPriceContractStatus1(int.Parse(Eval("id").ToString()), yearCount, monthCount)%></td>
        <td align="center"><a href="list_view.aspx?stuid=<%#Eval("id")%>&channel_id=<%#this.channel_id %>">课时详情</a>
        </td>
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
