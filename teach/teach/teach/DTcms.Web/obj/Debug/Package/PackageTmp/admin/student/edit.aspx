<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="DTcms.Web.admin.student.edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑学生信息</title>
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
    <div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 学生信息管理 &gt; 编辑信息</div>
    <div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
        <li><a onclick="tabs('#contentTab',1);" href="javascript:;">合同信息</a></li>
       
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>学生姓名：</th>
                <td><asp:TextBox ID="txtstu_name" runat="server" CssClass="txtInput normal required" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>学校：</th>
                <td><asp:TextBox ID="txtstu_school" runat="server" CssClass="txtInput normal" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>年级：</th>
                <td><asp:DropDownList ID="txtgrade" runat="server" CssClass="select required"></asp:DropDownList></td>
            </tr>
            <tr style="display:none">
                <th>家庭住址：</th>
                <td><asp:TextBox ID="txtstu_addr" runat="server" CssClass="txtInput normal" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>剩余课时：</th>
                <td><asp:TextBox ID="txtstu_lesson" runat="server" ReadOnly="true" CssClass="txtInput normal" maxlength="100" ></asp:TextBox></td>
            </tr>
             <tr>
                <th>签约来源：</th>
                <td><asp:DropDownList ID="ddlQianYue" runat="server" CssClass="required">
                    <asp:ListItem Value="">==请选择==</asp:ListItem>
                    <asp:ListItem Value="直访">直访</asp:ListItem>
                    <asp:ListItem Value="来电约访">来电约访</asp:ListItem>
                    <asp:ListItem Value="市场约访">市场约访</asp:ListItem>
                    <asp:ListItem Value="呼叫中心约访">呼叫中心约访</asp:ListItem>
                    <asp:ListItem Value="转介绍">转介绍</asp:ListItem>
                    <asp:ListItem Value="老生续单">老生续单</asp:ListItem>
                    <asp:ListItem Value="其他">其他</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
              <tr>
                <th>约访人：</th>
                <td><asp:TextBox ID="txtstu_tel" runat="server" CssClass="txtInput normal" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr style="display:none">
                <th>备注：</th>
                <td><asp:TextBox ID="txtstu_remark" runat="server" maxlength="255" TextMode="MultiLine" CssClass="small" /></td>
            </tr>

            </tbody>
        </table>
    </div>
    <div class="tab_con">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>合同编号：</th>
                <td><asp:TextBox ID="txtcontract_no" runat="server" CssClass="txtInput normal" maxlength="100" ReadOnly="true" Text="系统自动生成" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>购买课时：</th>
                <td><asp:TextBox ID="txtcontract_lesson" runat="server" CssClass="txtInput normal required number" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>课时单价：</th>
                <td><asp:TextBox ID="txtcontract_lesson_price" runat="server" CssClass="txtInput normal required number" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>综合服务费：</th>
                <td><asp:TextBox ID="txtcontract_service_price" runat="server" CssClass="txtInput normal required number" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>教育咨询费 ：</th>
                <td><asp:TextBox ID="txtcontract_advice_price"   runat="server" CssClass="txtInput normal required number" maxlength="100" ></asp:TextBox>(注：教育咨询费=购买课时*课时单价)</td>
            </tr>
            <tr style="display:none;">
                <th>未支付教育咨询费：</th>
                <td><asp:TextBox ID="txtcontract_advice_price_surplus" runat="server" CssClass="txtInput normal" maxlength="100" >0</asp:TextBox></td>
            </tr>
                <tr><th>赠送课时</th>
                    <td><asp:TextBox ID="txtcontract_give_lesson" runat="server" CssClass="txtInput normal" maxlength="100" >0</asp:TextBox></td>
                </tr>
            <tr>
                <th>合同状态：</th>
                <td><asp:Label ID="lblstutas" runat="server"></asp:Label></td>
            </tr>
               
                <tr> <th>1对：</th>
                    <td><asp:TextBox ID="txtOneSeveral" runat="server" CssClass="txtInput small required digits" maxlength="10">1</asp:TextBox></td>
                </tr>
                <tr>
                    <th>
                        课时单价倍数：
                    </th>
                    <td><asp:TextBox ID="txtKeShiMultiple" runat="server" CssClass="txtInput normal required number" maxlength="100" ></asp:TextBox></td>
                </tr>
            <tr>
                <th>备注：</th>
                <td><asp:TextBox ID="txtcontract_remark" runat="server" maxlength="255" TextMode="MultiLine" CssClass="small" /></td>
            </tr>
            </tbody>
        </table>
    </div>
   
    <div class="foot_btn_box">
    <%if (this.channel_id != 8)
      { %>
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" onclick="btnSubmit_Click" />
    &nbsp;<input name="重置" type="reset" class="btnSubmit" value="重 置" />
    <%} %>
    </div>
</div>
</form>
</body>
</html>
