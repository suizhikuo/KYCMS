<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Switch.aspx.cs" Inherits="system_Switch" %>
<html>

<body bgcolor="#6197B9" style="margin:0px" scroll="no">

<table cellpadding=0 cellspacing=0 border=0 height=100%>
<tr>
    <td>
            <table cellpadding=0 cellspacing=0 border=0>
            <tr>
                <td><img src="images/skin/default/right.gif" style="cursor:hand" onclick="javascript:left()" id="imgSwitch"></td> 
            </tr> 
            <tr height="80px">
           <td></td> </tr> 
            </table>
    </td>
</tr>
</table>


</body>
</html>
<script>
function left()
{
    var s = window.parent.frames["FramesetLeft"].cols;
    if(s!="0,9,*")
    { 
        document.getElementById("imgSwitch").src="images/skin/default/left.gif";
        window.parent.frames["FramesetLeft"].cols="0,9,*";
   } 
   else
   {
         document.getElementById("imgSwitch").src="images/skin/default/right.gif";
        window.parent.frames["FramesetLeft"].cols="190,9,*";
   }
}
</script>