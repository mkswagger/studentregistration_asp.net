<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="studentdetails.aspx.cs" Inherits="WebApplication2.WebForm3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <br />
        <h1>Student Details</h1>
        <br />
        <asp:Panel ID="pnlAdd" runat="server">
            <table class="registration-form">
                <tr>
                    <td>
                        Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Autocomplete="off" Placeholder="Name"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtName" FilterType="LowercaseLetters" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Please enter your name" Font-Size="Small" ForeColor="Red" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <!-- Rest of the form controls and validators -->
                <tr>
                    <td>
                        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlShow" runat="server">
            <asp:GridView ID="gvStudentDetails" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="DOB" HeaderText="DOB" />
                    <asp:BoundField DataField="Course" HeaderText="Course" />
                    <asp:BoundField DataField="Image" HeaderText="Image" />
                    <asp:BoundField DataField="Password" HeaderText="Password" />
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F77"/>
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
        </asp:Panel>

        <br />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </center>

    <script type="text/javascript">
        function showMessage(message) {
            alert(message);
        }
    </script>
</asp:Content>

