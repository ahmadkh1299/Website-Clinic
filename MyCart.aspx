<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MyCart.aspx.cs" Inherits="MyCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <asp:Label ID="LabelMessage" runat="server"></asp:Label>
        &nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" Visible="False" OnClick="LinkButton1_Click">LogIn as a Patient</asp:LinkButton>
        <br />
        <center>
            <h3>
                If one of your items is deleted it's because it's no longer available</h3>
        </center>
        <br />
    </center>
    <br />
    <asp:DataList ID="DataListCart" runat="server" BackColor="White" BorderColor="#CC9966"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Both" Width="100%"
        RepeatColumns="1" RepeatDirection="Horizontal" OnDeleteCommand="DataListCart_DeleteCommand">
        <EditItemTemplate>
            <br />
            <center>
                <asp:Label ID="LabelItem" runat="server" Text='<%# Bind("Item") %>'></asp:Label>
            </center>
            <br />
            <br />
            <center>
                <asp:Label ID="LabelPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                &nbsp;x
                <asp:TextBox ID="TextBoxNewNumber" runat="server" Height="16px" Text='<%# Bind("Number") %>'
                    Width="19px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="ButtonUpdate" runat="server" CommandArgument="Update" CommandName="Update"
                    Text="Done" />
            </center>
        </EditItemTemplate>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <HeaderTemplate>
            <center>
                Items in your Cart</center>
        </HeaderTemplate>
        <ItemStyle ForeColor="#330099" BackColor="White" />
        <ItemTemplate>
            <asp:LinkButton ID="LinkButtonDelete" runat="server" CommandArgument="Delete" CommandName="Delete"
                OnClientClick="return confirm('Are You Sure?');">X</asp:LinkButton>
            <br />
            <center>
                Product Name:
                <asp:Label ID="LabelItem" runat="server" Text='<%# Bind("Item") %>'></asp:Label>
            </center>
            <br />
            <br />
            <center>
                <asp:Label ID="LabelPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                &nbsp;ILS &nbsp;x
                <asp:Label ID="LabelNumber" runat="server" Font-Size="Small" Text='<%# Bind("Number") %>'></asp:Label>
                <br />
                <br />
            </center>
            <br />
        </ItemTemplate>
        <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    </asp:DataList>
    <br />
    <center>
        <asp:Label ID="Label4" runat="server" Text="Your Payment"></asp:Label>
        &nbsp;<asp:Label ID="Label5" runat="server"></asp:Label>
        <br />
        <asp:Button ID="ButtonBuy" runat="server" Text="Buy" OnClick="ButtonBuy_Click" />
    </center>
</asp:Content>
