<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="DTcms.Web.admin.budget.report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>月报表统计</title>
    <link type="text/css" rel="stylesheet" href="../images/style.css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="navigation">首页 &gt; 月报表统计</div>
         <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="10%" align="center">月份</th>
        <th width="13%" align="right">总金额</th>
        <th></th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><%#Eval("date")%></td>
        <td align="right"><%#Eval("price")%></td>
        <td></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"2\">暂无记录</td></tr>" : ""%>
      </table>
    </FooterTemplate>
    </asp:Repeater>
    </form>
</body>
</html>
