<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="center.aspx.cs" Inherits="DTcms.Web.admin.center" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>管理首页</title>
<link href="images/style.css" rel="stylesheet" type="text/css" />
</head>
<body class="mainbody">
<form id="form1" runat="server">
<div class="navigation nav_icon">你好，<i><%=admin_info.user_name %>(<%=new DTcms.BLL.manager_role().GetTitle(admin_info.role_id) %>)</i>，欢迎进入后台管理中心</div>
<div class="line10"></div>
<div class="nlist1">
	<ul>
    	<li>本次登录IP：<asp:Literal ID="litIP" runat="server" Text="-" /></li>
        <li>上次登录IP：<asp:Literal ID="litBackIP" runat="server" Text="-" /></li>
        <li>上次登录时间：<asp:Literal ID="litBackTime" runat="server" Text="-" /></li>
    </ul>
</div>

<div class="biaoge">
    	<div class="biaoge_left">
        	<div class="biaoge_grjy">
            	<div class="biaoge_performance">
                	<h3><span><input type="button" value="查看历史"  style="margin-top:5px"></span>个人业绩</h3>
					<div id="dataInfo" class="e12cm01table" style="">
                      <table id="dataInfo1" width="100%" cellspacing="0" cellpadding="0" border="0">
		                 <tbody>
                            <tr class="e21bgcolor">
                                <td> 本月业绩指标 </td>
                                <td> 当月累计 </td>
                                <td> 任务 </td>
                                <td> 完成率(%) </td>
                            </tr>
                            <tr>
                                <td>续签合同总金额(元)</td>
                                <td class="e12bluecolor">
                                <a target="_blank" style="color:blue;text-decoration:underline " href="#">0</a>
                                </td>
                                <td>--</td>
                                <td>--</td>
                            </tr>
                            <tr>
                                <td>续签实收(元)</td>
                                <td class="e12bluecolor">
                                <a target="_blank" style="color:blue;text-decoration:underline " href="#">0</a>
                                </td>
                                <td>20,000</td>
                                <td>0.0%</td>
                            </tr>
                            <tr>
                                <td>1对1课时量(个)</td>
                                <td class="e12bluecolor">
                                <a target="_blank" style="color:blue;text-decoration:underline " href="#">157.0个</a>
                                </td>
                                <td>594.0</td>
                                <td>26.4%</td>
                            </tr>
                            <tr>
                                <td>1对1课时收入(元)</td>
                                <td class="e12bluecolor">27,532</td>
                                <td>--</td>
                                <td>--</td>
                            </tr>
                            <tr>
                                <td>退费金额(元)</td>
                                <td class="e12bluecolor">
                                <a target="_blank" style="color:blue;text-decoration:underline " href="#">0</a>
                                </td>
                                <td>--</td>
                                <td>--</td>
                            </tr>
                          </tbody>
                      </table>
                    </div>                    
                </div>
                <div class="zhanbao">
                	<h3>分公司今日续费实时战报</h3>
                    <div id="dataInfo" style="">
                    <div id="dataType1" class="e12cm01table" style="">
                        <table id="dataInfo1" width="100%" cellspacing="0" cellpadding="0" border="0" style="font-size: 12px">
                            <tbody>
                                <tr class="e21bgcolor">
                                    <td> 校区 </td>
                                    <td width="20%" bgcolor="#f2f2f2" align="center" style="font-size: 12px; color=#333333"> 签约人 </td>
                                    <td width="20%" bgcolor="#f2f2f2" align="center" style="font-size: 12px; color=#333333"> 签约课时 </td>
                                    <td width="20%" bgcolor="#f2f2f2" align="center" style="font-size: 12px; color=#333333"> 合同金额 </td>
                                    <td width="20%" bgcolor="#f2f2f2" align="center" style="font-size: 12px; color=#333333"> 产品类型 </td>
                                </tr>
                                <tr>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;">华侨大学 </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;">李某某 </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;">20.00</td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;">300000.00 </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;">咨询</td>
                                </tr>
                                <tr>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                </tr>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                <tr>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                </tr>
                                <tr>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                </tr>
                                <tr>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                </tr>
                                <tr>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                    <td width="20%" height="20" align="center" style="font-size: 13px;"> </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>                                    
                </div>
            </div>
        </div>
            <div class="biaoge_phb">
               <div id="title" class="e12conmid01" style="">
                <span>
                <img src="images/e12titlepic.jpg">
                </span>
               <span class="e12conmid01t"> 排行榜</span>
            </div> 
