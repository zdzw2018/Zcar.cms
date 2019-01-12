﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="keshi.aspx.cs" Inherits="DTcms.Web.admin.xgyj.keshi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>课时信息管理</title>
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
        
        <div class="select_box">
            选择赛选：&nbsp;
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
        </div>
        </div>
        
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
      <th width="15%" align="center">姓名</th>
       <th align="center" width="10%">年份</th>
       <th align="center" width="10%">月份</th>
        <th align="center" width="10%">新签课时数</th>
        <th align="center">新签课时收入</th>
        <th align="center" width="10%">续费课时数</th>
        <th align="center" width="10%">续费课时收入</th>
          <th align="center" width="10%">总课时</th>
          <th align="center" width="10%">总课时收入</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><%#Eval("manager_name")%></td>
        <td align="center"><%=yearCount %></td>
        <td align="center"><%=monthCount %></td>
        <td align="center"><%#getKeShiMonth(int.Parse(Eval("manager_id").ToString()),0)%></td>
        <td align="center"><%#getPriceContractStatus(int.Parse(Eval("manager_id").ToString()),0).ToString("0.0")%></td>
        <td align="center"><%#getKeShiMonth(int.Parse(Eval("manager_id").ToString()),1)%></td>
        <td align="center"><%#getPriceContractStatus(int.Parse(Eval("manager_id").ToString()),1).ToString("0.0")%></td>
          <td align="center"><%#getKeShiMonth(int.Parse(Eval("manager_id").ToString()),0)+getKeShiMonth(int.Parse(Eval("manager_id").ToString()),1)%></td>
          <td align="center"><%#(getPriceContractStatus(int.Parse(Eval("manager_id").ToString()),0)+getPriceContractStatus(int.Parse(Eval("manager_id").ToString()),1)).ToString("0.0")%></td>
              </tr>
    </ItemTemplate>
    <FooterTemplate>
      <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
      </table>
    </FooterTemplate>
    </asp:Repeater>
    <!--列表展示.结束-->

   

   
    <div class="line15"></div>
    <div class="page_box">
      
      
    </div>
    <div class="line10"></div>


</form>
</body>
</html>
