<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PAllVisits.aspx.cs" Inherits="PAllVisits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="LabelMessage" runat="server"></asp:Label>
    <br />
    <center>
        <asp:Label ID="Label2" runat="server" Text="All your visits" ForeColor="#CC6600"
            Font-Size="Larger"></asp:Label>
    </center>
    <asp:GridView ID="GridViewVisits" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
        BorderColor="#DEBA84" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CellSpacing="2"
        OnRowDeleting="GridViewVisits_RowDeleting" Width="100%">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
        <Columns>
            <asp:TemplateField HeaderText="DoctorName" Visible="True" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <HeaderTemplate>
                    Doctor Name
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text="DR."></asp:Label>
                    <asp:Label ID="LabelFName" runat="server" Text='<%# Bind("FName") %>'></asp:Label>
                    &nbsp;<asp:Label ID="LabelLName" runat="server" Text='<%# Bind("LName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date Of Visit" SortExpression="Date of Visit" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:Label ID="LabelVisitDate" runat="server" Text='<%# FormateDate(Eval("VisitDate")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Time" SortExpression="Time" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:Label ID="LabelTime" runat="server" Text='<%# Bind("Time") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Specialty" SortExpression="Specialty" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:Label ID="LabelSpecialty" runat="server" Text='<%# Bind("Specialty") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonDelete" runat="server" OnClientClick="return confirm('Are you sure?');"
                        CommandName="Delete">
                Delete
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <center>
        <asp:Button ID="Button1" runat="server" BackColor="#FFCC66" ForeColor="#FF3300" 
            Text="Add a new Visit" onclick="Button1_Click" /></center>
</asp:Content>