<div class="xinwen">
<div class="itemcon">
              <ul class="nav2">
                <li><a href="#" class="bj_1" id="tab_b0" onmouseover="showsub_b(0)">续费实收</a></li>
                <li><a href="#" class="bj_2" id="tab_b1" onmouseover="showsub_b(1)">课时量</a></li>   
                <li><a href="#" class="bj_2" id="tab_b2" onmouseover="showsub_b(2)">课时收入</a></li>                                        
              </ul>
              <div class="clearfix"></div>
              <!--open-->
              <div class="itemlist" id="sub_b0">
                   <div id="ExtendContract" class="e12cm01tableph" >
                <table width="100%" cellspacing="0" cellpadding="0" border="0" style="font-size: 12px">
                <tbody>
                <tr class="e21bgcolor">
                <td width="30%" style="border-bottom-color: currentColor; border-bottom-width: medium; border-bottom-style: none; padding-left:10px;">学管师</td>
                <td width="30%" style="border-bottom: none;padding-left:10px;">分公司排名</td>
                <td width="40%" style="border-bottom: none;padding-left:10px;">续费实收</td>
                </tr>
                <tr class="e21phnotice" style="">
                <td style="padding: 5px 10px;" colspan="3">
                我的排名：校区第
                <span class="red"> 7 </span>
                名  分公司第
                <span class="red"> 33 </span>
                名  全国第
                <span class="red"> 1477 </span>
                名
                </td>
                </tr>
                <tr>
                <td>
                <em>1</em>
                <span>陈晓曦</span>
                </td>
                <td>
                第
                <span>8</span>
                名  
                <span style="color: #ff6600"> </span>
                </td>
                <td>
                <div class="bgnormal" style="position:relative;z-index:1;">
                <span class="rate" style="width:0px;height:16px;position:absolute;left:0px;top:0px;"></span>
                <span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">￥0</span>
                </div>
                </td>
                </tr>
                <tr>
                <td>
                <em>2</em>
                <span>郭琴丹</span>
                </td>
                <td>
                第
                <span>12</span>
                名  
                <span style="color: #ff6600"> </span>
                </td>
                <td>
                <div class="bgnormal" style="position:relative;z-index:1;"></div>
                </td>
                </tr>
                <tr>
                <td>
                <em>3</em>
                <span>黄丽君</span>
                </td>
                <td>
                第
                <span>13</span>
                名  
                <span style="color: #ff6600"> </span>
                </td>
                <td>
                <div class="bgnormal" style="position:relative;z-index:1;">
                <span class="rate" style="width:0px;height:16px;position:absolute;left:0px;top:0px;"></span>
                <span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">￥0</span>
                </div>
                </td>
                </tr>
                <tr>
                <td>
                <em>4</em>
                <span>黄少艺</span>
                </td>
                <td>
                第
                <span>15</span>
                名  
                <span style="color: #ff6600"> </span>
                </td>
                <td>
                <div class="bgnormal" style="position:relative;z-index:1;">
                <span class="rate" style="width:0px;height:16px;position:absolute;left:0px;top:0px;"></span>
                <span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">￥0</span>
                </div>
                </td>
                </tr>
                <tr>
                <td>
                <em>5</em>
                <span>江琴</span>
                </td>
                <td>
                第
                <span>18</span>
                名  
                <span style="color: #ff6600"> </span>
                </td>
                <td>
                <div class="bgnormal" style="position:relative;z-index:1;">
                <span class="rate" style="width:0px;height:16px;position:absolute;left:0px;top:0px;"></span>
                <span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">￥0</span>
                </div>
                </td>
                </tr>
                <tr>
                <td>
                <em>6</em>
                <span>王婷</span>
                </td>
                <td>
                第
                <span>29</span>
                名  
                <span style="color: #ff6600"> </span>
                </td>
                <td>
                <div class="bgnormal" style="position:relative;z-index:1;">
                <span class="rate" style="width:0px;height:16px;position:absolute;left:0px;top:0px;"></span>
                <span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">￥0</span>
                </div>
                </td>
                </tr>
                <tr>
                <td>
                <em>7</em>
                <span>周利花</span>
                </td>
                <td>
                第
                <span>33</span>
                名  
                <span style="color: #ff6600"> </span>
                </td>
                <td>
                <div class="bgnormal" style="position:relative;z-index:1;">
                <span class="rate" style="width:0px;height:16px;position:absolute;left:0px;top:0px;"></span>
                <span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">￥0</span>
                </div>
                </td>
                </tr>
                <tr>
                <td>
                <em> </em>
                <span></span>
                </td>
                <td>   </td>
                <td>   </td>
                </tr>
                <tr>
                <td>
                <em> </em>
                <span></span>
                </td>
                <td>   </td>
                <td>   </td>
                </tr>
                <tr>
                <td>
                <em> </em>
                <span></span>
                </td>
                <td>   </td>
                <td>   </td>
                </tr>
                <tr>
                <td colspan="3" style="border-bottom: none; padding: 15px 10px 5px 0;">
                <div class="e12right clearfix">
                <a class="e12lastpage" onclick="#" href="#" ></a>
                <a class="e12lnextpage" onclick="#" href="#" ></a>
                </div>
                </td>
                </tr>
                </tbody>
                </table>
                <div style="text-align: center; display: none">
                <img style="margin: auto;" src="/DashUI/images/dataloading.gif">
                </div>
                </div>                   
              </div>
              <!--over-->
              <!--open-->
          <div class="itemlist" id="sub_b1" style="display:none">
   <div id="CourseCount" class="e12cm01tableph">
