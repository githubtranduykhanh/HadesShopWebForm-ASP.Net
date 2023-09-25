<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="LienHe.aspx.cs" Inherits="HADESvn.cms.index.page.LienHe" %>

<%@ Register Src="~/cms/index/control/lienhe.ascx" TagPrefix="uc1" TagName="lienhe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:lienhe runat="server" id="lienhe" />
</asp:Content>
