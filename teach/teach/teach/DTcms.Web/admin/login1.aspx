<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login1.aspx.cs" Inherits="DTcms.Web.admin.login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员登录</title>
    <link href="../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link  href="login/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery/jquery.validate.min.js"></script> 
    <script type="text/javascript" src="../scripts/jquery/messages_cn.js"></script>
    <script type="text/javascript" src="../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript" src="js/function.js"></script>
    <script type="text/javascript">
        //表单验证
        $(function () {
            //检测IE
            if ($.browser.msie && $.browser.version == "6.0") {
                window.location.href = 'ie6update.html';
            }
            $('#txtUserName').focus();
            $("#form1").validate({
                errorPlacement: function (lable, element) {
                    element.ligerTip({ content: lable.html(), appendIdTo: lable });
                },
                success: function (lable) {
                    lable.ligerHideTip();
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="nr">
	<div class="nr_1">
    	<dl>
        	<dt><img src="login/logo.png" /></dt>
            <dd><img src="login/zwjz.png" /></dd>
        </dl>
    </div>

    <div class="nr_3">
<table border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="60" colspan="3"><h3>登陆网站后台管理</h3></td>
              </tr>
              <tr>
                <td width="75" height="40">登陆账号：</td>
                <td height="40" colspan="2">
                	<input name="" type="text" style="background:url(login/csrk.png) no-repeat; border:none; height:33px; width:206px; text-indent:10px;"/>
                </td>
      </tr>
              <tr>
                <td width="75" height="40">登陆密码：</td>
                <td height="40" colspan="2">
                	<input name="" type="text" style="background:url(login/csrk.png) no-repeat; border:none; height:33px; width:206px;text-indent:10px;"/>
                </td>
              </tr>
              <tr>
                <td width="75" height="40">验证码：</td>
                <td width="130" height="40"><input name="" type="text" style="background:url(login/dsrk.png) no-repeat; border:none; height:33px; width:106px;text-indent:10px;"/></td>
                <td height="40"><img src="login/yzm.jpg" /></td>
              </tr>
              <tr>
                <td height="60" colspan="2" align="center"><asp:CheckBox ID="cbRememberId" runat="server" Text="记住用户名" Checked="True" /></td>
                <td height="60"><asp:Button ID="btnSubmit" runat="server" Text="登 录" CssClass="login_btn" onclick="btnSubmit_Click" /><input name="" type="submit" value="登陆" style="background:url(login/an.png) no-repeat; width:92px; height:35px; border:none; padding-top:5px; text-indent:-3px;"/></td>
      </tr>
      </table>
  </div>
</div>
    </form>
</body>
</html>