<table width="100%" cellspacing="0" cellpadding="0" border="0" style="font-size: 12px">
<tbody>
<tr class="e21bgcolor">
<td width="30%" style="border-bottom-color: currentColor; border-bottom-width: medium; border-bottom-style: none;">学管师</td>
<td width="30%" style="border-bottom: none">分公司排名</td>
<td width="40%" style="border-bottom: none">课时量</td>
</tr>
<tr class="e21phnotice" style="">
<td style="padding: 5px 10px;" colspan="3">
我的排名：校区第
<span class="red"> 6 </span>
名  分公司第
<span class="red"> 26 </span>
名  全国第
<span class="red"> 640 </span>
名
</td>
</tr>
<tr>
<td>
<em>1</em>
<span>江琴</span>
</td>
<td>
第
<span>5</span>
名  
<span style="color: #ff6600"> </span>
</td>
<td>
<div class="bgnormal" style="position:relative;z-index:1;">
<span class="rate" style="width:5.87325px;height:16px;position:absolute;left:0px;top:0px;"></span>
<span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">286.5个/286.5小时</span>
</div>
</td>
</tr>
<tr>
<td>
<em>2</em>
<span>郭琴丹</span>
</td>
<td>
第
<span>9</span>
名  
<span style="color: #ff6600"> </span>
</td>
<td>
<div class="bgnormal" style="position:relative;z-index:1;">
<span class="rate" style="width:5.62725px;height:16px;position:absolute;left:0px;top:0px;"></span>
<span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">274.5个/274.5小时</span>
</div>
</td>
</tr>
<tr>
<td>
<em>3</em>
<span>陈晓曦</span>
</td>
<td>
第
<span>13</span>
名  
<span style="color: #ff6600"> </span>
</td>
<td>
<div class="bgnormal" style="position:relative;z-index:1;">
<span class="rate" style="width:4.797px;height:16px;position:absolute;left:0px;top:0px;"></span>
<span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">234.0个/234.0小时</span>
</div>
</td>
</tr>
<tr>
<td>
<em>4</em>
<span>黄少艺</span>
</td>
<td>
第
<span>19</span>
名  
<span style="color: #ff6600"> </span>
</td>
<td>
<div class="bgnormal" style="position:relative;z-index:1;"></div>
</td>
</tr>
<tr>
<td>
<em>5</em>
<span>黄丽君</span>
</td>
<td>
第
<span>24</span>
名  
<span style="color: #ff6600"> </span>
</td>
<td>
<div class="bgnormal" style="position:relative;z-index:1;">
<span class="rate" style="width:3.731px;height:16px;position:absolute;left:0px;top:0px;"></span>
<span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">182.0个/182.0小时</span>
</div>
</td>
</tr>
<tr>
<td>
<em>6</em>
<span>周利花</span>
</td>
<td>
第
<span>26</span>
名  
<span style="color: #ff6600"> </span>
</td>
<td>
<div class="bgnormal" style="position:relative;z-index:1;">
<span class="rate" style="width:3.2185px;height:16px;position:absolute;left:0px;top:0px;"></span>
<span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">157.0个/157.0小时</span>
</div>
</td>
</tr>
<tr>
<td>
<em>7</em>
<span>王婷</span>
</td>
<td>
第
<span>27</span>
名  
<span style="color: #ff6600"> </span>
</td>
<td>
<div class="bgnormal" style="position:relative;z-index:1;">
<span class="rate" style="width:3.1775px;height:16px;position:absolute;left:0px;top:0px;"></span>
<span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">155.0个/155.0小时</span>
</div>
</td>
</tr>
<tr>
<td>
<em> </em>
<span></span>
</td>
<td>   </td>
<td>   </td>
</tr>
<tr>
<td>
<em> </em>
<span></span>
</td>
<td>   </td>
<td>   </td>
</tr>
<tr>
<td>
<em> </em>
<span></span>
</td>
<td>   </td>
<td>   </td>
</tr>
<tr>
<td colspan="3" style="border-bottom: none; padding: 15px 10px 5px 0;">
<div class="e12right clearfix">
<a class="e12lastpage" onclick="pagerPre(this);" href="#" action="CourseCount"></a>
<input type="hidden" value="">
<a class="e12lnextpage" onclick="pagerNxt(this)" href="#" action="CourseCount"></a>
<input type="hidden" value="">
</div>
</td>
</tr>
</tbody>
</table>
<div style="text-align: center; display: none"></div>
</div>              
              </div>
              <!--over-->
              <!--open-->
