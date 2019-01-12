<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xufei_contract.aspx.cs" Inherits="DTcms.Web.admin.student.xufei_contract" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>合同信息管理</title>
    <link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
    <link type="text/css" rel="stylesheet" href="../images/style.css" />
    <link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
    <div class="navigation">首页 &gt; 合同信息管理 &gt; 管理列表</div>
    <div class="tools_box">
	    <div class="tools_bar">
            <div class="search_box">
             <asp:DropDownList ID="ddlShouSou" runat="server" CssClass="select2" >
                <asp:ListItem Value="stu">学生姓名</asp:ListItem>
                <asp:ListItem Value="fang">约访人</asp:ListItem>
                </asp:DropDownList>
			    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click" />
		    </div>
		    <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>
             <%if (GetAdminInfo().role_id == 1){ %>
            <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn"  
                OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><span><b class="delete">批量删除</b></span></asp:LinkButton>
            <%} %>
        </div>
        <div class="select_box">
            <%if (GetAdminInfo().role_id == 1){ %>
            合同状态：<asp:DropDownList ID="ddlProperty" runat="server" CssClass="select2" AutoPostBack="True" onselectedindexchanged="ddlProperty_SelectedIndexChanged">
            <asp:ListItem Text="全部状态" Value=""></asp:ListItem>
            <asp:ListItem Text="未审核" Value="1" ></asp:ListItem>
            <asp:ListItem Text="审核通过" Value="2"></asp:ListItem>
            <asp:ListItem Text="审核失败" Value="3"></asp:ListItem>
            </asp:DropDownList>

            <asp:DropDownList ID="ddlZiXunShi" runat="server" CssClass="select2" 
                AutoPostBack="true" onselectedindexchanged="ddlZiXunShi_SelectedIndexChanged">

            </asp:DropDownList>
            <%} %>
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

            <asp:DropDownList ID="ddlQianYue" runat="server" CssClass="select2" 
                AutoPostBack="True" 
                onselectedindexchanged="ddlQianYue_SelectedIndexChanged">
                 <asp:ListItem Value="">==签约来源选择==</asp:ListItem>
                    <asp:ListItem Value="直访">直访</asp:ListItem>
                    <asp:ListItem Value="来电约访">来电约访</asp:ListItem>
                    <asp:ListItem Value="市场约访">市场约访</asp:ListItem>
                    <asp:ListItem Value="呼叫中心约访">呼叫中心约访</asp:ListItem>
                    <asp:ListItem Value="转介绍">转介绍</asp:ListItem>
                    <asp:ListItem Value="其他">其他</asp:ListItem>
            </asp:DropDownList>
	    </div>

        
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="6%">选择</th>
      
        <th width="6%" align="center">学生姓名</th>
       <th width="6%" align="center">年级</th>
        <th width="6%" align="center">签订课时</th>
           <th width="6%" align="center">赠送课时</th>
        <th width="6%" align="center">综合费</th>
          <th width="8%" align="center">教育咨询费</th>
          
        <th width="7%" align="center">合同状态</th>
        <th width="9%" align="center">添加时间</th>
        <th width="7%" align="center">申请人</th>
        <th width="7%" align="center">签约来源</th>
        <th width="7%" align="center">约访人</th>
       <th width="7%" align="center">操作</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("contract_id")%>' runat="server" /></td>
      
        <td align="center"><%#Eval("stu_name")%></td>
        <td align="center"><%#Eval("stu_grade")%></td>
        <td align="center"><%#Eval("contract_lesson")%></td>
          <td align="center"><%#Convert.ToDecimal(Eval("give_lesson").ToString()).ToString("0.0")%></td>
        <td align="center"><%#Convert.ToDecimal(Eval("contract_service_price").ToString()).ToString("0.0")%></td>
        <td align="center"><%#Convert.ToDecimal(Eval("contract_advice_price").ToString()).ToString("0.0")%></td>
        
        <td align="center"><%#Eval("stutas_name")%></td>
        <td align="center"><%#string.Format("{0:d}", Eval("Expr2"))%></td>
        <td align="center"><%#new DTcms.BLL.manager().GetModel(int.Parse(Eval("user_id").ToString())).real_name %></td>
        <td align="center"><%#Eval("stu_parent_name") %></td>
         <td align="center"><%#Eval("stu_tel") %></td>
        <td align="center">
            <%if (GetAdminInfo().role_id == 1){%>
            <a href="/admin/contract/edit.aspx?channel_id=<%=channel_id %>&id=<%#Eval("contract_id") %>&action=Edit">修改</a>
            <%} %>
        </td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
    <tr>
       <td align="center">总和：</td>
       <td align="center">-</td>
       <td align="center">-</td>
       <td align="center">-</td>
        <td align="center">-</td>
       <td align="center"><%=totalnewmoney.ToString("0.0")%></td>
       <td align="center"><%=totalrealmoney.ToString("0.0")%></td>
       <td align="center"></td>
       <td align="center">-</td>
       <td align="center">-</td>
       <td align="center">-</td>
       <td align="center">-</td>
       
       
    </tr>
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
