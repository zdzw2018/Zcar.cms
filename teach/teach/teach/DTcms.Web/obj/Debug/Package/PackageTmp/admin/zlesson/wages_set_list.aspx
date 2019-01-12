<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wages_set_list.aspx.cs" Inherits="DTcms.Web.admin.zlesson.wages_set_list" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>课时工资列表</title>
    <link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
    <link type="text/css" rel="stylesheet" href="../images/style.css" />
    <link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <div class="navigation">首页 &gt; 课时信息管理 &gt; 管理列表</div>
        <div class="tools_box">
            <div class="tools_bar">
                <div class="search_box">
                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" OnClick="btnSearch_Click" />
                </div>
                <a href="wages_set.aspx?action=<%=ActionEnum.Add %>&channel_id=<%=channel_id %>" class="tools_btn"><span><b class="add">添加课时工资</b></span></a>
                <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>
                <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn"
                    OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><span><b class="delete">批量删除</b></span></asp:LinkButton>
            </div>
        </div>
        <!--列表展示.开始-->
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                    <tr>
                        <th width="6%">选择</th>
                        <th width="13%" align="left">年级</th>
                        <th align="left">课时区间</th>
                        <th align="left">课时工资</th>
                        <th width="8%">操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                    </td>
                    <td><%#DTcms.Common.Utils.DelLastComma(Eval("grade").ToString().Substring(1)).Split(',')[0] %> ~ <%#DTcms.Common.Utils.DelLastComma(Eval("grade").ToString().Substring(1)).Split(',')[Eval("grade").ToString().Split(',').Length-3] %></td>
                    <td><%#Eval("keshi_begin")%>-<%#Eval("keshi_end") %></td>
                    <td><%#Eval("wages")%></td>
                    <td align="center"><a href="wages_set.aspx?action=<%#ActionEnum.Edit %>&id=<%#Eval("id")%>&channel_id=<%=channel_id %>">修改</a></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
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
