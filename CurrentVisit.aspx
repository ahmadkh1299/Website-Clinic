<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CurrentVisit.aspx.cs" Inherits="CurrentVisit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" 
        style="background-image: url('Images/job_description.png'); background-repeat: no-repeat; background-position: center center; height: 456px;">
        <tr>
            <td colspan="2" align="center" style="height: 232px">
                <h2>
                    Current Visit Information</h2>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 38px">
                <asp:Label ID="Label1" runat="server" Text="Patient ID"></asp:Label>
            </td>
            <td align="center" style="height: 38px">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                    ControlToValidate="TextBox1" ErrorMessage="*" MaximumValue="999999" 
                    MinimumValue="0"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox1" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 45px">
                <asp:Label ID="Label2" runat="server" Text="Reason of Visit"></asp:Label>
            </td>
            <td align="center" style="height: 45px">
                &nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox2" ErrorMessage="*"></asp:RequiredFieldValidator>
&nbsp;</td>
        </tr>
        <tr>
            <td align="center" style="height: 39px">
                <asp:Label ID="Label3" runat="server" Text="Diagnose"></asp:Label>
            </td>
            <td align="center" style="height: 39px">
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox3" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 36px">
                <asp:Label ID="Label4" runat="server" Text="Medication"></asp:Label>
            </td>
            <td align="center" style="height: 36px">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="TextBox4" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr><td colspan="2" align="center" style="height: 54px">
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Done" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" CausesValidation="False" Text="Clear" 
                onclick="Button2_Click" style="width: 46px" />
            <br />
            <asp:Label ID="LabelMessage" runat="server"></asp:Label>
            </td></tr>
    </table>
</asp:Content>
