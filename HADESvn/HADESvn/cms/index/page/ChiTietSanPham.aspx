<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="ChiTietSanPham.aspx.cs" Inherits="HADESvn.cms.index.page.ChiTietSanPham" %>

<%@ Register Src="~/cms/index/control/chitietsanpham.ascx" TagPrefix="uc1" TagName="chitietsanpham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:chitietsanpham runat="server" id="chitietsanpham" />
</asp:Content>
