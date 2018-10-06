<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ShoppingCartPage.aspx.cs" Inherits="eCommerceShoppingCartPage" %>

<%@ Register Src="~/Controls/ShoppingCartControl.ascx" TagPrefix="uc1" TagName="ShoppingCartControl" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <uc1:ShoppingCartControl runat="server" ID="ShoppingCartControl" />
    </p>
    <asp:Label id="lblMessage" runat ="server"></asp:Label>
    <a href ="Default1.aspx" runat="server" >Continue Shopping</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <a href ="Checkout.aspx" runat="server" id ="btnCheckout">Check Out</a>
</asp:Content>
