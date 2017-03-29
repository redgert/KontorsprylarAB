<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="Website.checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="myForm" runat="server">
        <div class="table-responsive">
            <asp:Table ID="checkOutTable" CssClass="table table-responsive" runat="server"></asp:Table>
        </div>
        <asp:Button ID="myButton" runat="server" Text="Place order" OnClick="myButton_Click" />
    </form>
</asp:Content>
