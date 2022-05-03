<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PVisit.aspx.cs" Inherits="PVisit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="LabelMessage" runat="server" ></asp:Label>
    <table width="80%">
        <tr>
            <td>
                <h3 style="width: 418px; height: 24px">
                    spceialization</h3>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListSpecialty" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSpecialty_SelectedIndexChanged">
                    <asp:ListItem>Select a Specialty</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 32px">
                <h3 style="width: 374px">
                    doctornames</h3>
            </td>
            <td style="height: 32px">
                <asp:DropDownList ID="DropDownListDoctors" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListDoctors_SelectedIndexChanged">
                    <asp:ListItem>Select a Doctor</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 132px" colspan="2">
                <center>
                    <h3>
                        Pick a Date<asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender"
                            Style="margin-top: 3px" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="#FFFFCC"
                            BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana"
                            Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                            <OtherMonthDayStyle ForeColor="#CC9966" />
                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                            <SelectorStyle BackColor="#FFCC66" />
                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                        </asp:Calendar>
                    </h3>
                </center>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 139px" align="center">
                <h3>
                    Pick an hour</h3>
                <asp:DropDownList ID="DropDownListTimes" runat="server" OnSelectedIndexChanged="DropDownListTimes_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;<asp:LinkButton ID="LinkButtonSet" runat="server" Font-Size="Large" OnClick="LinkButtonSet_Click"></asp:LinkButton>
                &nbsp;<br />
                &nbsp;<asp:Label ID="LabelSucces" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
