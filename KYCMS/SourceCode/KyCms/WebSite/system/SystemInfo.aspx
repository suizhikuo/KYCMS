<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemInfo.aspx.cs" Inherits="system_SystemInfo" %>
<html>
<head>
    <title>KYCMS</title>
    <link href="css/default.css" type="text/css" rel="stylesheet">
</head>
<body leftmargin="0" topmargin="0" scroll="yes">
       
    <table class="border" cellspacing="1" cellpadding="2" width="98%" align="center"
        border="0">
        <tbody>
            <tr class="title" height="25px">
                <td>
                    欢迎使用酷源网站管理系统免费版
               </td>
            </tr>

            <tr class="sysinfo">
                <td class="sysinfo" height="1">

                    <asp:Literal ID="lbNotice" runat="server"></asp:Literal>

                </td>
            </tr>
           <tr class="sysinfo">
                <td class="sysinfo" height="1">

                    当前版本：<script src="../js/ver.js"></script>&nbsp;&nbsp;&nbsp;最新版本：<script src="http://info.kycms.com/ver.js"></script>

                </td>
            </tr> 
        </tbody>
    </table>
    <table class="border" cellspacing="0" cellpadding="2" width="98%" align="center" border="0">
            <tr class="title">
                <td height="25" align=left colspan="2">&nbsp;<b>信息记录</b></td>
            </tr>
            <tr class="sysinfo"  height="0">
                <td  colspan="2">
                    <strong><asp:Literal runat="server" ID="litUserName"></asp:Literal></strong>&nbsp;您好！ 身份：<asp:Literal runat="server" ID="litGroupName"></asp:Literal> 今天是：<asp:Literal runat="server" ID="litDate"></asp:Literal></td>
            </tr>
           <tr>
                <td valign="top"  colspan="2">
                <asp:Literal ID="LitCount" runat="server"></asp:Literal>
                </td> 
             </tr>  
    </table>
  
    <table id="ShortCutTable" class="border" cellspacing="1" cellpadding="2" align="center"
        border="0">
        <tbody>
            <tr class="title" height="25">
                <td align="left" colspan="9">&nbsp;<b>系统帮助信息</b></td>
            </tr>
               <tr> <td colspan="9"> 如果您是第一次使用本系统，请按以下步骤配置：</td></tr>
              
               <tr><td>
        <a href="website/SetSiteInfo.aspx"><img src="../system/images/sys_idx_01.gif" alt="配置全站参数" border="none" /></a></td>
        <td>
            <img src="../system/images/sys_idx_arrow.gif" /></td>
        <td>
           <a href="info/ChannelList.aspx"> <img src="../system/images/sys_idx_02.gif" alt="频道/栏目管理" border="none" /></a></td>
        <td><img src="../system/images/sys_idx_arrow.gif" /></td>
        <td>
            <a href="label/SetStyle.aspx"><img src="../system/images/sys_idx_03.gif" alt="添加样式" border="none" /></a></td>
        <td><img src="../system/images/sys_idx_arrow.gif" /></td>
        <td>
            <a href="label/SetLabelContent.aspx"><img src="../system/images/sys_idx_04.gif" alt="创建标签" border="none" /></a></td>
        <td><img src="../system/images/sys_idx_arrow.gif" /></td>
        <td>
           <a href="create/CreateNews.aspx?modelId=1"><img src="../system/images/sys_idx_05.gif" alt="生成与发布" border="none" /></a></td>
        </tr>
               <tr><td  colspan="9">其他帮助资源：<a href="http://edu.kycms.com" target="_blank"><font color="red">帮助文档</font></a> |  <a href="http://bbs.kycms.com" target=_blank><font color=red>官方论坛</font></a></td></tr>
            
            
        </tbody>
    </table>
    
    <table class="border"  cellspacing="1" cellpadding="2" width="98%" align="center"
        border="0">
        <tbody>
            <tr class="title" height="25px">
                <td width="100%" height="25" align=left>
                    <b>&nbsp;开发团队</b></td>
            </tr>
            <tr class="sysinfo">
                <td height="25">
                    邓维杰 陈帮军 肖育杨 王小东 邱兵</td>
            </tr>
        </tbody>
    </table>
    <table class="border" cellspacing="1" cellpadding="2" width="98%" align="center"
        border="0">
        <tbody>
            <tr class="title" height="25px">
                <td colspan="4" align=left>
                    <b>&nbsp;联系我们</b></td>
            </tr>
            <tr class="sysinfo">
                <td height="20">
                    <div align="center">
                        产品开发</div>
                </td>
                <td height="20">
                    酷源科技（成都）有限公司</td>
                <td>
                    <div align="center">
                        定制开发</div>
                </td>
                <td>
                    QQ：575709164 309755239
                </td>
            </tr>
            <tr class="sysinfo">
                <td width="13%" height="20">
                    <div align="center">
                        总机电话</div>
                </td>
                <td width="30%" height="20">
                   028-85195590</td>
                <td width="12%">
                    <div align="center">
                        产品咨询</div>
                </td>
                <td width="45%">
                    TEL：028-85195590  13076061951  QQ：575709164</td>
            </tr>
            <tr class="sysinfo">
                <td width="13%" height="20">
                    <div align="center">
                        传 真</div>
                </td>
                <td width="30%" height="20">
                    028-85195590</td>
                <td width="12%">
                    <div align="center">
                        客服电话</div>
                </td>
                <td width="45%">
                    028-85195590</td>
            </tr>
            <tr class="sysinfo">
                <td width="13%" height="20">
                    <div align="center">
                        官方网站</div>
                </td>
                <td width="30%" height="20">
                    <a href="http://www.kycms.com/">kycms.com</a></td>
                <td width="12%">
                    <div align="center">
                        帮助中心</div>
                </td>
                <td width="45%">
                    <a href="http://help.kycms.com/" target="_blank">Help.kycms.com</a> 论坛：<a href="http://bbs.kycms.com/">bbs.kycms.com</a></td>
            </tr>
            <tr class="sysinfo">
                <td colspan="4" height="20">
                    <div align="center">
                        &copy;  2007-2010 <a href="http://bbs.kycms.com">酷源科技</a>  Inc. All Rights Reserved</div>
                </td>
            </tr>
        </tbody>
    </table>

</body>
</html>
