<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Patients.aspx.cs" Inherits="Patients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="LabelMsg" runat="server"></asp:Label>
    <asp:DataList ID="DataListPatients" runat="server" BackColor="White" BorderColor="#CCCCCC"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Both"
        RepeatColumns="4" Width="100%" OnCancelCommand="DataListPatients_CancelCommand"
        OnDeleteCommand="DataListPatients_DeleteCommand" OnEditCommand="DataListPatients_EditCommand"
        OnUpdateCommand="DataListPatients_UpdateCommand" Height="541px" Style="margin-bottom: 0px"
        OnItemCommand="DataListPatients_ItemCommand" RepeatDirection="Horizontal" 
        onselectedindexchanged="DataListPatients_SelectedIndexChanged">
        <HeaderTemplate>
            <asp:Label ID="LabelPatients" runat="server" Text="Patients" />
            &nbsp;&nbsp;
            <asp:Button ID="ButtonFName" runat="server" CommandArgument="FName" CommandName="Sort"
                Text="Sort By Fname" Width="150px" />
            <asp:Button ID="ButtonLName" runat="server" CommandArgument="LName" CommandName="Sort"
                Text="Sort By Lname" Width="150px" />
            <asp:CheckBox ID="ChBOrder" runat="server" AutoPostBack="True" EnableViewState="True"
                Text="ASC" />
            <br />
            Search ID number:
            <asp:TextBox ID="TextBoxSearch" runat="server"></asp:TextBox>
            &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" 
                ControlToValidate="TextBoxSearch" ErrorMessage="*" ForeColor="Red" 
                MaximumValue="999999999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="TextBoxSearch" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Button ID="ButtonSearch" runat="server" CommandArgument="Search" CommandName="Search"
                Text="Search" />
        </HeaderTemplate>
        <ItemTemplate>
            <center>
                <asp:Label ID="Label1" runat="server" Text="PatientID: "></asp:Label>
                <asp:Label ID="LabelPatientID" runat="server" Text='<%# Bind("PatientID") %>'></asp:Label>
            </center>
            <br />
            <br />
            <center>
                <asp:Label ID="Label2" runat="server" Text="FName: "></asp:Label>
                <asp:Label ID="LabelFName" runat="server" Text='<%# Bind("FName") %>'></asp:Label>
            </center>
            <br />
            <br />
            <center>
                <asp:Label ID="Label3" runat="server" Text="LName: "></asp:Label>
                <asp:Label ID="LabelLName" runat="server" Text='<%# Bind("LName") %>'></asp:Label>
            </center>
            <br />
            <center>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" Text="Edit" Width="100px" />
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" OnClientClick="return confirm('Are You Sure?');"
                    Text="Delete" Width="100px" />
            </center>
        </ItemTemplate>
        <EditItemTemplate>
            Patient ID Number:&nbsp;
            <asp:Label ID="LabelPatientID" runat="server" Text='<%# Bind("PatientID") %>'></asp:Label>
            <br />
            FName:&nbsp;
            <asp:TextBox ID="TextboxFName" Text='<%# DataBinder.Eval(Container.DataItem, "FName")%>'
                runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFName" runat="server" ErrorMessage="**"
                ControlToValidate="TextboxFName" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            LName:&nbsp;
            <asp:TextBox ID="TextboxLName" Text='<%# DataBinder.Eval(Container.DataItem, "LName")%>'
                runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLName" runat="server" ErrorMessage="**"
                ControlToValidate="TextboxLName" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            PassWord:&nbsp;
            <asp:TextBox ID="TextboxPassWord" Text='<%# DataBinder.Eval(Container.DataItem, "PassWord")%>'
                runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPW" runat="server" ErrorMessage="**"
                ControlToValidate="TextboxPassWord" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            Email:&nbsp;
            <asp:TextBox ID="TextboxEmail" Text='<%# DataBinder.Eval(Container.DataItem, "Email")%>'
                runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="**"
                ControlToValidate="TextboxEmail" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            Date Of Birth:&nbsp;
            <asp:TextBox ID="TextboxDOB" Text='<%# DataBinder.Eval(Container.DataItem, "DateOfBirth")%>'
                runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDOB" runat="server" ErrorMessage="**"
                ControlToValidate="TextboxDOB" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:LinkButton ID="LinkButton3" CommandName="Update" Text="Update" Width="100px"
                runat="server" />
            <asp:LinkButton ID="LinkButton4" CommandName="Cancel" Text="Cancel" Width="100px"
                runat="server" CausesValidation="False" /><br />
        </EditItemTemplate>
        <FooterTemplate>
            <table>
                <tr>
                    <td colspan="2" style="font-weight: bold">
                        Insert a new Patient
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Patient ID number
                    </td>
                    <td>
                        <asp:TextBox ID="TextboxPatientID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        FName
                    </td>
                    <td>
                        <asp:TextBox ID="TextboxNewFName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        LName
                    </td>
                    <td>
                        <asp:TextBox ID="TextboxNewLName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Password
                    </td>
                    <td>
                        <asp:TextBox ID="TextboxNewPassword" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Date Of Birth
                    </td>
                    <td>
                        <asp:TextBox ID="TextboxNewDOB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Email
                    </td>
                    <td>
                        <asp:TextBox ID="TextboxNewEmail" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="LinkButton3" CommandName="Insert" Text="Insert" Width="100px"
                            runat="server" />
                    </td>
                </tr>
            </table>
        </FooterTemplate>
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <ItemStyle ForeColor="#000066" />
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
</asp:Content>
