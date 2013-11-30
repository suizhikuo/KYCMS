<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateNews.aspx.cs" Inherits="System_create_CreateNews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>发布管理</title>
    <link rel="stylesheet" href="../css/default.css" type="text/css" />
    <script type="text/javascript" src="../../js/RiQi.js"></script>
	<script language="javascript" type="text/javascript" src="../../JS/Common.js"></script>
    <script language="javascript" type="text/javascript">
           function UpdateChild(result)
           {

              var childDropDown = document.forms[0].elements['ColumnList'];
              if (!childDropDown)
                 return;

              childDropDown.length = 0;

              if (!result)
                  return;
              
              var ddlChild = document.getElementById("ColumnList");
              var items=result.split('|');
              for (var i = 0; i < items.length; i++)
              {
                 var item=items[i].split(',');
				 if(item[0]!="")
				 {
	                var option = document.createElement("OPTION");
					option.value = item[1];
					option.innerHTML = item[0];
					ddlChild.appendChild(option);
				}
              }              
           }

           function UpdateChild1(result)
           {

              var childDropDown = document.forms[0].elements['lbColumn'];
              if (!childDropDown)
                 return;

              childDropDown.length = 0;

              if (!result)
                  return;
              
              var ddlChild = document.getElementById("lbColumn");
              var items=result.split('|');
              for (var i = 0; i < items.length; i++)
              {
                 var item=items[i].split(',');
				 if(item[0]!="")
				 {
					 var option = document.createElement("OPTION");
					 option.value = item[1];
					 option.innerHTML = item[0];
					 ddlChild.appendChild(option);
				 }
              }
              
           }
           
           function ShowError(result, context)
           {
			  if(result=="未将对象引用设置到对象的实例。s")
			  {
				alert("此频道下还没有栏目");
			  }
           }  
           
           
           function myfun()
           {
                if(document.form1.ColumnList.value=="")
                {
                    alert("请选择栏目");
                    return false;
                }
           }
           function lbChannelCheck()
           {
                if(document.form1.lbChannel.value=="")
                {
                    alert("请选择频道");
                    return false;
                }
           }
           function lbColumnCheck()
           {
                if(document.form1.lbColumn.value=="")
                {
                    alert("请选择栏目");
                    return false;
                }                
           }
           
           function lbSpeacilCheck()
           {
                if(document.form1.lbSpeacil.value=="")
                {
                    alert("请选择专题");
                    return false;
                }  
           }

		 function ShowCreate(result)
		{
			HideCreate();
			result.style.display="";
		}

		function HideCreate()
		{
			for(i=1;i<5;i++)
			{
				eval("crt"+i).style.display="none";	
			}
		}
		function SetColor()
		{
			var id=<%= modelId%>;
			var modid="mod"+id;
			var amodid="amod"+id;
			var obj=document.getElementById(modid);
			var obj1=document.getElementById(amodid);
			obj1.style.color="#FFF";
			obj.style.backgroundColor="#4975dc";
		}
    </script> 

