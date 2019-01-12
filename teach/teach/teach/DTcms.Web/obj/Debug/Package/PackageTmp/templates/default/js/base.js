/* 
*作者：一些事情
*时间：2012-6-28
*需要结合jquery和jquery.form和liger ui一起使用
----------------------------------------------------------*/
/*搜索查询*/
function SiteSearch(send_url, divTgs) {
	var str = $.trim($(divTgs).val());
	if (str.length > 0 && str != "输入关健字") {
		window.location.href = send_url + "?keyword=" + encodeURI($(divTgs).val());
	}
}
/*切换验证码*/
function ToggleCode(obj, codeurl) {
    $(obj).children("img").eq(0).attr("src", codeurl + "?time=" + Math.random());
}
/*表单AJAX提交封装*/
function AjaxOnSubmit(form_id, btn_id, send_url){
    $('#' + form_id).validate({
		errorPlacement: function (lable, element) {
			element.ligerTip({ content: lable.html(), appendIdTo: lable });
		},
		success: function(lable){
			lable.ligerHideTip();
		},
		submitHandler: function(form) {
			//AJAX提交表单
            $(form).ajaxSubmit({
                beforeSubmit: formRequest,
                success: formResponse,
                error: formError,
                url: send_url,
                type: "post",
                dataType: "json",
                //resetForm: true,
                timeout: 30000
            });
            return false;
		}
	});
    
    //表单提交前
    function formRequest(formData, jqForm, options) {
        $("#" + btn_id).attr("disabled", "disabled");
        $("#" + btn_id).val("提交中...");
    }

    //表单提交后
    function formResponse(data, textStatus) {
        if (data.msg == 1) {
            $("#" + btn_id).val("提交成功");
			$.ligerDialog.success(data.msgbox,function(){
			  if($("#turl").length > 0 && $("#turl").val() != ""){
			    location.href = $("#turl").val();
			  }
			});
        } else {
            $.ligerDialog.warn(data.msgbox);
            $("#" + btn_id).attr("disabled", "");
            $("#" + btn_id).val("再次提交");
        }
    }

    //表单提交出错
    function formError(XMLHttpRequest, textStatus, errorThrown) {
        $.ligerDialog.error("状态：" + textStatus + "；出错提示：" + errorThrown);
        $("#" + btn_id).attr("disabled", "");
        $("#" + btn_id).val("再次提交");
    }
}

/*显示AJAX分页列表*/
function AjaxPageList(listDiv, pageDiv, pageSize, pageCount, sendUrl) {
    //pageIndex -页面索引初始值
    //pageSize -每页显示条数初始化
    //pageCount -取得总页数
	InitComment(0);//初始化评论数据
	$(pageDiv).pagination(pageCount, {
		callback: pageselectCallback,
		prev_text: "« 上一页",
		next_text: "下一页 »",
		items_per_page:pageSize,
		num_display_entries:3,
		current_page:0,
		num_edge_entries:5,
		link_to:"javascript:;"
	});
	
    //分页点击事件
    function pageselectCallback(page_id, jq) {
        InitComment(page_id);
    }
    //请求评论数据
    function InitComment(page_id) {                                
        page_id++;
		$.ajax({ 
            type: "POST",
            dataType: "text",
            url: sendUrl + "&page_size=" + pageSize + "&page_index=" + page_id,
            success: function(data) {
                $(listDiv).html(data);
            }
        });
    }
}