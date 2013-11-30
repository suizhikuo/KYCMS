<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="List" %>
<%@ Import Namespace="Ky.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head runat="server">
    <title>搜索结果</title>
    <style>
    td{font-size:12px}
    BODY
    {
	font-size: 12px;
	background: #fff;
	margin: 0px 0px 0px 0px;
	color: #000;
	font-family: tahoma, 宋体, fantasy;
    }
form{margin:0px} 
a{color:black;text-decoration:none}
a:hover{color:red;text-decoration:underline;line-heigth:120%}
.button{height:20px}
    </style>
<script language='javascript' src='js/Page.js'></script> 
</head>
<body style="text-decoration:none">
    <asp:Literal ID="litHeader" runat="server"></asp:Literal>
   <asp:Repeater ID="repInfo" runat="server" EnableViewState="false" OnItemDataBound="repInfo_ItemDataBound">
   <ItemTemplate>
        <asp:Literal ID="litItem" runat="server"></asp:Literal>
   </ItemTemplate>
   </asp:Repeater>
    <asp:Literal ID="litFooter" runat="server"></asp:Literal> 
</body>
</html>