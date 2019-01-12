<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="DTcms.Web.admin.zlesson.edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>课时信息管理</title>
    <link href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../images/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.form.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.validate.min.js"></script> 
    <script type="text/javascript" src="../../scripts/jquery/messages_cn.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
    <script type="text/javascript" src="../../scripts/calendar.js"></script>
    <script type="text/javascript">
        //表单验证
        $(function () {
            $("#form1").validate({
                invalidHandler: function (e, validator) {
                    parent.jsprint("有 " + validator.numberOfInvalids() + " 项填写有误，请检查！", "", "Warning");
                },
                errorPlacement: function (lable, element) {
                    //可见元素显示错误提示
                    if (element.parents(".tab_con").css('display') != 'none') {
                        element.ligerTip({ content: lable.html(), appendIdTo: lable });
                    }
                },
                success: function (lable) {
                    lable.ligerHideTip();
                }
            });
        });
</script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 课时信息管理 &gt; 编辑信息</div>
        <div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>上课日期：</th>
                <td><asp:TextBox ID="txtlesson_date" runat="server"  CssClass="txtInput required" onclick="return Calendar('txtlesson_date');" maxlength="100"></asp:TextBox><label id="lblweek">*</label></td>
            </tr>
            <tr>
                <th>上课时间：</th>
                <td>
                    <asp:DropDownList ID="txtLessonTimeStart" runat="server"  CssClass="select required">
                        <asp:ListItem Text="开始时间" Value=""></asp:ListItem>
                        <asp:ListItem Text="8:00" Value="8:00"></asp:ListItem>
                        <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                        <asp:ListItem Text="9:00" Value="9:00"></asp:ListItem>
                        <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                        <asp:ListItem Text="10:00" Value="10:00"></asp:ListItem>
                        <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                        <asp:ListItem Text="11:00" Value="11:00"></asp:ListItem>
                        <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                        <asp:ListItem Text="12:00" Value="12:00"></asp:ListItem>
                        <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                        <asp:ListItem Text="13:00" Value="13:00"></asp:ListItem>
                        <asp:ListItem Text="13:30" Value="13:30"></asp:ListItem>
                        <asp:ListItem Text="14:00" Value="14:00"></asp:ListItem>
                        <asp:ListItem Text="14:30" Value="14:30"></asp:ListItem>
                        <asp:ListItem Text="15:00" Value="15:00"></asp:ListItem>
                        <asp:ListItem Text="15:30" Value="15:30"></asp:ListItem>
                        <asp:ListItem Text="16:00" Value="16:00"></asp:ListItem>
                        <asp:ListItem Text="16:30" Value="16:30"></asp:ListItem>
                        <asp:ListItem Text="17:00" Value="17:00"></asp:ListItem>
                        <asp:ListItem Text="17:30" Value="17:30"></asp:ListItem>
                        <asp:ListItem Text="18:00" Value="18:00"></asp:ListItem>
                        <asp:ListItem Text="18:30" Value="18:30"></asp:ListItem>
                        <asp:ListItem Text="19:00" Value="19:00"></asp:ListItem>
                        <asp:ListItem Text="19:30" Value="19:30"></asp:ListItem>
                        <asp:ListItem Text="20:00" Value="20:00"></asp:ListItem>
                        <asp:ListItem Text="20:30" Value="20:30"></asp:ListItem>
                        <asp:ListItem Text="21:00" Value="21:00"></asp:ListItem>
                        <asp:ListItem Text="21:30" Value="21:30"></asp:ListItem>
                        <asp:ListItem Text="22:00" Value="22:00"></asp:ListItem>
                    </asp:DropDownList> 到 <asp:DropDownList ID="txtLessonTimeEnd" runat="server"  
                        CssClass="select required" AutoPostBack="True" 
                        onselectedindexchanged="txtLessonTimeEnd_SelectedIndexChanged">
                         <asp:ListItem Text="结束时间" Value=""></asp:ListItem>
                        <asp:ListItem Text="8:00" Value="8:00"></asp:ListItem>
                        <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                        <asp:ListItem Text="9:00" Value="9:00"></asp:ListItem>
                        <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                        <asp:ListItem Text="10:00" Value="10:00"></asp:ListItem>
                        <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                        <asp:ListItem Text="11:00" Value="11:00"></asp:ListItem>
                        <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                        <asp:ListItem Text="12:00" Value="12:00"></asp:ListItem>
                        <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                        <asp:ListItem Text="13:00" Value="13:00"></asp:ListItem>
                        <asp:ListItem Text="13:30" Value="13:30"></asp:ListItem>
                        <asp:ListItem Text="14:00" Value="14:00"></asp:ListItem>
                        <asp:ListItem Text="14:30" Value="14:30"></asp:ListItem>
                        <asp:ListItem Text="15:00" Value="15:00"></asp:ListItem>
                        <asp:ListItem Text="15:30" Value="15:30"></asp:ListItem>
                        <asp:ListItem Text="16:00" Value="16:00"></asp:ListItem>
                        <asp:ListItem Text="16:30" Value="16:30"></asp:ListItem>
                        <asp:ListItem Text="17:00" Value="17:00"></asp:ListItem>
                        <asp:ListItem Text="17:30" Value="17:30"></asp:ListItem>
                        <asp:ListItem Text="18:00" Value="18:00"></asp:ListItem>
                        <asp:ListItem Text="18:30" Value="18:30"></asp:ListItem>
                        <asp:ListItem Text="19:00" Value="19:00"></asp:ListItem>
                        <asp:ListItem Text="19:30" Value="19:30"></asp:ListItem>
                        <asp:ListItem Text="20:00" Value="20:00"></asp:ListItem>
                        <asp:ListItem Text="20:30" Value="20:30"></asp:ListItem>
                        <asp:ListItem Text="21:00" Value="21:00"></asp:ListItem>
                        <asp:ListItem Text="21:30" Value="21:30"></asp:ListItem>
                        <asp:ListItem Text="22:00" Value="22:00"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <th>课时数：</th>
                <td><asp:TextBox ID="txtlesson_count" runat="server" ReadOnly="true" CssClass="txtInput number required" maxlength="100" /><label>*</label></td>
            </tr>
           
            <tr>
                <th>科目：</th>
                <td>
                    <asp:DropDownList ID="txtlesson" runat="server" CssClass="select2 required" 
                        AutoPostBack="true" onselectedindexchanged="txtlesson_SelectedIndexChanged">
                 <asp:ListItem Value="">请选择..</asp:ListItem>
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
                </td>
            </tr>
            <tr>
                <th>任课教师：</th>
                <td><asp:DropDownList ID="txtteach" runat="server" CssClass="select2 required"></asp:DropDownList>
                </td>
            </tr>
            </tbody>
        </table>
    </div>
    <div class="foot_btn_box">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" onclick="btnSubmit_Click" />
    &nbsp;<input name="重置" type="reset" class="btnSubmit" value="重 置" />
    </div>
</div>
    </form>
</body>
</html>
