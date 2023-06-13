<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    <center>
    <h1>Login Page</h1>
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" Autocomplete="off" PlaceHolder="Username"></asp:TextBox>
            </td>
       
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Please enter your Username"  Font-Size="Small" ForeColor="Red" ControlToValidate ="txtUsername"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="10" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            
               <td>&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Please enter your Password"  Font-Size="Small" ForeColor="Red" ControlToValidate ="txtPassword"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblMessage" runat="server" Font-Size="Small" Text="Label" Visible="false" ></asp:Label>
            </td>
         
        </tr>
        <tr>
            
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click1" />
     
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Not Registered Yet?&nbsp&nbsp;<a href="#">Click Here</a> to Register</td>
        </tr>
    </table>
    </center>
    </form>
</body>
</html>
