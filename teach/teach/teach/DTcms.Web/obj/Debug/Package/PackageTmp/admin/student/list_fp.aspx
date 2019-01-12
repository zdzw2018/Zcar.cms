<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list_fp.aspx.cs" Inherits="DTcms.Web.admin.student.list_fp" %>

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
    <script type="text/javascript">
        $(function () {
            $("#txtteach").change(function () {
                $("#hidIdTeach").val($(this).val());
            });
        })
    </script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
    <div class="navigation">首页 &gt; 学生信息管理 &gt; 管理列表</div>
    <div class="tools_box">
	    <div class="tools_bar">
            <div class="search_box">
              <asp:LinkButton ID="lbAll" runat="server" onclick="lbAll_Click"
                    >所有回访记录</asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="lbTwo" runat="server" CommandArgument="2" 
                    onclick="lbTwo_Click">2天内有回访</asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="zeorHuiFan" runat="server" CommandArgument="011" onclick="zeorHuiFan_Click">0次回访</asp:LinkButton>&nbsp;&nbsp;
                <asp:LinkButton ID="zeroLeftKeshi" runat="server" CommandArgument="012" onclick="zeroLeftKeshi_Click">课时剩余0</asp:LinkButton>&nbsp;&nbsp;
                <asp:LinkButton ID="LeftKeshitween" runat="server" CommandArgument="013" OnClick="LeftKeshitween_Click" >课时剩余小于20</asp:LinkButton>&nbsp;&nbsp;
            <asp:DropDownList ID="ddlShouSou" runat="server" CssClass="select2" >

                <asp:ListItem Value="stu">学生姓名</asp:ListItem>
                <asp:ListItem Value="xuexiao">学校名</asp:ListItem>
               
                </asp:DropDownList>
			    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click" />
		    </div>
		    <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>
           
             <asp:LinkButton ID="btnFenPei" runat="server" CssClass="tools_btn"  
                OnClientClick="return ExePostBack('btnFenPei');" OnClick="btnFenPei_Click" ><span><b class="">批量分配学管</b></span></asp:LinkButton>
        </div>
        <div class="select_box" >
           <asp:DropDownList ID="ddlProperty" runat="server" Visible="false" CssClass="select2" AutoPostBack="True" onselectedindexchanged="ddlProperty_SelectedIndexChanged">
            <asp:ListItem Text="全部" Value=""></asp:ListItem>
            <asp:ListItem Text="未签合同" Value="添加合同"></asp:ListItem>
            <asp:ListItem Text="已签合同" Value="查看合同"></asp:ListItem>
            </asp:DropDownList>
           
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
	    &nbsp; <asp:DropDownList ID="ddlXueGuan" CssClass="select2" AutoPostBack="true" 
                runat="server" onselectedindexchanged="ddlXueGuan_SelectedIndexChanged">
        </asp:DropDownList>

          <asp:DropDownList ID="ddlGrade" runat="server" CssClass="select2" 
                AutoPostBack="True" onselectedindexchanged="ddlGrade_SelectedIndexChanged">
            </asp:DropDownList>

             <asp:DropDownList ID="txtteach" runat="server" CssClass="select2" />
             <asp:HiddenField ID="hidIdTeach"  runat="server" />
	    </div>
       
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="4%">选择</th>
        <th align="center" width="7%">学生姓名</th>
        <th align="center"  width="5%">学校</th>
        <th align="center"  width="5%">年级</th>
        <th align="center"  width="5%">课时</th>
        <th align="center"  width="5%">剩余课时</th>
        <th align="center"  width="6%">剩余赠送课时</th>
        <th align="center"  width="5%">学管师</th>
        <th width="5%" align="center">操作</th>
         <th width="5%" align="center">回访次数</th>
        <th width="8%" align="center">月回访次数</th>
        
        <th align="center" width="5%">回访记录</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" />
        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
        <asp:HiddenField ID="hidcontract_id" Value='<%#Eval("contract_id")%>' runat="server" />
        <asp:HiddenField ID="hidStuId" Value='<%#Eval("stu_id")%>' runat="server" />
        </td>
        <td align="center"><a href="edit.aspx?channel_id=<%#this.channel_id %>&action=<%#ActionEnum.Edit %>&id=<%#Eval("id")%>"><%#Eval("stu_name")%></a></td>
        <td align="center"><%#Eval("stu_school")%></td>
        <td align="center"><%#Eval("stu_grade")%></td>
        <td align="center"><%#getTotalKeShi(int.Parse(Eval("id").ToString())).ToString("0.0")%></td>
        <td align="center"><%#(getTotalKeShi(int.Parse(Eval("id").ToString())) - getKeShi(int.Parse(Eval("id").ToString()))).ToString("0.0")%></td>
           <td align="center"><%#(getTotalGiveKeShi(int.Parse(Eval("id").ToString())) - getGiveKeShi(int.Parse(Eval("id").ToString()))).ToString("0.0")%></td>
        <td align="center"><%#getXueGuanName(int.Parse(Eval("id").ToString())) %></td>
        <td align="center">
       <a href="list_xueguan.aspx?channel_id=<%#this.channel_id %>&user_id=<%#Eval("id")%>&tpage=<%=page %>">添加学管师</a>
        </td>
          <td align="center"><%#getReturnCount(int.Parse(Eval("id").ToString()))%></td>
          <td align="center"><%=yearCount %>年<%=monthCount%>月份：<%#getReturnMonth(int.Parse(Eval("id").ToString()), monthCount, yearCount)%>次</td>
        <td align="center"><a href="../student_return/list_view.aspx?channel_id=<%#this.channel_id %>&user_id=<%#Eval("id")%>">记录详情</a></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
         <tr>
       <td align="center">总和：</td>
       <td align="center">-</td>
       <td align="center">-</td>
       <td align="center">-</td>
       <td align="center"><%=total_keshi %></td>
       <td align="center"><%=total_left_keshi %></td>
       <td align="center"><%=total_left_give_keshi %></td>
       
       <td align="center">-</td>
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

