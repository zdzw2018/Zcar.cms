<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="DTcms.Web.admin.market_out.edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑学生资源信息</title>
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
    <div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 外场信息管理 &gt; 编辑信息</div>
    <div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>活动时间：</th>
                <td><asp:TextBox ID="txtactivity_time" runat="server" CssClass="txtInput normal required" onclick="return Calendar('txtactivity_time');" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>活动地点：</th>
                <td><asp:TextBox ID="txtactivity_location" runat="server" CssClass="txtInput normal" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>活动内容：</th>
                <td><asp:TextBox ID="txtactivity_content" runat="server" maxlength="255" TextMode="MultiLine" CssClass="small" /></td>
            </tr>
             <tr>
                <th>关注人数：</th>
                <td><asp:TextBox ID="txtwatchers" runat="server" CssClass="txtInput normal" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>收集有效信息数：</th>
                <td><asp:TextBox ID="txtcollect_msg" runat="server" CssClass="txtInput normal" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>地推费用：</th>
                <td><asp:TextBox ID="txtoprice_push" runat="server" CssClass="txtInput normal" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>兼职费用：</th>
                <td><asp:TextBox ID="txtpart_time_fees" runat="server" CssClass="txtInput normal" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>问题与反馈：</th>
                <td><asp:TextBox ID="txtques_feed" runat="server" maxlength="255" TextMode="MultiLine" CssClass="small" /></td>
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

