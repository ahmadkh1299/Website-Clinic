<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DAllVisits.aspx.cs" Inherits="DAllVisits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="LabelMessage" runat="server"></asp:Label>
    <br />
    <center>
        <asp:Label ID="Label2" runat="server" Text="All your visits" ForeColor="#CC6600"
            Font-Size="Larger"></asp:Label>
    </center>
    <asp:GridView ID="GridViewVisits" runat="server" 
    AutoGenerateColumns="False" BackColor="#DEBA84"
        BorderColor="#DEBA84" BorderStyle="Solid" BorderWidth="1px" 
    CellPadding="3" CellSpacing="2" Width="100%" 
        onrowdeleting="GridViewVisits_RowDeleting">
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
            <asp:TemplateField HeaderText="Patient Name" Visible="True" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
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
            <asp:TemplateField HeaderText="Patient ID Number" SortExpression="PatientID" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:Label ID="LabelPatientID" runat="server" Text='<%# Bind("PatientID") %>'></asp:Label>
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
    </asp:Content>

