<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="DTcms.Web.admin.student.view" %>

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
                <th>家长姓名：</th>
                <td><%=model.stu_parent_name%></td>
            </tr>
            <tr>
                <th>学生姓名：</th>
                <td><%=model.stu_name%></td>
            </tr>
            <tr>
                <th>联系电话：</th>
                <td><%=model.stu_tel%></td>
            </tr>
            <tr>
                <th>学校：</th>
                <td><%=model.stu_school%></td>
            </tr>
            <tr>
                <th>年级：</th>
                <td><%=model.stu_grade%></td>
            </tr>
            <tr>
                <th>家庭住址：</th>
                <td><%=model.stu_addr%></td>
            </tr>
            <tr>
                <th>剩余课时：</th>
                <td><%=model.stu_lesson%></td>
            </tr>
            <tr>
                <th>备注：</th>
                <td><%=model.stu_remark%></td>
            </tr>

            </tbody>
        </table>
    </div>
       <div class="tab_con">
            <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
      
        <th align="center" width="15%">合同编号</th>
        <th width="10%" align="center">学生姓名</th>
        <th width="10%" align="center">签订课时</th>
          <th width="10%" align="center">教育咨询费</th>
           <th width="10%" align="center">未支付教育咨询费</th>
        <th width="10%">合同状态</th>
        <th width="6%">合同信息</th>
        <th width="10%" align="center">添加时间</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><%#Eval("contract_no")%></td>
        <td align="center"><%#Eval("stu_name")%></td>
        <td align="center"><%#Eval("contract_lesson")%></td>
        <td align="center"><%#Eval("contract_advice_price") %></td>
        <td align="center"><%#Eval("contract_advice_price_surplus") %></td>
        <td align="center"><%#Eval("stutas_name")%></td>
        <td align="center"><%#Eval("contract_status").ToString()=="0" ? "正常合同" : "续费合同" %></td>
        <td align="center"><%#string.Format("{0:d}", Eval("Expr2"))%></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
      </table>
    </FooterTemplate>
    </asp:Repeater>
    <!--列表展示.结束-->
    <div class="line15"></div>
    <div class="page_box">
      <div id="PageContent" runat="server" class="flickr right"></div>
      <div class="left">
         显示<asp:TextBox ID="txtPageNum" runat="server" CssClass="txtInput2 small2" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" 
             ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
      </div>
    </div>
    <div class="line10"></div>
       </div>
    <div class="foot_btn_box">
   <input name="返回列表" onclick="history.go(-1);" type="button" class="btnSubmit" value="返回列表" />
    </div>
</div>
</form>
</body>
</html>
