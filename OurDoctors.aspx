<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="OurDoctors.aspx.cs" Inherits="OurDoctors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="border: medium solid #000000">
        <tr>
            <td align="center">
                <h4 style="color: #0000FF">
                    Welcome to our Website, here we will provide you all the help you do your usual
                    functions from home Here you will find help from our doctors and you can buy you
                    medicine without the trouble to stand in lines Also You won't have to wait for the
                    doctor in unnessacry order you can just set your visit witch is 30 min dedcated
                    for you</h4>
            </td>
        </tr>
        <tr>
            <td>
                <center>
                <h3>This is the list of our doctors just select a specialty</h3>
                    <asp:Label ID="Label1" runat="server" Text="Select Specialty"></asp:Label>&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:DropDownList ID="DropDownListSpecialty" runat="server" OnSelectedIndexChanged="DropDownListSpecialty_SelectedIndexChanged"
                        AutoPostBack="True">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                </center>
                <asp:DataList ID="DataListDoctors" runat="server" BackColor="White" BorderColor="White"
                    BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" RepeatColumns="3"
                    RepeatDirection="Horizontal" Width="100%">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <ItemStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <ItemTemplate>
                        <asp:Label ID="Label2" Font-Size="XX-Large" runat="server" Text="Doctor Name: Dr."></asp:Label>
                        <asp:Label ID="LabelFName" Font-Size="XX-Large" runat="server" Text='<%# Bind("FName") %>'></asp:Label>
                        <asp:Label ID="LabelLName" runat="server" Font-Size="XX-Large" Text='<%# Bind("LName") %>'></asp:Label>
                        <br />
                        <asp:Image ID="ImageDoctor" runat="server" Width="200px" Height="200px" ImageUrl='<%# Bind("ImageSource") %>' />
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                </asp:DataList>
                <br />
                <br />
            </td>
        </tr>
    </table>
    <asp:Label ID="LabelMessage" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
