<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="System_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>菜单</title>
    <link href="Css/default.css" type="text/css" rel="stylesheet" />
    <style type="text/css">


body {
	background-color: #B2E2FD;
	}
	ul
	{
	    list-style-type:none;margin:0px;padding:0px;text-align:center;width:100%
	}


        </style>
       <SCRIPT language=javascript>  
function ShowMenuModel() 
{ 
    document.getElementById("dvModel").innerHTML = "";
	var event= arguments[0] || window.event;   
	
	var obj = event.target||event.srcElement;
	var objTitle = obj.title;
	
	if(objTitle==null||objTitle=="")
	{
	    document.getElementById("dvModel").style.display = "none";   
	    return false;
	}    
	paramArray = objTitle.split("$") ;
	
	
	var rightedge = document.body.clientWidth-event.clientX;   
	var bottomedge = document.body.clientHeight-event.clientY;   

	if (rightedge < document.getElementById("dvModel").offsetWidth)   
	
    		document.getElementById("dvModel").style.left = document.body.scrollLeft + event.clientX - document.getElementById("dvModel").offsetWidth+"px";   
	else   
    		document.getElementById("dvModel").style.left = document.body.scrollLeft + event.clientX+"px";
    		   
	if (bottomedge <document.getElementById("dvModel").offsetHeight)   
   		 document.getElementById("dvModel").style.top = document.body.scrollTop + event.clientY - document.getElementById("dvModel").offsetHeight+"px";   
	else    
   		 document.getElementById("dvModel").style.top = document.body.scrollTop + event.clientY+"px";  
   	if(paramArray[0]=="分类右键操作")
	{
     	GetChTypeOper(paramArray[1]);
    }	
    else if(paramArray[0]=="频道右键操作") 
    {
        GetChannelOper(paramArray[1],paramArray[2]) ;
    }  
    else if(paramArray[0]=="栏目右键操作") 
   {
        GetColumnOper(paramArray[1],paramArray[2])
   } 
	document.getElementById("dvModel").style.display = "";   
	return false;   
}   

function HiddenMenuModel(evt) 
{   
	document.getElementById("dvModel").style.display = "none";   
}   

function GetChTypeOper(val)
{
    document.getElementById("dvModel").innerHTML+="<ul><li onmouseover=this.style.backgroundColor='#c2cfe5' onmouseout=this.style.removeAttribute('backgroundColor')><a href=\"info/SetChannel.aspx?chtype="+val+"\" target=\"ContentIframe\">添加频道</a></li></ul>";
}
function AddInfo(val,val2)
{
    System_Left.GetInfoUrl(val,val2,Callback_GetInfoUrl);
}
function Callback_GetInfoUrl(result)
{
    window.parent.ContentIframe.location.href= result.value;
}
function GetChannelOper(val,val2)
{
         document.getElementById("dvModel").innerHTML+="<ul><li onmouseover=this.style.backgroundColor='#c2cfe5' onmouseout=this.style.removeAttribute('backgroundColor')><a href=\"javascript:AddInfo('"+val+"','0')\">添加内容</a></li><li onmouseover=this.style.backgroundColor='#c2cfe5' onmouseout=this.style.removeAttribute('backgroundColor')><a href=\"info/SetChannel.aspx?ChId="+val+"&ChType="+val2+"\" target=\"ContentIframe\">修改频道</a></li><li onmouseover=this.style.backgroundColor='#c2cfe5' onmouseout=this.style.removeAttribute('backgroundColor')><a href=\"info/SetColumn.aspx?ChId="+val+"\" target=\"ContentIframe\">添加栏目</a></li><li onmouseover=this.style.backgroundColor='#c2cfe5' onmouseout=this.style.removeAttribute('backgroundColor')><a href=\"javascript:CreateChannel('"+val+"')\">生成频道</a></li></ul>";
}
function GetColumnOper(val,val2)
{
        document.getElementById("dvModel").innerHTML+="<ul><li onmouseover=this.style.backgroundColor='#c2cfe5' onmouseout=this.style.removeAttribute('backgroundColor')><a href=\"javascript:AddInfo('"+val2+"','"+val+"')\">添加内容</a></li><li onmouseover=this.style.backgroundColor='#c2cfe5' onmouseout=this.style.removeAttribute('backgroundColor')><a href=\"info/SetColumn.aspx?ColId="+val+"&ChId="+val2+"\" target=\"ContentIframe\">修改栏目</a></li><li onmouseover=this.style.backgroundColor='#c2cfe5' onmouseout=this.style.removeAttribute('backgroundColor')><a href=\"javascript:CreateColumn('"+val+"')\">生成栏目</a></li><li onmouseover=this.style.backgroundColor='#c2cfe5' onmouseout=this.style.removeAttribute('backgroundColor')><a href=\"javascript:CreateInfoByColId('"+val+"')\">生成内容</a></li></ul>";
}
function CreateChannel(val)
{
    System_Left.CreateChannel(val,Callback_CreateChannel)
}
function Callback_CreateChannel(result)
{
    var paramArray = result.value.split("$") 
    if(paramArray[0]!="succ")
    {
        alert(paramArray[1]); 
    }   
    else
    {
        window.parent.ContentIframe.location.href="create/Createing.aspx?type=channel" ;
    }   
}

