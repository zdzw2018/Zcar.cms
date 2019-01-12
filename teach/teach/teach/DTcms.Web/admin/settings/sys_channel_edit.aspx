<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_channel_edit.aspx.cs" Inherits="DTcms.Web.admin.settings.sys_channel_edit" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑频道信息</title>
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
        $('#txtName').focus();
        $("#form1").validate({
            errorPlacement: function (lable, element) {
                element.ligerTip({ content: lable.html(), appendIdTo: lable });
            },
            rules: {
                txtName: {
                    required: true,
                    minlength: 2,
                    maxlength: 100,
                    remote: {
                        type: "post",
                        url: "../../tools/admin_ajax.ashx?action=sys_channel_validate",
                        data: {
                            channelname: function () {
                                return $("#txtName").val();
                            },
                            oldname: function () {
                                return $("#hidName").val();
                            }
                        },
                        dataType: "html",
                        dataFilter: function (data, type) {
                            if (data == "true")
                                return true;
                            else
                                return false;
                        }
                    }
                }
            },
            success: function (lable) {
                lable.ligerHideTip();
            },
            messages: {
                txtName: {
                    required: "输入(2-100)位字符",
                    minlength: "必须大于2位字符",
                    maxlength: "必须小于100位字符",
                    remote: "很抱歉，该名称已被使用"
                }
            }
        });
    });
    //菜单事件处理
    $(function () {
        //初始化按钮事件
        $("#item_box tr").each(function (i) {
            initButton(i);
        });
        //添加按钮(点击绑定)
        $("#itemAddButton").click(function () {
            var navSize = $('#item_box tr').size();
            var navRow = getTr(navSize);
            $("#item_box").append(navRow);
            initButton(navSize);
            //默认URL配置
            IndexSetValue(navSize);
        });
    });

    //表格行的菜单内容
    function getTr(indexValue) {
        var navRow = '<tr>'
        + '<td><select name="item_type" class="select2" style="width:100%;" onchange="ItemSelect(this);"><option value="index">首页</option><option value="list">列表页</option><option value="detail">详细页</option></select></td>'
        + '<td><input name="item_name" type="text" class="txtInput small" style="width:98%;" onblur="checkItemName(this);" /></td>'
        + '<td><input name="item_path" type="text" class="txtInput small3" style="width:98%;" /></td>'
        + '<td><input name="item_pattern" type="text" class="txtInput small3" style="width:98%;" /></td>'
        + '<td><input name="item_querystring" type="text" class="txtInput small3" style="width:98%;" /></td>'
        + '<td><input name="item_templet" type="text" class="txtInput small" style="width:98%;" /></td>'
		+ '<td align="center"><img alt="删除" src="../images/icon_del.gif" class="operator" /></td>'
		+ '</tr>';
        return navRow;
    }

    //初始化按钮事件
    function initButton(indexValue) {
        //功能操作按钮
        $("#item_box tr:eq(" + indexValue + ") .operator").each(function (i) {
            switch (i) {
                //删除                   
                case 0:
                    $(this).click(function () {
                        var obj = $(this);
                        $.ligerDialog.confirm("确定要删除吗？", "提示信息", function (result) {
                            if (result) {
                                obj.parent().parent().remove(); //删除节点
                            }
                        });
                    });
                    break;
            }
        });
    }

    //选择URL类型
    function ItemSelect(obj) {
        var indexValue = $("#item_box tr").index($(obj).parent().parent());
        IndexSetValue(indexValue);
    }

    //给URL配置首页赋值
    function IndexSetValue(indexValue) {
        //咨询是否使用默认设置
        $.ligerDialog.confirm("是否使用默认配置？", "提示信息", function (result) {
            if (result) {
                var trObj = $("#item_box tr:eq(" + indexValue + ")");
                var itemType = trObj.find("select[name='item_type']");
                var channelName = $("#txtName").val(); //获得频道名称
                if (channelName == "") {
                    return false;
                }
                switch (itemType.children("option:selected").attr("value")) {
                    case "list":
                        trObj.find("input[name='item_name']").val(channelName + "_list");
                        trObj.find("input[name='item_path']").val(channelName + "/{0}/{1}.aspx");
                        trObj.find("input[name='item_pattern']").val(channelName + "/(\\d+)*/(\\w+).aspx$");
                        trObj.find("input[name='item_querystring']").val("category_id=$1^page=$2");
                        trObj.find("input[name='item_templet']").val(channelName + "_list.html");
                        break;
                    case "detail":
                        trObj.find("input[name='item_name']").val(channelName + "_show");
                        trObj.find("input[name='item_path']").val(channelName + "/show/{0}.aspx");
                        trObj.find("input[name='item_pattern']").val(channelName + "/show/(\\d+).aspx$");
                        trObj.find("input[name='item_querystring']").val("id=$1");
                        trObj.find("input[name='item_templet']").val(channelName + "_show.html");
                        break;
                    default:
                        trObj.find("input[name='item_name']").val(channelName);
                        trObj.find("input[name='item_path']").val(channelName + ".aspx");
                        trObj.find("input[name='item_pattern']").val(channelName + ".aspx$");
                        trObj.find("input[name='item_querystring']").val("");
                        trObj.find("input[name='item_templet']").val(channelName + ".html");
                        break;
                }
            }
        });
    }

    //检查名称是否重复
    var isDialog = false;
    function checkItemName(obj) {
        if (isDialog) {
            return false;
        }
        var indexValue = $("#item_box tr").index($(obj).parent().parent());
        $("input[name='item_name']").each(function (i) {
            if ($(this).val() == $(obj).val() && i != indexValue) {
                isDialog = true;
                $.ligerDialog.warn('对不起，URL配置名称不能重复！', function () {
                    isDialog = false;
                    //$.ligerDialog.close(function () {
                        //$(obj).focus();
                    //});
                });
                return false;
            }
        });
    }
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 控制面板 &gt; 系统频道</div>
<div id="navtips" class="navtips">
    编辑频道信息需具备基本的正则表达式知识，注意URL配置的名称不要重复，以下正则表达式可供参考：<br />
    约定参数：category_id为频道ID，page为分页页码；<br />
    (\d+)：表示只允许1个或以上的数字；<br />
    (\w+)：表示只允许字母、数字、下划线或汉字；<br />
    <a href="javascript:CloseTip('navtips');" class="close">关闭</a>
