<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jianzhi_teacher_keshi_danjia_edit.aspx.cs" Inherits="DTcms.Web.admin.zlesson.jianzhi_teacher_keshi_danjia_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
        <div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 兼职老师课时单价 &gt; 编辑信息</div>
        <div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
                <tr>
                    <th>按老师筛选</th>
                    <td><asp:TextBox ID="txtSx" runat="server" CssClass="txtInput" AutoPostBack="true" OnTextChanged="txtSx_TextChanged"  maxlength="100"></asp:TextBox><label>输入老师姓名匹配</label></td>
                </tr>
                 <tr>
                <th>任课教师：</th>
                <td><asp:DropDownList ID="ddlTeacher" runat="server" CssClass="select2 required"></asp:DropDownList>
                </td>
            </tr>

                <tr>
                <th>年级：</th>
                <td><asp:CheckBoxList runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" ID="cblGrade">
                         <asp:ListItem Value="小学">小学</asp:ListItem>
                         <asp:ListItem Value="初一初二">初一初二</asp:ListItem>
                         <asp:ListItem Value="初三">初三</asp:ListItem>
                         <asp:ListItem Value="高一高二">高一高二</asp:ListItem>
                         <asp:ListItem Value="高三">高三</asp:ListItem>
                </asp:CheckBoxList> <label>*</label></td>
            </tr>
                 
            <tr>
                <th>课时单价：</th>
                <td><asp:TextBox ID="txtKeShiDanJia" runat="server"  CssClass="txtInput  required"  maxlength="100"></asp:TextBox><label id="lblweek">*多个年级用逗号分隔，如果没有用逗号分隔按0计算</label></td>
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
