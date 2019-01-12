<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="DTcms.Web.admin.student.list" %>

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
    <div class="navigation">首页 &gt; 学生信息管理 &gt; 管理列表</div>
    <div class="tools_box">
	    <div class="tools_bar">
            <div class="search_box">
                <asp:DropDownList ID="ddlShouSou" runat="server" CssClass="select2" >
                <asp:ListItem Value="stu">学生姓名</asp:ListItem>
                <asp:ListItem Value="xuexiao">学校名</asp:ListItem>
                <asp:ListItem Value="fang">约访人</asp:ListItem>
                </asp:DropDownList>
			    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click" />
		    </div>
            <a href="edit.aspx?action=<%=ActionEnum.Add %>&channel_id=<%=this.channel_id %>" class="tools_btn"><span><b class="add">添加信息</b></span></a>
		    <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>
             
            <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn"  
                OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><span><b class="delete">批量删除</b></span></asp:LinkButton>

        </div>
        <div class="select_box">
            <asp:DropDownList ID="ddlProperty" runat="server" CssClass="select2" AutoPostBack="True" onselectedindexchanged="ddlProperty_SelectedIndexChanged">
            </asp:DropDownList>

             <asp:DropDownList ID="ddlGrade" runat="server" CssClass="select2" 
                AutoPostBack="True" onselectedindexchanged="ddlGrade_SelectedIndexChanged">
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
                    <asp:ListItem Value="老生续单">老生续单</asp:ListItem>
                    <asp:ListItem Value="其他">其他</asp:ListItem>
            </asp:DropDownList>
	    </div>
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="6%" align="center">选择</th>
        <th align="center" width="7%">学生姓名</th>
        <th width="7%" align="center">学校</th>
        <th width="7%" align="center">年级</th>
     
        <th width="7%" align="center">综合服务费</th>
        <th width="7%" align="center">教育咨询费</th>
        
        <th width="7%" align="center">咨询师</th>
         <th width="7%" align="center">签约来源</th>
          <th width="7%" align="center">约访人</th>
        <th width="7%" align="center">在校信息</th>
        <th width="8%" align="center">操作</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" />
        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
        <asp:HiddenField ID="hidcontract_id" Value='<%#Eval("contract_id")%>' runat="server" />
        </td>
        <td align="center"><a href="edit.aspx?channel_id=<%#this.channel_id %>&action=<%#ActionEnum.Edit %>&id=<%#Eval("id")%>"><%#Eval("stu_name")%></a></td>
        <td align="center"><%#Eval("stu_school")%></td>
        <td align="center"><%#Eval("stu_grade")%></td>
        <td align="center"><%#Convert.ToDecimal(Eval("contract_service_price").ToString()).ToString("0.0")%></td>
        <td align="center"><%#Convert.ToDecimal(Eval("contract_advice_price").ToString()).ToString("0.0")%></td>
       
        <td align="center"><%#new DTcms.BLL.manager().GetModel(int.Parse(Eval("user_id").ToString())).real_name %></td>
        <td align="center"><%#Eval("stu_parent_name")%></td>
         <td align="center"><%#Eval("stu_tel")%></td>
        <td align="center"><a href="score_list.aspx?channel_id=<%#this.channel_id %>&user_id=<%#Eval("id") %>">在校信息</a></td>
        <td align="center"><a href="edit.aspx?channel_id=<%#this.channel_id %>&action=<%#ActionEnum.Edit %>&id=<%#Eval("id")%>">修改</a></td>
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

