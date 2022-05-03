<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EditPharmacy.aspx.cs" Inherits="EditPharmacy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <asp:Label ID="LabelMsg" runat="server"></asp:Label>
        <asp:GridView ID="GridViewPharmacy" runat="server" Style="margin-right: 0px" AutoGenerateColumns="False"
            ShowFooter="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
            BorderWidth="1px" CellPadding="4" OnRowCancelingEdit="GridViewPharmacy_RowCancelingEdit"
            OnRowDeleting="GridViewPharmacy_RowDeleting" OnRowEditing="GridViewPharmacy_RowEditing"
            OnRowUpdating="GridViewPharmacy_RowUpdating" 
            OnRowCommand="GridViewPharmacy_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="MedicineID" Visible="True" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <EditItemTemplate>
                        <asp:Label ID="LabelMedicineID" runat="server" Text='<%# Bind("MedicineID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelMedicineID" runat="server" Text='<%# Bind("MedicineID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Medicine" SortExpression="Medicine" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemTemplate>
                        <asp:Label ID="LabelMedicine" runat="server" Text='<%# Bind("Medicine") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxMedicine" runat="server" Text='<%# Bind("Medicine") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxNewMedicine" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Number" SortExpression="Number" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemTemplate>
                        <asp:Label ID="LabelNumber" runat="server" Text='<%# Bind("Number") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxNumber" runat="server" Text='<%# Bind("Number") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxNewNumber" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemTemplate>
                        <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxDescription" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxNewDescription" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" SortExpression="Price" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemTemplate>
                        <asp:Label ID="LabelPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxPrice" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxNewPrice" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Images" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="150px" 
                            ImageUrl='<%# Bind("ImageSource") %>' Width="150px" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:FileUpload ID="FileUpload2" runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonEdit" runat="server" CommandName="Edit" Text="Edit"> </asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButtonUpdate" runat="server" CommandName="Update" Text="Update"> </asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel" Text="Cancel"> </asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonDelete" runat="server" OnClientClick="return confirm('Are you sure?');"
                            CommandName="Delete"> Delete </asp:LinkButton>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="LinkButtonAdd" runat="server" CommandName="Insert" Text="Insert"> </asp:LinkButton>
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
