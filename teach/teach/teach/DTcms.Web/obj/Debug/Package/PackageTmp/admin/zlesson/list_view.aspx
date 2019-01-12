<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list_view.aspx.cs" Inherits="DTcms.Web.admin.zlesson.list_view" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>课时信息管理</title>
    <link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
    <link type="text/css" rel="stylesheet" href="../images/style.css" />
    <link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
     <script type="text/javascript" src="../../scripts/calendar.js"></script>
    <script type="text/javascript">
        //执行回传函数
        function ExePostBackI(objId, objmsg) {

            var msg = "删除记录后不可恢复，您确定吗？";
            if (arguments.length == 2) {
                msg = objmsg;
            }
            $.ligerDialog.confirm(msg, "提示信息", function (result) {
                if (result) {
                    __doPostBack(objId, '');
                }
            });
            return false;
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <div class="navigation">
        <%if(user_id>0){ %>
       <a href="keshi_list.aspx?channel_id=<%=this.channel_id %>" class="back">后退</a> 首页 &gt; 课时安排管理 &gt; 管理列表
         <%} %>

        <%else{ %>
        <a href="javascript:history.go(-1);" class="back">后退</a> 首页 &gt; 课时安排管理 &gt; 管理列表
        <%} %>
        </div>
    <div class="tools_box">
        <div class="tools_bar">
            <div class="search_box">
                <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" OnClick="btnSearch_Click" />
            </div>
            <%if(Request.QueryString["leftkeshi"]!=null&&double.Parse(Request.QueryString["leftkeshi"].ToString())!=0.0){ %>
            <a href="edit.aspx?stuid=<%=this.stuid%>&channel_id=<%=this.channel_id %>&leftkeshi=<%=Request.QueryString["leftkeshi"].ToString() %>&user_id=<%=user_id %>" class="tools_btn"><span><b class="add">添加课时</b></span></a>
            <%} %>
              <asp:LinkButton ID="btnExport" runat="server" CssClass="tools_btn" onclick="btnExport_Click"><span><b class="send">导出</b></span></asp:LinkButton>
        </div>
        <div class="select_box">
            请选择：
            <asp:DropDownList ID="ddlLesson" runat="server" CssClass="select2" 
                AutoPostBack="true" onselectedindexchanged="ddlLesson_SelectedIndexChanged">
                  <asp:ListItem Value="">=请选择科目=</asp:ListItem>
                <asp:ListItem Value="语文">语文</asp:ListItem>
                <asp:ListItem Value="数学">数学</asp:ListItem>
                <asp:ListItem Value="外语">外语</asp:ListItem>
                <asp:ListItem Value="生物">生物</asp:ListItem>
                <asp:ListItem Value="历史">历史</asp:ListItem>
                <asp:ListItem Value="地理">地理</asp:ListItem>
                <asp:ListItem Value="物理">物理</asp:ListItem>
                <asp:ListItem Value="化学">化学</asp:ListItem>
                <asp:ListItem Value="政治">政治</asp:ListItem>
            </asp:DropDownList>
             年级：
              <asp:DropDownList ID="ddlGrade" runat="server" CssClass="select2" 
                AutoPostBack="True" onselectedindexchanged="ddlGrade_SelectedIndexChanged">
            </asp:DropDownList>
           
            <asp:DropDownList ID="ddlTeacher" CssClass="select2" AutoPostBack="true" 
                runat="server" onselectedindexchanged="ddlTeacher_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlXueGuan" CssClass="select2" AutoPostBack="true" 
                runat="server" onselectedindexchanged="ddlXueGuan_SelectedIndexChanged">
        </asp:DropDownList>
            <%if(channel_id==11) {%>
            年份：<asp:DropDownList ID="ddlYear" runat="server" CssClass="select2" 
                AutoPostBack="True" 
                onselectedindexchanged="ddlYear_SelectedIndexChanged"  >

                </asp:DropDownList>

            月：<asp:DropDownList ID="ddlMonth" runat="server" CssClass="select2" 
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
            <%} %>
            <%else if(channel_id==13) {%>
             从：
               
            <asp:TextBox ID="txtStartTime" runat="server" CssClass="txtInput small required" onclick="return Calendar('txtStartTime');" maxlength="100" ></asp:TextBox>
          到：  

     <asp:TextBox ID="txtEndTime" runat="server" CssClass="txtInput small required" onclick="return Calendar('txtEndTime');" maxlength="50" ></asp:TextBox>
            <%} %>
        </div>
    </div>
    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                <tr>
                    
                    <th width="13%" align="center">
                        上课日期
                    </th>
                    <th align="center">
                        上课时间
                    </th>
                    <th align="center">
                        课时
                    </th>
                    <th align="center">
                    学生姓名
                    </th>
                     <th align="center">
                    年级
                    </th>
                     <th align="center">
                        学管师
                    </th>
                    <th align="center">
                        上课老师
                    </th>
                   
                    <th align="center">
                        科目
                    </th>
                    <th align="center" width="8%">
                        操作
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                
                <td align="center">
                
                        <%#Convert.ToDateTime(Eval("lesson_date")).ToString("yyyy-MM-dd")%>
                </td>
                <td align="center">
                    <%#Eval("lesson_time")%>
                </td>
              
                 <td align="center">
                    <%#Eval("lesson_count")%>
                </td>
                  <td align="center">
                
                   <%#new DTcms.BLL.student_info().GetModel(int.Parse(Eval("stu_id").ToString())) == null ? "" : new  DTcms.BLL.student_info().GetModel(int.Parse(Eval("stu_id").ToString())).stu_name%>
                  
                </td>
                 <td align="center">
                  
                    <%#new DTcms.BLL.student_info().GetModel(int.Parse(Eval("stu_id").ToString())) == null ? "" : new  DTcms.BLL.student_info().GetModel(int.Parse(Eval("stu_id").ToString())).stu_grade%>
                 
                </td>
                 <td align="center">
                     <%#new DTcms.BLL.student_teach().GetList(1,"stu_id="+Eval("stu_id").ToString()+" and lesson=''","id").Tables[0].Rows.Count>0 ?  new DTcms.BLL.student_teach().GetList(1,"stu_id="+Eval("stu_id").ToString()+" and lesson=''","id").Tables[0].Rows[0]["manager_name"] : "" %>

                </td>
                <td align="center">
                    <%#Eval("manager_name")%>
                </td>
                
                <td align="center">
                    <%#Eval("lesson_name")%>
                </td>
                <%if (GetAdminInfo().role_id != 11)
                  { %>
                <td align="center">
                    <a href="edit.aspx?action=<%#ActionEnum.Edit %>&id=<%#Eval("id")%>&stuid=<%#Eval("stu_id") %>&channel_id=<%=this.channel_id %>&leftkeshi=<%=leftkeshi %>">
                        修改</a>&nbsp; <asp:LinkButton ID="shanchu" CommandArgument='<%#Eval("id")%>'   runat="server"  OnClientClick="return confirm('删除记录后不可恢复，您确定吗？');" onclick="shanchu" >删除</asp:LinkButton>
                </td>
                <%} %>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <tr>
                <td align="center">总和：</td>
                <td align="center">-</td>
                <td align="center"><%=totalKeshi %></td>
                <td align="center">-</td>
                <td align="center">-</td>
                <td align="center">-</td>
                 <td align="center">-</td>
                <td align="center">-</td>
                 <td align="center">-</td>
            </tr>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <!--列表展示.结束-->
    <div class="line15">
    </div>
    <div class="page_box">
        <div id="PageContent" runat="server" class="flickr right">
        </div>
        <div class="left">
            显示<asp:TextBox ID="txtPageNum" runat="server" CssClass="txtInput2 small2" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));"
                OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
        </div>
    </div>
    <div class="line10">
    </div>
    </form>
</body>
</html>
