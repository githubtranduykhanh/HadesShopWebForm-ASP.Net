<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="AllProduct.aspx.cs" Inherits="HADESvn.cms.index.page.AllProduct" %>

<%@ Register Src="~/cms/index/control/allproduct.ascx" TagPrefix="uc1" TagName="allproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:allproduct runat="server" ID="allproduct" />
</asp:Content>
