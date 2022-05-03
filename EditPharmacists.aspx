<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EditPharmacists.aspx.cs" Inherits="EditPharmacists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:Label ID="LabelMsg" runat="server"></asp:Label>
    <asp:GridView ID="GridViewPharmacists" runat="server" Style="margin-right: 0px" AutoGenerateColumns="False"
        ShowFooter="True" BackColor="White" BorderColor="White" 
        BorderStyle="Ridge" BorderWidth="2px"
        CellPadding="3" CellSpacing="1" GridLines="None" OnPageIndexChanging="GridViewPharmacists_PageIndexChanging"
        OnRowCancelingEdit="GridViewPharmacists_RowCancelingEdit"
        OnRowDeleting="GridViewPharmacists_RowDeleting" OnRowEditing="GridViewPharmacists_RowEditing"
        OnRowUpdating="GridViewPharmacists_RowUpdating" Width="100%" AllowPaging="True"
        PageSize="5" Height="208px" onrowcommand="GridViewPharmacists_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="PharmacistID" Visible="True" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <EditItemTemplate>
                    <asp:Label ID="LabelPharmacistID" runat="server" 
                        Text='<%# Bind("PharmacistID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelPharmacistID" runat="server" Text='<%# Bind("PharmacistID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FName" SortExpression="FName" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:Label ID="LabelFName" runat="server" Text='<%# Bind("FName") %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxFName" runat="server" Text='<%# Bind("FName") %>'>
                    </asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxNewFName" runat="server">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxNewFName"
                        ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="LName" SortExpression="LName" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:Label ID="LabelLName" runat="server" Text='<%# Bind("LName") %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxLName" runat="server" Text='<%# Bind("LName") %>'>
                    </asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxNewLName" runat="server">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxNewLName"
                        ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="UserName" SortExpression="UserName" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:Label ID="LabelUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxNewUserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxNewUserName"
                        ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Password" SortExpression="Password" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:Label ID="LabelPassWord" runat="server" Text='<%# Bind("Password") %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxPassWord" runat="server" Text='<%# Bind("Password") %>'>
                    </asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxNewPassWord" runat="server">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxNewPassWord"
                        ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonEdit" runat="server" CommandName="Edit" Text="Edit"
                        CausesValidation="False"></asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButtonUpdate" runat="server" CommandName="Update" Text="Update"
                        CausesValidation="False"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel" Text="Cancel"
                        CausesValidation="False"></asp:LinkButton>
                </EditItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonDelete" runat="server" OnClientClick="return confirm('Are you sure?');"
                        CommandName="Delete" CausesValidation="False">
                Delete
                    </asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="LinkButtonAdd" runat="server" CommandName="Insert" Text="Insert">
                    </asp:LinkButton>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        <PagerSettings Mode="NextPreviousFirstLast" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#594B9C" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#33276A" />
    </asp:GridView>
</asp:Content>
