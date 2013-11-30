<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginInfo.aspx.cs" Inherits="userspace_LoginInfo" %>
<% if (!userBll.IsLogin())
   {
       Response.Write("<a href='javascript:window.location.href=\"../user/Reg.aspx\"' target=\"blank\">注册</a>┆<a href='javascript:showtips(\"UserLogin.aspx\",\"300px\",\"170px\")'>登录<a/>┆<a href='../user/main.aspx' target='_blank'>发表文章<a/>");
   }
   else
   {
       Response.Write("" + userBll.GetCookie().LogName + " 您好！┆<a href='../user/main.aspx' target='_blank' target='_blank'>发表文章<a/>┆<a href='SignOut.aspx'>安全退出</a>");
   } %>
