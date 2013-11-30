<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="System_Index" %>
<html>
<head runat="server">
    <title></title>
</head>
   <frameset rows="85,*" border="0" frameSpacing="0" frameBorder="0">
		<frame src="top.aspx" frameborder="0" noresize>
		<frameset cols="190,9,*" border="0" frameSpacing="0" id="FramesetLeft" >
			<frame src="Left.aspx?Id=1" frameborder="0" name="LeftIframe" id="LeftIframe">
			<frame src="Switch.aspx" frameborder="0" noresize>
			<frame src="SystemInfo.aspx" name="ContentIframe" id="ContentIframe"  scrolling="yes">
		</frameset>
	</frameset>
</html>
