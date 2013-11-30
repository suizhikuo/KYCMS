<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetSpecial.aspx.cs" Inherits="system_collection_SetSpecial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>选择专题</title>
	<link rel="stylesheet" href="../css/default.css" type="text/css" />
	<script language="javascript" type="text/javascript" src="../../js/Common.js"></script>
	<script language="javascript" type="text/javascript">
		function setValue()
		{
		   var id="|";
		  var name="";
		   var lst1=$("lBoxTopicIdStr");
		   var length=lst1.options.length;
		   var tt="";
		   for(var i=0;i<length;i++)
		   {
				if(lst1[i].selected == true)
				{
					id=id+lst1[i].value+"|";
					name=name+lst1[i].text+",";
				}
		   }
			var nameArr=name.split(',');
			reName="";
			for(i=0;i<nameArr.length-1;i++)
			{
				if(i==nameArr.length-2)
					reName=reName+nameArr[i];
				else
					reName=reName+nameArr[i]+",";	
			}			
					
			window.opener.document.all.hidSpecialId.value=id;
			window.opener.document.all.txtSpecialId.value=reName.replace("└","");
			window.close();				
		}


		function btnSetToppicStr(val)
		{
		   var lst1=$("lBoxTopicIdStr");
		   var length=lst1.options.length;
		   var tt="";
		   if(val=="ChooseAll")
		   {
			   for(var i=0;i<length;i++)
			   {
					lst1.options[i].selected = true;
			   }
		   }
		   else 
		   {
			   for(var i=0;i<length;i++)
			   {
					lst1.options[i].selected = false;
			   }
		   }
		}

	
	</script>
</head>
<body class="bqright">
    <form id="form1" runat="server">
	<div>
		<table>
            <tbody>
				<tr>
					<td>请选择专题：</td>
				</tr>
                <tr>
                    <td>
                        <asp:ListBox ID="lBoxTopicIdStr" runat="server" Height="160px" SelectionMode="Multiple" Width="150px"></asp:ListBox>
                        <input type="button" id="btnSelAllTopicIdStr" name="btnSelAllTopicIdStr" value="全 选"
                            class="btn" onclick="btnSetToppicStr('ChooseAll')" />
                        <input type="button" id="btnCanCelTopicIdStr" name="btnCanCelTopicIdStr" value="取 消"
                            class="btn" onclick="btnSetToppicStr('Cancel')" />
						<input id="Button1" type="button" value="确 定" class="btn" onclick="setValue()" />
                    </td>
                </tr>
            </tbody>
		</table>
	</div>
<!--
    <div>
            <asp:TreeView ID="tvNav" runat="server" ExpandDepth="1" ShowLines="True" EnableViewState="false">
            </asp:TreeView>		     
    </div>
-->
    </form>
</body>
</html>
