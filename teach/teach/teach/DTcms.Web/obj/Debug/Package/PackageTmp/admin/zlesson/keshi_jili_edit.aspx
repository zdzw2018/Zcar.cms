<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="keshi_jili_edit.aspx.cs" Inherits="DTcms.Web.admin.zlesson.keshi_jili_edit" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title>课时激励管理</title>
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
    <div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 课时激励管理 &gt; 编辑激励</div>
        <div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>激励区间：</th>
                <td><asp:TextBox ID="txtTotalBegin" runat="server"  CssClass="txtInput number required" maxlength="100" /><label>*</label>
                     到 
                    <asp:TextBox ID="txtTotalEnd" runat="server" CssClass="txtInput number required" maxlength="100" /><label>*</label>
                </td>
            </tr>
                <tr>
                    <th>课时档位</th>
                    <td><asp:TextBox ID="txtDangWei" runat="server" CssClass="txtInput small required digits" maxlength="10"></asp:TextBox></td>
                </tr>
            <tr>
                <th>增加课时费/小时：</th>
                <td><asp:TextBox ID="txtAddWages" runat="server"  CssClass="txtInput number required" maxlength="100" /><label>*</label></td>
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
