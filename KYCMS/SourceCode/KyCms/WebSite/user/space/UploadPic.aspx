<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadPic.aspx.cs" Inherits="user_space_UploadPic" %>

<%@ Import Namespace="Ky.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../Css/default.css" type="text/css" rel="stylesheet" />

<script type="text/javascript" src="../../JS/Common.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上传照片</title>
</head>
<body onload="SetCount('on')">
    <form id="form1" runat="server">
        <asp:TextBox ID="FilePicPath" runat="server" Text="" Style="display: none"></asp:TextBox>
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="27">
                    <img src="../images/skin/default/you.gif" width="17" height="16"></td>
                <td>
                    您现在的位置： <a href="../welcome.aspx">用户后台</a> &gt;&gt; <a href="AlbumManage.aspx">相册管理</a>
                    &gt;&gt; 上传照片
                </td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border wzdh" align="center">
            <tr>
                <td>
                    &nbsp;<a href="RegSpace.aspx">空间管理</a> | <a href="AlbumManage.aspx">相册管理</a> | <a
                        href="MessageManage.aspx">留言管理</a>
                </td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh border" align="center">
            <tr>
                <td style="width: 115px">
                    <span class="impButton">我的相册</span>
                </td>
                <td>
                    ·<a href="AlbumManage.aspx">相册首页</a> ·<a href="CreateAlbum.aspx">创建相册</a> ·上传相片
                </td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <!--上传相片-->
                <tr>
                    <td class="bqleft">
                        照片名称：
                    </td>
                    <td class="bqright">
                        <asp:TextBox ID="txtPhotoName" runat="server" Width="30%"></asp:TextBox>
                        *</td>
                </tr>
                <tr>
                    <td class="bqleft">
                        选择相册：
                    </td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlAlbum" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="bqleft" style="height: 97px">
                        照片预览：
                    </td>
                    <td class="bqright" style="height: 97px">
                        <table>
                            <tr id="tempTr">
                                <td align="center" style="background-image: url(../images/pic.gif); background-repeat: no-repeat;
                                    width: 124px; height: 96px; padding: 5px; display: none" id="tetd">
                                    <asp:Image ID="imgView" runat="server" ImageUrl="~/userspace/skin/images/view.gif"
                                        Width="111px" Height="85px" />
                                </td>
                            </tr>
                            <tr id='tempTrList'>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        上传照片：
                    </td>
                    <td class="bqright" align="center">
                        &nbsp; 设定照片数量<asp:TextBox ID="txtPhotoNum" runat="server" name="txtPhotoNum" Width="27px"
                            onkeypress="if(window.event.keyCode==13){document.form1.btnsetcount.focus(); }"
                            onkeyup="value=value.replace(/[^\d]/g,'')" MaxLength="2" Text="5" onblur="SetCount('off')"></asp:TextBox>
                        <input type="button" value="设定" class="btn" id="btnsetcount" name="btnsetcount" onclick="SetCount('off')"
                            onfocus="true" />
                        <asp:TextBox ID="txtSaveNum" Width="27px" runat="server" Text="5"></asp:TextBox>
                        <div id="temp" style="display: none">
                            <div id="item">
                                照 片
                                <input name="nmPh" id="txtPh" style="width: 30%" readonly="readonly" />
                                <input class="btn" type="button" value="浏览" onclick="WinOpenDialog('UploadPhoto.aspx?ControlId='+escape('txtPh'),460,400)" /></div>
                        </div>
                        <div id="ShowList">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        照片介绍：
                    </td>
                    <td class="bqright">
                        <asp:TextBox ID="txtDescription" runat="server" Width="50%" TextMode="MultiLine"
                            Height="96px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                    </td>
                    <td class="bqright">
                        <asp:Button ID="btnPublish" runat="server" Text="立即发布" CssClass="btn" OnClientClick="return CheckValidate()"
                            OnClick="btnPublish_Click" />
                        <input type="button" onclick="javascript:history.back()" value="取 消" class="btn" />
                    </td>
                </tr>
        </table>
    </form>
</body>
</html>

<script>
function CheckValidate()
{
    if($('txtPhotoName').value.trim()=="")
    {
        alert("照片名称必须填写");
        $('txtPhotoName').focus();
        return false;
    }
    if($("ddlAlbum").value=="-1")
    {
        alert("请选择相册");
        $("ddlAlbum").focus();
        return false;
    }
}
    function SetCount(flag)
    {
        var template =$("temp").innerHTML
   //     alert(templateTr);
        var num=$('txtPhotoNum').value;
        if(num.length==0)
        {
            alert("请输入预设定的值");
            $('txtPhotoNum').focus();
            return;
        } 
        var num1=num-0;
        if(num1>10)
        {
            alert("设定的值必须小于等于10");
            $('txtPhotoNum').focus();
            return;
        }
        var saveNum=$('txtSaveNum').value-0;
        if(flag=="on")
        {
            num1=5;
            saveNum=0;
        }

        if(num1>saveNum)
         {
            for(var i=saveNum+1;i<=num1; i++)
            {
                var items=ReplaceTemplate(template,i);
                $('ShowList').insertAdjacentHTML("beforeEnd",items);
                var otd=document.createElement("TD");
                otd.align="center";
                otd.id=i;
                otd.Style="background-image:url(../images/pic.gif); background-repeat:no-repeat; width:124px; height:96px; padding:5px; display:none";
                var oimg=document.createElement("IMG");
                oimg.src="../../userspace/skin/images/view.gif";
                oimg.width=111;
                oimg.height=85;
                oimg.id="imgSrc"+i;
                otd.insertAdjacentElement("afterbegin",oimg)
                document.getElementById("tempTrList").insertAdjacentElement("beforeend",otd);

            } 
            if(num1%5 == 0)
            {
                $('ShowList').insertAdjacentHTML("beforeEnd","</tr><tr>");
            }

         }
        else if(saveNum>num1)
         {
            for(var i=num1+1;i<=saveNum; i++)
            {
            
                var items=ReplaceTemplate(template,i);
                eval("item"+i).outerHTML="";
                var len=document.getElementById("tempTrList").cells.length;
                var otd=document.getElementById("tempTrList").cells[len-1];
               document.getElementById("tempTrList").removeChild(otd);
             }
         }
         $('txtSaveNum').value=num1;

        
    }
    function ReplaceTemplate(val,i)
    {
        return val.replace("item","item"+i).replace("照 片","照 片"+i).replace("nmPh","nmPh"+i).replace("'txtPh'","'txtPh"+i+"'").replace("txtPh","txtPh"+i).replace("txtPhoto","txtPhoto"+i);
    }

 function SetImg()
 {
     var obj=document.getElementById("tempTrList").getElementsByTagName("IMG");
    var n=$("txtSaveNum").value-0;
    for(var i=1;i<=n;i++)
    {
        var txt=$('nmPh'+i).value.trim();
            if(txt.length==0)
                obj[i-1].src="../../userspace/skin/images/view.gif";
            else
                obj[i-1].src="<%=Param.ApplicationRootPath %>/user/upload/"+txt;
        }

 }
</script>

