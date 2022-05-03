<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DHistory.aspx.cs" Inherits="DHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:Label ID="LabelMessage" runat="server"></asp:Label>
    <asp:DataList ID="DataListHistory" runat="server" BackColor="White" BorderColor="#CCCCCC"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Both" RepeatColumns="4"
        Width="100%"
        Height="541px" Style="margin-bottom: 0px"
        RepeatDirection="Horizontal" onitemcommand="DataListHistory_ItemCommand">
        <HeaderTemplate>
            Search ID number:
            <asp:TextBox ID="TextBoxSearch" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TextBoxSearch" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" 
                ControlToValidate="TextBoxSearch" ErrorMessage="*" MaximumValue="9999999999" 
                MinimumValue="0"></asp:RangeValidator>
            <asp:Button ID="ButtonSearch" runat="server" CommandArgument="Search" CommandName="Search"
                Text="Search" />
        </HeaderTemplate>
        <ItemTemplate>
            <table>
                <tr>
                    <td style="width: 274px">
                        <center>
                            <asp:Label ID="Label1" runat="server" Text="PatientID: "></asp:Label>
                            <asp:Label ID="LabelPatientID" runat="server" Text='<%# Bind("PatientID") %>'></asp:Label>
                        </center>
                        <br />
                        <center>
                            <asp:Label ID="Label2" runat="server" Text="Patient Name: "></asp:Label>
                            <asp:Label ID="LabelFName" runat="server" Text='<%# Bind("PFName") %>'></asp:Label>
                            <asp:Label ID="LabelLName" runat="server" Text='<%# Bind("PLName") %>'></asp:Label>
                        </center>
                        <br />
                    </td>
                    <td style="width: 301px" align="center">
                        <asp:Label ID="Label4" runat="server" Text="License Number: "></asp:Label>
                        <asp:Label ID="LabelLicenseNumber" runat="server" 
                            Text='<%# Bind("LicenseNumber") %>'></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="DoctorName:"></asp:Label>
                        <asp:Label ID="LabelFNameD" runat="server" Text='<%# Bind("DFName") %>'></asp:Label>
                        <asp:Label ID="LabelLNameD" runat="server" Text='<%# Bind("DLName") %>'></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <center>
                            <asp:Label ID="Label7" runat="server" Text="Specialty:"></asp:Label>
                            <asp:Label ID="LabelSpecialty" runat="server" Text='<%# Bind("Specialty") %>'></asp:Label>
                            &nbsp;<br />
                            <br />
                            The visit was at
                            <asp:Label ID="LabelDate" runat="server" Text='<%# FormateDate(Eval("VisitDate")) %>'></asp:Label>
                            <br />
                            <br />
                            <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Height="57px" 
                                Text='<%# Bind("Description") %>' TextMode="MultiLine" Width="209px"></asp:TextBox>
                        </center>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <ItemStyle ForeColor="#000066" />
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
</asp:Content>
