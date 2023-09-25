<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="ThongTinCaNhan.aspx.cs" Inherits="HADESvn.cms.index.page.ThongTinCaNhan" %>

<%@ Register Src="~/cms/index/control/thongtincanhan.ascx" TagPrefix="uc1" TagName="thongtincanhan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:thongtincanhan runat="server" id="thongtincanhan" />
</asp:Content>
