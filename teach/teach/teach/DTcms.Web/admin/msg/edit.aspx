<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="DTcms.Web.admin.msg.edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑资讯信息</title>
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

    //删除附件Li节点
    function DelAttachLi(obj) {
        $.ligerDialog.confirm("确定要删除吗？", "提示信息", function (result) {
            if (result) {
                $(obj).parent().remove(); //删除节点
            }
        });
    }
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 发件信箱管理 &gt; <%if (action == "Edit")
                                                                                                      { %>查看信息<%}else{ %>编辑信息<%}%></div>
<div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>收件人：</th>
                <td><asp:TextBox ID="txtmsg_income_user" runat="server" CssClass="txtInput normal required" maxlength="100" />
                <%if (action == "Add")
               { %>
                <label>请填写收件人帐号 多个用 ','隔开*</label><span style=" color:Red;">如果用户名填写错误将信息发不出去</span>
                <%} %>
                </td>
            </tr>
            <tr>
                <th>标题名称：</th>
                <td><asp:TextBox ID="txtmsg_title" runat="server" CssClass="txtInput normal required" maxlength="100" /><label>*</label></td>
            </tr>
            <tr>
                <th>详细内容：</th>
                <td><asp:TextBox ID="txtmsg_content" runat="server" maxlength="255" TextMode="MultiLine" CssClass="small" />
                </td>
            </tr>
             <%if (action == "Add")
               { %><tr>
                <th valign="top" style="padding-top:10px;">上传附件：</th>
                <td>
                    <a href="javascript:;" class="files"><input type="file" id="FileUpload2" name="FileUpload2" onchange="AttachUpload('AttachList','FileUpload2');" /></a>
                    <span class="uploading">正在上传，请稍候...</span>
                </td>
            </tr>
            <%} %>
            <tr>
                <th></th>
                <td>
                    <div id="AttachList" class="attach_list">
                      <ul>
                        <!--
                        <li>
                          <input name="hidFileName" type="hidden" value="ID|原名|新名" />
                          <b title="删除" onclick="DelAttachLi(this);"></b>附件：原名.jpg
                        </li>
                        -->
                        <asp:Repeater ID="rptAttach" runat="server">
                        <ItemTemplate>
                        <li>
                          <input name="hidFileName" type="hidden" value="<%#Eval("id")%>|<%#Eval("title")%>|<%#Eval("file_path")%>" />
                          <a href="<%#Eval("file_path")%>" target="_blank">下载</a><b title="删除" onclick="DelAttachLi(this);"></b>附件：<%#Eval("title")%>
                        </li>
                        </ItemTemplate>
                        </asp:Repeater>
                      </ul>
                    </div>
                </td>
            </tr>
           
            </tbody>
        </table>
    </div>
    <%if (action == "Add")
      { %>
    <div class="foot_btn_box">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" onclick="btnSubmit_Click" />
    &nbsp;<input name="重置" type="reset" class="btnSubmit" value="重 置" />
    </div>
    <%}%>
</div>
</form>
</body>
</html>

