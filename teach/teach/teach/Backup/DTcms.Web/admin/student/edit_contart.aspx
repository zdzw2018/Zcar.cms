<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_contart.aspx.cs" Inherits="DTcms.Web.admin.student.edit_contart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑合同信息</title>
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
    <div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 合同信息管理 &gt; 编辑信息</div>
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
    </ul>
     <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>学生姓名：</th>
                <td><asp:TextBox ID="txtstuName" runat="server" CssClass="txtInput normal" maxlength="100"  ReadOnly="true" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>合同编号：</th>
                <td><asp:TextBox ID="txtcontract_no" runat="server" CssClass="txtInput normal" maxlength="100"  ReadOnly="true"  ></asp:TextBox></td>
            </tr>
            <tr>
                <th>购买课时：</th>
                <td><asp:TextBox ID="txtcontract_lesson" runat="server" CssClass="txtInput normal" maxlength="100"  ></asp:TextBox></td>
            </tr>
            <tr>
                <th>课时单价：</th>
                <td><asp:TextBox ID="txtcontract_lesson_price" runat="server" CssClass="txtInput normal" maxlength="100"  ></asp:TextBox></td>
            </tr>
            <tr>
                <th>综合服务费：</th>
                <td><asp:TextBox ID="txtcontract_service_price" runat="server" CssClass="txtInput normal" maxlength="100"  ></asp:TextBox></td>
            </tr>
            <tr>
                <th>教育咨询费 ：</th>
                <td><asp:TextBox ID="txtcontract_advice_price" runat="server" CssClass="txtInput normal" maxlength="100"  ></asp:TextBox></td>
            </tr>
            <tr>
                <th>未支付教育咨询费：</th>
                <td><asp:TextBox ID="txtcontract_advice_price_surplus" runat="server" CssClass="txtInput normal" maxlength="100"  ></asp:TextBox></td>
            </tr>
            <tr>
                <th valign="top">备注：</th>
                <td><asp:TextBox ID="txtcontract_remark" runat="server" maxlength="255" TextMode="MultiLine" CssClass="small"  /></td>
            </tr>

            </tbody>
        </table>
            <div class="foot_btn_box">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" onclick="btnSubmit_Click" />&nbsp;
   <input name="返回列表" onclick="history.go(-1);" type="button" class="btnSubmit" value="返回列表" />
    </div>
     </div>
    </form>
</body>
</html>