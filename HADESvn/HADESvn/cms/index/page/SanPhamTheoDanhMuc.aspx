<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="SanPhamTheoDanhMuc.aspx.cs" Inherits="HADESvn.cms.index.page.SanPhamTheoDanhMuc" %>

<%@ Register Src="~/cms/index/control/sanphamtheodanhmuc.ascx" TagPrefix="uc1" TagName="sanphamtheodanhmuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:sanphamtheodanhmuc runat="server" id="sanphamtheodanhmuc" />
</asp:Content>
