<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="ThanhToan.aspx.cs" Inherits="HADESvn.cms.index.page.ThanhToan" %>

<%@ Register Src="~/cms/index/control/thanhtoan.ascx" TagPrefix="uc1" TagName="thanhtoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:thanhtoan runat="server" id="thanhtoan" />
</asp:Content>
