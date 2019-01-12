<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sysother.aspx.cs" Inherits="DTcms.Web.admin.settings.sysother"   ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>基础信息配置</title>
<link href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
<link href="../images/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
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
<div class="navigation">首页 &gt; 控制面板 &gt; 基础信息配置</div>
<div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基础信息配置</a></li>
    </ul>
    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="180px"><col>
            <tbody>
             <tr>
                <th>收集途径设置：</th>
                <td><asp:TextBox ID="txtsyscollection" runat="server" maxlength="250" TextMode="MultiLine" CssClass="small"></asp:TextBox><label>用回车符号隔开</label></td>
            </tr>
            <tr>
                <th>学校设置：</th>
                <td><asp:TextBox ID="txtsysschool" runat="server" maxlength="250" TextMode="MultiLine" CssClass="small"></asp:TextBox><label>用回车符号隔开</label></td>
            </tr>
            <tr>
                <th>年级设置：</th>
                <td><asp:TextBox ID="txtsysgrade" runat="server" maxlength="250" TextMode="MultiLine" CssClass="small"></asp:TextBox><label>用回车符号隔开</label></td>
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
