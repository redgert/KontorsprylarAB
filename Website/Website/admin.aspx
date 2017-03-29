<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Website.adminsida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="table-responsive">
            <table id="productTable" class="table">
                <thead>
                    <tr>
                        <th>Product ID</th>
                        <th>Price Inc Vat</th>
                        <th>Stock</th>
                        <th>Short Description</th>
                        <th>Long Description</th>
                        <th>URL</th>
                        <th>Vat Tag</th>
                    </tr>
                </thead>
                <tbody id="tableBody">
                </tbody>
            </table>
        </div>
        <button class="btn btn-default" onclick="AddProduct();">Add Product</button>
    </div>
    <script src="Scripts/tablesorter/jquery.tablesorter.combined.js"></script>
    <script src="js/adminJS.js"></script>
</asp:Content>
