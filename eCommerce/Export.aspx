<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Export.aspx.cs" Inherits="eCommerceExport" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="grdExport" runat="server" DataSourceID="srcExport"
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" />
            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" />
        </Columns>
    </asp:GridView>
    <p>
    <a href ="#" onclick ="window.print();">Print</a>
    </p>
    <asp:ObjectDataSource ID="srcExport" runat="server" SelectMethod="GetShoppingCartFromService"
        TypeName="eCommerceModels.BLL"></asp:ObjectDataSource>
    
</asp:Content>
