<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="ListNews.aspx.cs" Inherits="HADESvn.cms.index.page.ListNews" %>

<%@ Register Src="~/cms/index/control/listnews.ascx" TagPrefix="uc1" TagName="listnews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:listnews runat="server" id="listnews" />
</asp:Content>
