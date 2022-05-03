<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PMessages.aspx.cs" Inherits="Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="LabelMessage" runat="server"></asp:Label><center>
    <asp:Button ID="Button1" runat="server" BackColor="#006666" ForeColor="White" 
        Text="Write a message" onclick="Button1_Click" /></center>
    <asp:DataList ID="DataListMessages" runat="server" BackColor="White" BorderColor="#336666"
        BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal"
        Width="100%" onitemcommand="DataListMessages_ItemCommand" 
        ondeletecommand="DataListMessages_DeleteCommand">
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <HeaderTemplate>
            <center>
                Your Messages</center>
        </HeaderTemplate>
        <ItemStyle BackColor="White" ForeColor="#333333" />
        <ItemTemplate>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton 
                ID="LinkButtonDelete" runat="server" CommandArgument="Delete" 
                CommandName="Delete">X</asp:LinkButton>
            <br />
            <asp:Label ID="Label1" runat="server" Text="From: Dr."></asp:Label>
            <asp:Label ID="LabelFName" runat="server" Text='<%# Bind("FName") %>'></asp:Label>
            &nbsp;<asp:Label ID="LabelLName" runat="server" Text='<%# Bind("LName") %>'></asp:Label>
            &nbsp;&nbsp; (<asp:Label ID="LabelLicenseNumber" runat="server" ForeColor="#CCCCCC" 
                Text='<%# Bind("LicenseNumber") %>'></asp:Label>
            )<br />
            <asp:Label ID="LabelMessage" runat="server" Text='<%# Bind("Message") %>'></asp:Label>
            <br />
            <center>
                <asp:LinkButton ID="LinkButtonRebly" runat="server" CommandName="Reply">Reply</asp:LinkButton>
            </center>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
</asp:Content>
