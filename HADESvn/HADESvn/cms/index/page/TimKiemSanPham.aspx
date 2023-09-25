<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="TimKiemSanPham.aspx.cs" Inherits="HADESvn.cms.index.page.TimKiemSanPham" %>

<%@ Register Src="~/cms/index/control/timkiemsanpham.ascx" TagPrefix="uc1" TagName="timkiemsanpham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:timkiemsanpham runat="server" id="timkiemsanpham" />
</asp:Content>
