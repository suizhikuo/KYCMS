<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="System_Top" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <script src="../JS/Common.js" type="text/javascript"></script>
    <link href="Css/top.css" type="text/css" rel="stylesheet" />
</head>
<body style="margin: 0px" scroll="no">
    <form name="form1" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td background="images/top_bg.gif" height="80">
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td width="22%" rowspan="3">
                                <img src="images/top_logo.gif" /></td>
                          <td valign="top"><table align="right">
                            <tr>
                              <td><a href="javascript:ClearCache()"> <img src="images/huancun.gif" border="0" /></a></td>
                              <td><a href="SignOut.aspx" target="_parent"> <img src="images/out.gif" border="0" /></a></td>
                              <td><a href="http://www.kycms.com" target="_blank"> <img src="images/help_1.gif" border="0" /></a></td>
                            </tr>
                          </table></td>
                        </tr>
                        <tr>
                          <td valign="bottom"><table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                              <td width="80" height="22" align="center" nowrap background="images/t2.gif" id="ddl0"><a href="javascript:SetNav(0)"><span>我的控制台</span></a></td>
                              <td width="10"></td>
                              <td width="80" align="center" nowrap background="images/t1.gif" id="ddl1"><a href="javascript:SetNav(1)"><span>内容管理</span></a></td>
                              <td width="10"></td>
                              <td width="80" align="center" nowrap background="images/t1.gif" id="ddl2"><a href="javascript:SetNav(2)"><span>模板&标签</span></a></td>
                              <td width="10"></td>
                              <td width="80" align="center" nowrap background="images/t1.gif" id="ddl3"><a href="javascript:SetNav(3)"><span>模型&表单</span></a></td>
                              <td width="10">                          
                              <td width="80" align="center" nowrap background="images/t1.gif" id="ddl5"><a href="#" onclick="window.alert('此版本中暂不提供商城系统,如有需求我们将提供定制服务!\r\n\r\n联系方式：028-85195590 13076061951 QQ：575709164')"><span>商城管理</span></a></td>
                              <td width="10">                          
                              <td width="80" align="center" nowrap background="images/t1.gif" id="ddl7"><a href="#" onclick="window.alert('此版本中暂不提供考试系统,如有需求我们将提供定制服务!\r\n\r\n联系方式：028-85195590 13076061951 QQ：575709164')"><span>在线考试</span></a></td>
                              <td width="10"></td>
                              <td width="80" align="center" nowrap background="images/t1.gif" id="ddl4"><a href="javascript:SetNav(4)"><span>用户管理</span></a></td>
                              <td width="10"></td>
                              <td width="80" align="center" nowrap background="images/t1.gif" id="ddl6"><a href="javascript:SetNav(6)"><span>扩展功能</span></a></td>
                              <td width="10"></td>
                            </tr>
                          </table></td>
                        </tr>
                  </table>
              </td>
            </tr>
      </table>
	  	<table width="100%" cellpadding="0" cellspacing="0">
			<tr>
			  <td height="5" bgcolor="2666AA"></td>
		  </tr>
		</table>
    </form>
</body>
</html>
<script type="text/javascript"> 
var tid=0;
function SetNav(val)
{
    if(val!=tid)
    {
		$("ddl"+val).background="images/t2.gif";
        $("ddl"+tid).background ="images/t1.gif";
		tid=val;
    }
	
    var objLeft =  window.parent.frames['LeftIframe'];
    var objContent = window.parent.frames['ContentIframe']; 
    
    switch(val)
    {
        default:
        case 0:
            objLeft.location.href="Left.aspx?Id=1";
            objContent.location.href="SystemInfo.aspx";
            break;
        case 1:
            objLeft.location.href="Left.aspx?Id=3";
            objContent.location.href="info/ChannelList.aspx"; 
            break;
        case 2:
            objLeft.location.href="Left.aspx?Id=5";
            objContent.location.href="template/CreateFolder.aspx";
            break; 
        case 3:
            objLeft.location.href="Left.aspx?Id=2";
            objContent.location.href="infomodel/ModelList.aspx";
            break;
        case 4:
            objLeft.location.href="Left.aspx?Id=6";
            objContent.location.href="other/NoticeList.aspx" 
            break;
        case 5:
           objLeft.location.href="Left.aspx?Id=7";
           objContent.location.href="shop/OrderList.aspx"
            break;
       case 6: 
            objLeft.location.href="Left.aspx?Id=8";
            objContent.location.href="user/LogList.aspx"; 
            break;
       case 7: 
            objLeft.location.href="Left.aspx?Id=8";
            objContent.location.href="exam/TestManager.aspx"; 
            break;
    }
}
function ClearCache()
{
    System_Top.ClearCache();
    alert('缓存更新成功'); 
}
</script>

