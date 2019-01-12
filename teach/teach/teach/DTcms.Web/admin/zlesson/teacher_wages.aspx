<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacher_wages.aspx.cs" Inherits="DTcms.Web.admin.zlesson.teacher_wages" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>老师工资列表</title>
    <link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
    <link type="text/css" rel="stylesheet" href="../images/style.css" />
    <link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
     <div class="navigation">首页 &gt; 教师工资管理 &gt; 教师工资列表</div>
        <div class="tools_box">
           
            <div class="tools_bar">
                 <asp:LinkButton ID="btnExport" runat="server" CssClass="tools_btn" onclick="btnExport_Click"><span><b class="send">导出</b></span></asp:LinkButton>
                <div class="search_box">
                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" OnClick="btnSearch_Click" />
                </div>
                 </div>
                 <div class="select_box">
                    
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
                     <%if (model.role_id == 1 || model.role_id == 10 || model.role_id == 16)
                { %>
                  教师筛选：<asp:DropDownList ID="ddlTeacher" CssClass="select2" AutoPostBack="true" 
                runat="server" onselectedindexchanged="ddlTeacher_SelectedIndexChanged">
            </asp:DropDownList>

                      年级：
              <asp:DropDownList ID="ddlGrade" runat="server" CssClass="select2" 
                AutoPostBack="True" onselectedindexchanged="ddlGrade_SelectedIndexChanged">
            </asp:DropDownList>
                     <%} %>

	    </div>
                    
            </div>
        
        <!--列表展示.开始-->
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                    <tr>
                        <th width="10%" align="center">教师</th>
                        <th width="10%" align="center">学生</th>
                        <th width="10%" align="center">年级</th>
                         <th width="10%" align="center">课时</th>
                        <th width="10%" align="center">年份</th>
                        <th width="10%" align="center">月份</th>
                         <th width="13%" align="center">课时单价</th>
                         <th width="13%" align="center">课时工资</th>
                         <th width="13%" align="center">课时激励</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    
                    <td align="center"><%#Eval("manager_name") %></td>
                    <td align="center"> <%#new DTcms.BLL.student_info().GetModel(int.Parse(Eval("stu_id").ToString())) == null ? "" : new  DTcms.BLL.student_info().GetModel(int.Parse(Eval("stu_id").ToString())).stu_name%></td>
                     <td align="center"> <%#new DTcms.BLL.student_info().GetModel(int.Parse(Eval("stu_id").ToString())) == null ? "" : new  DTcms.BLL.student_info().GetModel(int.Parse(Eval("stu_id").ToString())).stu_grade%></td>
                     <td align="center">  <%#Eval("lesson_count")%></td>
                     <td align="center"><%=yearCount %></td>
                    <td align="center"><%=monthCount %></td>
                    <td align="center"><%#(GetWages(int.Parse(Eval("manager_id").ToString()),new DTcms.BLL.student_info().GetModel(int.Parse(Eval("stu_id").ToString())) == null ? "" : new  DTcms.BLL.student_info().GetModel(int.Parse(Eval("stu_id").ToString())).stu_grade)*getKeShiMultiple(int.Parse(Eval("stu_id").ToString()))).ToString("0.0") %></td>
                    <td align="center"><%#(GetWages(int.Parse(Eval("manager_id").ToString()),new DTcms.BLL.student_info().GetModel(int.Parse(Eval("stu_id").ToString())) == null ? "" : new  DTcms.BLL.student_info().GetModel(int.Parse(Eval("stu_id").ToString())).stu_grade)*decimal.Parse(Eval("lesson_count").ToString())*getKeShiMultiple(int.Parse(Eval("stu_id").ToString()))).ToString("0.0") %></td>
                    <td align="center"><%#(GetJiLi(Eval("stu_id").ToString(),Eval("manager_id").ToString())*decimal.Parse(Eval("lesson_count").ToString())).ToString("0.0") %></td>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <tr>
            <td width="10%" align="center">总和：</td>
            <td width="10%" align="center"> - </td>
            <td width="10%" align="center"> - </td>
            <td width="10%" align="center"> <%=total_keshi %> </td>
            <td width="10%" align="center">-</td>
            <td width="10%" align="center">-</td>
           <td width="13%" align="center">-</td>
            <td width="13%" align="center"> <%=total_wages.ToString("0.0")%> </td>
            <td width="13%" align="center"> <%=total_jili.ToString("0.0") %> </td>
        </tr>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暂无记录</td></tr>" : ""%>
      </table>
            </FooterTemplate>
        </asp:Repeater>
        <!--列表展示.结束-->


        <div class="line15"></div>
        <div class="page_box">
            <div id="PageContent" runat="server" class="flickr right"></div>
            <div class="left">
                显示<asp:TextBox ID="txtPageNum" runat="server" CssClass="txtInput2 small2" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));"
                    OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
            </div>
        </div>
        <div class="line10"></div>
    </form>
</body>
</html>
