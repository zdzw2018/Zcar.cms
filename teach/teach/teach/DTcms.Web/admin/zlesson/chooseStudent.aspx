<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chooseStudent.aspx.cs"
    Inherits="DTcms.Web.admin.zlesson.chooseStudent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>选择学生</title>
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
                errorPlacement: function (lable, element) {
                    element.ligerTip({ content: lable.html(), appendIdTo: lable });
                },
                success: function (lable) {
                    lable.ligerHideTip();
                }
            });
        });
        //选中相关的checkbox
        function SelectedItems(obj, className) {
            if ($(obj).attr("checked") == true) {
                $("." + className).attr("checked", true);
            } else {
                $("." + className).attr("checked", false);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="navigation">
        <a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 控制面板 &gt; 选择上课的学生</div>
    <div id="contentTab">
        <ul class="tab_nav">
            <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">选择上课的学生</a></li>
        </ul>
        <div class="tab_con" style="display: block;">
            <table class="form_table">
                <col width="180px">
                <col>
                <tbody>
                    <tr style="display:none;">
                        <th>
                            年级：
                        </th>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlgrade" CssClass="select2">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th></th>
                        <td><label><input type="checkbox" class="cball" onclick="SelectedItems(this, 'config');" /><b>全选</b></label></td>
                    </tr>
                    <tr>
                        <th>
                        </th>
                        <td class="item_list">
                           <asp:Repeater id="rptlist" runat="server">
                                <ItemTemplate>
                                     <asp:HiddenField ID="hidId" Value="0" runat="server" />
                                     <label><input type="checkbox" runat="server" id="cblNavName" value='<%#Eval("id")%>' class="config" /><%#Eval("stu_name")%></label>
                                </ItemTemplate>
                           </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <th></th>
                        <td><asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" onclick="btnSubmit_Click" /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
