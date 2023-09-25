<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="ItemNew.aspx.cs" Inherits="HADESvn.cms.index.page.ItemNew" %>

<%@ Register Src="~/cms/index/control/itemnew.ascx" TagPrefix="uc1" TagName="itemnew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:itemnew runat="server" ID="itemnew" />
</asp:Content>
