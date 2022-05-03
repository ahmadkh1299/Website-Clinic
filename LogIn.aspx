<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="LogIn.aspx.cs" Inherits="LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="3" width="100%">
        <tr>
            <td colspan="2">
                <center>
                    <h2>
                        LogIn</h2>
                </center>
            </td>
        </tr>
        <tr>
            <td>
                <center>
                    <asp:Label ID="LabelUserName" runat="server" Text="UserName"></asp:Label>
                </center>
            </td>
            <td>
                <center>
                    <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
                    <br /> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter a UserName 
                     if a patient enter your ID
                     if a doctor enter your license"
                        ControlToValidate="TextBoxUserName" ForeColor="Red"></asp:RequiredFieldValidator>
                </center>
            </td>
        </tr>
        <tr>
            <td>
                <center>
                    <asp:Label ID="LabelPassWord" runat="server" Text="PassWord"></asp:Label>
                </center>
            </td>
            <td>
                <center>
                    <asp:TextBox ID="TextBoxPassWord" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter PassWoed"
                        ForeColor="Red" ControlToValidate="TextBoxPassWord"></asp:RequiredFieldValidator>
                </center>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <center>
                    <asp:Button ID="ButtonLogIn" runat="server" Text="LogIn" OnClick="ButtonLogIn_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                        onclick="ButtonCancel_Click" CausesValidation="False" />
                    <br />
                    <asp:Label ID="LabelMsg" runat="server"></asp:Label>
                </center>
            </td>
        </tr>
    </table>
</asp:Content>
