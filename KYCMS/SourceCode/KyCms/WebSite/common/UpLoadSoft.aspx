<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpLoadSoft.aspx.cs" Inherits="common_UpLoadSoft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上传软件</title>
    <base target="_self" />
    <script type="text/javascript" src="../js/Common.js"></script>
    <link href="../user/css/default.css" type="text/css" rel="stylesheet" />
    <style> 
		.progressBar { WIDTH: 350px; HEIGHT: 21px } 
		.progressInfo { BORDER-RIGHT: #3366ff 1px solid; BORDER-TOP: #3366ff 1px solid; FONT-SIZE: 12px; OVERFLOW: hidden; BORDER-LEFT: #3366ff 1px solid; WIDTH: 350px; PADDING-TOP: 1px; BORDER-BOTTOM: #3366ff 1px solid; POSITION: absolute; HEIGHT: 18px; TEXT-ALIGN: center } 
		.progress { OVERFLOW: hidden; WIDTH: 0%; HEIGHT: 19px; BACKGROUND-COLOR: #ff9900 } 
		</style>

    <script src="xmlLib.js"></script>

    <script>
		var r = "传输: {0}K 还未完成";
		var s = "您的文件已经上传完成";
		var t = "上传失败";
		function progressBar()
		{

			this.totalSize = 100;
			this.sizeCompleted = 0;
			this.percentDone = "0%";
			this.setSize = function(totalSize, size)
			{
				var oProgressInfo = document.getElementById("progressInfo");
				var oProgress = document.getElementById("progress");
				if (oProgress == null || oProgressInfo == null)
					return;

				if (totalSize <= 0)
					return;

				this.totalSize = totalSize;
				this.sizeCompleted = size;
				if (size < 0)
					this.sizeCompleted = 0;
				else if (size > this.totalSize)
					this.sizeCompleted = this.totalSize;

				var sizeLeft = 0;
				var progressInfoText = "";
				sizeLeft = this.totalSize - this.sizeCompleted;

				this.percentDone = Math.round(size / this.totalSize * 100) + "%";
				oProgress.style.width = this.percentDone;
				
				if (sizeLeft > 0)
					progressInfoText = r.replace("{0}", sizeLeft);
				else
					progressInfoText = s;

				oProgressInfo.innerHTML = progressInfoText;
			}
			this.UploadError = function()
			{
				var oProgressInfo = document.getElementById("progressInfo");
				var oProgress = document.getElementById("progress");
				if (oProgressInfo != null)
					oProgressInfo.innerHTML = t;
				if (oProgress != null)
					oProgress.style.width = "0";
			}
			this.UploadComplete = function()
			{
				var oProgressInfo = document.getElementById("progressInfo");
				var oProgress = document.getElementById("progress");
				if (oProgressInfo != null)
					oProgressInfo.innerHTML = s;
				if (oProgress != null)
					oProgress.style.width = "100%";
			}
		}
		var iTimerID = null;
		var xmlHttp = XmlHttpPool.pick();
		var url = "Progress.aspx?UploadID=<%=Request.QueryString["UploadID"]%>"
		var pb = new progressBar();	
		function LoadProgressInfo()
		{
			try
			{
				xmlHttp.open("GET", url + "&t=" + Math.random(), true);
				xmlHttp.send(null);
				xmlHttp.onreadystatechange = function()
				{
					LoadData(xmlHttp);
				}
			}
			catch(e)
			{
				alert(e)
			}
		}

		function LoadData(xmlhttp)
		{
			if (xmlhttp.readyState == 4)
			{
				iTimerID = window.setTimeout("LoadProgressInfo()", 200); 
				try{
					eval(xmlhttp.responseText);
				}
				catch(e)
				{
					alert(e)
				}
			}
		}
		
		function ClearTimer()
		{
			if (iTimerID != null)
			{
				window.clearTimeout(iTimerID);
				iTimerID = null;
			}
		}
		
		function UploadCancel()
		{
			window.close();
		}
		
		function isok()
		{
			JinDu.style.display="";
		}
    </script>

</head>
<body onload="setxx()">
    <form id="form1" runat="server" onsubmit="isok()">
        <table width="99%" cellpadding="2" cellspacing="0" border="0" align="center" height="99%">
            <tr>
                <td><asp:TextBox ID="File_PicPath" runat="server" style="display:none"></asp:TextBox>
                    <table width="100%" cellpadding="2" cellspacing="0" border="0" align="center">
                        <tr>
                            <td>
                                <input id="uploadFile" type="file" runat="server" class="btn" size="51">
                            </td>
                        </tr>
                        <tbody id="JinDu" style="display: none">
                            <tr>
                                <td height="25">
                                    <div id="progressBar" class="progressBar">
                                        <div class="progressInfo" id="progressInfo" onselectstart="return false;">
                                            &nbsp;
                                        </div>
                                        <div class="progress" id="progress">
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                        <tr>
                            <td height="30" align="center">
                                <asp:Button ID="btnUpload" runat="server" Text="  上传  " OnClick="btnUpload_Click"
                                    CssClass="btn"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                <input id="Button1" type="button" value="  取消  " onclick="UploadCancel()" class="btn"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
<script>
function setxx()
{
  $('File_PicPath').value = dialogArguments.document.all.FilePicPath.value
}
</script>
