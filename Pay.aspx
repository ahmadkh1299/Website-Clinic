<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Pay.aspx.cs" Inherits="Pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
            onclick="LinkButton1_Click">Return to cart</asp:LinkButton>
&nbsp;&nbsp;
        <asp:Label ID="LabelMessage" runat="server"></asp:Label></center>
    <table style="background-position: center center; border: thin solid #008080; width: 100%; background-image: none; background-repeat: no-repeat; background-color: #66FF99;" 
        border="1" cellpadding="5"
        cellspacing="1">
        <tr>
            <td colspan="2" align="center" style="height: 39px">
                <h2>
                    Enter your information</h2>
                <p style="color: #FF0000">
                    * - Are required fields</p>
                <p style="color: #FF0000">
                    <asp:Label ID="LabelMsg" runat="server" ForeColor="Red"></asp:Label>
                </p>
            </td>
        </tr>
        <tr>
            <td style="height: 32px" align="center">
                <h4>
                    Visa Number</h4>
            </td>
            <td style="height: 32px" align="center">
                <asp:TextBox ID="TextBoxVisaNr" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxVisaNr"
                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center">
                <h4>
                    Validiation Number</h4>
            </td>
            <td align="center">
                &nbsp;<asp:TextBox ID="TextBoxValidiationNr" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxValidiationNr"
                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center">
                <h4>
                    ID Number of the owner</h4>
            </td>
            <td align="center">
                &nbsp;<asp:TextBox ID="TextBoxID" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxID"
                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="ButtonPay" runat="server" Text="Pay" OnClick="ButtonPay_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CausesValidation="False"
                    OnClick="ButtonCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
