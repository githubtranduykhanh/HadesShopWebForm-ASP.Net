<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="DanhMucNews.aspx.cs" Inherits="HADESvn.cms.index.page.DanhMucNews" %>

<%@ Register Src="~/cms/index/control/danhmucnews.ascx" TagPrefix="uc1" TagName="danhmucnews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:danhmucnews runat="server" id="danhmucnews" />
</asp:Content>
