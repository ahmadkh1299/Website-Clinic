<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="LabelMsg" runat="server" ></asp:Label>
    <asp:DataList ID="DataList1" runat="server" BackColor="White" 
    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
    GridLines="Both" RepeatColumns="4" RepeatDirection="Horizontal" Width="878px" 
        ondeletecommand="DataList1_DeleteCommand">
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <ItemStyle BackColor="White" ForeColor="#003399" />
        <ItemTemplate>
        <div>
            <asp:LinkButton ID="LinkButtonDelete" runat="server" CommandArgument="Delete" 
                CommandName="Delete" ForeColor="Red" OnClientClick="return confirm('Are You Sure?');">X</asp:LinkButton>
            </div>
        <center>
            <asp:Label ID="Label1" runat="server" Text="Phone Number:"></asp:Label>
            &nbsp;<asp:Label ID="LabelPhoneNumber" runat="server" 
                Text='<%# Bind("PhoneNumber") %>'></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Message"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Enabled="False" TextMode="MultiLine" 
                Text='<%# Bind("Message") %>'></asp:TextBox>
      </center>  </ItemTemplate>
        <SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
    </asp:DataList>
</asp:Content>

