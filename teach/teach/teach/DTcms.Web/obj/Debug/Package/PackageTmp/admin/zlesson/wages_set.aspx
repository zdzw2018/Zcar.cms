<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wages_set.aspx.cs" Inherits="DTcms.Web.admin.zlesson.wages_set" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>课时工资管理</title>
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
                <th>年级：</th>
                <td>
                    <asp:CheckBoxList runat="server" RepeatDirection="Horizontal" CssClass="required"  RepeatLayout="Flow" ID="cblGrade">
                         <asp:ListItem Value="小一">小一</asp:ListItem>
                <asp:ListItem Value="小二">小二</asp:ListItem>
                <asp:ListItem Value="小三">小三</asp:ListItem>
                <asp:ListItem Value="小四">小四</asp:ListItem>
                <asp:ListItem Value="小五">小五</asp:ListItem>
                <asp:ListItem Value="小六">小六</asp:ListItem>
                <asp:ListItem Value="初一">初一</asp:ListItem>
                <asp:ListItem Value="初二">初二</asp:ListItem>
                <asp:ListItem Value="初三">初三</asp:ListItem>
                <asp:ListItem Value="高一">高一</asp:ListItem>
                <asp:ListItem Value="高二">高二</asp:ListItem>
                <asp:ListItem Value="高三">高三</asp:ListItem>
                <asp:ListItem Value="大一">大一</asp:ListItem>
                <asp:ListItem Value="大二">大二</asp:ListItem>
                <asp:ListItem Value="大三">大三</asp:ListItem>
                <asp:ListItem Value="大四">大四</asp:ListItem>
                </asp:CheckBoxList><label id="lblweek">*</label></td>
            </tr>
            <tr>
                <th>课时区间：</th>
                <td><asp:TextBox ID="txtKeShiBegin" runat="server"  CssClass="txtInput number required" maxlength="100" /><label>*</label>
                     到 
                    <asp:TextBox ID="txtKeShiEnd" runat="server" CssClass="txtInput number required" maxlength="100" /><label>*</label>
                </td>
            </tr>

            <tr>
                <th>课时工资：</th>
                <td><asp:TextBox ID="txtWages" runat="server"  CssClass="txtInput number required" maxlength="100" /><label>*</label></td>
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