<div class="itemlist" id="sub_b2" style="display:none">
            <div id="CourseRevenue" class="e12cm01tableph">
<table width="100%" cellspacing="0" cellpadding="0" border="0" style="font-size: 12px">
<tbody>
<tr class="e21bgcolor">
<td width="30%" style="border-bottom-color: currentColor; border-bottom-width: medium; border-bottom-style: none;">学管师</td>
<td width="30%" style="border-bottom: none">分公司排名</td>
<td width="40%" style="border-bottom: none">课时收入</td>
</tr>
<tr class="e21phnotice" style="">
<td style="padding: 5px 10px;" colspan="3">
我的排名：校区第
<span class="red"> 6 </span>
名  分公司第
<span class="red"> 26 </span>
名  全国第
<span class="red"> 686 </span>
名
</td>
</tr>
<tr>
<td>
<em>1</em>
<span>江琴</span>
</td>
<td>
第
<span>2</span>
名  
<span style="color: #ff6600"> </span>
</td>
<td>
<div class="bgnormal" style="position:relative;z-index:1;">
<span class="rate" style="width:12.39348px;height:16px;position:absolute;left:0px;top:0px;"></span>
<span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">￥50,380</span>
</div>
</td>
</tr>
<tr>
<td>
<em>2</em>
<span>郭琴丹</span>
</td>
<td>
第
<span>7</span>
名  
<span style="color: #ff6600"> </span>
</td>
<td>
<div class="bgnormal" style="position:relative;z-index:1;">
<span class="rate" style="width:11.175534px;height:16px;position:absolute;left:0px;top:0px;"></span>
<span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">￥45,429</span>
</div>
</td>
</tr>
<tr>
<td>
<em>3</em>
<span>陈晓曦</span>
</td>
<td>
第
<span>13</span>
名  
<span style="color: #ff6600"> </span>
</td>
<td>
<div class="bgnormal" style="position:relative;z-index:1;">
<span class="rate" style="width:9.46608px;height:16px;position:absolute;left:0px;top:0px;"></span>
<span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">￥38,480</span>
</div>
</td>
</tr>
<tr>
<td>
<em>4</em>
<span>黄少艺</span>
</td>
<td>
第
<span>17</span>
名  
<span style="color: #ff6600"> </span>
</td>
<td>
<div class="bgnormal" style="position:relative;z-index:1;">
<span class="rate" style="width:9.275184px;height:16px;position:absolute;left:0px;top:0px;"></span>
<span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">￥37,704</span>
</div>
</td>
</tr>
<tr>
<td>
<em>5</em>
<span>黄丽君</span>
</td>
<td>
第
<span>22</span>
名  
<span style="color: #ff6600"> </span>
</td>
<td>
<div class="bgnormal" style="position:relative;z-index:1;">
<span class="rate" style="width:7.891434px;height:16px;position:absolute;left:0px;top:0px;"></span>
<span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">￥32,079</span>
</div>
</td>
</tr>
<tr>
<td>
<em>6</em>
<span>周利花</span>
</td>
<td>
第
<span>26</span>
名  
<span style="color: #ff6600"> </span>
</td>
<td>
<div class="bgnormal" style="position:relative;z-index:1;">
<span class="rate" style="width:6.772872px;height:16px;position:absolute;left:0px;top:0px;"></span>
<span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">￥27,532</span>
</div>
</td>
</tr>
<tr>
<td>
<em>7</em>
<span>王婷</span>
</td>
<td>
第
<span>27</span>
名  
<span style="color: #ff6600"> </span>
</td>
<td>
<div class="bgnormal" style="position:relative;z-index:1;">
<span class="rate" style="width:6.711864px;height:16px;position:absolute;left:0px;top:0px;"></span>
<span class="bgover1" style="heigth:16px;line-height:16px;position:absolute;padding-top:2px;left:0;top:0px;z-index:3;">￥27,284</span>
</div>
</td>
</tr>
<tr>
<td>
<em> </em>
<span></span>
</td>
<td>   </td>
<td>   </td>
</tr>
<tr>
<td>
<em> </em>
<span></span>
</td>
<td>   </td>
<td>   </td>
</tr>
<tr>
<td>
<em> </em>
<span></span>
</td>
<td>   </td>
<td>   </td>
</tr>
<tr>
<td colspan="3" style="border-bottom: none; padding: 15px 10px 5px 0;">
<div class="e12right clearfix">
<a class="e12lastpage" onclick="pagerPre(this);" href="#" action="CourseRevenue"></a>
<input type="hidden" value="">
<a class="e12lnextpage" onclick="pagerNxt(this)" href="#" action="CourseRevenue"></a>
<input type="hidden" value="">
</div>
</td>
</tr>
</tbody>
</table>
<div style="text-align: center; display: none">
</div>
</div>    
              </div>             

                                                                                                            
            </div>        
        </div>                

    </div>
            <div class="daibanshq">
                	<h3><span><input type="button" value="查看历史"  style="margin-top:5px"></span>待办任务</h3>
