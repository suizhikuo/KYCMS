<%@ Page Language="C#" MasterPageFile="~/userspace/enterprisespace/MasterPage.master"
    AutoEventWireup="true"%>
<%@ Import Namespace="Ky.Common" %>
<%@ Import Namespace="Ky.BLL" %>
<%@ Import Namespace="Ky.Model" %>
<%@ Import Namespace="System.Data" %> 
<script runat="server" language="c#">
    B_User userBll = new B_User();
    DataRow userDr = null;
    int userId = 0;
    int id = 0;
    M_Enterprise EnterpriseModel = null;
    B_Enterprise enterpriseBll = new B_Enterprise(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
        {
            userId = Convert.ToInt32(Request.QueryString["uid"]);
        }
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
        }
        Page.Title = "查看企业信息";
        userDr = userBll.GetUserAllInfo(userId);
        EnterpriseModel = enterpriseBll.GetEnterpriseById(id, userId);
    }
    string UserInfo(DataRow dr, string fieldName)
    {
        if (dr != null)
        {
            if (dr.Table.Columns.Contains(fieldName))
            {
                return dr[fieldName].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        else
        {
            return string.Empty;
        }
    } 
</script> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="685px" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="5">
                &nbsp;</td>
            <td height="400" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="3" align="left">
                            您现在的位置：查看企业信息</td>
                    </tr>
                    <tr>
                        <td width="5" height="30" class="rg01">
                        </td>
                        <td width="674" align="left" class="rg02">
                           <span class="savIcon"></span>查看企业信息</td>
                        <td width="5" height="30" class="rg03">
                        </td>
                    </tr>
                    <tr>
                        <td height="412" colspan="3" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="leftbk">
                                <tr>
                                    <td height="410" valign="top" align="" style="padding:20px;">
                                        <table width="90%" border="0" cellspacing="0" cellpadding="0" align="center">
                                            <tr>
                                                <td>
                                                    <span style="font:30px verdana; color:Red;"><%=EnterpriseModel.Title %></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td> <span>作者：<%=UserInfo(userDr,"name")%></span>&nbsp;&nbsp;发布时间：<span><%=EnterpriseModel.AddTime%></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left"> <span><%=EnterpriseModel.Conetent%></span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
