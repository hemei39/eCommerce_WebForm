<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ShoppingCartPage.aspx.cs" Inherits="Mei.ShoppingCartPage" %>

<%@ Register Src="~/Controls/ShoppingCartControl.ascx" TagPrefix="uc1" TagName="ShoppingCartControl" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <uc1:ShoppingCartControl runat="server" ID="ShoppingCartControl" />
    </p>
    <a href ="Default1.aspx">Continue Shopping</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <a href ="Checkout.aspx">Check Out</a>
</asp:Content>
