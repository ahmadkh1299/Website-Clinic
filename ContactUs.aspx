
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" style="background-color: #C0C0C0">
        <tr>
            <td colspan="2" align="center">
                <asp:Image ID="Image5" runat="server" Height="154px" 
                    ImageUrl="~/Images/contact-us-1769323__340.png" Width="793px" />
                <br />
                <asp:Label ID="LabelMsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Image ID="Image2" runat="server" Height="100px" ImageUrl="~/Images/Phone.png"
                                Width="100px" />
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Font-Size="Larger" Text="04-6746228"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image3" runat="server" Height="100px" ImageUrl="~/Images/Email.png"
                                Width="100px" />
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Font-Size="Larger" Text="A.kh@Clinic.com"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image4" runat="server" Height="100px" ImageUrl="~/Images/Location.png"
                                Width="100px" />
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Font-Size="Larger" Text="Sakhnin, 805 (khalt Ballout)"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table width="100%">
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="Label3" runat="server" Font-Size="Larger" ForeColor="Black" Text="Or leave us your Message with your phone and we will call you"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="#EA2BA0" Text="Your Message"></asp:Label>
                            <br />
                            <asp:TextBox ID="TextBox1" runat="server" Height="112px" Width="248px" 
                                TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="Label2" runat="server" Font-Size="Larger" ForeColor="#E7249A" Text="Phone Number"></asp:Label>
                        </td>
                        <td align="center">
                            &nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>050</asp:ListItem>
                                <asp:ListItem>052</asp:ListItem>
                                <asp:ListItem>053</asp:ListItem>
                                <asp:ListItem>054</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="TextBox2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                ControlToValidate="TextBox2" ErrorMessage="*" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="Button1" runat="server" BackColor="#CC6699" Font-Bold="True" Font-Size="Larger"
                                ForeColor="#EB289E" Height="38px" Text="Send" Width="116px" 
                                onclick="Button1_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
