<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCartControl.ascx.cs" Inherits="eCommerceControls.ShoppingCartControl" %>
<div>
    <div style ="width:100%;">
        <asp:GridView ID="grdShoppingCart" runat="server" DataSourceID="srcShoppingCart"
            AutoGenerateColumns="False" OnRowCommand="grdShoppingCart_RowCommand" 
            ShowFooter="True" OnRowDataBound="grdShoppingCart_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" />
                <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" />
                <asp:ButtonField Text="Delete" CommandName="DeleteCart" />
                <asp:ButtonField Text="Update" CommandName="UpdateCart" />
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
    </div>
    <div style ="text-align:right;width:100%;float:right;">
        Total:
        <label id="lblTotal"></label>
    </div>
</div>
<asp:ObjectDataSource ID="srcShoppingCart" runat="server" SelectMethod="GetShoppingCart"
    TypeName="eCommerceModels.BLL"></asp:ObjectDataSource>
