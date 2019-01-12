<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="DTcms.Web.admin.student_score.edit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑回访信息</title>
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
<div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 学员成绩管理 &gt; 编辑学员成绩信息</div>
<div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>学年度：</th>
                <td><asp:DropDownList id="ddllesson_year" CssClass="select2 required" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <th>学期：</th>
                <td><asp:DropDownList id="ddllesson_semester" CssClass="select2 required" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <th>成绩类别：</th>
                <td><asp:DropDownList id="ddllesson_type" CssClass="select2 required" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <th>学员姓名：</th>
                <td><asp:Label ID="lblstu_name" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <th>语文：</th>
                <td><asp:TextBox ID="TextBox1" runat="server" CssClass="txtInput normal" maxlength="100">0.00</asp:TextBox></td>
            </tr>
            <tr>
                <th>数学：</th>
                <td><asp:TextBox ID="TextBox2" runat="server" CssClass="txtInput normal" maxlength="100">0.00</asp:TextBox></td>
            </tr>
            <tr>
                <th>外语：</th>
                <td><asp:TextBox ID="TextBox3" runat="server" CssClass="txtInput normal" maxlength="100">0.00</asp:TextBox></td>
            </tr>
            <tr>
                <th>文综：</th>
                <td><asp:TextBox ID="TextBox4" runat="server" CssClass="txtInput normal" maxlength="100">0.00</asp:TextBox></td>
            </tr>
            <tr>
                <th>理综：</th>
                <td><asp:TextBox ID="TextBox5" runat="server" CssClass="txtInput normal" maxlength="100">0.00</asp:TextBox></td>
            </tr>
            <tr>
                <th>生物：</th>
                <td><asp:TextBox ID="TextBox6" runat="server" CssClass="txtInput normal" maxlength="100">0.00</asp:TextBox></td>
            </tr>
            <tr>
                <th>历史：</th>
                <td><asp:TextBox ID="TextBox7" runat="server" CssClass="txtInput normal" maxlength="100">0.00</asp:TextBox></td>
            </tr>
            <tr>
                <th>地理：</th>
                <td><asp:TextBox ID="TextBox8" runat="server" CssClass="txtInput normal" maxlength="100">0.00</asp:TextBox></td>
            </tr>
            <tr>
                <th>物理：</th>
                <td><asp:TextBox ID="TextBox9" runat="server" CssClass="txtInput normal" maxlength="100">0.00</asp:TextBox></td>
            </tr>
            <tr>
                <th>化学：</th>
                <td><asp:TextBox ID="TextBox10" runat="server" CssClass="txtInput normal" maxlength="100">0.00</asp:TextBox></td>
            </tr>
            
            <tr>
                <th>总分：</th>
                <td><asp:TextBox ID="TextBox14" runat="server" CssClass="txtInput normal" maxlength="100">0.00</asp:TextBox></td>
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