<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WriteMessageD.aspx.cs" Inherits="WriteMessageD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="LabelMessage" runat="server" ></asp:Label>
    <table width="100%" border="5px" style="background-image: url('Images/message.gif')"
        align="center">
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" Text="To:"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="DropDownList1" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="Label2" runat="server" Text="Message"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox1" ErrorMessage="*"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TextBox1" runat="server" BackColor="Transparent" ForeColor="Black"
                    Height="450px" Width="800px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="ButtonSend" runat="server" Text="Send" 
                    onclick="ButtonSend_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonClear" runat="server" Text="Clear" 
                    onclick="ButtonClear_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
