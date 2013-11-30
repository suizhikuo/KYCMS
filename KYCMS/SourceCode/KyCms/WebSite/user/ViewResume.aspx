<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewResume.aspx.cs" Inherits="user_ViewResume" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看简历</title>
    <link href="Css/default.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" cellpadding="2" cellspacing="1" style="width:590px;border:solid 1px #000;margin-top:10px;">
                <tr style="text-align:right;">
                    <td  colspan="5"><a href="javascript:window.print();">打印简历</a>  <a href="javascript:window.close();">关闭窗口</a></td>
                </tr>
                <tr>
                    <td colspan="5" style="text-align:center;padding-top:10px;">
                        <h2><asp:Literal ID="litUserName" runat="server"></asp:Literal>的简历</h2></td>
                </tr>
                
                <tr>
                    <td colspan="5">
                        <h4 style="color:#3C6880">基本信息</h4></td>
                </tr>
                <tr>
                    <td><strong>姓名：</strong>
                    </td>
                    <td>
                        <asp:Label ID="lbTrueName" runat="server"></asp:Label></td>
                    <td><strong>性别：</strong>
                    </td>
                    <td>
                        <asp:Label ID="lbSex" runat="server"></asp:Label></td>
                    <td rowspan="6">
                        <asp:Image ID="imgPic" runat="server" onerror="this.src='upload/UserFace/null.jpg'" /></td>
                </tr>
                <tr>
                    <td><strong>出生年月：</strong>
                    </td>
                    <td>
                        <asp:Label ID="lbBirth" runat="server"></asp:Label></td>
                    <td>
                        <strong>身高：</strong>
                    </td>
                    <td>
                        <asp:Label ID="lbHeight" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 19px">
                        <strong>最高学历：</strong></td>
                    <td style="height: 19px">
                        <asp:Label ID="lbDegree" runat="server"></asp:Label></td>
                    <td style="height: 19px">
                        &nbsp;<strong>所在省份：</strong></td>
                    <td style="height: 19px">
                        <asp:Label ID="lbGeographical" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <strong>所在城市：</strong>
                    </td>
                    <td>
                        <asp:Label ID="lbCity" runat="server"></asp:Label></td>
                    <td>
                        <strong>现住地址：</strong></td>
                    <td>
                        <asp:Label ID="lbAress" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 19px">
                        <strong>联系电话：</strong></td>
                    <td style="height: 19px">
                        <asp:Label ID="lbPhone" runat="server"></asp:Label></td>
                    <td style="height: 19px">
                        &nbsp;<strong>电子邮件：</strong></td>
                    <td style="height: 19px">
                        <asp:Label ID="lbEmail" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <strong>QQ：</strong></td>
                    <td>
                        <asp:Label ID="lbQq" runat="server"></asp:Label></td>
                    <td>
                        <strong></strong></td>
                    <td>
                        </td>
                </tr>
                <tr>
                    <td valign="top">
                        <strong>工作经验：</strong></td>
                    <td colspan="4" style="height: 150px" valign="top">
                        <asp:Label ID="lbexperience" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="5">
                        <h4 style="color:#3C6880">扩展信息</h4></td>
                </tr>
                <tr>
                    <td>
                        <strong>期望工作类型：</strong>
                    </td>
                    <td>
                        <asp:Label ID="lbWorktype" runat="server"></asp:Label></td>
                    <td>
                        <strong>所在行业：</strong>
                    </td>
                    <td>
                        <asp:Label ID="lbIndustry" runat="server"></asp:Label></td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>期望岗位：</strong>
                    </td>
                    <td>
                        <asp:Label ID="lbPosts" runat="server"></asp:Label></td>
                    <td>
                        <strong>期望工作地点：</strong>
                    </td>
                    <td>
                        <asp:Label ID="lbPostsArea" runat="server"></asp:Label></td>
                    <td>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <strong>期望企业类型：</strong>
                        
                    </td>
                    <td>
                        <asp:Label ID="lbPostsTypes" runat="server"></asp:Label></td>
                    <td>
                        <strong>期望最少月薪：</strong>
                        
                    </td>
                    <td>
                        <asp:Label ID="lbPostsMoney" runat="server"></asp:Label></td>
                     <td>
                     </td>
                </tr>
                <tr>
                    <td>
                        <strong>最快到岗时间：</strong>
                        
                    </td>
                    <td>
                        <asp:Label ID="lbTimes" runat="server"></asp:Label></td>
                    <td>
                        <strong>发展方向：</strong>
                        
                    </td>
                    <td>
                        <asp:Label ID="lbDirection" runat="server"></asp:Label></td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <strong>其他要求：</strong>
                        
                    </td>
                    <td colspan="4" style="height: 100px" valign="top">
                        <asp:Label ID="lbMore" runat="server"></asp:Label></td>
                </tr>
            </table>
            </div>
    </form>
</body>
</html>