<div class="renwu">
                    	<h2><span><img src="images/e12titlemore.jpg" height="15" width="50" /></span><b>今天未完成的(7)</b></h2>
<div class="news_deta4">
                    <ul> 	
                        <li><a href="#">2011年度华南大区总经理述职2011年度华南大区总经理述职重在…    </a></li>
                        <li><a href="#">美国南达科他州农业领导团来访海…美国南达科他州农业领导团来访海…</a></li>
                        <li><a href="#">总裁助理张桂君接受广州日报记者…总裁助理张桂君接受广州日报记者…总裁助理张桂君接受广州日报记者…</a></li>
                        <li><a href="#">"海之星"追"星""海之星"追"星""海之星"追"星""海之星"追"星"</a></li>    
                        <li><a href="#">2011年度华南大区总经理述职2011年度华南大区总经理述职重在…    </a></li>
                        <li><a href="#">美国南达科他州农业领导团来访海…美国南达科他州农业领导团来访海…</a></li>
                        <li><a href="#">总裁助理张桂君接受广州日报记者…总裁助理张桂君接受广州日报记者…总裁助理张桂君接受广州日报记者…</a></li>
                        <li><a href="#">"海之星"追"星""海之星"追"星""海之星"追"星""海之星"追"星"</a></li>    
                      </ul>
                      </div>                        
                    </div>
