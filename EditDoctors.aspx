<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EditDoctors.aspx.cs" Inherits="EditDoctors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center style="height: 305px; width: 1046px">
        <asp:Label ID="LabelMsg" runat="server"></asp:Label>
        <asp:GridView ID="GridViewDoctors" runat="server" Style="margin-right: 0px" AutoGenerateColumns="False"
            ShowFooter="True" BackColor="White" BorderColor="#3366CC" 
            BorderStyle="None" BorderWidth="1px"
            CellPadding="4" OnPageIndexChanging="GridViewDoctors_PageIndexChanging"
            OnRowCancelingEdit="GridViewDoctors_RowCancelingEdit" OnRowCommand="GridViewDoctors_RowCommand"
            OnRowDeleting="GridViewDoctors_RowDeleting" OnRowEditing="GridViewDoctors_RowEditing"
            OnRowUpdating="GridViewDoctors_RowUpdating" Width="2%" AllowPaging="True" 
            onselectedindexchanged="GridViewDoctors_SelectedIndexChanged" PageSize="5" 
            Height="236px">
            <Columns>
                <asp:TemplateField HeaderText="LicenseNumber" Visible="True" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxNewLicenseNumber" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="TextBoxNewLicenseNumber" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="*" 
                            MaximumValue="999999" MinimumValue="100000" 
                            ControlToValidate="TextBoxNewLicenseNumber"></asp:RangeValidator>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelLicenseNumber" runat="server" Text='<%# Bind("LicenseNumber") %>'>
                        </asp:Label>
                    </ItemTemplate>
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="TextBoxNewPassWord" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </FooterTemplate>
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="TextBoxNewFName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="TextBoxNewLName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Specialty" SortExpression="Specialty" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemTemplate>
                        <asp:Label ID="LabelSpecialty" runat="server" Text='<%# Bind("Specialty") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxSpecialty" runat="server" Text='<%# Bind("Specialty") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxNewSpecialty" runat="server">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="TextBoxNewSpecialty" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Is Manger?" SortExpression="IsManger" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBoxIsManger" runat="server" Enabled="false" Checked='<%# Bind("IsManger") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBoxEditIsManger" runat="server" Checked='<%# Bind("IsManger") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:CheckBox ID="CheckBoxNewIsManger" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonEdit" runat="server" CommandName="Edit" 
                            Text="Edit" CausesValidation="False"></asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButtonUpdate" runat="server" CommandName="Update" 
                            Text="Update" CausesValidation="False"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel" 
                            Text="Cancel" CausesValidation="False"></asp:LinkButton>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="FileUpload1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
    </center>
</asp:Content>