</div>
<div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">编辑频道信息</a></li>
    </ul>
    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="180px"><col>
            <tbody>
            <tr>
                <th>频道名称：</th>
                <td>
                    <asp:HiddenField ID="hidName" runat="server" Value="" />
                    <asp:TextBox ID="txtName" runat="server" CssClass="txtInput normal"></asp:TextBox><label>*只允许英文字母、下划线，不可重复</label></td>
            </tr>
            <tr>
                <th>频道标题：</th>
                <td><asp:TextBox ID="txtTitle" runat="server" CssClass="txtInput normal required" minlength="2" maxlength="100"></asp:TextBox><label>*</label></td>
            </tr>
            <tr>
                <th>所属模型：</th>
                <td><asp:DropDownList id="ddlModelId" CssClass="select2 required" runat="server"></asp:DropDownList><label>*更改模型请手动删除旧内容</label></td>
            </tr>
            <tr>
                <th>排 序：</th>
                <td><asp:TextBox ID="txtSortId" runat="server" CssClass="txtInput normal small required digits"></asp:TextBox><label>*</label></td>
            </tr>
            <tr>
                <th>URL配置：</th>
                <td><button id="itemAddButton" type="button" class="btnSelect"><span class="add">添 加</span></button></td>
            </tr>
            <tr>
                <th></th>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" class="border_table" width="99%">
                        <thead>
                        <tr>
                            <th width="9%">类型</th>
                            <th width="15%">名称</th>
                            <th width="18%">URL重写</th>
                            <th width="18%">正则表达式</th>
                            <th width="18%">参数配置</th>
                            <th width="15%">模板文件</th>
                            <th width="5%">操作</th>
                        </tr>
                        </thead>
                        <tbody id="item_box">
                        <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                        <tr class="td_c">
                            <td>
                                <select name="item_type" class="select2" style="width:100%;" onchange="ItemSelect(this);">
	                                <option value="index" <%#Eval("type").ToString() == "index" ? " selected" : ""%>>首页</option>
	                                <option value="list" <%#Eval("type").ToString() == "list" ? " selected" : ""%>>列表页</option>
	                                <option value="detail" <%#Eval("type").ToString() == "detail" ? " selected" : ""%>>详细页</option>
                                </select>
                            </td>
                            <td><input name="item_name" type="text" value="<%#Eval("name")%>" class="txtInput small" style="width:98%;" onblur="checkItemName(this);" /></td>
                            <td><input name="item_path" type="text" value="<%#Eval("path")%>" class="txtInput small3" style="width:98%;" /></td>
                            <td><input name="item_pattern" type="text" value="<%#Eval("pattern")%>" class="txtInput small3" style="width:98%;" /></td>
                            <td><input name="item_querystring" type="text" value="<%#Eval("querystring")%>" class="txtInput small3" style="width:98%;" /></td>
                            <td><input name="item_templet" type="text" value="<%#Eval("templet")%>" class="txtInput small" style="width:98%;" /></td>
                            <td><img alt="删除" src="../images/icon_del.gif" class="operator" /></td>
                        </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                        </tbody>
                    </table>
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