<div class="renwu">
                    	<h2><span><img src="images/e12titlemore.jpg" height="15" width="50" /></span><b>无日期未完成的(0)</b></h2>
<div class="news_deta4">
                    <ul> 	
                        <li><a href="#">2011年度华南大区总经理述职2011年度华南大区总经理述职重在…    </a></li>
                        <li><a href="#">美国南达科他州农业领导团来访海…美国南达科他州农业领导团来访海…</a></li>
                        <li><a href="#">总裁助理张桂君接受广州日报记者…总裁助理张桂君接受广州日报记者…总裁助理张桂君接受广州日报记者…</a></li>
                        <li><a href="#">"海之星"追"星""海之星"追"星""海之星"追"星""海之星"追"星"</a></li>    
                        <li><a href="#">2011年度华南大区总经理述职2011年度华南大区总经理述职重在…    </a></li>
                        <li><a href="#">美国南达科他州农业领导团来访海…美国南达科他州农业领导团来访海…</a></li>
                        <li><a href="#">总裁助理张桂君接受广州日报记者…总裁助理张桂君接受广州日报记者…总裁助理张桂君接受广州日报记者…</a></li>
                        <li><a href="#">"海之星"追"星""海之星"追"星""海之星"追"星""海之星"追"星"</a></li>    
                      </ul>
                      </div>                        
                    </div>
<div class="renwu">
                    	<h2><span><img src="images/e12titlemore.jpg" height="15" width="50" /></span><b>本周未完成的(21)</b></h2>
<div class="news_deta4">
                    <ul> 	
                        <li><a href="#">2011年度华南大区总经理述职2011年度华南大区总经理述职重在…    </a></li>
                        <li><a href="#">美国南达科他州农业领导团来访海…美国南达科他州农业领导团来访海…</a></li>
                        <li><a href="#">总裁助理张桂君接受广州日报记者…总裁助理张桂君接受广州日报记者…总裁助理张桂君接受广州日报记者…</a></li>
                        <li><a href="#">"海之星"追"星""海之星"追"星""海之星"追"星""海之星"追"星"</a></li>    
                        <li><a href="#">2011年度华南大区总经理述职2011年度华南大区总经理述职重在…    </a></li>
                        <li><a href="#">美国南达科他州农业领导团来访海…美国南达科他州农业领导团来访海…</a></li>
                        <li><a href="#">总裁助理张桂君接受广州日报记者…总裁助理张桂君接受广州日报记者…总裁助理张桂君接受广州日报记者…</a></li>
                        <li><a href="#">"海之星"追"星""海之星"追"星""海之星"追"星""海之星"追"星"</a></li>    
                      </ul>
                      </div>                        
                    </div>