function CreateColumn(val)
{
    System_Left.CreateColumn(val,Callback_CreateColumn)
}
function Callback_CreateColumn(result)
{
    var paramArray = result.value.split("$") 
    if(paramArray[0]!="succ")
    {
        alert(paramArray[1]); 
    }   
    else
    {
        window.parent.ContentIframe.location.href="create/Createing.aspx?type=column" ;
    }   
}
function CreateInfoByColId(val)
{
    System_Left.CreateInfoByColId(val,Callback_CreateInfoByColId)
}
function Callback_CreateInfoByColId(result)
{
    var paramArray = result.value.split("$") 
    if(paramArray[0]!="succ")
    {
        alert(paramArray[1]); 
    }   
    else
    {
        window.parent.ContentIframe.location.href="create/Createing.aspx?type=infocolumn&modelId="+paramArray[1] ;
    }   
}

</SCRIPT>   
</head>
<body style="margin: 0px" topmargin="1" scroll="auto">
    <form id="Form1" runat="server">
   
        <% string LeftId = Request["ID"];%>
        <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0" class="border1">
            <!-- 控制中心 -->
            <tr>
                <td height="5" bgcolor="white">
                </td>
            </tr>
            <tr>
                <td class="leftdh1">
                    <strong>控制中心</strong></td>
            </tr>
            <tr>
                <td class="leftdh">
					 <a href="create/CreateNews.aspx?modelId=1" target="ContentIframe">生成发布</a>
                </td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="website/SetSiteInfo.aspx" target="ContentIframe">全站参数设置</a>
                </td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="website/SetController.aspx" target="ContentIframe">我的控制台设置</a>
                </td>
            </tr>
            <%
                if (LeftId == "1")
                {
            %>
            <tr>
                <td class="leftdh1">
                    <strong>我的控制台</strong></td>
            </tr>
            <asp:Literal ID="ltController" runat="server"></asp:Literal><%} %><!-- 内容管理 --><%
                                                                                               if (LeftId == "3")
                                                                                               {
            %><tr>
                <td class="leftdh1">
                    <strong><a href="info/channellist.aspx" target="ContentIframe">内容管理</a></strong></td>
            </tr>
            <tr>
                <td style="background-color:White">
                    <asp:TreeView ID="tvNav" runat="server" ExpandDepth="0" ShowLines="True" EnableViewState="false" NodeIndent="10">
                    </asp:TreeView>
                </td>
            </tr>
           <script language="javascript">document.getElementById("tvNav").oncontextmenu = ShowMenuModel;document.body.onclick = HiddenMenuModel</script> 
            <tr>
                <td class="leftdh1">
                    <strong>其他管理</strong>
                </td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="info/SpecialList.aspx" target="ContentIframe">专题管理</a>
                </td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="info/SinglePageList.aspx" target="ContentIframe">单页管理</a>
                </td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="info/MoveExpireArticle.aspx" target="ContentIframe">归档管理</a>
                </td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="info/RecycleChannel.aspx" target="ContentIframe">回收站管理</a>
                </td>
            </tr>
            <%} %>
            <!-- 模板管理 -->
            <%
                if (LeftId == "5")
                {
            %>
            <tr>
                <td class="leftdh1">
                    <strong>模板&标签</strong></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="template/CreateFolder.aspx" target="ContentIframe">模板管理</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="label/StyleManager.aspx" target="ContentIframe">样式管理</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="label/LabelManager.aspx" target="ContentIframe">标签管理</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="label/SuperLabelList.aspx" target="ContentIframe">超级标签</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="info/ColumnToTemplate.aspx" target="ContentIframe">模板批量设置</a></td>
            </tr>
            <%} %>
            <!-- 用户管理 -->
            <%
                if (LeftId == "6")
                {
            %>
            <tr>
                <td class="leftdh1">
                    <strong>用户管理</strong></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="UserGroupModel/UserGroupModelList.aspx" target="ContentIframe">用户注册模型</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="other/NoticeList.aspx" target="ContentIframe">用户公告管理</a></td>
            </tr>
            <tr style="background-color:#FFF">
                <td><table class="lefthr" align="center"><tr><td></td></tr></table></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="user/GroupList.aspx" target="ContentIframe">用户组管理</a></td>
            </tr>
            <asp:Repeater ID="RepUserGroupModel" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="leftdh">
                            <a href='user/UserList.aspx?TypeId=<%# Eval("Id") %>' target="ContentIframe"><%# Eval("Name") %>管理</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            
            <tr style="background-color:#FFF">
                <td><table class="lefthr" align="center"><tr><td></td></tr></table></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="user/AdminGroupList.aspx" target="ContentIframe">管理员组管理</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="user/AdminList.aspx" target="ContentIframe">管理员管理</a></td>
            </tr>
            <tr style="background-color:#FFF">
                <td><table class="lefthr" align="center"><tr><td></td></tr></table></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="WebMessage/WebMessageList.aspx" target="ContentIframe">短消息管理</a></td>
            </tr>            
            <tr>
                <td class="leftdh">
                    <a href="user/Card.aspx" target="ContentIframe">充值卡管理</a></td>
            </tr>
            <%} %>
            <!-- 扩展功能 -->
            <%
                if (LeftId == "8")
                {
            %>
            <tr>
                <td class="leftdh1">
                    <strong>扩展功能</strong></td>
            </tr>
             <tr>
                <td class="leftdh">
                    <a href="collection/CollectionManager.aspx" target="ContentIframe">采集管理</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="User/LogList.aspx" target="ContentIframe">系统日志管理</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="other/TagCategoryList.aspx" target="ContentIframe">关键字类别管理</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="other/TagList.aspx" target="ContentIframe">关键字管理</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="website/DictionaryList.aspx" target="ContentIframe">数据字典</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="info/DownLoadServerList.aspx" target="ContentIframe">镜像服务器管理</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="Vote/vote.aspx" target="ContentIframe">投票系统</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="review/ReviewManage.aspx" target="ContentIframe">用户评论管理</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="WebSite/SiteCount.aspx?type=year&filter=cur" target="ContentIframe">统计系统</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="user/ReportList.aspx" target="ContentIframe">举报管理</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="other/LinkList.aspx" target="ContentIframe">友情链接管理</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="other/PushInfoList.aspx" target="ContentIframe">广告管理</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="other/FeedbackList.aspx" target="ContentIframe">问答管理</a></td>
            </tr>
            <%} %>
            <!----模型管理--->
            <%
                if (LeftId == "2")
                {
            %>
            <tr>
                <td class="leftdh1">
                    <strong>模型管理</strong></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="infomodel/ModelList.aspx" target="ContentIframe">内容模型管理</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="infomodel/SetInfoModel.aspx" target="ContentIframe">添加内容模型</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="infomodel/SearchStyleList.aspx" target="ContentIframe">模型搜索列表样式</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="infomodel/CustomFormList.aspx" target="ContentIframe">自定义表单管理</a></td>
            </tr>
            <tr>
                <td class="leftdh">
                    <a href="infomodel/CustomForm.aspx" target="ContentIframe">添加自定义表单</a></td>
            </tr>
            <%} %>
        </table>
        <!-- 版权信息-->
        <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0" class="border1">
            <tr>
                <td height="60" align="left" valign="middle">
                    &nbsp;<asp:Literal ID="litDv" runat="server"></asp:Literal><br />
                    &nbsp;技术支持：<a href="http://www.kycms.com" target="_blank">酷源科技</a><br />
                    &nbsp;论坛服务：<a href="http://bbs.kycms.com" target="_blank">酷源科技</a></td>
            </tr>
        </table>
    </form>
   <div id="dvModel" style="display:none;position:absolute;left:0px;top:0px;line-height:200%;border:solid 1px #a3c7e2;background-color:#eef6fb;width:70px" ></div>  
</body>

</html>
