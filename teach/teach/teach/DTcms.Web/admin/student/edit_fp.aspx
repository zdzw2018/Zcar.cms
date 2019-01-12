﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_fp.aspx.cs" Inherits="DTcms.Web.admin.student.edit_fp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑学生信息</title>
    <link href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../images/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.form.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.validate.min.js"></script> 
    <script type="text/javascript" src="../../scripts/jquery/messages_cn.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
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
    <div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 分配学员管理 &gt; 编辑信息 &nbsp;<a href="list_teach_lesson.aspx?channel_id=<%=this.channel_id%>&user_id=<%=this.user_id%>">教师列表</a></div>
    
     
    <div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
      
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>学生姓名：</th>
                <td><asp:TextBox ID="txtstu_name" runat="server" CssClass="txtInput normal" ReadOnly="true" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>年级：</th>
                <td><asp:TextBox ID="txtgrade" runat="server" CssClass="txtInput normal"  ReadOnly="true" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>课程：</th>
                <td>
                <asp:DropDownList ID="txtlesson" runat="server" CssClass="select2" 
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
                </asp:DropDownList> </td>
            </tr>
            <tr>
                <th>老师：</th>
                <td><asp:DropDownList ID="txtteach" runat="server" CssClass="select2"><asp:ListItem Value="">请选择..</asp:ListItem></asp:DropDownList></td>
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
