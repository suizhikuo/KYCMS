<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MoveExpireArticle.aspx.cs" Inherits="system_info_MoveExpireArticle" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文章归档操作</title>
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />

    <script language="javascript">
    function isok(ChId,ColId)
    {
        Layer1.style.display="";
        Div1.style.display="";
        Div2.style.display="none";
        Div_3.style.display="";
        system_info_MoveExpireArticle.DoWithExpireArticle(ChId,ColId,Call_Back);
    }
    
    function Call_Back(response)
    {
        Div2.style.display="";
        Div2_1.innerHTML=response.value;
        Layer1.style.display="none";
        Div1.style.display="none";
        Div_3.style.display="";
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="Layer1" style="display: none; filter: Alpha(Opacity=50); position: absolute;
            width: 99%; height: 100%; z-index: 1; background-color: #CCCCCC; layer-background-color: #CCCCCC;
            border: 1px none #000000; text-align: center">
        </div>
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="27" height="24">
                    &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" /></td>
                <td>
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 文章归档操作
                </td>
                <td width="116" align="center">
                    &nbsp;
                </td>
            </tr>
        </table>
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align=center>
            <tr>
                <td>
                    <asp:DataList ID="dlistChannel" runat="server" RepeatColumns="10">
                        <ItemTemplate>
                            <table class="wzdh">
                                <tr>
                                    <td width="80px" align="center">
                                        <a href="MoveExpireArticle.aspx?ChId=<%# Eval("ChId") %>">
                                            <%# Eval("ChName") %>
                                        </a><asp:Literal ID="litChId" Visible=false runat="server" Text='<%#Eval("ChId") %>'></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
        </table>
        <div id="Div_3" style="display: none">
            <table width="99%" align="center" cellpadding="2" cellspacing="0" bgcolor="#f5f5f5">
                <tbody id="Div2" style="display: none; z-index: 2">
                    <tr>
                        <td height="30" align="center">
                            <div id="Div2_1">
                            </div>
                        </td>
                    </tr>
                </tbody>
                <tbody id="Div1" style="display: none; z-index: 2">
                    <tr>
                        <td height="30" align="center">
                            <img src="../../images/loading.gif" align="absmiddle" />&nbsp;&nbsp;正在进行归档操作,请稍后...
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table width="99%" align="center" cellpadding="1" cellspacing="0">
            <tr>
                <td>
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" class="qxborder">
                        <asp:Repeater ID="repColumn" runat="server">
                            <ItemTemplate>
                                <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                    <td align="left" width="65%">
                                        <%# GetImgNum(ChId, int.Parse(Eval("ColId", "{0}")), int.Parse(Eval("Depth", "{0}")))%>
                                        <%# Eval("ColName") %>
                                    </td>
                                    <td>
                                        <input id="Button1" type="button" value=" 归档该栏目文章 " class="btn" onclick="isok('<%# ChId %>','<%# Eval("ColId") %>')" /></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
        </table>
        <table width="99%" align="center" cellpadding="5" cellspacing="0">
            <tr>
                <td align="center">
                    <input id="Button1" type="button" value=" 归档【<%=ChName %>】频道下所有文章 " class="btn" onclick="isok('<%= ChId%>','0')" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
