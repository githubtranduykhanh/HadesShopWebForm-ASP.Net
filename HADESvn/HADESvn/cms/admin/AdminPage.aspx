<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="HADESvn.cms.admin.AdminPage" %>
<%@ Register src="AdminControl.ascx" tagname="AdminControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AdminControl ID="AdminControl1" runat="server" />
</asp:Content>
