<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="HADESvn.cms.index.page.Index" %>

<%@ Register Src="~/cms/index/control/index.ascx" TagPrefix="uc1" TagName="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:index runat="server" id="index" />
</asp:Content>
