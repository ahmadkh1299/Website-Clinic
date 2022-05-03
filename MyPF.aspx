<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MyPF.aspx.cs" Inherits="MyPF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LabelMsg" runat="server"></asp:Label>
    <asp:DataList ID="DataListDoctors" runat="server" BackColor="#CCCCCC" BorderColor="#999999"
        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" GridLines="Both"
        RepeatDirection="Horizontal" Width="100%" OnCancelCommand="DataListDoctors_CancelCommand"
        OnEditCommand="DataListDoctors_EditCommand" 
    OnUpdateCommand="DataListDoctors_UpdateCommand" ForeColor="Black">
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <HeaderTemplate>
            My Information :-
        </HeaderTemplate>
        <ItemStyle BackColor="White" />
        <ItemTemplate>
            <table>
                <tr>
                    <td>
                        <br />
                        License Number:
                        <asp:Label ID="LabelLicenseNumber" runat="server" Text='<%# Bind("LicenseNumber") %>'></asp:Label>
                        <br />
                        <br />
                        First Name:
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("FName") %>'></asp:Label>
                        <br />
                        <br />
                        Last Name:
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("LName") %>'></asp:Label>
                        <br />
                        <br />
                        Specialty:
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Specialty") %>'></asp:Label>
                        <br />
                        <br />
                        PassWord:
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("PassWord") %>'></asp:Label>
                        <br />
                    </td>
                    <td>
                        <br />
                        &nbsp; &nbsp; My Picture
                        <br />
                        &nbsp; &nbsp;
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("ImageSource") %>' Height="200px"
                            Width="200px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <center>
                            <asp:LinkButton ID="LinkButton1" CommandName="Edit" Text="Edit" Width="100px" runat="server" />
                        </center>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <EditItemTemplate>
            License Number:
            <asp:Label ID="LabelLicenseNumber1" runat="server" Text='<%# Bind("LicenseNumber") %>'></asp:Label>
            <br />
            <br />
            First Name:
            <asp:TextBox ID="TextBoxFName" runat="server" Text='<%# Bind("FName") %>'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TextBoxFName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            Last Name:<asp:TextBox ID="TextBoxLName" runat="server" Text='<%# Bind("LName") %>'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="TextBoxLName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            Specialty:
            <asp:TextBox ID="TextBoxSpecialty" runat="server" Text='<%# Bind("Specialty") %>'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="TextBoxSpecialty" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            PassWord:
            <asp:TextBox ID="TextBoxPassWord" runat="server" Text='<%# Bind("PassWord") %>'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="TextBoxPassWord" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            New Picture:<br />
            <asp:FileUpload ID="PicUpload" runat="server" />
            <br />
            <br />
            <asp:LinkButton ID="LinkButton3" CommandName="Update" Text="Update" Width="100px"
                runat="server" />
            <asp:LinkButton ID="LinkButton4" CommandName="Cancel" Text="Cancel" Width="100px"
                runat="server" CausesValidation="False" />
        </EditItemTemplate>
        <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
    <asp:DataList ID="DataListPatients" runat="server" BackColor="#CCCCCC" BorderColor="#999999"
        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" GridLines="Both"
        RepeatDirection="Horizontal" OnCancelCommand="DataListPatients_CancelCommand"
        OnEditCommand="DataListPatients_EditCommand" OnUpdateCommand="DataListPatients_UpdateCommand"
        Width="100%" ForeColor="Black">
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <HeaderTemplate>
            My Information
        </HeaderTemplate>
        <ItemStyle BackColor="White" />
        <ItemTemplate>
            ID Number:
            <asp:Label ID="LabelID" runat="server" Text='<%# Bind("PatientID") %>'></asp:Label>
            <br />
            <br />
            First Name:
            <asp:Label ID="LabelFName" runat="server" Text='<%# Bind("FName") %>'></asp:Label>
            <br />
            <br />
            Last Name:
            <asp:Label ID="LabelLName" runat="server" Text='<%# Bind("LName") %>'></asp:Label>
            <br />
            <br />
            PassWord:
            <asp:Label ID="LabelPassWord" runat="server" Text='<%# Bind("PassWord") %>'></asp:Label>
            <br />
            <br />
            Date Of Birth:
            <asp:Label ID="LabelDOB" runat="server" Text='<%# Bind("DateOfBirth") %>'></asp:Label>
            <br />
            <br />
            Email:
            <asp:Label ID="LabelEMail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
            <br />
            <center>
                <asp:LinkButton ID="LinkButton1" CommandName="Edit" Text="Edit" Width="100px" runat="server" />
            </center>
        </ItemTemplate>
        <EditItemTemplate>
            ID Number:
            <asp:Label ID="LabelPatientID" runat="server" Text='<%# Bind("PatientID") %>'></asp:Label>
            <br />
            <br />
            First Name:
            <asp:TextBox ID="TextBoxFName" runat="server" Text='<%# Bind("FName") %>'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="TextBoxFName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            Last Name:
            <asp:TextBox ID="TextBoxLName" runat="server" Text='<%# Bind("LName") %>'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="TextBoxLName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            PassWord:
            <asp:TextBox ID="TextBoxPassWord" runat="server" Text='<%# Bind("PassWord") %>'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="TextBoxPassWord" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            Date Of Birth:
            <asp:TextBox ID="TextBoxDOB" runat="server" Text='<%# Bind("DateOfBirth") %>'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                ControlToValidate="TextBoxDOB" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            EMail:
            <asp:TextBox ID="TextBoxEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                ControlToValidate="TextBoxEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:LinkButton ID="LinkButton3" CommandName="Update" Text="Update" Width="100px"
                runat="server" />
            <asp:LinkButton ID="LinkButton4" CommandName="Cancel" Text="Cancel" Width="100px"
                runat="server" CausesValidation="False" />
        </EditItemTemplate>
        <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
    <asp:DataList ID="DataListPharmacists" runat="server" BackColor="#CCCCCC" BorderColor="#999999"
        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" GridLines="Both"
        RepeatDirection="Horizontal" OnCancelCommand="DataListPharmacists_CancelCommand"
        OnEditCommand="DataListPharmacists_EditCommand" OnUpdateCommand="DataListPharmacists_UpdateCommand"
        Width="100%" ForeColor="Black">
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <HeaderTemplate>
            My Information
        </HeaderTemplate>
        <ItemStyle BackColor="White" />
        <ItemTemplate>
            Pharmacist ID :
            <asp:Label ID="LabelID" runat="server" Text='<%# Bind("PharmacistID") %>'></asp:Label>
            <br />
            <br />
            First Name:
            <asp:Label ID="LabelFName" runat="server" Text='<%# Bind("FName") %>'></asp:Label>
            <br />
            <br />
            Last Name:
            <asp:Label ID="LabelLName" runat="server" Text='<%# Bind("LName") %>'></asp:Label>
            <br />
            <br />
            UserName:&nbsp;
            <asp:Label ID="LabelUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
            <br />
            <br />
            PassWord:
            <asp:Label ID="LabelPassWord" runat="server" Text='<%# Bind("PassWord") %>'></asp:Label>
            <br />
            <center>
                <asp:LinkButton ID="LinkButton1" CommandName="Edit" Text="Edit" Width="100px" runat="server" />
            </center>
        </ItemTemplate>
        <EditItemTemplate>
            &nbsp;<asp:Label ID="LabelPharmacistID" runat="server" 
                Text='<%# Bind("PharmacistID") %>'></asp:Label>
            <br />
            <br />
            First Name:
            <asp:TextBox ID="TextBoxFName" runat="server" Text='<%# Bind("FName") %>'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="TextBoxFName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            Last Name:
            <asp:TextBox ID="TextBoxLName" runat="server" Text='<%# Bind("LName") %>'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="TextBoxLName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            UserName:
            <asp:TextBox ID="TextBoxUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="TextBoxUserName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            PassWord:
            <asp:TextBox ID="TextBoxPassWord" runat="server" Text='<%# Bind("PassWord") %>'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                ControlToValidate="TextBoxPassWord" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:LinkButton ID="LinkButton3" CommandName="Update" Text="Update" Width="100px"
                runat="server" />
            <asp:LinkButton ID="LinkButton4" CommandName="Cancel" Text="Cancel" Width="100px"
                runat="server" CausesValidation="False" />
        </EditItemTemplate>
        <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
</asp:Content>
