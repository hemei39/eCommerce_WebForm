<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="eCommerceCheckout" MasterPageFile="~/Site.Master" %>

<%@ Register Src="~/Controls/ShoppingCartControl.ascx" TagPrefix="uc1" TagName="ShoppingCartControl" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="grdCheckout" runat="server" DataSourceID="srcCheckout"
        AutoGenerateColumns="False" ShowFooter ="True" OnRowDataBound ="grdCheckout_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" />
            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" />

        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>

    <asp:ObjectDataSource ID="srcCheckout" runat="server" SelectMethod="GetShoppingCartFromService"
        TypeName="eCommerceModels.BLL"></asp:ObjectDataSource>
    <p>
    <a href="Default1.aspx">Continue Shopping</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <a href="ShoppingCartPage.aspx">View Shopping Cart</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <a href ="Export.aspx">Export</a>
    </p>
</asp:Content>