<div class="renwu">
                    	<h2><span><img src="images/e12titlemore.jpg" height="15" width="50" /></span><b>超期未完成的(1281)</b></h2>
<div class="news_deta4">
                    <ul> 	
                        <li><a href="#">2011年度华南大区总经理述职2011年度华南大区总经理述职重在…    </a></li>
                        <li><a href="#">美国南达科他州农业领导团来访海…美国南达科他州农业领导团来访海…</a></li>
                        <li><a href="#">总裁助理张桂君接受广州日报记者…总裁助理张桂君接受广州日报记者…总裁助理张桂君接受广州日报记者…</a></li>
                        <li><a href="#">"海之星"追"星""海之星"追"星""海之星"追"星""海之星"追"星"</a></li>    
                        <li><a href="#">2011年度华南大区总经理述职2011年度华南大区总经理述职重在…    </a></li>
                        <li><a href="#">美国南达科他州农业领导团来访海…美国南达科他州农业领导团来访海…</a></li>
                        <li><a href="#">总裁助理张桂君接受广州日报记者…总裁助理张桂君接受广州日报记者…总裁助理张桂君接受广州日报记者…</a></li>
                        <li><a href="#">"海之星"追"星""海之星"追"星""海之星"追"星""海之星"追"星"</a></li>    
                      </ul>
                      </div>                        
                    </div>                                                                                
            
            </div>
    </div>
        <div class="biaoge_right">
           <div class="help">
           	 <h3>帮助与支持</h3>
             <div class="imghelp"><a href="#"><img src="images/email.gif" height="54" width="89" /></a> <a href="#"><img src="images/y_f.jpg" height="60" width="87" /></a></div>
             <div class="h_list">
             	<ul>
                	<li>技术支持邮箱：<a style="color:#cc3300;" href="#">support@21edu.com</a></li>
                    <li>技术支持电话：<font style="color:#cc3300;">010-64465149-666</font></li>
                </ul>
             </div>
           </div>
           <div class="shenptx">
           	 <h3>审批提醒</h3>
<div class="e12cm01list">
<p>
我提交待审批的事项：
<a target="_blank" href="#">3</a>
</p>
<p>待我审批的事项：0</p>
</div>             
           
           </div>
<div class="shenptx">
           	 <h3>预警提醒</h3>
<div class="e12cm01list">
<p>
剩余课时少于30的学生： 9</p>
</div>             
           
           </div> 
           <div class="shenptx">
           	 <h3><span><a href="#">更多&gt;&gt;</a></span>版本历史</h3>
             <div class="data"><a href="#">2013年07月02日    3.1.0</a></div>
             <div class="list_sjm">
<p>1. 增加短信上行功能</p>
<p>2. 优化短信日志列表</p>
<p>3. 限制短信内容中出现敏感文字</p>
<p>4. 优化CTI推送客户至PPTS的规则</p>
<p>5. 增加员工个人信息完备检查</p>
<p>6. 记录Passport登录异常IP及操作记录</p>
<p>7. 导出员工档案时增加"招聘来源"字段</p>
<p>8. 所有员工列表不再显示删除的岗位</p>
<p>9. 发入职Offer时取消OurATS验证码</p>
<p>10. 学生详情-合同页，付部分款时显示实际付款金额</p>
<p>11. 学员列表-历史停课增加出库规则</p>
<p>12. 增加分客服查看分公司内全部退费审批记录</p>
<p>13. 修改文档中心"我的上传"入口</p>
<p>14. 辅导教案中"学生课时计划"改为非必填项</p>
<p>15. 课后评价内容"理解能力"改为"应用能力"</p>
<p>16. 课后评价内容"自我总结"改为非必填项</p>
<p>17. 修改制度内退费、1对1跨校区转学、九折以上合同审批流程</p>             
             </div>
             </div>                 
        	
        </div>    
    </div>

</form>
</body>
</html>