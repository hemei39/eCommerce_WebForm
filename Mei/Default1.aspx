<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default1.aspx.cs" Inherits="Mei.Default1" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div style="float: left; margin-right:50px;">
            Categories: 
            <asp:DropDownList ID="ddlstCategories" runat="server" DataSourceID="srcCategories"
                DataTextField="CategoryName" DataValueField="CategoryID" AutoPostBack="true" 
                OnSelectedIndexChanged="ddlstCategories_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div style="float: left;">
            Products: 
            <asp:GridView ID="grdProduct" runat="server" AutoGenerateColumns="False" DataSourceID="srcProducts"
                AllowPaging="True" AllowSorting="True" OnRowCommand="grdProduct_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID" />
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                    <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock" />
                    <asp:ButtonField Text="Add To Shopping Cart" CommandName="Add" />
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
        <asp:ObjectDataSource ID="srcCategories" runat="server" SelectMethod="GetCategories" TypeName ="Mei.Models.BLL" ></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="srcProducts" runat="server" SelectMethod="GetProducts" 
            TypeName="Mei.Models.BLL" SortParameterName="sortColumn">
            <SelectParameters>
                <asp:ControlParameter Name="categoryID" ControlID="ddlstCategories" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>

