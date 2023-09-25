<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="HADESvn.cms.index.page.GioHang" %>

<%@ Register Src="~/cms/index/control/giohang.ascx" TagPrefix="uc1" TagName="giohang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:giohang runat="server" id="giohang" /> 
</asp:Content>