</head>
<body onload="SetColor()">
    <form id="form1" runat="server">
    <div>
		<!--start您现在的位置-->
		<table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
			<tr>
				<td height="24" width="20"><img src="../images/skin/default/you.gif" align=absmiddle /></td>
				<td align=left style="padding-top:3px;" >您现在的位置：<a href="../SystemInfo.aspx">后台管理</a>  >> 生成发布 </td>
				<td width="50" align="right"><img src="../images/skin/default/help.gif" align="absmiddle" /></td>
			</tr>
		</table>
		<!--end您现在的位置-->

		<!--start操作管理-->
        <table width="99%" cellspacing="1" cellpadding="0"  class="border" align="center">
            <tr class="wzlist"><td align="left"><a href="#" onclick="ShowCreate(crt1)">发布主页与文章</a> | <a href="#" onclick="ShowCreate(crt3)">发布频道</a> | <a href="#" onclick="ShowCreate(crt2)">发布栏目</a> | <a href="#" onclick="ShowCreate(crt4)">发布专题</a> </td></tr>
        </table>
		<!--end操作管理-->
       
        <!--body-->
        <!--发布全站主页-->
        <table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center">
            <tr class="title"><td colspan="2" align="left">&nbsp;发布站点主页</td></tr>
            <tr class="tdbg"><td align="left" class="bqleft">&nbsp;发布站点主页：</td><td  align="left" class="bqright"><asp:Button ID="btnCreate" runat="server" Text="开始发布" CssClass="btn" OnClick="btnCreate_Click" /></td></tr>
        </table>
        <!--end发布全站主页-->

 
      
        <!--top生成内容页-->
        <table width="99%" border="0" cellpadding="0" cellspacing="1" class="border" align="center" id="crt1">
            <tr class="title"><td colspan="2" align="left">&nbsp;发布内容</td></tr>            

			<tr>
				<td class="bqleft">
					选择模型：
				</td>
				<td style="padding:0px; background-color:#e6e6e6;" class="bqright">
							<asp:Repeater ID="repModel" runat="server">
								<ItemTemplate><span style="background-color: #e6e6e6; border-right:solid 1px #FFF; padding:5px; text-align:center;"  id="mod<%# Eval("ModelId") %>" ><a id="amod<%# Eval("ModelId") %>" href="CreateNews.aspx?ModelId=<%# Eval("ModelId") %>"><%#Eval("ModelName") %></a></span></ItemTemplate>
							</asp:Repeater>

				</td>
			</tr>

            <tr><td align="left" class="bqleft" style="height: 24px">&nbsp;发布所有：</td><td align="left" class="bqright" style="height: 24px"><asp:Button ID="btnNewsContent" runat="server" Text="开始发布" CssClass="btn" OnClick="btnNewsContent_Click" /></td></tr>
            
            <tr><td align="left"  class="bqleft">&nbsp;按照ID发布：</td>
                <td align="left" class="bqright">
                    <asp:TextBox ID="txtIdStart" runat="server"></asp:TextBox> 
                    <asp:TextBox ID="txtIdEnd" runat="server"></asp:TextBox> 
                    <asp:Button ID="btnCreateId" runat="server" Text="开始发布" CssClass="btn" OnClick="btnCreateId_Click" />
                </td>
            </tr>
            
            <tr>
                <td class="bqleft">发布最新：</td>
                <td class="bqright"><asp:TextBox ID="txtNewsCount" runat="server"></asp:TextBox> <asp:Button ID="btnNewsCount" runat="server" Text="开始发布" CssClass="btn" OnClick="btnNewsCount_Click" /></td>
            </tr>
            
            <tr>
                <td class="bqleft">按照日期发布：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtStartDate" runat="server" onblur="setday(this);" onclick="setday(this);"></asp:TextBox>
                    <asp:TextBox ID="txtEndDate" runat="server" onblur="setday(this);" onclick="setday(this);"></asp:TextBox> 
                    <asp:Button ID="Button2" runat="server" Text="开始发布" CssClass="btn" OnClick="Button2_Click" />
                </td>
            </tr>
            
            <tr>
                <td class="bqleft" valign="middle">按照栏目发布：</td>
                <td class="bqright" valign="middle" style="padding:0px;">
                    <div>
                        频道：<asp:DropDownList ID="ddlParent" runat="server" onchange="ListData(this.options[this.selectedIndex].value);">
                         </asp:DropDownList>
                    </div>
                    <div style="float:left;"><asp:ListBox ID="ColumnList" runat="server" Width="200" Height="220" SelectionMode="Multiple"></asp:ListBox></div> 
                    <div style="margin-top:100px; float:left;">&nbsp;<asp:Button ID="btnColumnCreate" runat="server" Text="开始发布" CssClass="btn" OnClick="btnColumnCreate_Click" OnClientClick="return myfun()" /></div>
                </td>
            </tr>
        </table>        
        <!--end生成内容页-->
        
        <!--start发布栏目-->
        <table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" id="crt2" style="display:none;">
            <tr class="title"><td colspan="2" align="left">&nbsp;发布栏目</td></tr>
            
			<tr>
				<td class="bqleft">选择栏目：</td>
				<td class="bqright"><asp:Button ID="btnCreateColumnAll" runat="server" Text="发布所有栏目" CssClass="btn" OnClick="btnCreateColumnAll_Click" /></td>
			</tr>

            <tr>
				<td align="left" class="bqleft">&nbsp;频道：</td>
				<td align="left" class="bqright">
					<asp:DropDownList ID="ddlCh" runat="server" onchange="ListData1(this.options[this.selectedIndex].value);">
                    </asp:DropDownList>
				</td>
			</tr>
            
            <tr>
                <td class="bqleft" valign="middle">选择栏目：</td>
                <td class="bqright" valign="middle" style="padding:0px;">
                    <div style="float:left;"><asp:ListBox ID="lbColumn" runat="server" Width="200" Height="220" SelectionMode="Multiple"></asp:ListBox></div> 
                    <div style="margin-top:100px; float:left;">&nbsp;<asp:Button ID="btnCreateColumn" runat="server" Text="开始发布" CssClass="btn" OnClientClick="return lbColumnCheck()" OnClick="btnCreateColumn_Click" /></div>
                </td>
            </tr>
        </table>
        <!--end发布栏目-->
        
        <!--start发布频道-->
        <table width="99%" border=0 cellpadding=2 cellspacing=1 class="border" align="center" id="crt3" style="display:none;">
            <tr class="title"><td colspan="2" align="left">&nbsp;发布频道</td></tr>
       
            <tr>
                <td class="bqleft" valign="middle">选择频道：</td>
                <td class="bqright" valign="middle" style="padding:0px;">
                    <div style="float:left;"><asp:ListBox ID="lbChannel" runat="server" Width="200" Height="220" SelectionMode="Multiple"></asp:ListBox></div> 
                    <div style="margin-top:100px; float:left;">&nbsp;<asp:Button ID="btnCreateChannel" runat="server" Text="开始发布" CssClass="btn" OnClientClick="return lbChannelCheck()" OnClick="btnCreateChannel_Click" /></div>
                </td>
            </tr>
        </table>        
        <!--end发布频道-->
            
        <!--start发布主题-->
        <table width="99%" border=0 cellpadding=2 cellspacing=1 class=border align="center" id="crt4" style="display:none;">
            <tr class="title"><td colspan="2" align="left">&nbsp;发布专题</td></tr>
       
            <tr>
                <td class="bqleft" valign="middle">选择专题：</td>
                <td class="bqright" valign="middle" style="padding:0px;">
                    <div style="float:left;"><asp:ListBox ID="lbSpeacil" runat="server" Width="200" Height="220" SelectionMode="Multiple"></asp:ListBox></div> 
                    <div style="margin-top:100px; float:left;">&nbsp;<asp:Button ID="btnCreateSpeacil" runat="server" Text="开始发布" CssClass="btn" OnClientClick="return lbSpeacilCheck()" OnClick="btnCreateSpeacil_Click" /></div>
                </td>
            </tr>
        </table>        
        <!--end发布主题--> 
 
        <!--endbody-->        
    </div>
        <asp:Literal ID="litMessage" runat="server"></asp:Literal>
    </form>
</body>
</html>
