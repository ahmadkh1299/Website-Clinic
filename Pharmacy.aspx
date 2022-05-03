<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Pharmacy.aspx.cs" Inherits="Pharmacy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="LabelMsg" runat="server" ></asp:Label>
    <asp:DataList ID="DataListPharmacy" runat="server" CellPadding="4" RepeatColumns="4"
        RepeatDirection="Horizontal" Width="100%" 
        onitemcommand="DataListPharmacy_ItemCommand" ForeColor="#333333">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderTemplate>
            <center>
                <asp:Label ID="Label1" runat="server" Text="Our Pharmacy"></asp:Label>
                <br />
                &nbsp;&nbsp;
                <asp:Image ID="Image2" runat="server" Height="150px" 
                    ImageUrl="~/Images/PharmacyCross.png" Width="150px" />
            </center>
        </HeaderTemplate>
        <ItemStyle BackColor="#E3EAEB" />
        <ItemTemplate>
            <asp:Label ID="LabelMedicine" runat="server" Text='<%# Bind("Medicine") %>'></asp:Label>
            <br />
            <center>
                <asp:Image ID="Image1" runat="server" Height="150px" ImageUrl='<%# Bind("ImageSource") %>'
                    Width="200px" />
            </center>
            <br />
            <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
            <center>
                &nbsp;<br />Retails for<asp:Label ID="LabelPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                &nbsp;shekels<br /> <br />
            </center>
            <center>
                <asp:Label ID="Label2" runat="server" Text="How Many Do you want"></asp:Label>
                &nbsp;<asp:TextBox ID="TextBox1" runat="server" Height="21px" Width="36px">1</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:LinkButton ID="LinkButtonBuy" runat="server" CommandName="Add to cart">Add to cart</asp:LinkButton></center>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    </asp:DataList>
</asp:Content>
