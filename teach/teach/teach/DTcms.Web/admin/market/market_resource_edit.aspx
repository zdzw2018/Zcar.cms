<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="market_resource_edit.aspx.cs" Inherits="DTcms.Web.admin.market.market_resource_edit" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑录入信息</title>
<link href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
<link href="../images/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery.form.js"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery.validate.min.js"></script> 
<script type="text/javascript" src="../../scripts/jquery/messages_cn.js"></script>
<script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
<script type='text/javascript' src="../../scripts/swfupload/swfupload.js"></script>
<script type='text/javascript' src="../../scripts/swfupload/swfupload.queue.js"></script>
<script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
<script type="text/javascript" src="../js/function.js"></script>
<script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
<script type="text/javascript">
    //加载编辑器
    $(function () {
        var editor = KindEditor.create('textarea[name="txtContent"]', {
            resizeType: 1,
            uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
            fileManagerJson: '../../tools/upload_ajax.ashx?action=ManagerFile',
            allowFileManager: true
        });

    });
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
    //初始化上传控件
    $(function () {
        InitSWFUpload("../../tools/upload_ajax.ashx", "Filedata", "2 MB", "../../scripts/swfupload/swfupload.swf", 1, 1);
    });
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 录入管理 &gt; 编辑信息</div>
<div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li> 
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>所属类别：</th>
                <td><asp:DropDownList id="ddlCategoryId" CssClass="select2 required" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <th>家长姓名：</th>
                <td><asp:TextBox ID="txtrparent_name" runat="server" CssClass="txtInput normal required" maxlength="100" /></td>
            </tr>
             <tr>
                <th>学生姓名：</th>
                <td><asp:TextBox ID="txtrstudent_name" runat="server" CssClass="txtInput normal required" maxlength="100" /></td>
            </tr>
             <tr>
                <th>联系电话：</th>
                <td><asp:TextBox ID="txttel" runat="server" CssClass="txtInput normal required" maxlength="100" /></td>
            </tr>

            <tr>
              <td>收集日期：</td>
              <td><asp:TextBox ID="txtadd_time" runat="server" CssClass="txtInput normal" onclick="return Calendar('txtadd_time');"maxlength="100" ></asp:TextBox></td>
            </tr>

             <tr>
                <th>学校：</th>
                <td><asp:TextBox ID="txtrschool" runat="server" CssClass="txtInput normal required" maxlength="100" /></td>
            </tr>
             <tr>
                <th>年级：</th>
                <td><asp:TextBox ID="txtrgrade" runat="server" CssClass="txtInput normal required" maxlength="100" /></td>
            </tr>
             <tr>
                <th>家庭住址：</th>
                <td><asp:TextBox ID="txtraddr" runat="server" CssClass="txtInput normal required" maxlength="100" /></td>
            </tr>

             <tr>
                <th>市场人员：</th>
                <td><asp:TextBox ID="txtrmarket_man" runat="server" CssClass="txtInput normal required" maxlength="100" /></td>
            </tr>
              
            <tr>
                <th>收集途径：</th>
                <td>
                    <asp:CheckBoxList ID="cblItem" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1">允许评论</asp:ListItem>
                        <asp:ListItem Value="1">置顶</asp:ListItem>
                        <asp:ListItem Value="1">推荐</asp:ListItem>
                        <asp:ListItem Value="1">热点</asp:ListItem>
                        <asp:ListItem Value="1">幻灯</asp:ListItem>
                        <asp:ListItem Value="1">隐藏</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
          <tr>
                <th valign="top">详细描述：</th>
                <td>
                    <textarea id="txtContent" cols="100" rows="8" style="width:99%;height:350px;visibility:hidden;" runat="server"></textarea>
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
