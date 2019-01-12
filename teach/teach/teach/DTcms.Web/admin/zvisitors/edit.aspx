﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="DTcms.Web.admin.zvisitors.edit" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>来访资源管理</title>
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
    <div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 来访资源管理 &gt; 编辑信息</div>
    <div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>来访日期：</th>
                <td><asp:TextBox ID="txtdate_visit" runat="server" CssClass="txtInput normal required" onclick="return Calendar('txtdate_visit');" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>家长姓名：</th>
                <td><asp:TextBox ID="txtpartent_name" runat="server" CssClass="txtInput normal" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>学生姓名：</th>
                <td><asp:TextBox ID="txtstu_name" runat="server" CssClass="txtInput normal" maxlength="100"  /></td>
            </tr>
             <tr>
                <th>联系电话：</th>
                <td><asp:TextBox ID="txttel" runat="server" CssClass="txtInput normal" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>学校：</th>
                <td><asp:TextBox ID="txtschool" runat="server" CssClass="txtInput normal" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>年级：</th>
                <td><asp:DropDownList ID="txtGrade" runat="server" CssClass="select required"></asp:DropDownList></td>
            </tr>
            <tr>
                <th>家庭住址：</th>
                <td><asp:TextBox ID="txtaddress" runat="server" CssClass="txtInput normal" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>来访性质：</th>
                <td><asp:DropDownList ID="txtvisiting_nature"  runat="server" CssClass="select">
                    <asp:ListItem Value="直访" Text="直访"></asp:ListItem>
                    <asp:ListItem Value="来电约访" Text="来电约访"></asp:ListItem>
                    <asp:ListItem Value="市场约访" Text="市场约访"></asp:ListItem>
                    <asp:ListItem Value="呼叫中心约访" Text="呼叫中心约访"></asp:ListItem>
                    <asp:ListItem Value="转介绍" Text="转介绍"></asp:ListItem>
                    <asp:ListItem Value="其他" Text="其他"></asp:ListItem>
                </asp:DropDownList></td>
            </tr>
              <tr>
                <th>签约已否：</th>
                <td><asp:DropDownList ID="txtsigned"  runat="server" CssClass="select">
                    <asp:ListItem Value="已签" Text="已签"></asp:ListItem>
                    <asp:ListItem Value="未签" Text="未签"></asp:ListItem>
                </asp:DropDownList></td>
            </tr>
           <tr>
            <td>来访咨询情况</td>
            <td>
               <asp:TextBox ID="txtZiXun" runat="server" maxlength="255" TextMode="MultiLine" CssClass="required small"  />
            </td>
           </tr>
           <tr>
            <td>跟进情况</td>
            <td>
                <asp:TextBox ID="txtGenJin" runat="server" maxlength="255" TextMode="MultiLine" CssClass="required small"  />
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
