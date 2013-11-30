<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TemplateHtmlEdit.aspx.cs" Inherits="system_template_TemplateHtmlEdit" %>


<html>
<head id="Head1" runat="server">
    <title>HTML编辑模板</title>
    <link rel="stylesheet" href="../css/default.css" type="text/css" />
    <script src="../../JS/Common.js" type="text/javascript"></script>
</head>
<body onload="GetLabel($('ddlCategory').value);SetContent();">
    <form id="form1" runat="server">
    <div> 
        <table width="99%" cellpadding="2" border="0" cellspacing="1" class="border" align="center">
            <tr class="title">
                 <td align="left"> HTML编辑模板　　　文件名：<%=FileName %> 　　　路径:<%=ShowPath%></td>
           </tr>
            <tr class="tdbg">
                <td align="left">
                    <asp:DropDownList ID="ddlCategory" runat="server" onchange="GetLabel(this.value)"></asp:DropDownList> 
                    <div id="lbShow"></div>
                </td>
            </tr>
            <tr class="tdbg">
            <td height="490x" align="left">
                <iframe width="100%" height="100%" frameborder="0" src="../../js/editor/KyPageEditor.html" id="kyeditor"></iframe><asp:TextBox TextMode="MultiLine" runat="server" ID="textContent" style="display:none"></asp:TextBox>
            </td>
          </tr>
            <tr class="tdbg"><td align="left"><asp:Button ID="btnSave" runat="server" Text="保存模板" CssClass="btn" OnClientClick="GetContent()" OnClick="btnSave_Click"/> <asp:Button ID="btnReset" CssClass="btn" runat="server" Text="恢复模板" OnClick="btnReset_Click" /></td></tr>
        </table>
    </div>
    </form>
</body>
</html>
<script language="javascript">
function GetLabel(categoryId)
{
     system_template_TemplateHtmlEdit.GetLabelList(categoryId,Callback)
}
function SetContent()
{
    document.frames["kyeditor"].SetDocument($("textContent").value);
    
}
function GetContent()
{
    $("textContent").value = document.frames["kyeditor"].GetDocument();
}
function Callback(result)
{
    $('lbShow').innerHTML = "";
    var count = result.value.Rows.length;
    var str =  "<table cellpadding='1' cellspacing='0' border='0'><tr>" ;
    for(var i=0;i<count;i++)
    {
        var text = result.value.Rows[i]["Name"]; 
        str+= "<td nowrap>"+ FillText(text)+"</td>" ;
       if(i!=0&&(i+1)%7==0&&(i+1)!=count) 
       {
            str+="</tr><tr>"
       }
    }
   str+="</tr></table>"  
   $('lbShow').innerHTML=str;
}
function FillText(val)
{
    return "<div unselectable='on' onclick='SetValue(this)' style='cursor:hand;border:solid 1px #9c9c9c;width=99%;height:99%;text-align:center'>"+val+"</div>"
}

var labelStr;
function DragStart()
{
    dragclear();
    window.drag = 1;
    dragspan = document.createElement('div');
    dragspan.style.position = "absolute";
    dragspan.className="div" ;
    var mousePos = mouseCoords(window.event);
    dragspan.style.left = mousePos.x + 10;
    dragspan.style.top = mousePos.y + 8;    
    labelStr = window.event.srcElement.innerText;
    dragspan.appendChild(document.createTextNode(window.event.srcElement.innerHTML));
    document.body.appendChild(dragspan);
}
function SetValue(val)
{
      document.frames["kyeditor"].SetPasteHTML2(val.innerText);
//    document.all.textContent.focus();
//   var tarobj = document.selection.createRange();
//   tarobj.text = labelStr;
//    if(window.drag)
//    {
//        window.drag = 0;
//        window.event.returnValue = true;
//    } 
    
}
function dragend()
{
    if(window.drag)
    {
        document.body.removeChild(dragspan); 
        SetValue(); 
    }
}
function mouseCoords(ev) {
    if(ev.pageX || ev.pageY) {
      return {x:ev.pageX, y:ev.pageY};
    }
    return {
      x:ev.clientX + document.documentElement.scrollLeft - document.body.clientLeft,
      y:ev.clientY + document.documentElement.scrollTop - document.body.clientTop
    };
}
function dragclear()
{
    if(window.drag)
    {
        document.body.removeChild(dragspan);
        window.drag = 0;
        window.event.returnValue = true;
    }
    
}
function dragmove()
{
    if(window.drag)
    {
        var ev = ev || window.event;
        var mousePos = mouseCoords(ev);
        ev.returnValue = false; 
        dragspan.style.left = mousePos.x + 10;
        dragspan.style.top = mousePos.y + 8;
    }
}
function movePoint() 
{
    if(window.drag)
    {
        var rng = event.srcElement.createTextRange(); 
        rng.moveToPoint(event.x,event.y); 
        rng.select(); 
    }
}
</script>

